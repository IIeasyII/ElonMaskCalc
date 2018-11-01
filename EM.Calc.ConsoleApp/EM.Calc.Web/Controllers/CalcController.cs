using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EM.Calc.Web.Controllers
{
    public class CalcController : Controller
    {
        public ActionResult Calc(string oper, double[] values)
        {
            Core.Calc calc = new Core.Calc();

            var result = calc.Execute(oper, values);

            ViewBag.Result = result;

            return View();
        }
    }
}