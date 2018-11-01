using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.Core
{
    /// <summary>
    /// New
    /// </summary>
    class NewOperation : IExtOperation
    {
        public string Name => "new";

        public double[] Operands { get; set; }

        public double? Result { get; private set; }

        public Guid Uid => new Guid("{1450CC69-FE29-4592-8C89-F7AE2419FFE3}");

        public int? ArgCount => 0;

        public string Description => "Возвращает позитив";

        public double? Execute()
        {
            Result = Double.PositiveInfinity;
            return Result;
        }
    }
}
