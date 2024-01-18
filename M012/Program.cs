using System.Diagnostics;
using System.Security.Cryptography;

namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		#region IEnumerable
		//IEnumerable
		//Sammelbegriff für alle Listen
		//Nur die Anleitung für die Erstellung einer fertigen Liste

		IEnumerable<int> zahlen = Enumerable.Range(0, 20); //Nur eine Anleitung zum Erstellen der Zahlen von 0 bis 19, hier gibt es keine konkreten Werte
		zahlen.ToList(); //5ms, hier wird die Liste erzeugt

		IEnumerable<int> vieleZahlen = Enumerable.Range(0, 1_000_000_000);
		//vieleZahlen.ToList(); //3.5s, hier wird die Liste erzeugt

		List<int> x = new List<int>();
		x.AddRange(zahlen); //Hier wird die Anleitung übergeben und einmal ausgeführt

		List<int> neueZahlen = zahlen.ToList(); //Anleitung einmal ausführen
		x.AddRange(neueZahlen); //Liste übergeben und nochmal die Anleitung ausführen
		#endregion

		#region Einfache Linq-Funktionen
		List<int> ints = [1, 2, 3, 4, 5, 6, 7, 8, 9];

		//Erweiterungsmethoden: Methoden die an beliebige Typen angehängt werden können
		//Alle Linq Methoden sind Erweiterungsmethoden die sich auf IEnumerable beziehen
		Console.WriteLine(ints.Average());
        Console.WriteLine(ints.Min());
        Console.WriteLine(ints.Max());
        Console.WriteLine(ints.Sum());

        Console.WriteLine(ints.First()); //Gibt das erste Element zurück, Exception wenn kein Element gefunden wurde
        Console.WriteLine(ints.Last()); //Gibt das letzte Element zurück, Exception wenn kein Element gefunden wurde

		Console.WriteLine(ints.FirstOrDefault()); //Gibt das erste Element zurück, Standardwert wenn kein Element gefunden wurde
		Console.WriteLine(ints.LastOrDefault()); //Gibt das letzte Element zurück, Standardwert wenn kein Element gefunden wurde
                                                 //Standardwert basiert auf dem Datentyp, int: 0, double: 0, bool: false, Person: null

        //Console.WriteLine(ints.First(e => e % 20 == 0)); //Exception
        Console.WriteLine(ints.FirstOrDefault(e => e % 20 == 0)); //0
		#endregion

		#region Linq mit Objekten
		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		//Finde alle VWs
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW);

		//Finde alle VWs die mindestens 200km/h fahren können
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW && e.MaxV >= 200); //12 Durchläufe mit 2 ifs
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW).Where(e => e.MaxV >= 200); //12 Durchläufe + 4 Durchläufe

		//Sortiere nach Marke
		fahrzeuge.OrderBy(e => e.Marke); //Hier wird nur das Feld benötigt
		fahrzeuge.OrderByDescending(e => e.Marke);

		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV);
		fahrzeuge.OrderByDescending(e => e.Marke).ThenByDescending(e => e.MaxV);

		//All & Any
		//Prüft ob Alle oder mindestens ein Element der Liste einer Bedingung entsprechen

		//Können alle Fahrzeuge mindestens 200km/h fahren?
		if (fahrzeuge.All(e => e.MaxV >= 200))
            Console.WriteLine("Alle Fahrzeuge können 200km/h fahren");

		//Haben wir einen VW in unserem Fahrzeugpark?
		if (fahrzeuge.Any(e => e.Marke == FahrzeugMarke.VW))
			Console.WriteLine("Wir haben mindestens einen VW");

		//Wieviele VWs haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.VW);

		//Wieviele VWs und BMWs haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.VW || e.Marke == FahrzeugMarke.BMW);

		//Finde alle VWs, und sortiere nach Geschwindigkeit
		fahrzeuge
			.Where(e => e.Marke == FahrzeugMarke.VW)
			.OrderByDescending(e => e.MaxV);

		//Was ist die Durchschnittsgeschwindigkeit aller VWs?
		fahrzeuge
			.Where(e => e.Marke == FahrzeugMarke.VW)
			.Average(e => e.MaxV);

		//Was ist der langsamte BMW?
		fahrzeuge
			.Where(e => e.Marke == FahrzeugMarke.BMW)
			.Min(e => e.MaxV); //Die kleinste Geschwindigkeit (int)

		fahrzeuge
			.Where(e => e.Marke == FahrzeugMarke.BMW)
			.MinBy(e => e.MaxV); //Das Fahrzeug mit der kleinsten Geschwindigkeit (Fahrzeug)

		fahrzeuge.Skip(5); //Überspringe die ersten 5 Elemente, nimm dem Rest
		fahrzeuge.Take(5); //Nimm die ersten 5 Elemente, überspringe den Rest

		//Die 3 schnellsten Fahrzeuge
		fahrzeuge
			.OrderByDescending(e => e.MaxV)
			.Take(3);

		//Beispiel: Webshop
		int page = 0;
		fahrzeuge
			.Skip(10 * page)
			.Take(10 * (page + 1));

		fahrzeuge.Chunk(10); //10 große Arrays erzeugen
		fahrzeuge.Chunk(10).SelectMany(e => e); //Liste von Listen glätten

		//Select
		//Liste transformieren

		//Zwei Anwendungsfälle
		//1. Fall (80% der Fälle): Einzelnes Feld aus der Liste entnehmen
		fahrzeuge.Select(e => e.Marke); //Liste von FahrzeugMarken
		fahrzeuge.Select(e => e.MaxV); //Liste der Geschwindigkeiten (int)

		//Welche Marken haben wir?
		fahrzeuge
			.Select(e => e.Marke)
			.Distinct();

		//2. Fall (20% der Fälle): Liste transformieren in eine komplett andere Form
		fahrzeuge.Select(e => (int) e.Marke);
		"Hallo Welt".Select(e => (int) e);
		Enumerable.Range(0, 255).Select(e => (char) e);

		//Aus einem Ordner alle Dateinamen finden
		string[] pfade = Directory.GetFiles("C:\\Windows");
		List<string> pfadeOhneEndung = [];
		foreach (string s in pfade)
			pfadeOhneEndung.Add(Path.GetFileNameWithoutExtension(s));

		//Mit Linq
		Directory.GetFiles("C:\\Windows")
			.Select(e => Path.GetFileNameWithoutExtension(e))
			.ToList();

		//Aus einer Liste von Textdateien (.txt) die Gesamtlänge herausfinden
		Directory.GetFiles("C:\\Windows") //Finde alle Pfade im Ordner
			.Where(e => Path.GetExtension(e) == ".txt") //Finde alle .txt Dateien innerhalb der Pfade
			.Select(e => File.ReadAllLines(e).Length) //Lies alle Dateien ein und nimm die Länge
			.Sum(); //Summiere die Längen auf

		//GroupBy
		fahrzeuge.GroupBy(e => e.Marke);
		//Teilt die Liste in Gruppen auf anhand eines Kriteriums
		//Jedes Element der Liste kommt in die Gruppe seines Kriteriums

		fahrzeuge.GroupBy(e => (e.Marke, e.MaxV)); //Nach mehreren Feldern gruppieren mithilfe eines Tupels

		foreach (var group in fahrzeuge.GroupBy(e => e.Marke))
		{
            Console.WriteLine($"Die Gruppe {group.Key} enthält {group.Count()} Fahrzeuge.");
        }

		var lookup = fahrzeuge.GroupBy(e => e.Marke).ToLookup(e => e.Key);

		lookup[FahrzeugMarke.VW].First(); //Gruppe entnehmen
		lookup[FahrzeugMarke.VW].First().ToList(); //Fahrzeuge entnehmen

		Dictionary<FahrzeugMarke, List<Fahrzeug>> dict = fahrzeuge.GroupBy(e => e.Marke).ToDictionary(e => e.Key, e => e.ToList());
		#endregion

		#region Erweiterungsmethoden
		int zahl = 3582;
        Console.WriteLine(zahl.Quersumme());

        Console.WriteLine(329875239.Quersumme());

		//Liste Randomizen (eigene Linq Funktion)
		fahrzeuge.Shuffle();
        #endregion
    }
}

[DebuggerDisplay("Marke: {Marke}, MaxV: {MaxV}")]
public class Fahrzeug
{
	public int MaxV { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int maxV, FahrzeugMarke marke)
	{
		MaxV = maxV;
		Marke = marke;
	}
}

public enum FahrzeugMarke { Audi, BMW, VW }