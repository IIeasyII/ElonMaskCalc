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
            /*List<SelectListItem> listOperations = new List<SelectListItem>();
            foreach (var item in calc.Operations)
            {
                listOperations.Add(new SelectListItem() { Text = item.Name });
            }
            var model = new InputModel()
            {
                Operations = listOperations
            };*/

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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!calc.Operations.Any(m => m.Name == model.Operations.SelectedValue.ToString()))
            {
                ModelState.AddModelError("Name", "Такой операции нет");

                return View(model);
            }

            var result = Calc(model.Operations.SelectedValue.ToString(), new[] { 1d, 2 });
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