using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.Core
{
    /// <summary>
    /// Получение суммы элементов массива
    /// </summary>
    public class SumOperation : IOperation
    {
        public string Name => "sum";

        public double[] Operands { get; set; }

        public double? Result { get; private set; }

        public double? Execute()
        {
            Result = Operands.Sum();
            return Result;
        }

        public double? Accuracy(int accuracy)
        {
            Result = Math.Round(Convert.ToDouble(Result), accuracy);
            return Result;
        }
    }
}
