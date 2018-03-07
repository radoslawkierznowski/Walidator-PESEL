/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: rados
 * Data: 04.03.2018
 * Godzina: 18:01
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Walidator_PESEL
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}
		void Validate_Click(object sender, RoutedEventArgs e)
		{
			string pesel = Convert.ToString(Pesel.Text);
			char[] peselChar = new char[11];
			string[] peselString = new string[11];
			double[] peselDouble = new double[11];
			double wynik = 0;
			int j = 0;
			for (int i = 0; i < 11; i++) {
				peselChar[i] = pesel[i];
				peselString[i] = Convert.ToString(peselChar[i]);
				peselDouble[i] = Convert.ToDouble(peselString[i]);
			}
			while (j!=10)
			{
				if (j == 1 || j == 5 || j == 9)
					peselDouble[j] *= 3;
				if (j == 2 || j == 6 || j == 10)
					peselDouble[j] *= 7;
				if (j == 3 || j == 7 || j == 11)
					peselDouble[j] *= 9;
				j++;
			}
			for (int i = 0; i < 10; i++) {
				wynik += peselDouble[i];
			}
			wynik %= 10;
			wynik = 10 - wynik;
			if (wynik == 10)
				wynik = 0;
			Status.Text = wynik == peselDouble[10] ? "PESEL jest poprawny" : "PESEL jest błędny";
		}
	}
}