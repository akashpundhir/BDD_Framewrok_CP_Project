using HtmlAgilityPack;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmailWrapper
{
    public class MessageWrapper
    {
        private string gmailServer = "imap.gmail.com";
        private string gmailLogin = "dcpcoloplast@gmail.com";
        private string gmailPassword = "lchicoIReBoK";
        private int gmailPort = 993;
        private bool gmailSsl = true;

        public string GetB2CEmails(string Email, string subject)
        {
            var mailRepository = new MailRepository(gmailServer, gmailPort, gmailSsl, gmailLogin, gmailPassword);
            string mailList = mailRepository.GetB2CEmails(Email, subject).Result;

            return mailList;
        }

        public string GetCareConnectEmails(string Email, string subject)
        {
            var mailRepository = new MailRepository(gmailServer, gmailPort, gmailSsl, gmailLogin, gmailPassword);
            string mailList = mailRepository.GetCareConnectEmails(Email, subject).Result;

            return mailList;
        }



        public void DeleteMails(string email)
        {
            var mailRepository = new MailRepository(gmailServer, gmailPort, gmailSsl, gmailLogin, gmailPassword);
            mailRepository.DeleteEmails(email);
        }
        public void DeleteMailsBySubject(string subject)
        {
            var mailRepository = new MailRepository(gmailServer, gmailPort, gmailSsl, gmailLogin, gmailPassword);
            mailRepository.DeleteEmailsBySubject(subject);
        }

        public string GetDocuSignLinkFromEmail(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var nodes = htmlDoc.DocumentNode.SelectNodes("//a[contains(@href,'docusign.net/Signing')]").FirstOrDefault();

            return nodes.Attributes["href"].Value;
        }
    }
}
