using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;
using ConsoleApp1;



namespace ConsoleApp1
{
    public class Input {
        public string name;
        public string color;
        public int numb;

        Input(string name, string color, int numb)
        {
            this.name = name;
            this.color = color;
            this.numb = numb;
        }

        public static void Read (ref Infile.Status st, ref Input e, ref TextFileReader x)
        {
            e = new Input("", "", 0);
            x.ReadString(out e.name);
            x.ReadString(out e.color);
            bool l = x.ReadInt(out e.numb);
            st = l ? Infile.Status.norm : Infile.Status.abnorm;

        }
    }


    public class Output
    {
        public string name;
        public int numb;

        public override string ToString()
        {
            return
                "(" + name + "," +  numb + ")";
        }
    }


    public class Infile
    {
        private TextFileReader x;
        public enum Status { norm, abnorm};
        private Status st;
        private Input e;
        private bool end;
        private Output curr;



        public Infile(string filename)
        {
            x = new TextFileReader(filename);
            curr = new Output();
        }

        public void First()
        {
            Input.Read(ref st, ref e, ref x);
            Next();
        }        

        public Output Current()
        {
            return curr;
        }

        public bool End()
        {
            return end;
        }


        public void Next()
        {
            end = (st == Status.abnorm);
            if (!end)
            {
                curr.name = e.name;
                curr.numb = 0;
                while (e.name == curr.name && st == Status.norm)
                {
                    curr.numb += e.numb;
                    Input.Read(ref st, ref e, ref x);
                }
            }
        }


    }
}
