using System;
using System.Net;
using System.Web;
using System.Text.RegularExpressions;
using SpeechNet.Controllers;
using Microsoft.Extensions.Logging;
using System.IO;

namespace SpeechNet.Services
{
    public class PageCreatorService
    {
        public static string HTMLgenerator(string CodeHTML)
        {
            string args = "def";

            FileStream htmlStream = new FileStream(args, FileMode.Create, FileAccess.ReadWrite);

            return CodeHTML;
        }
        public static string AddPage(string txtHTML)
        {
            string page = HTMLgenerator(txtHTML);

            return "Add page";
        }

        public static string DelPage(string namePage)
        {
            return "Del page";
        }
    }
}