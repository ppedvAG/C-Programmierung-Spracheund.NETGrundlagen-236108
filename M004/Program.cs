using System.Net;
using System.Net.Http.Headers;

namespace M004
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Schleifen
			int a = 0;
			int b = 10;
			while (a < b) //Am Ende der Schleife wird geprüft, ob die Bedingung noch true ist
			{
                Console.WriteLine($"while: {a}");
                a++;
			}

			a = 0;
			do //Do-While funktioniert wie while, wird aber immer mindestens einmal ausgeführt (bei while kann die Bedingung von Anfang an false sein)
			{
				Console.WriteLine($"do-while: {a}");
				a++;
			}
			while (a < b);

			while (true)
			{
				//Endlosschleife

				break; //break: Beendet die Schleife, generell immer in Kombination mit einer if
				continue; //continue: Springe zum Schleifenkopf zurück, überspringe allen Code der nach continue in der Schleife kommen würde
			}

			//do-while mit while (true)
			a = 0;
			while(true) //Läuft für immer
			{
				Console.WriteLine($"while-true: {a}");
				a++;

				if (a >= b) //Bis eine Bedingung getroffen wird
					break;
			}

            //for Schleife: Wie while Schleife, nur mit einer integrierten Zählervariable
            for (int i = 0; i < 10; i++) //for + Tab + Tab
            {
                Console.WriteLine($"for: {i}");
            }

            for (int i = 10 - 1; i >= 0; i--) //forr + Tab + Tab
            {
                Console.WriteLine($"forr: {i}");
            }

			//Eine for-Schleife kann beliebig viele Zähler, Bedingungen, Inkremente haben
			for (int i = 1, j = 0, k = 0; i < j && i < k; i++, j--, k *= 2)
			{

			}

			for (int i = 10 - 1; i >= 0; i--) //forr + Tab + Tab
				Console.WriteLine($"forr: {i}");

			//foreach
			//Collection durchgehen
			int[] zahlen = [1, 2, 3, 4, 5, 6, 7, 8, 9];
			foreach (int i in zahlen) //Laufvariable in Collection
			{
                Console.WriteLine($"foreach: {i}");
            }

			//for (int i = 0; i < zahlen.Length; i++)
			//{
			//	i++; //Bei einem Array kann mit einem Index daneben gegriffen werden, bei foreach nicht möglich
			//	Console.WriteLine(zahlen[i]); //System.IndexOutOfRangeException: 'Index was outside the bounds of the array.'
			//}

			int[,] zweiD = new int[3, 3];
			foreach (int d in zweiD)
			{
                Console.WriteLine(d);
            }

			for (int i = 0; i < zweiD.GetLength(0); i++)
				for (int j = 0; j < zweiD.GetLength(1); j++)
					Console.WriteLine(zweiD[i, j]);
			#endregion

			#region	Enum
			//Enum: Liste von Konstanten
			//Eigener Typ, in dem diese Konstanten gespeichert werden
			Wochentag tag = Wochentag.Mo;
			if (tag == Wochentag.Di)
			{
                Console.WriteLine("Heute ist Dienstag");
            }

			string s = "Mo"; //Inkonsistenz in Daten (Montag statt Mo, MO statt Mo)
			if (s == "Di") //Ein String kann alles speichern, ein Enumwert kann nur seine Zustände speichern
			{
				Console.WriteLine("Heute ist Dienstag");
			}

			//Hinter jedem Enumwert steckt ein int
			//z.B. HttpCodes ist ein Enum und besteht aus numerischen Werte
			Wochentag wochenende = Wochentag.Sa | Wochentag.So; //Mehrere Enumwerte in einer Variable speichern, wenn das Enum Binär aufgebaut ist

			//Alle Enumwerte in ein Array schreiben
			Wochentag[] tage = [Wochentag.Mo, Wochentag.Di, Wochentag.Mi, Wochentag.Do, Wochentag.Fr, Wochentag.Sa, Wochentag.So];
			Wochentag[] tageV = Enum.GetValues<Wochentag>(); //Dynamisch anhand des Enums die Werte herausholen
			HttpStatusCode[] codes = Enum.GetValues<HttpStatusCode>();

			//Casting mit Enums
			
			//String zu Enum
			Enum.Parse<Wochentag>("Mo"); //In spitzer Klammer das Zielenum angeben

            //int zu Enum
            Console.WriteLine((Wochentag) 3);
			#endregion

			#region Switch
			Wochentag x = Wochentag.Mo;

			//Strg + .: Add missing cases
			switch (x)
			{
				case Wochentag.Mo:
				case Wochentag.Di:
				case Wochentag.Mi:
				case Wochentag.Do:
				case Wochentag.Fr:
                    Console.WriteLine("Wochentag");
                    break;
				case Wochentag.Sa:
				case Wochentag.So:
                    Console.WriteLine("Wochenende");
                    break;
				default:
                    Console.WriteLine("Fehler");
                    break;
			}

			switch (x)
			{
				//Hier sind &&, || nicht möglich
				case >= Wochentag.Mo and <= Wochentag.Fr:
					Console.WriteLine("Wochentag");
					break;
				case Wochentag.Sa or Wochentag.So:
					Console.WriteLine("Wochenende");
					break;
				default:
					Console.WriteLine("Fehler");
					break;
			}
			#endregion
		}
	}

	enum Wochentag
	{
		//Enumwerten können auch selbst Werte zugewiesen werden
		//Mo = 1, Di = 2, Mi = 4, Do = 8, Fr = 16, Sa = 32, So = 64
		Mo = 1, Di, Mi, Do, Fr, Sa, So
	}
}
