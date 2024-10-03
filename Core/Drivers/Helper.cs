using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using OpenQA.Selenium;

namespace Core.Drivers
{
    public class Helper
    {
        internal const int DEFAULT_TEST_TIMEOUT = 900000;
        public const int PAGE_LOAD_TIMEOUT = 120;
        public const int IMPLICIT_WAIT_TIMEOUT = 120;
        private static readonly CultureInfo provider = CultureInfo.InvariantCulture;
        public const int DEFAULT_WAIT = 120;
        public const int DEFAULT_WAIT_30 = 30;

        public static string MultisiteEmail = "";
        public static string HCPEmail = "";
        public static string ndis = "";

        public enum BrowserTypes
        {
            Firefox,
            InternetExplorer,
            Chrome,
            Safari,
            Edge
        }

        /// <summary>
        /// Removing extra whitespaces from string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string NormalizeWhiteSpace(string input)
        {
            int len = input.Length,
                index = 0,
                i = 0;
            var src = input.ToCharArray();
            bool skip = false;
            char ch;
            for (; i < len; i++)
            {
                ch = src[i];
                switch (ch)
                {
                    case '\u0020':
                    case '\u00A0':
                    case '\u1680':
                    case '\u2000':
                    case '\u2001':
                    case '\u2002':
                    case '\u2003':
                    case '\u2004':
                    case '\u2005':
                    case '\u2006':
                    case '\u2007':
                    case '\u2008':
                    case '\u2009':
                    case '\u200A':
                    case '\u202F':
                    case '\u205F':
                    case '\u3000':
                    case '\u2028':
                    case '\u2029':
                    case '\u0009':
                    case '\u000A':
                    case '\u000B':
                    case '\u000C':
                    case '\u000D':
                    case '\u0085':
                        if (skip) continue;
                        src[index++] = ch;
                        skip = true;
                        continue;
                    default:
                        skip = false;
                        src[index++] = ch;
                        continue;
                }
            }

            return new string(src, 0, index);
        }

        public static string GetBrowserName()
        {
            var caps = Driver.GetBrowserCapabilities();

            return caps.GetCapability("browserName").ToString();
        }

        public static DirectoryInfo TryGetSolutionDirectoryInfo(string currentPath = null)
        {
            var directory = new DirectoryInfo(
                currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            return directory;
        }

        public static string GetPhoneNumberFromGeneratedEmail(string email)
        {
            int pFrom = email.IndexOf("+") + "+".Length;
            int pTo = email.LastIndexOf("@");

            var ticks = email.Substring(pFrom, pTo - pFrom);

            return "412" + ticks.Substring(ticks.Length - 12, 6);
        }

        public static void ScrollDown()
        {
            ((IJavaScriptExecutor)Driver.Browser).ExecuteScript("window.scrollBy(0,document.body.scrollHeight)", "");

            System.Threading.Thread.Sleep(1000);
        }

        public static void SaveScreenshotOnAzureShare(string name)
        {
            string connectionString =
                "DefaultEndpointsProtocol=https;AccountName=muldvwest;AccountKey=0oc1reSrwUj0SI41oej6Qaocf3J+LlBebRz25hWHaP71vQa8LR4sfDmLeHkhoDBdcVdGU2YuGWshP79aZJw3hQ==;EndpointSuffix=core.windows.net";

            string shareName = "multisitescreenshots";

            ShareClient shareClient = new ShareClient(connectionString, shareName);

            ShareDirectoryClient directoryClient = shareClient.GetRootDirectoryClient();

            ShareFileClient fileClient = directoryClient.GetFileClient(name);

            FileStream filestream = File.OpenRead(name);

            var openWriteOptions = new ShareFileOpenWriteOptions() { MaxSize = filestream.Length };

            using (var fs = fileClient.OpenWrite(true, 0, openWriteOptions))
            {
                filestream.CopyTo(fs);
            }

            filestream.Close();
        }

        public static string GetProjectName()
        {
            string startupPath = Environment.CurrentDirectory;

            var folders = startupPath.Split('\\').ToList();
            var position = folders.IndexOf("bin");

            return folders[position - 1];
        }

        public static void DeleteOldFiles()
        {
            try
            {
                string connectionString =
                    "DefaultEndpointsProtocol=https;AccountName=muldvwest;AccountKey=0oc1reSrwUj0SI41oej6Qaocf3J+LlBebRz25hWHaP71vQa8LR4sfDmLeHkhoDBdcVdGU2YuGWshP79aZJw3hQ==;EndpointSuffix=core.windows.net";

                string shareName = "multisitescreenshots";

                ShareClient shareClient = new ShareClient(connectionString, shareName);

                foreach (var x in shareClient.GetRootDirectoryClient().GetFilesAndDirectories())
                {
                    try
                    {
                        ShareDirectoryClient directoryClient = shareClient.GetRootDirectoryClient();

                        ShareFileClient fileClient = directoryClient.GetFileClient(x.Name);

                        ShareFileProperties fileProp = fileClient.GetProperties().Value;

                        if (fileProp.LastModified < DateTime.UtcNow.AddDays(-7))
                        {
                            try
                            {
                                fileClient.Delete();
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }
    }
}
