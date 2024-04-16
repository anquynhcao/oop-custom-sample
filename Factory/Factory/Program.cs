using TextFile;
namespace Factory;

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

                List<string> list = new List<string>();
                while (!t.End())
                {

                    list.Add(t.Current().ToString());
                    t.Next();
                }

                string a = String.Join(",", list);
                Console.WriteLine(a);



                FileErr = false;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
        } while (FileErr);
    }
}

