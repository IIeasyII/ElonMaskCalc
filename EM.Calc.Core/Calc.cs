using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.Core
{
    public class Calc
    {
        /// <summary>
        /// Операции
        /// </summary>
        public IList<IOperation> Operations { get; set; }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public Calc()
        {
            Operations = new List<IOperation>();

            var path = AssemblyDirectory;

            //Получаю пути до dll файлов проекта
            var dllFiles = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories);

            foreach (var dll in dllFiles)
            {
                LoadOperations(Assembly.LoadFrom(dll));

                /*

                //Получить сборку по указанному пути
                Assembly asm = Assembly.LoadFile(dll);

                //Взять у неё все типы
                var types = asm.GetTypes();

                var needType = typeof(IOperation);

                //Пройтись по ним
                foreach (var item in types.Where(t => t.IsClass && !t.IsAbstract))
                {
                    var interfaces = item.GetInterface(needType.ToString());

                    //если класс реализует заданный интерфейс
                    if (item.GetInterface("IOperation") != null)
                    {
                        //добавляем в операции экземпляр данного класса
                        var instance = Activator.CreateInstance(item);

                        var operation = instance as IOperation;
                        if (operation != null)
                        {
                            Operations.Add(operation);
                        }
                    }
                }*/
            }
        }

        private void LoadOperations(Assembly assembly)
        {
            // загрузить все типы из сборки
            var types = assembly.GetTypes();

            var needType = typeof(IOperation);

            // перебираем все классы в сборке
            foreach (var item in types.Where(t => t.IsClass && !t.IsAbstract))
            {
                var interfaces = item.GetInterfaces();

                // если класс реализаует заданный интерфейс
                if (interfaces.Contains(needType))
                {
                    //добавляем в операции экземпляр данного класса
                    var instance = Activator.CreateInstance(item);

                    var operation = instance as IOperation;
                    if (operation != null)
                    {
                        Operations.Add(operation);
                    }
                }
            }
        }

        public double? Execute(string operName, double[] values)
        {
            foreach (var item in Operations)
            {
                if (item.Name == operName)
                {
                    item.Operands = values;
                    item.Execute();
                    return item.Result;
                }
            }

            return null;
        }

        #region
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

        public double New(double[] args)
        {
            return Double.PositiveInfinity;
        }
        #endregion
    }
}