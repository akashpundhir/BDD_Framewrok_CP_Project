using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Util;
using Google.Apis.Util.Store;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmailWrapper
{
    public class MailRepository
    {
        private readonly string mailServer, login, password;
        private readonly int port;
        private readonly bool ssl;

        public MailRepository(string mailServer, int port, bool ssl, string login, string password)
        {
            this.mailServer = mailServer;
            this.port = port;
            this.ssl = ssl;
            this.login = login;
            this.password = password;
        }

        public async Task<SaslMechanismOAuth2> GetOAuthToken()
        {
            var clientSecrets = new ClientSecrets
            {
                ClientId = "604760100424-svidq6pcvts9qoamuevrvje5lt45sl08.apps.googleusercontent.com",
                ClientSecret = "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"
            };

            var codeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                DataStore = new FileDataStore("CredentialCacheFolder", false),
                Scopes = new[] { "https://mail.google.com/" },
                ClientSecrets = clientSecrets
            });

            var codeReceiver = new LocalServerCodeReceiver();
            var authCode = new AuthorizationCodeInstalledApp(codeFlow, codeReceiver);

            var credential = await authCode.AuthorizeAsync(mailServer, CancellationToken.None);

            if (credential.Token.IsExpired(SystemClock.Default))
                await credential.RefreshTokenAsync(CancellationToken.None);

            var oauth2 = new SaslMechanismOAuth2(credential.UserId, credential.Token.AccessToken);

            return oauth2;
        }

        public async Task<IEnumerable<MimeMessage>> GetEmailsAsync(string email, string subject)
        {            
            var messages = new List<MimeMessage>();

            using (var client = new ImapClient())
            {
                var oauth2 = GetOAuthToken();
                await client.ConnectAsync(mailServer, port, SecureSocketOptions.SslOnConnect);
                client.AuthenticationMechanisms.Add("XOAUTH2");
                await client.AuthenticateAsync(oauth2.Result);

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadWrite);
                //var results = inbox.Fetch(0, -1, MessageSummaryItems.UniqueId | MessageSummaryItems.BodyStructure | MessageSummaryItems.Envelope);
                for (int i = 0; i < inbox.Count; i++)
                {
                    try
                    {
                        var message = inbox.GetMessage(i);
                        if (message.Subject.Contains(subject) && message.To.ToString() == email)
                            messages.Add(message);
                    }
                    catch
                    {
                    }
                }

                await client.DisconnectAsync(true);
            }

            return messages;
        }
        
        public async Task<IEnumerable<MimeMessage>> GetEmailsEqualSubjectAsync(string email, string subject)
        {
            var messages = new List<MimeMessage>();

            using (var client = new ImapClient())
            {
                var oauth2 = GetOAuthToken();
                await client.ConnectAsync("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(oauth2.Result);

                // The Inbox folder is always available on all IMAP servers...
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadWrite);
                //var results = inbox.Fetch(0, -1, MessageSummaryItems.UniqueId | MessageSummaryItems.BodyStructure | MessageSummaryItems.Envelope);
                for (int i = 0; i < inbox.Count; i++)
                {
                    try
                    {
                        var message = inbox.GetMessage(i);
                        if (message.Subject.Equals(subject) && message.To.ToString().Contains(email))
                            messages.Add(message);
                    }
                    catch
                    {
                    }
                }

                await client.DisconnectAsync(true);
            }

            return messages;
        }

        public async Task<string> GetB2CEmails(string email, string subject)
        {
            IEnumerable<MimeMessage> messages = new List<MimeMessage>();
            int count = 0;

            while (messages.Count() == 0)
            {
                messages = await GetEmailsAsync(email, subject);

                count++;
                if (count == 30)
                {
                    throw new Exception($"Mail wasn't sent in 5 minutes, Expected notification: {subject}");
                }

                if (messages.Count() == 0)
                    Thread.Sleep(5000);
            }

            return messages.LastOrDefault().HtmlBody;
        }

        public async Task<string> GetCareConnectEmails(string email, string subject)
        {
            IEnumerable<MimeMessage> messages = new List<MimeMessage>();
            int count = 0;

            while (messages.Count() == 0)
            {
                messages = await GetEmailsEqualSubjectAsync(email, subject);

                count++;
                if (count == 30)
                {
                    throw new Exception($"Mail wasn't sent in 5 minutes, Expected notification: {subject}");
                }

                if (messages.Count() == 0)
                    Thread.Sleep(10000);
            }

            return messages.LastOrDefault().HtmlBody;
        }

        public async void DeleteEmails(string email)
        {
            var messages = new List<MimeKit.MimeMessage>();

            using (var client = new ImapClient())
            {
                var oauth2 = GetOAuthToken();
                await client.ConnectAsync("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(oauth2.Result);

                // The Inbox folder is always available on all IMAP servers...
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadWrite);

                for(int i = 0; i < inbox.Count; i++)
                {
                    try
                    {
                        var message = inbox.GetMessage(i);
                        if (message.To.ToString() == email)
                            inbox.AddFlags(i, MessageFlags.Deleted, true);
                    }
                    catch
                    {
                    }
                }

                inbox.Expunge();

                await client.DisconnectAsync(true);
            }
        }

        public async void DeleteEmailsBySubject(string subject)
        {
            var messages = new List<MimeMessage>();

            using (var client = new ImapClient())
            {
                var oauth2 = GetOAuthToken();
                await client.ConnectAsync("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(oauth2.Result);

                // The Inbox folder is always available on all IMAP servers...
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadWrite);

                for (int i = 0; i < inbox.Count; i++)
                {
                    try
                    {
                        var message = inbox.GetMessage(i);
                        if (message.Subject.ToString() == subject)
                            inbox.AddFlags(i, MessageFlags.Deleted, true);
                    }
                    catch
                    {
                    }
                }

                inbox.Expunge();

                await client.DisconnectAsync(true);
            }
        }
    }
}
