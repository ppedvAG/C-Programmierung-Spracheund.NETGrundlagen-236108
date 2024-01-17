namespace M007;

internal class Program
{
	public static void Main(string[] args)
	{
		#region GC
		for (int i = 0; i < 5; i++)
		{
			Person p = new Person();
		}

		//Hier am Ende des Programms wird nicht auf die Finalizer gewartet
		GC.Collect();
		GC.WaitForPendingFinalizers();
		#endregion

		#region	Static
		//Static: Global, kann von überall aufgerufen
		//WICHTIG: Hängt nicht mit Objekten zusammen
		Console.WriteLine(); //WriteLine ist Static und spricht die Konsole einfach an
							 //Console c = new Console(); //Nicht möglich

		//Person.Sprechen("Hallo"); //Hier ist nicht klar welche Person gemeint ist -> hier wird ein Objekt benötigt
		Person p2 = new Person();
		p2.Sprechen("Hallo"); //Sprechen ist nicht Static und benötigt dafür ein Objekt

		//Personenzähler
		Person.PersonenZaehler++;
		Person.PrintZaehler();
		#endregion

		#region Datumswerte
		//Arbeiten mit Datumswerten
		//DateTime und TimeSpan
		DateTime jetzt = DateTime.Now;
		Console.WriteLine(jetzt.Hour);
		Console.WriteLine(jetzt.Minute);
		Console.WriteLine(jetzt.Second);

		//Wie alt bin ich in Tagen?
		DateTime gebDat = new DateTime(1998, 07, 18);
		Console.WriteLine(jetzt - gebDat); //Ergebnis TimeSpan

		TimeSpan alterInTagen = jetzt - gebDat;
		Console.WriteLine(new DateTime(alterInTagen.Ticks));

		Console.WriteLine(DateTime.Now - TimeSpan.FromDays(10));
		#endregion

		#region Werte- und Referenztypen
		//class und struct

		//Referenztyp
		//class
		//Wenn eine Variable erstellt wird, liegt in dieser Variable nur ein Zeiger auf das unterliegende Objekt
		//Wenn zwei Objekte von einem Referenztyp verglichen werden, werden die Speicheradressen verglichen
		Person p3 = new Person(); //Hier wird das Objekt erstellt und ein Zeiger auf das Objekt gelegt
		Person p4 = p3; //Hier wird ein Zeiger auf das Objekt unter p3 gelegt
		p3.SetVorname("Max"); //p3 und p4 werden verändert, weil unter beiden Variablen das selbe Objekt liegt

		Test(p3);

		if (p3 == p4)
		{
			//true
		}

        Console.WriteLine(p3.GetHashCode());
        Console.WriteLine(p4.GetHashCode());

		//Wertetyp
		//struct
		//Wenn eine Variable erstellt wird, liegt in dieser Variable der Wert
		//Wenn zwei Objekte von einem Wertetyp verglichen werden, werden die Inhalte verglichen
		int x = 5; //Hier wird der Wert 5 im RAM abgelegt und in x gespeichert
		int y = x; //Hier wird der Wert 5 in y kopiert
		x = 10; //Hier bleibt y unverändert

		Test(x);
		Test(ref x);

		if (x == 10)
		{
			//true
		}
		#endregion

		#region Null
		//Eine Variable von einem Referenztypen (class) ist null, wenn kein Wert enthalten ist
		Person p5 = new Person(); //Zeiger auf Person Objekt
		Person p6 = p5;
		p5 = null; //Löscht den Zeiger auf das Objekt, Objekt ist aber weiterhin existent

        Console.WriteLine(p6.GetHashCode()); //Möglich, obwohl p5 = null
        //Console.WriteLine(p5.GetHashCode()); //Absturz

		if (p5 != null)
		{
			Console.WriteLine(p5.GetHashCode());
		}

		if (p5 is not null)
		{
			Console.WriteLine(p5.GetHashCode());
		}

		p5?.GetHashCode(); //Schneller Null-Check: Führe den Code nach dem ? nur aus, wenn das Objekt davor nicht null ist

		//Structs dürfen nicht null sein
		//int z = null;
		//double d = null;
		//DayOfWeek dw = null;

		//Mit einem ? am Ende des Typens den Typen Nullable machen
		int? z = null;
		double? d = null;
		DayOfWeek? dw = null;
		#endregion
	}

	/// <summary>
	/// Der Parameter p stellt eine Referenz dar
	/// </summary>
	public static void Test(Person p)
	{
		p.Nachname = "Mustermann";
	}

	/// <summary>
	/// Der Parameter stellt eine Kopie des originalen Werts dar
	/// </summary>
	public static void Test(int x)
	{
		x = 50; //Funktioniert nicht
	}

	/// <summary>
	/// Der Parameter stellt eine Referenz dar
	/// </summary>
	public static void Test(ref int x)
	{
		x = 50; //Funktioniert
	}
}
