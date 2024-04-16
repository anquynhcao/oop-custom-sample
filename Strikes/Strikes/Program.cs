
using TextFile;
//determine if every round has at least 1 strike = a 10 score. if yes return "yes", no return "no". inputfile included

namespace Strikes;


class Program
{
    static void Main(string[] args)
    {

        bool FileErr = true;
        do
        {
            try
            {
                Console.WriteLine("Enter file name: ");
                string name = Console.ReadLine();
                Infile t = new Infile(name);
                
                t.First();
                bool strikes = true;
                while (!t.End())
                {
                    
                    strikes = (strikes && t.Current().strike);
                    t.Next();
                }
                if (strikes)
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }



                FileErr = false;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
        } while (FileErr);
       
    }
}

