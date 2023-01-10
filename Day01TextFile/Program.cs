using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01TextFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

            while (true)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter("data.txt"))
                    {
                        Console.WriteLine(Path.GetFullPath("data.txt"));
                        for (int i = 0; i < 3; i++)
                        {
                            sw.WriteLine(name);
                        }
                        sw.Close();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can't write to file, try again");
                }
            }


            try
            {
                string line = "";
                using (StreamReader sr = new StreamReader("data.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            } catch(Exception ex)
            {
                Console.WriteLine("File can't be read.");
            }

            Console.ReadKey();

        }
    }
}
