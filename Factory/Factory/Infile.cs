using System;
using TextFile;
namespace Factory
{

	public class Worker
	{
		public int id;
		public int product;


		Worker(int id, int product)
		{
			this.id = id;
			this.product = product;
		}

		public static void Read(ref Infile.Status st, ref Worker e, ref TextFileReader x)
		{
			e = new Worker(0, 0);
			bool l = x.ReadInt(out e.id) && x.ReadInt(out e.product);
			st = l ? Infile.Status.norm : Infile.Status.abnorm;
		}
	}
	public class Output
	{
		public int id;
		public int maxPr;
        public override string ToString()
        {
			return "(" + id + "," + maxPr + ")";
        }
    }


	public class Infile
	{
		public enum Status { norm, abnorm};
		private Status st;
		private Worker e;
		private Output curr;
		private TextFileReader x;
		private bool end;
		
		public Infile( string filename)
		{
			x = new TextFileReader(filename);
			curr = new Output();
		}


		public bool End()
		{
			return end;
		}

		public Output Current()
		{
			return curr;
		}


		public void First()
		{
			Worker.Read(ref st, ref e, ref x);
			Next();

		}

		public void Next()
		{
			end = (st == Status.abnorm);
			if (!end)
			{
				curr.id = e.id;
				curr.maxPr = 0;
				while (e.id == curr.id && st == Status.norm)
				{
					if (e.product > curr.maxPr)
					{
						curr.maxPr = e.product;
					}
					Worker.Read(ref st, ref e, ref x);
				}
			}
		}
	}
}

