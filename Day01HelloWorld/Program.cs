using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");

            Console.WriteLine("what is your name??");
            string name = Console.ReadLine();

            Console.WriteLine("How old are you?");
            string ageStr = Console.ReadLine();

            if (!int.TryParse(ageStr, out int age))
            {
                Console.WriteLine("Error: you must enter an integer number");
            }
            else
            {
                Console.WriteLine("Hello {0}, you are {1} y/o.", name, age);
            }

            /*
            versin 1
            try
            {
               int age = int.Parse(ageStr);
                Console.WriteLine("Hello {0}, you are {1} y/o.", name, age);
            } catch (FormatException ex)
            {
                Console.WriteLine("Error: you must enter an integer number");
            }
            */

            Console.ReadKey();
        }
    }
}

