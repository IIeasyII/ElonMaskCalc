using EM.Calc.DB;
using EM.Calc.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EM.Calc.Web.Controllers
{
    public class ResultOperationController : Controller
    {
        string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Fraps\ELMA\git\ElonMaskCalc\EM.Calc.ConsoleApp\EM.Calc.Web\App_Data\ElonMusk.mdf;Integrated Security = True";

        UserRepository UserRepository;

        public ResultOperationController()
        {
            UserRepository = new UserRepository(connectionString);
        }

        public ActionResult Index()
        {
            var model = new GetAllModel()
            {
                All = UserRepository.GetAll()
            };
            return View(model);
        }
    }
}