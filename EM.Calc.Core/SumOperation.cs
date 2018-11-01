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
    public class SumOperation : IExtOperation
    {
        public string Name => "sum";

        public double[] Operands { get; set; }

        public double? Result { get; private set; }

        public Guid Uid => new Guid("{EB4892CD-A31F-4C43-BE25-342777F19B5D}");

        public int? ArgCount => 2;

        public string Description => "Сумма";

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
