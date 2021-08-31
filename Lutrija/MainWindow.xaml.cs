using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lutrija
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public Korisnik Igrac { get; set; } = new();
		public List<Listic> Listici { get; set; } = new();
		public MainWindow()
		{
			InitializeComponent();
			DataContext = Igrac;

			/*string asd = "asd";
			asd = null;

			int broj = 4;
			//broj = null; ne moze da bude null :)

			int? broj2 = null;*/
		}

		private void Dalje(object sender, RoutedEventArgs e)
		{
			/*if (Igrac.Rodj is null)
			{
				MessageBox.Show("Unesi datum!");
			} else if (Igrac.Rodj.Value.AddYears(18) > DateTime.Now)
			{
				MessageBox.Show("Jock!");
			} else if (Igrac.BrojBrojeva < 1 || Igrac.BrojBrojeva > 10)
			{
				MessageBox.Show("Los broj");
			}else*/
			{
				//Unos.Visibility = Visibility.Collapsed;
				//Izvlacenje.Visibility = Visibility.Visible;
			}
		}
		private void DodajBrojeve(object sender, RoutedEventArgs e)
		{
			// "15 7 5" --> {"15", "7", "5"}
			string[] brojevi = Igrac.BrojeviUnos.Split(" ");
			if (brojevi.Count() != Igrac.BrojBrojeva)
			{
				MessageBox.Show("Los broj brojeva!");
				return;
			}

			bool greska = false;
			Listic l = new();

			foreach (string br in brojevi)
			{
				if (int.TryParse(br, out int broj))
				{
					if (broj < 1 || broj > 99)
					{
						MessageBox.Show($"{broj} nije izmedju 1 i 99");
						greska = true;
					} else
					{
						l.Brojevi.Add(broj);
					}

				} else
				{
					MessageBox.Show($"\"{br}\" nije broj!");
					greska = true;
				}
			}
			if (greska)
				return;
			if (l.Brojevi.Count != Igrac.BrojBrojeva)
			{
				MessageBox.Show("Imate duplikata!");
				return;
			}
			Listici.Add(l);
		}
		private async void Igraj(object sender, RoutedEventArgs e)
		{
			Random nasumcino = new();
			do
			{
				int broj = nasumcino.Next(0, 100);

				Brush pozadina = Brushes.Red;

				foreach(Listic l in Listici)
				{
					if (l.Brojevi.Contains(broj))
					{
						l.Brojevi.Remove(broj);
						pozadina = Brushes.Green;
					} 
				}
				
				mestoZaBrojeve.Children.Add(new Label { Content = broj, Background = pozadina });

				foreach (Listic l in Listici)
				{
					if (l.Brojevi.Count() == 0)
					{
						MessageBox.Show($"Dobitni listic je sa serijskim brojem {l.SerijskiBroj}!");
						return;
					}
				}
				await Task.Delay(2000);
			} while (true);
		}
	}
}
