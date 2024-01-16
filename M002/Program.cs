namespace M002
{
	/// <summary>
	/// Das ist die Program Klasse
	/// </summary>
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Variablen
			//Aufbau:
			//Datentyp Name = Wert;
			int zahl = 5;
			Console.WriteLine(zahl); //cw + Tab

			//Datentypen
			//Ganze Zahlen:
			//byte, short, int, long
			short kurzeZahl;

			//Kommazahlen:
			//float, double, decimal
			double d = 239847.321579321;
			float f = 23598125.3291587193F; //Kommazahlen sind standardmäßig doubles, mit dem F Suffix in einen float konvertieren
			decimal m = 357923.3215791275M; //Kommazahlen sind standardmäßig doubles, mit dem M Suffix in ein decimal konvertieren

			//Texttypen:
			//char, string
			string str = "Das ist ein Text"; //Text unter doppelte Hochkomma setzen
			char c = 'A'; //Char unter einzelne Hochkomma setzen

			//Boolean
			bool bt = true;
			bool bf = false;
			#endregion

			#region Strings
			//Strings verbinden
			//Mit +
			string kombination = "Die Zahl ist " + zahl + ", der Text ist " + str + ", der Boolean ist " + bt;
            Console.WriteLine(kombination);

			//String Interpolation ($-String): Ermöglicht, Code in einen String einzubauen
			string interpolation = $"Die Zahl ist {zahl}, der Text ist {str}, der Boolean ist {bt}";
            Console.WriteLine(interpolation);

			//Escape-Sequenzen: Untippbare Zeichen in einen String einbaue
			//https://docs.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170
			string umbruch = "Das ist\n ein Text"; //\n: Zeilenumbruch
            Console.WriteLine(umbruch);

			string weitere = "\t \" \' \\";

			//Verbatim String (@-String): Nimmt den String 1:1 wie er im Code steht
			string verbatim = @"Das ist
ein Text\n";
            Console.WriteLine(verbatim);

			string pfad = @"C:\Program Files\dotnet\shared\Microsoft.NETCore.App\7.0.5\System.Runtime.dll";  //Escape-Sequenzen werden nicht interpretiert
			#endregion

			#region Eingabe
			//Konsoleneingabe mit Console.ReadLine(): Liest Text bis Enter gedrückt wird
			string eingabe = Console.ReadLine(); //Eingabe vom User steht jetzt in der Variable
			Console.WriteLine($"Du hast {eingabe} eingegeben");

			ConsoleKeyInfo info = Console.ReadKey(); //Lies ein einziges Zeichen vom Benutzer ein (ohne Enter)
			Console.WriteLine(info.Key);
			#endregion

			#region Konvertierungen
			//string -> anderer Typ: Parse
			//anderer Typ -> string: ToString()
			//anderer Typ -> anderer Typ: Typecast
			string parse = "358729";
			//Console.WriteLine(parse * 2); //Nicht möglich, weil Typen inkompatibel sind
			int konvertiert = int.Parse(parse); //Ermöglicht, Strings zu einem bestimmten Typen zu konvertieren
            Console.WriteLine(konvertiert * 2);

			double kd = double.Parse(parse); //String zu einer Kommazahl konvertieren
            Console.WriteLine(kd);

            //Zu String konvertieren
            Console.WriteLine("Die Zahl ist " + zahl); //Hier wird implizit konvertiert
            Console.WriteLine(zahl.ToString()); //Explizite Konvertierung erzwingen

			//Typen ineinander Konvertieren
			//int z = 32523.9587315; //Nicht implizit kompatibel -> Konvertierung erzwingen
			int z3 = (int) 32523.9587315; //Konvertierung erzwingen über einen Cast, Typecast, Casting
            Console.WriteLine(z3); //Kommastellen werden abgeschnitten
			double d2 = z3; //Hier kein Cast erforderlich, weil alle ints immer in double passen

			long l = 387593217593175981;
			int i = (int) l; //Hier wird int.MaxValue so oft subtrahiert, bis die resultierende Zahl in int passt
            Console.WriteLine(i);
            Console.WriteLine(int.MaxValue); //2^31 - 1, 2147483647
			#endregion

			#region Arithmetik
			int z1 = 4;
			int z2 = 7;

            Console.WriteLine(z1 + z2); //Originale Werte werden nicht verändert, die Summe wird gebildet und ausgegeben
			z1 += z2; //Addiere z2 auf z1, z1 wird hier verändert

			z1 -= z2;
			z1 *= z2;
			z1 /= z2;
			z1 %= z2; //Schreibe den Rest der Division in die erste Zahl hinein

			z1++;
			z2--;

			Math.Ceiling(4.5); //Aufrunden
			Math.Floor(4.5); //Abrunden
			Math.Round(4.5); //Rundet auf oder ab, .5 wird zur nächsten geraden Zahl gerundet -> 4
			Math.Round(5.5); //-> 6
			Math.Round(5.5, 2); //Anzahl Kommastellen angeben

            Console.WriteLine(8 / 5); //1, weil hier eine Int-Division durchgeführt wurde
            Console.WriteLine(8.0 / 5); //1.6, weil eine der Zahlen eine Kommazahl ist
            Console.WriteLine(8 / 5.0); //1.6, weil eine der Zahlen eine Kommazahl ist
            Console.WriteLine(8f / 5); //1.6, weil eine der Zahlen eine Kommazahl ist
            Console.WriteLine(8d / 5); //1.6, weil eine der Zahlen eine Kommazahl ist
            Console.WriteLine((double) z1 / z2); //Bei Variablen eine Kommadivision über einen Cast erzwingen
            #endregion
        }
	}
}