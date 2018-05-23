using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace pregunta_2
{
    
    [Serializable]
    class Program
    {
        Person dueno = null;
        static void Main(string[] args)
        {
            List<Person> personas = new List<Person>();
            List<Address> addresses = new List<Address>();
            List<Car> cars = new List<Car>();
            try
            {
                using (Stream stream1 = File.Open("MyFile1.bin", FileMode.Open))
                using (Stream stream2 = File.Open("MyFile2.bin", FileMode.Open))
                using (Stream stream3 = File.Open("MyFile3.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    try
                    {
                        personas = (List<Person>)bin.Deserialize(stream1);
                        addresses = (List<Address>)bin.Deserialize(stream2);
                        cars = (List<Car>)bin.Deserialize(stream3);

                    }
                    catch { }

                }
            }
            catch (IOException)
            {
            }

            while (true)
            {

                Console.WriteLine("¿Que quieres hacer?\n");
                Console.WriteLine("\t1. Crear Persona");
                Console.WriteLine("\t2. Crear Direccion");
                Console.WriteLine("\t3. Crear Auto");
                Console.WriteLine("\t4. Pagar");
                Console.WriteLine("\t5. Salir");

                while (true)
                {
                    String answer = Console.ReadLine();
                    if (answer == "1")
                    {
                        Console.WriteLine("Ingrese Nombre");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese Apellido");
                        string apellido = Console.ReadLine();
                        Console.WriteLine("Ingrese Cumpleaños");
                        DateTime cumple = Convert.ToDateTime(Console.ReadLine());
                        int i = 0;

                        foreach (Address dir in addresses)
                        {
                            Console.WriteLine("\n" + dir.Street + "  " + i.ToString());
                            i += 1;
                        }
                        Console.WriteLine("Ingrese Direccion [numero]");
                        Address direccion = addresses[Convert.ToInt32(Console.ReadLine())];
                        Console.WriteLine("Ingrese Rut");
                        string rut = Console.ReadLine();

                        personas.Add(new Person(nombre, apellido, cumple, direccion, rut, null, null));


                        break;
                    }
                    else if (answer == "2")
                    {
                        Console.WriteLine("Ingrese Calle");
                        string calle = Console.ReadLine();
                        Console.WriteLine("Ingrese numero");
                        int numero = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese Comuna");
                        string comuna = Console.ReadLine();
                        Console.WriteLine("Ingrese Ciudad");
                        string ciudad = Console.ReadLine();
                        int i = 0;

                        foreach (Person p in personas)
                        {
                            Console.WriteLine("\n" + p.First_name + "  " + i.ToString());
                            i += 1;
                        }
                        Console.WriteLine("Ingrese Dueño [numero]");
                        Person dueno = personas[Convert.ToInt32(Console.ReadLine())];  
                        Console.WriteLine("Ingrese año de contruccion");
                        int ano = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese Numero de Habitaciones");
                        int habi = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese Numero de baños");
                        int banos = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Jardin? true/false");
                        bool jardin = Convert.ToBoolean(Console.ReadLine());

                        addresses.Add(new Address(calle, numero, comuna, ciudad, dueno, ano, habi, banos, jardin, false));
                        break;

                    }
                    else if (answer == "3")
                    {
                        Console.WriteLine("Ingrese Marca");
                        string marca = Console.ReadLine();
                        Console.WriteLine("Ingrese modelo");
                        string modelo = Console.ReadLine();
                        Console.WriteLine("Ingrese año");
                        int ano = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese Ciudad");
                        string ciudad = Console.ReadLine();
                        int i = 0;

                        foreach (Person p in personas)
                        {
                            Console.WriteLine("\n" + p.First_name + "  " + i.ToString());
                            i += 1;
                        }
                        Console.WriteLine("Ingrese Dueño [numero]");
                        Person dueno = personas[Convert.ToInt32(Console.ReadLine())];

                        Console.WriteLine("Ingrese la patente");
                        string patente = Console.ReadLine();
                        Console.WriteLine("Ingrese Numero de cinturoness");
                        int cint = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Diesel? true/false");
                        bool diesel = Convert.ToBoolean(Console.ReadLine());

                        cars.Add(new Car(marca, modelo, ano, dueno, patente, cint, diesel));
                        break;
                    }
                    else if (answer == "4")
                    {

                        break;
                    }
                    else if (answer == "5") { }
                    {
                        IFormatter formatter = new BinaryFormatter();
                        Stream stream1 = new FileStream("MyFile1.bin",
                                                 FileMode.Create,
                                                 FileAccess.Write, FileShare.None);

                        formatter.Serialize(stream1, personas);
                        stream1.Close();

                        Stream stream2 = new FileStream("MyFile2.bin",
                                                 FileMode.Create,
                                                 FileAccess.Write, FileShare.None);

                        formatter.Serialize(stream2, addresses);
                        stream2.Close();

                        Stream stream3 = new FileStream("MyFile3.bin",
                                                 FileMode.Create,
                                                 FileAccess.Write, FileShare.None);

                        formatter.Serialize(stream3, cars);
                        stream3.Close();
                        Environment.Exit(1);
                    }
                }
            }
        }
    }
}

        


 

