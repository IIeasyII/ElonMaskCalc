using EM.Calc.DB;
using EM.Calc.Web.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EM.Calc.Web.Controllers
{
    public class HomeController : Controller
    {
        string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Fraps\ELMA\git\ElonMaskCalc\EM.Calc.ConsoleApp\EM.Calc.Web\App_Data\ElonMusk.mdf;Integrated Security = True";

        UserRepository UserRepository;

        public HomeController()
        {
            UserRepository = new UserRepository(connectionString);
        }

        public ActionResult Index()
        {
            ViewBag.Results = UserRepository.Load(3);

            UserRepository.GetAll();

            //UserRepository.Update(new User() { Id = 5, Login = "sdfdsfsdf"});

            return View();
        }
    }
}