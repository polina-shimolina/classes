using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    [Serializable]
    class Person
    {
        public string Name { get; set; }
        public string Age { get; set; }

        public Person(string name, string age)
        {
            Name = name;
            Age = age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            BinaryFormatter formatter = new BinaryFormatter();
            int l = 0;

            int k = 0;
            string name ="";
            int n = 0;

            string age = "";
            while (n != 5)
            {
                string input = Console.ReadLine();
                n = int.Parse(input);
                switch (n)
                {
                    case 1:
                        {
                            name = Console.ReadLine();
                            age = Console.ReadLine();
                            people.Add(new Person(name, age));
                            break;
                        }

                    case 2:
                        {
                            for (int i = 0; i < people.Count; i++)
                            {
                                Console.WriteLine(people[i].Name);
                                Console.WriteLine(people[i].Age);
                            }
                            break;
                        }
                    case 3:
                        {
                            
                            formatter = new BinaryFormatter();
                            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
                            {
                                formatter.Serialize(fs, people);
                            }
                            break;
                        }
                    case 4:
                        {
                            formatter = new BinaryFormatter();
                            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
                            {
                                Person[] deserilizePeople = (Person[])formatter.Deserialize(fs);
                                foreach (Person p in deserilizePeople)
                                {
                                    Console.WriteLine($"Имя: {p.Name} --- Возраст: {p.Age}");//записать в лист??? очистить лист перед этим
                                }
                            }
                            break;
                        }
                    case 5:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

                      