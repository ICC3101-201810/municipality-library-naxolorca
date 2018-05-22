using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
    class Program
    {

        static void Main(string[] args)
        {
            Assembly archivoAssembly;
            archivoAssembly = Assembly.LoadFrom("a.dll");
            foreach (Type type in archivoAssembly.GetTypes())
            {
                Console.Write("\n"+type.Name + "\n");
                Console.WriteLine("----------\n");

                PropertyInfo[] properties = type.GetProperties();
                MethodInfo[] methods = type.GetMethods();
                ConstructorInfo[] contructores = type.GetConstructors();
                foreach(ConstructorInfo contructor in contructores)
                {
                    Console.WriteLine(contructor);
                }
                foreach (PropertyInfo property in properties)
                {
                   
                    Console.Write(property.Name+"   ");
                    Console.WriteLine(property.PropertyType.Name);
                }
                Console.WriteLine("----------\n");
                foreach (MethodInfo metodo in methods)
                {
                    Console.Write(metodo.Name + "   ");
                    Console.Write(metodo.DeclaringType.Name + "   ");
                    
                    Console.WriteLine(metodo.ReturnType.Name);


                }

            }
            
            Console.ReadKey();
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
