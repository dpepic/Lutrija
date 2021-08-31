using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lutrija
{
	public class Listic
	{
		public int SerijskiBroj { get; set; }
		public HashSet<int> Brojevi = new();

		public Listic()
		{
			Random r = new();
			SerijskiBroj = r.Next(10000, 99999);
		}

	}
}
