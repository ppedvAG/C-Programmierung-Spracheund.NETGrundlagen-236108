namespace M005
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PrintAddiere(2, 3);
			PrintAddiere(2, 3);
			PrintAddiere(2, 3);
			PrintAddiere(2, 3);
			PrintAddiere(2, 3);

			int x = Addiere(2, 3);

			Console.WriteLine(); //1 of 18: 18 Overloads

			double y = Addiere(5.0, 2); //Overload auswählen mithilfe der Parameter

			//params: Ermöglicht, einen Parameter zu definieren, der beliebig viele Werte empfangen kann
			Addiere(1, 2, 3);
			Addiere(1, 2, 3, 4, 5, 6, 7, 8);
			Addiere(1);
			Addiere(); //Keine Parameter sind auch beliebig viele Parameter

			int[] zahlen = [1, 2, 3];
			Addiere(zahlen);

			//Optionale Parameter: Parameter mit einem Standardwert, der geändert werden kann, aber nicht muss
			AddiereOderSubtrahiere(3, 4);
			AddiereOderSubtrahiere(3, 4);
			AddiereOderSubtrahiere(3, 4);
			AddiereOderSubtrahiere(3, 4);
			AddiereOderSubtrahiere(3, 4);
			AddiereOderSubtrahiere(3, 4, false);
			AddiereOderSubtrahiere(3, 4);
			AddiereOderSubtrahiere(3, 4);
			AddiereOderSubtrahiere(3, 4);

			AddiereOderSubtrahiere(add: false);
			//Über Parametername: kann ein bestimmter optionaler Parameter angesprochen werden
			//Es gibt Stellen mit 5, 10 oder 20 optionalen Parametern, da sollen nicht alle Parameter befüllt werden
			//-> Nur die Parameter, befüllen die wirklich benötigt werden

			//out
			//Mehrere Werte zurückgeben über out Parameter
			int ergebnis = 0;
			bool hatFunktioniert = int.TryParse("12t3", out ergebnis); //Hier wird die Ergebnis Variable mit der Funktion verbunden
			//Wenn Zeile 47 ausgeführt wird, wird der Boolean und das Ergebnis geschrieben
			if (hatFunktioniert)
			{
                Console.WriteLine("Zahl: " + ergebnis);
            }
			else
			{
                Console.WriteLine("Parsen hat nicht funktioniert");
            }

			//Eigene Funktion mit out
			int sub = 0;
			int summe = AddiereUndSubtrahiere(3, 4, out sub);

			//Tupel: Datentyp der mehrere Werte halten die benannt sind
			(int, int) summen = AddiereUndSubtrahiere(3, 1);
            Console.WriteLine(summen.Item1);
            Console.WriteLine(summen.Item2);
        }

		/// <summary>
		/// Aufbau: Modifier Rückgabetyp Name(Par1, Par2, ...)
		/// 
		/// Rückgabetyp kann ein beliebiger Typ sein oder void
		/// Bei Funktionen mit einem Rückgabetyp muss ein return in der Funktion enthalten sein, bei void ist return nicht erzwungen
		/// 
		/// Parameter: Typ Name, Typ2 Name2, ...
		/// Kann auch leer sein ()
		/// 
		/// Darunter in Klammern der Body, Code der ausgeführt wird, wenn die Funktion aufgerufen wird
		/// </summary>
		static void PrintAddiere(int x, int y)
		{
            Console.WriteLine($"{x} + {y} = {x + y}");
        }

		static int Addiere(int x, int y)
		{
			return x + y; //return: Funktion beenden und Ergebnis zurückgeben
		}

		static double Addiere(double x, double y)
		{
			return x + y;
		}

		/// <summary>
		/// Alle Parameter die bei Aufruf dieser Funktion gegeben wurden, kommen hier als Array hinein
		/// </summary>
		static int Addiere(params int[] x)
		{
			return x.Sum();
		}

		/// <summary>
		/// Über den Parameter add kann diese Funktion konfiguriert werden
		/// </summary>
		static int AddiereOderSubtrahiere(int x = 0, int y = 0, bool add = true)
		{
			return add ? x + y : x - y;
		}

		static int AddiereUndSubtrahiere(int x, int y, out int sub)
		{
			sub = x - y;
			return x + y;
		}

		static (int, int) AddiereUndSubtrahiere(int x, int y)
		{
			return (x + y, x - y);
		}

		static void Test(int x)
		{
			if (x == 0)
				return; //Beende die Funktion
            Console.WriteLine(x);
		}

		static void PrintWochentag(DayOfWeek d) //Bestimmte Werte erzwingen als Enum Funktionsparametertyp
		{
			Console.WriteLine(d);
		}
	}
}
