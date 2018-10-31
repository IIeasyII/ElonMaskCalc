using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.Core
{
    /// <summary>
    /// Возведение в степень элементов массива
    /// </summary>
    class PowOperation : IOperation
    {
        public string Name => "pow";

        public double[] Operands { get; set; }

        public double? Result { get; private set; }

        public double? Execute()
        {
            Result = Operands[0];

            for (int i = 1; i < Operands.Length; i++)
                Result = Math.Pow(Convert.ToDouble(Result), Operands[i]);

            return Result;
        }
    }
}
