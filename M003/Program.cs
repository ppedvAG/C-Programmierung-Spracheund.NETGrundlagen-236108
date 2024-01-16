using System.Runtime.CompilerServices;

namespace M003
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Arrays
			//Array: Variable die mehrere Werte halten kann
			int[] zahlen;
			zahlen = new int[5]; //Neues Array erstellen mit Länge 5 (5 Plätze), Index 0-4
			zahlen[2] = 10; //Bestimmte Stelle angreifen
			Console.WriteLine(zahlen[2]); //Mittleres Element (Indizes: 0, 1, 2, 3, 4)

			//Direkte Initialisierung
			int[] zahlen2 = new int[] { 2, 3, 44, 55 }; //Länge 4, Index 0-3
			int[] zahlen3 = new[] { 2, 3, 44, 55 }; //Länge 4, Index 0-3
			int[] zahlen4 = { 2, 3, 44, 55 }; //Länge 4, Index 0-3
			int[] zahlen5 = [2, 3, 44, 55]; //Neu mit C# 12

			Console.WriteLine(zahlen.Length); //Anzahl Plätze (5)
			Console.WriteLine(zahlen.Contains(10)); //Enthält zahlen 10? -> true

			//Mehrdimensionale Arrays
			int[,] zweiDArray = new int[3, 3]; //3x3 Matrix
			zweiDArray[0, 2] = 5; //Oben rechts

			Console.WriteLine(zweiDArray.Rank); //Anzahl der Dimensionen (2)
			Console.WriteLine(zweiDArray.GetLength(0)); //Länge der ersten Dimension (3)
			Console.WriteLine(zweiDArray.GetLength(1)); //Länge der zweiten Dimension (3)
			#endregion

			#region Bedingungen
			int z1 = 4;
			int z2 = 7;

			if (z1 == 4 && z2 == 7)
			{
                Console.WriteLine(z1 & z2);
                //100 & 111
                //100
                //111
                //->100

                Console.WriteLine(z1 | z2);
                //100 | 111
                //100
                //111
                //->111
            }

			if (z1 == 4 ^ z2 == 7) //XOR
			{
				//Nur true, wenn die beiden Bedingungen unterschiedlich sind
				//Immer false, wenn beide Bedingungen true oder false sind
			}

			if (!(z1 == 4)) //Negiert eine Bedingung
			{

			}

			if (!zahlen.Contains(5)) //NotContains existiert nicht -> Contains invertieren mit !
			{

			}

			//Einzeilige ifs/elses können ohne Klammern geschrieben
			if (!zahlen.Contains(5))
                Console.WriteLine("Zahlen enthält nicht 5");
			else
				Console.WriteLine("Zahlen enthält 5");

			//if (!zahlen.Contains(5))
			//	Console.WriteLine("Zahlen enthält nicht 5");
			//else if (...)
			//{

			//}

			//Ternary Operator (?-Operator): If/Else Konstrukte vereinfachen
			if (!zahlen.Contains(5))
				Console.WriteLine("Zahlen enthält nicht 5");
			else
				Console.WriteLine("Zahlen enthält 5");

            Console.WriteLine(zahlen.Contains(5) ? "Zahlen enthält 5" : "Zahlen enthält nicht 5"); //Nach ? kommt der if Teil, nach : kommt der else Teil
			string str = zahlen.Contains(5) ? "Zahlen enthält 5" : "Zahlen enthält nicht 5";
			//zahlen.Contains(5) ? Console.WriteLine("Zahlen enthält 5") : Console.WriteLine("Zahlen enthält nicht 5"); //Nicht möglich
            #endregion
        }
	}
}
