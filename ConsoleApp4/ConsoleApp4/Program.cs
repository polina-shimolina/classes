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

            List<string> people = new List<string>();
            List<string> ages = new List<string>();
            

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
                        name = Console.ReadLine();
                        age = Console.ReadLine();
                        ages.Add(age);
                        people.Add(name); 
                        break;
                    case 2:
                        for (int i = 0; i < people.Count; i++)
                        {
                            Console.WriteLine(people[i]);
                            Console.WriteLine(ages[i]);
                        }
                        break;
                    case 3:
                        Person person = new Person(name, age);
                        BinaryFormatter formatter = new BinaryFormatter();
                        using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
                        {
                            formatter.Serialize(fs, person);
                        }
                        break;
                    case 4:
                        using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
                        {
                            Person newPerson = (Person)formatter.Deserialize(fs);
                            Console.WriteLine($"Имя: {newPerson.Name} Возраст: {newPerson.Age}");
                        }
                            break;
                    case 5:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

                      