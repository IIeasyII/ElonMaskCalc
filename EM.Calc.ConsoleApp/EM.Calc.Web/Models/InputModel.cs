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
        [Display(Name = "Операция")]
        public string SelectedOperation { get; set; }
        
        public IEnumerable<SelectListItem> Operations { get; set; }

        /*[Display(Name = "Операция")]
        [Required(ErrorMessage = "Нам обязательно нужно знать операцию")]
        public string Name { get; set; }

        /*[Display(Name = "Параметры1")]
        public double[] Args1 { get; set; }*/

        [Display(Name = "Аргументы")]
        [Required]
        public string Args { get; set; }

        /*[ScaffoldColumn(false)]
        public SelectList Operations { get; set; }*/




        //public IList<IOperation> Operations { get; set; }
    }
}