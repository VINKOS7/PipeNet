using System;
using System.Net;
using System.Web;

namespace SpeechNet.Services
{
    public class TranslateService
    {
        public static string Translate(string txt)
        {
            var toLanguage = "ja";//Японский
            var fromLanguage = "ru";//Русский
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(txt)}";
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webClient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
            }
            catch
            {
                return "Error";
            }
        }
    }
}