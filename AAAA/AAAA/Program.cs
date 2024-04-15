using System.IO.Enumeration;
using System;
using TextFile;
using System.Xml.Linq;

namespace AAAA;

class Program
{
    static void Main(string[] args)
    {
        bool FileErr = true;
        do
        {
            try
            {
                Console.WriteLine("Enter file name:");
                string filename = Console.ReadLine();
                Infile t = new Infile(filename);

                t.First();
                int max = 0;
                while (!t.End())
                {
                    if (t.Current().attempt > max)
                    {
                        max = t.Current().attempt;

                    }

                    t.Next();

                }

                Console.WriteLine(max);
                FileErr = false;

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("file not found!\n");
            }

        } while (FileErr);
    }
}

