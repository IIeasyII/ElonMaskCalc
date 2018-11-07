using EM.Calc.Core;
using EM.Calc.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EM.Calc.Web.Models
{
    public class GetAllModel
    {
        public IEnumerable<User> All { get; set; }
    }
}