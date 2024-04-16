
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
               
                int strikes = 0;
                int round = 0; 
                //bool strikes = true;
                while (!t.End())
                {

                    strikes = strikes + t.Current().strike;
                    
                    if (t.Current().round > round)
                    {
                        round = t.Current().round;
                    }
                    t.Next();
                }
                if (round > strikes)
                {
                    Console.WriteLine("no");
                }
                else
                {
                    Console.WriteLine("yes");
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

