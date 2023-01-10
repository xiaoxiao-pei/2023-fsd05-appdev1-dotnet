using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day01PeopleListInFile
{
    public class Person
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length < 2 || value.Length > 100 || value.Contains(";"))
                    throw new ArgumentException(nameof(value), "Name must be 2-100 characters long, not containing semicolons");

                _name = value;
            }
        } // Name 2-100 characters long, not containing semicolons

        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0 || value > 150)
                    throw new ArgumentException(nameof(value), "Age should be 0-150");
                _age = value;
            }
        } // Age 0-150

        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                if (value.Length < 2 || value.Length > 100 || value.Contains(";"))
                    throw new ArgumentException(nameof(value), "City must be 2-100 characters long, not containing semicolons");

                _city = value;
            }
        } // City 2-100 characters long, not containing semicolons

        public override string ToString()
        {
            return Name + " is " + Age + " from " + City;
        }

    }
    internal class Program
    {
        static List<Person> people = new List<Person>();
        public const string FileName = "people.txt";
        static void AddPersonInfo()
        {
            Console.WriteLine("Adding a person");

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter age: ");
            string ageStr = Console.ReadLine();
            if (!int.TryParse(ageStr, out int age))
            {
                Console.WriteLine(" age must be an integer");
                return;
            }

            Console.Write("Enter city :");
            string city = Console.ReadLine();

            Person person = new Person();
            try
            {
                person.Name = name;
                person.Age = age;
                person.City = city;
                people.Add(person);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static void ListAllPersonsInfo()
        {
            Console.WriteLine("Listing all persons");
            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
        static void FindPersonByName()
        {
            Console.WriteLine("Enter partial person name:");
            string str = Console.ReadLine();
            Console.WriteLine("Matches found");
            foreach (Person person in people)
            {
                if (person.Name.Contains(str))
                {
                    Console.WriteLine(person.ToString());
                }
            }
        }
        static void FindPersonYoungerThan()
        {
            Console.WriteLine("Enter the maxium age:");
            string ageStr = Console.ReadLine();
            int.TryParse(ageStr, out int age);

            Console.WriteLine("Matches found");
            foreach (Person person in people)
            {
                if (person.Age < age)
                {
                    Console.WriteLine(person.ToString());
                }
            }
        }

        static void ReadAllPeopleFromFile()
        {
            try
            {
                string line = "";
                using (StreamReader sr = new StreamReader(FileName))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] lineArr = line.Split(';');
                        string name = lineArr[0];
                        int age = int.Parse(lineArr[1]);
                        string city = lineArr[2];

                        Person person = new Person();

                        try
                        {
                            person.Name = name;
                            person.Age = age;
                            person.City = city;
                            people.Add(person);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }

                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Failed to open file, " + e.Message);
            }
        }

        static void SaveAllPeopleToFile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FileName))
                {
                    foreach (Person person in people)
                    {
                        sw.WriteLine(person.Name + ";" + person.Age + ";" + person.City);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Failed to write to file, " + e.Message);
            }
        }
        static void Main(string[] args)
        {
            ReadAllPeopleFromFile();

            while (true)
            {
                Console.WriteLine();
                Console.Write("What do you want to do?\r\n" +
                   "1. Add person info\r\n" +
                   "2. List persons info\r\n" +
                   "3. Find a person by name\r\n" +
                   "4. Find all persons younger than age\r\n" +
                   "0. Exit\r\n" +
                   "Choice:");
                string choiceStr = Console.ReadLine();
                int.TryParse(choiceStr, out int choice);
                Console.WriteLine();

                switch (choice)
                {
                    case 0:
                        SaveAllPeopleToFile();
                        Console.WriteLine("Good bye!");

                        Environment.Exit(0);
                        break;
                    case 1:
                        AddPersonInfo();
                        break;
                    case 2:
                        ListAllPersonsInfo();
                        break;
                    case 3:
                        FindPersonByName();
                        break;
                    case 4:
                        FindPersonYoungerThan();
                        break;
                    default:
                        Console.WriteLine("Invalid choice try again.");
                        break;
                }

            }
        }
    }
}
