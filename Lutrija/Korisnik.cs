using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lutrija
{
	public class Korisnik
	{
		public string Ime { get; set; } = "Pera";
		public string Prezime { get; set; } = "ksjhkj";
		public DateTime? Rodj { get; set; }
		public int BrojBrojeva { get; set; } = 1;

		public string BrojeviUnos { get; set; }
		public List<int> Brojevi { get; set; } = new();
	}
}
