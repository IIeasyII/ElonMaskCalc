using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.Core
{
    public class Calc
    {
        public object Sum(object obj)
        {
            if(obj is int[])
                return ((int[])obj).Sum();
            else if(obj is double[])
                return Convert.ToDouble(Convert.ToString(((double[])obj).Sum()));

            return 0;
        }

        public object Ras(object obj)
        {
            if (obj is int[])
            {
                var result = ((int[])obj)[0];
                for (int i = 1; i < ((int[])obj).Length; i++)
                    result -= ((int[])obj)[i];
                return result;
            }
            else if (obj is double[])
            {
                var result = ((double[])obj)[0];
                for (int i = 1; i < ((double[])obj).Length; i++)
                    result -= ((double[])obj)[i];
                return result;
            }

            return 0;
        }

        public object Pow(object obj)
        {
            if (obj is int[])
            {
                var result = ((int[])obj)[0];
                for (int i = 1; i < ((int[])obj).Length; i++)
                    result = (int)Math.Pow(result, ((int[])obj)[i]);
                return result;
            }
            else if (obj is double[])
            {
                var result = ((double[])obj)[0];
                for (int i = 1; i < ((double[])obj).Length; i++)
                    result = Math.Pow(result, ((double[])obj)[i]);
                return result;
            }

            return 0;
        }
    }
}
