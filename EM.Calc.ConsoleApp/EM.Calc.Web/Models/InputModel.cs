using EM.Calc.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EM.Calc.Web.Models
{
    public class InputModel
    {
        public InputModel()
        {
            Operations = new List<IOperation>();
        }

        [Display(Name = "Операция")]
        public string Name { get; set; }

        [Display(Name = "Аргументы")]
        public double[] Args { get; set; }

        public IList<IOperation> Operations { get; set; }
    }
}