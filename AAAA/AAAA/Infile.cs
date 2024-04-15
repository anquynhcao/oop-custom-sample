using System;
using TextFile;

namespace AAAA
{
	public class Input
	{
		public string name;
		public int grade;
        Input(string name, int grade)
        {
            this.name = name;
            this.grade = grade;
        }
        public static void Read(ref Infile.Status st, ref Input e, ref TextFileReader x)
        {
            e = new Input("", 0);
            x.ReadString(out e.name);
            bool statusEnd = x.ReadInt(out e.grade);
            st = statusEnd ? Infile.Status.norm : Infile.Status.abnorm;


        }
    }

	public class Output
	{
		public string name;
		public int attempt;
		

		
	}
	public class Infile
	{
		public enum Status {abnorm, norm};
		private Status st;
		private Input e;
		private TextFileReader x;
		private Output curr;
		private bool end;



		public Infile(string filename)
		{
			x = new TextFileReader(filename);
			curr = new Output();

		}

		public void First()
		{
			Input.Read(ref st,ref e,ref x); //why
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
				curr.attempt = 0;
				while (st == Status.norm && e.name == curr.name)
				{
					curr.attempt += 1;
					Input.Read(ref st, ref e, ref x);
				}
				
			}

		}
	}
}

