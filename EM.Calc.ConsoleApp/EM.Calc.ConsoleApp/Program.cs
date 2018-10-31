using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Core.Calc calc = new Core.Calc();

            // найти файл с операцией

            // загрузить этот файл
            // найти в нем операцию
            
            // добавить операцию в калькулятор





            double[] values;

            string operation, operands;

            int accuracy = 0;

            string[] operations = calc.Operations
                .Select(o => o.Name)
                .ToArray();

            // Проверяем заполненность стартовой консоли
            if(args.Length == 0)
            {
                Console.WriteLine("List operations: ");
                foreach (var item in operations)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Enter operations: ");
                operation = Console.ReadLine();

                Console.WriteLine("Enter operands: ");
                operands = Console.ReadLine();

                Console.WriteLine("Enter accuracy: ");
                accuracy = int.Parse(Console.ReadLine());

                values = convertToDouble(operands.Split(new[] { " ", ";" }, StringSplitOptions.RemoveEmptyEntries));
            }
            else // Берем операцию и значения из стартовой консоли
            {
                operation = args[0].ToLower();
                values = convertToDouble(args, 1);
            }

            // Результат операции
            var result = calc.Execute(operation, values);

            Console.WriteLine(result);

            Console.ReadKey();
        }

        private static double[] convertToDouble(string[] args, int start = 0)
        {
            return args
                .Skip(start)
                .Select(n => Convert.ToDouble(n))
                .ToArray();
        }


        #region
        [Obsolete]
        private static object splitArray(string str)
        {
            var array = str.Split(Convert.ToChar(" "));

            ArrayList newArray = new ArrayList();

            if (str.Contains(","))
            {
                for (int i = 1; i < array.Length; i++)
                    newArray.Add((array[i]));
                return doubleArray(newArray);
            }
            else
            {
                for (int i = 1; i < array.Length; i++)
                    newArray.Add(Convert.ToInt32(array[i]));
                return newArray.OfType<int>().ToArray();
            }
        }

        [Obsolete]
        private static double[] doubleArray(ArrayList array)
        {
            List<double> termsList = new List<double>();

            foreach (object item in array)
                termsList.Add(Convert.ToDouble(item));

            return termsList.ToArray<double>();
        }
        #endregion
    }

}
