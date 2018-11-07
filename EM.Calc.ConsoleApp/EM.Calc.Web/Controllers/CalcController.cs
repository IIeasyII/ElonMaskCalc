using EM.Calc.Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EM.Calc.Web.Controllers
{
    public class CalcController : Controller
    {
        private Core.Calc calc;

        public CalcController()
        {
            calc = new Core.Calc(AppDomain.CurrentDomain.BaseDirectory);
        }

        public ActionResult Execute(string oper, double[] args)
        {
            var model = Calc(oper, args);

            return View(model);
        }

        [HttpGet]
        public ActionResult Input()
        {
            var model = new InputModel()
            {
                Operations = calc.Operations
            };

            return View(model);
        }

        [HttpPost]
        public PartialViewResult Input(InputModel model)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            if (!calc.Operations.Any(m => m.Name == model.Name))
            {
                ModelState.AddModelError("Name", "Такой операции нет");

                return null;
            }

            var result = Calc(model.Name, model.Args);

            return PartialView("Execute", result);

        }

        private OperationResult Calc(string oper, double[] args)
        {
            var result = calc.Execute(oper, args);

            return new OperationResult()
            {
                Name = oper,
                Result = result
            };
        }
    }
}