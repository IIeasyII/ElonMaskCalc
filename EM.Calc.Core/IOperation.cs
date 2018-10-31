using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.Core
{
    /// <summary>
    /// Операция
    /// </summary>
    public interface IOperation
    {
        /// <summary>
        /// Название операции
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Операнды массива
        /// </summary>
        double[] Operands { get; set; }

        /// <summary>
        /// Выполнить операцию
        /// </summary>
        /// <returns>Результат</returns>
        double? Execute();

        /// <summary>
        /// Получить результат
        /// </summary>
        double? Result { get; }
    }
}
