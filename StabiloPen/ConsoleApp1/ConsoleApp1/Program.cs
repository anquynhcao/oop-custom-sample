using System.Runtime.Intrinsics.X86;
using TextFile;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool FileErr = true;
            do 
            {
                try 
                {
                    Console.Write("enter file name: ");
                    string name = Console.ReadLine();
                    Infile t = new Infile(name);
                   
                    t.First();
                    int cnt = 0;
                    List<string> output = new List<string>();
                    while (!t.End())
                    {
                        if (t.Current().numb > 70)
                        {
                            cnt += 1;
                            Console.WriteLine(t.Current().name);
                            
                        }
   

                        // output.Add(t.Current().ToString());
                        t.Next();   
                    }
                    if (cnt == 0)
                    {
                        Console.WriteLine("no pen more than 70");
                    }

                    /*string output1 = string.Join(",", output);
                    Console.WriteLine(output1);*/



                    FileErr = false;
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("file not found, try again");
                }
            }
            while (FileErr);
        }
    }
}
