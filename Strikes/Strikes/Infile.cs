using System;
using TextFile;

namespace Strikes
{

	public class Input
	{
		int round;
		string name;
		int score;

		Input(int round, string name, int score)
		{
			this.round = round;
			this.name = name;
			this.score = score;

		}

		static void Read (ref Infile.Status st, ref Input e, ref TextFileReader x)
		{
			e = new Input(0, "", 0);
			x.ReadInt(out e.round);
			x.ReadString(out e.name);
			bool l = x.ReadInt(out e.score);
			st = l ? Infile.Status.norm : Infile.Status.abnorm;
		}
		


	}





	public class Output
	{
		int round;
		bool strike;


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
	}






}
	
