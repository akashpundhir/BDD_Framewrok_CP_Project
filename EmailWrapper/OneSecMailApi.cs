using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace EmailWrapper
{
    public class OneSecMailBaseResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("from")]
        public string From { get; set; }
        [JsonPropertyName("subject")]
        public string Subject { get; set; }
        [JsonPropertyName("date")]
        public string Date { get; set; }

    }

    public class Attachment
    {
        [JsonPropertyName("filename")]
        public string Filename { get; set; }
        [JsonPropertyName("contentType")]
        public string ContentType { get; set; }
        [JsonPropertyName("size")]
        public int Size { get; set; }
    }

    public class OneSecMailResponse : OneSecMailBaseResponse
    {
        [JsonPropertyName("attachments")]
        public List<Attachment> Attachments { get; set; }
        [JsonPropertyName("body")]
        public string Body { get; set; }
        [JsonPropertyName("textBody")]
        public string TextBody { get; set; }
        [JsonPropertyName("htmlBody")]
        public string HtmlBody { get; set; }
    }


    public class OnesecmailApi
    {
        private HttpClient _httpClient;
        private const string BaseUrl = "https://www.1secmail.com/api/v1";

        public OnesecmailApi()
        {
             _httpClient = new() { BaseAddress = new Uri(BaseUrl) };
        }

        public async Task<string> GetRandomEmail(int nrOfEmails = 1)
        {
            string action = "/?action=genRandomMailbox&count="+ nrOfEmails;
            var request = await _httpClient.GetAsync(_httpClient.BaseAddress + action);
            var stringContent = await request.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<List<string>>(stringContent);

            return response.FirstOrDefault();
        }

        public async Task<OneSecMailBaseResponse> GetLatestMail(string email)
        {
            MailAddress mailAddress = new(email);
            string action = "/?action=getMessages&login=" + mailAddress.User + "&domain=" + mailAddress.Host;
            var request = await _httpClient.GetAsync(_httpClient.BaseAddress + action);
            var stringContent = await request.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<List<OneSecMailBaseResponse>>(stringContent);

            return response.FirstOrDefault();
        }

        public async Task<OneSecMailResponse> GetEmailContent(string email, int id)
        {
            MailAddress mailAddress = new(email);
            string action = "/?action=readMessage&login=" + mailAddress.User + "&domain=" + mailAddress.Host + "&id=" + id;
            var request = await _httpClient.GetAsync(_httpClient.BaseAddress + action);
            var stringContent = await request.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<OneSecMailResponse>(stringContent);

            return response;
        }

        public static string GetCodeFromEmail(string htmlBody)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlBody);

            //HtmlNode span;

            //span = htmlDoc.DocumentNode.Descendants("span").
            //    Where(x => x.Attributes["id"].Value.Contains("UserVerificationEmailBodySentence2")).FirstOrDefault();

            var code = Regex.Matches(htmlBody, @"\d{6}").FirstOrDefault().Value;

            return code;
        }

    }
}
