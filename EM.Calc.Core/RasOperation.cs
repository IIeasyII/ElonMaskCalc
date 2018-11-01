using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.Core
{
    /// <summary>
    /// Нахождение разности между элементами массива
    /// </summary>
    class RasOperation : IExtOperation
    {
        public string Name => "ras";

        public double[] Operands { get; set; }

        public double? Result { get; private set; }

        public Guid Uid => new Guid("{F99119D4-7EB3-4FFB-98F5-380D1D35DC11}");

        public int? ArgCount => 2;

        public string Description => "Разность";

        public double? Execute()
        {
            Result = Operands[0];

            for (int i = 1; i < Operands.Length; i++)
                Result -= Operands[i];

            return Result;
        }
    }
}
