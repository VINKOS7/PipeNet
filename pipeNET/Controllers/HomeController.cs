using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeechNet.ViewModels;
using System.Diagnostics;
using SpeechNet.Services;
using System.Data;
using System.Web;
using SpeechNet.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.ServiceProcess;

namespace SpeechNet.Controllers
{
    public class HomeController : Controller
    {
        IWebHostEnvironment _appEnvironment;
        ApplicationContext _context;

        private readonly ILogger<HomeController> _logger;
       
        public HomeController(ILogger<HomeController> logger, ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View("Index");
        }
        [AllowAnonymous]
        public IActionResult About()
        {

            return View("About");
        }
        [AllowAnonymous]
        public IActionResult CalcTypeWord()
        {
            return View("CalcTypeWord");
        }

        [Authorize]
        public IActionResult PersonalArea()
        {
            return View("PersonalArea");
        }
        [Authorize]
        public IActionResult CalcQuantityTrumpet()
        {
            return View("CalcQuantityTrumpet");
        }

        [Authorize]
        public IActionResult PageCreator()
        {
            return View("PageCreator");
        }

        [AllowAnonymous]
        public IActionResult CalcTypeText()
        {
            return View("CalcTypeText");
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View("Privacy");
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public string InsidewordTYPE(string word = null)
        {
            if (String.IsNullOrEmpty(word))
            {
                return "ошибка";
            }
            else
            {
                string res = TypeWordService.TypeWord(word, 11);

                return res;
            }
        }

        [Authorize]
        [HttpPost]
        [Route("DelUserRole")]
        public IActionResult DelUserRole(string name = null, string admin = "adminGLOBAL")
        {

            if (String.IsNullOrEmpty(name))
                return StatusCode(1);
            else
            {
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=usersstoredb;Integrated Security=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string queryString = string.Format("DELETE FROM AspNetRoles WHERE Name = '{0}'", name);
                    SqlCommand command = new SqlCommand(queryString, connection);

                    command.ExecuteScalar();
                }
            }
            return new JsonResult("успешно");
        }

        [Authorize]
        [HttpPost]
        [Route("AddUserRole")]
        public IActionResult AddUserRole(string name = null, string role = null)
        {
            string id = null, NormalizedName = null, ConcurrencyStamp = role;

            if (String.IsNullOrEmpty(name))
                return StatusCode(1);
            else
            {
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=usersstoredb;Integrated Security=True;";          

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string getStringCheck = string.Format(@"IF EXISTS (SELECT 1 Name FROM AspNetRoles WHERE Name='{0}') SELECT 1 ELSE SELECT 0", name);
                    SqlCommand command_check = new SqlCommand(getStringCheck, connection);

                    if (Convert.ToInt32(command_check.ExecuteScalar()) > 0) DelUserRole(name);

                    string getString = string.Format("SELECT Id FROM AspNetUsers WHERE UserName='{0}'", name);
                    SqlCommand command_get = new SqlCommand(getString, connection);
                    id = command_get.ExecuteScalar().ToString();

                    getString = string.Format("SELECT UserName FROM AspNetUsers WHERE UserName='{0}'", name.ToUpper());
                    command_get = new SqlCommand(getString, connection);
                    NormalizedName = command_get.ExecuteScalar().ToString();

                    string queryString = string.Format("INSERT INTO AspNetRoles VALUES ('{0}', '{1}', '{2}', '{3}')", id, name, NormalizedName, ConcurrencyStamp);
                    SqlCommand command = new SqlCommand(queryString, connection);

                    command.ExecuteScalar();
                }
            }
            return new JsonResult("успешно");
        }

        [Authorize]
        [HttpPost]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(string username = null)
        {
            DataSet ds = new DataSet();

            if (String.IsNullOrEmpty(username))
                return StatusCode(1);
            else 
            {             
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=usersstoredb;Integrated Security=True;";
                string queryString = string.Format("DELETE FROM AspNetUsers WHERE UserName='{0}'", username);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(queryString, connection);

                    command.ExecuteScalar();
                }
            }
            return new JsonResult("успешно");
        }

        [Authorize]
        static public string dbGET(string username, int index_cell = 3, string role = "def", int numS = 0, int numT = 0)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=usersstoredb;Integrated Security=True;";

            object res = "";
            if (String.IsNullOrEmpty(username))
                return "lol";
            else
            {
                string queryString = "SELECT * FROM AspNetUsers";

                if (role == "check") queryString = "SELECT * FROM AspNetRoles";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(queryString, connection);

                    SqlDataReader reader = command.ExecuteReader();
;
                    if (username != "admin")
                    {
                        while (reader.Read())
                        {
                            if (reader.GetValue(1).ToString() != username) continue;
                            else
                            {
                                res = reader.GetValue(index_cell);

                                break;
                            }
                        }
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            if (numS != numT)
                            {
                                numS++;
                                continue;
                            }
                            else
                            {
                                res = reader.GetValue(index_cell);

                                break;
                            }
                        }

                    }

                    if (res.ToString() == "") return "def";
                    
                }
                return res.ToString();
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("wordTYPE")]
        public IActionResult wordTYPE(string word = null)
        {
            if (String.IsNullOrEmpty(word))
                return StatusCode(1);
            else
            {
                string res = TypeWordService.TypeWord(word, 11);
                return new JsonResult(res);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("translate")]
        public IActionResult translate(string translateTXT = null)
        {
            if (String.IsNullOrEmpty(translateTXT))
                return StatusCode(400);
            else
            {
                string res = TranslateService.Translate(translateTXT);

                return new JsonResult(res);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("PageCreatorSer")]
        public IActionResult PageCreatorSer(string command = null)
        {
            if (String.IsNullOrEmpty(command))
                return StatusCode(400);
            else if (command == "add")
                return new JsonResult(PageCreatorService.AddPage(command));
            else if (command == "del")
                return new JsonResult(PageCreatorService.DelPage(command));
            else
                return new JsonResult("err");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Text")]
        public IActionResult Text(string text = null)
        {
            if (String.IsNullOrEmpty(text))
                return StatusCode(400);
            else
            {
                string res = TypeTextService.TypeText(text);

                return new JsonResult(res);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("AddFile")]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            string userFile = User.Identity.Name;

            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/Files/" + userFile + ".bmp"; //uploadedFile.FileName
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
                _context.Files.Add(file);
                //_context.SaveChanges();
            }

            return View("CalcQuantityTrumpet");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("CalcTump")]
        public IActionResult CalcTump(string file = null)
        {
            if (String.IsNullOrEmpty(file))
            {
                file = "def";

                int res = QuantityTrumpetService.CalcTrump(file);

                return new JsonResult("труб " + res);
            }
            else
            {
                int res = QuantityTrumpetService.CalcTrump(file);

                return new JsonResult("труб " + res);
            }
        }
    }
}