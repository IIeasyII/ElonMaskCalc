using EM.Calc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lukoil.Calc.Finance
{
    public class FinanceOperation : IOperation
    {
        public string Name => "finance";

        public double[] Operands { get; set; }

        public double? Result { get; private set; }

        public double? Execute()
        {
            Result = new Random().NextDouble() * new Random().NextDouble();
            return Result;
        }

        public double? Accuracy(int accuracy)
        {
            return Math.Round(Convert.ToDouble(Result), accuracy);
        }
    }
}
