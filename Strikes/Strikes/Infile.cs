using System;
using TextFile;
//determine if every round has at least 1 strike = a 10 score. if yes return "yes", no return "no". inputfile included
namespace Strikes
{

	public class Input
	{
		public int round;
		public string name;
		public int score;

		Input(int round, string name, int score)
		{
			this.round = round;
			this.name = name;
			this.score = score;

		}
		

		public static void Read (ref Infile.Status st, ref Input e, ref TextFileReader x)
		{
			e = new Input(0,"", 0);
			x.ReadInt(out e.round);
			x.ReadString(out e.name);
			bool l = x.ReadInt(out e.score);
			st = l ? Infile.Status.norm : Infile.Status.abnorm;
		}
		


	}





	public class Output
	{
		public int round;
		public bool strike;


	}

	public class Infile
	{
		public enum Status { norm, abnorm };
		private Status st;
		private TextFileReader x;
		private Input e;
		private Output curr;
		private bool end;
		


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
				curr.round = e.round;
				curr.strike = false;
				while (e.round == curr.round && st == Status.norm)
				{
					curr.strike = (curr.strike || e.score == 10);
				}
				Console.WriteLine(curr.strike);
				Input.Read(ref st, ref e, ref x);
			}

		}
	}






}
	
