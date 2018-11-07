using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.DB
{
    public class Operation : IEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Rating { get; set; }

        public int ArgsCount { get; set; }

        public string Owner { get; set; }
    }
}
