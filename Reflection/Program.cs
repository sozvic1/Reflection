using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TemperatureLibrary;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var temp = 5;
            #region withReference
            //Calculate calc = new Calculate();
            //var type = calc.GetType();
            //MethodInfo convertToForen = type.GetMethod("ConvertToForengeite", BindingFlags.Instance | BindingFlags.NonPublic);
            //Console.WriteLine($"Конвертация температуры {temp} цельсий в Форенгейт = {convertToForen.Invoke(calc, new object[] { temp })}"); 
            #endregion withReference
            Assembly assembly = null;
            try
            {
                assembly = Assembly.Load("TemperatureLibrary");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            Type type = assembly.GetType("TemperatureLibrary.Calculate");
            object instance = Activator.CreateInstance(type);
            MethodInfo convertToForen = type.GetMethod("ConvertToForengeite", BindingFlags.Instance | BindingFlags.NonPublic);
                       
            Console.WriteLine($"Конвертация температуры {temp} цельсий в Форенгейт = {convertToForen.Invoke(instance, new object[] { temp })}");
            Console.ReadKey();
        }
    }
    }

