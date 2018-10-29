using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Core.Calc calc = new Core.Calc();

            var input = Console.ReadLine();

            object array = splitArray(input);

            object result = new object();

            switch (input.Split(Convert.ToChar(" "))[0])
            {
                case "sum":
                    result = calc.Sum(array);
                    break;
                case "ras":
                    result = calc.Ras(array);
                    break;
                case "pow":
                    result = calc.Pow(array);
                    break;
            }

            Console.Write(Convert.ToString(result));
            Console.ReadKey();
        }

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

        private static double[] doubleArray(ArrayList array)
        {
            List<double> termsList = new List<double>();

            foreach (object item in array)
                termsList.Add(Convert.ToDouble(item));

            return termsList.ToArray<double>();
        }
    }

}
