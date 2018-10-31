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
    class RasOperation : IOperation
    {
        public string Name => "ras";

        public double[] Operands { get; set; }

        public double? Result { get; private set; }

        public double? Execute()
        {
            Result = Operands[0];

            for (int i = 1; i < Operands.Length; i++)
                Result -= Operands[i];

            return Result;
        }
    }
}
