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
            List<string> list = new List<string>();

            foreach (var item in calc.Operations)
            {
                list.Add(item.Name);
            }

            // Список операций
            SelectList listOperations = new SelectList(list);

            var model = new InputModel()
            {
                Operations = listOperations
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Input(InputModel model)
        {
            model.SelectedOperation = Request.Form["Operations"].ToString();

            if (!calc.Operations.Any(m => m.Name == model.SelectedOperation))
            {
                ModelState.AddModelError("Name", "Такой операции нет");

                return View(model);
            }

            var result = Calc(model.SelectedOperation, model.Args.Split(' ').Select(Convert.ToDouble).ToArray());

            var values = model.Args.Split(' ')
                    .Select(Convert.ToDouble)
                    .ToArray();

            return View("Execute", result);

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