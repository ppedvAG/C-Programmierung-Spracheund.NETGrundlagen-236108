using System.Net.Mime;

namespace M009;

internal class Program
{
	static void Main(string[] args)
	{
		#region Polymorphismus
		//Polymorphimus
		//Typkompatibilität
		//-> Welche Typen sind mit welchen anderen Typen kompatibel?

		//Ein Objekt einer Unterklasse ist immer mit ihrer direkten Oberklasse kompatibel
		//Ein Objekt einer Unterklasse ist oftmals mit Klassen weiter oben in der Hierarchie kompatibel

		//Quiz
		//int und double
		int x = (int) 435.8325;
		double d = 4387294;

		//int und bool (nicht kompatibel)
		//int b = (int) true;
		//bool b2 = (bool) 1;

		//char und int
		char c = (char) 70;
		int ci = 'A';

		//Hund und Tier
		Tier t = new Hund(3, 4);
		//Hund h = (Hund) new Tier(3, 4); //InvalidCastException

		//Lebewesen und Katze
		Lebewesen l = new Katze(3, 4);
		//Katze k = (Katze) new Lebewesen(3); //InvalidCastException
		Katze k = (Katze) l; //Kann funktionieren, wenn in l eine Katze oder eine Unterklasse von Katze enthalten ist

		//object und Mensch
		object o = new Mensch(3, "Max");
		o = 123;
		o = "Hallo";
		o = false;

		//Mensch mensch = (Mensch) o; //Möglich, aber unwahrscheinlich
		//Alle Typen sind mit Objekt kompatibel, weil Object die Oberklasse von allen Klassen und Structs in C# ist
		#endregion

		#region Typen
		//Polymorphismus trifft überall zu, wo Typen zu finden sind (Parameter, Variablen, Rückgabetypen, ...)

		//Jedes Objekt hat einen Typen
		//Über .GetType() kann dieser Typ abgefragt werden
		Type oType = o.GetType(); //Entnimmt den Typen aus dem Objekt hinter o
        Console.WriteLine(oType.Name); //Boolean

		//Typ erzeugen über typeof
		//Typeof funktioniert nur bei Klassennamen
		Type mt = typeof(Mensch);
        Console.WriteLine(mt.Name); //Mensch
									//typeof(o); //Nicht möglich
		#endregion

		#region Typvergleiche
		//genauer Typvergleich
		if (o.GetType() == typeof(object))
		{
			//false
		}

		if (o.GetType() == typeof(bool))
		{
			//true
		}

		//Vererbungshierarchietypvergleich
		if (o is bool)
		{
			//true
		}

		if (o is object)
		{
			//true
		}
		#endregion

		//Anwendungsbeispiele
		Lebewesen[] zoo = new Lebewesen[4];
		zoo[0] = new Hund(3, 4);
		zoo[1] = new Katze(3, 4);
		zoo[2] = new Mensch(33, "Max");
		zoo[3] = new Hund(3, 4);

		foreach (Lebewesen lw in zoo) //Hier steht nicht fest, was genau für ein Typ hinter lw steht
		{
			if (lw.GetType() == typeof(Mensch))
			{
				Mensch mensch = (Mensch) lw;
				mensch.Sprechen("Hallo");
			}

			if (lw is Katze)
			{
				Katze katze = (Katze) lw;
				//katze.KatzeMethode();
			}

			if (lw is Hund)
			{
				Hund hund = (Hund) lw;
				//hund.HundMethode();
			}

			lw.Bewegen(10); //Bewegen muss in jeder Klasse existieren
		}
	}

	/// <summary>
	/// Hier kann jedes beliebige Objekt übergeben werden
	/// </summary>
	/// <param name="o"></param>
	public static void Test(object o)
	{
        Console.WriteLine(o.GetType());
    }

	public static object Test()
	{
		return new object();
		return 123;
		return false;
		//return new Lebewesen(3);
	}
}

#region	Klassen
/// <summary>
/// abstract: Definiert, das eine Klasse nur als Strukturklasse dienen soll
/// Von dieser Klasse kann danach kein Objekt mehr erstellt werden
/// Innerhalb dieser Klasse können Methoden ohne Body definiert werden, die in den Unterklassen implementiert werden müssen
/// </summary>
public abstract class Lebewesen
{
	public int Alter { get; set; } //Alter wird an alle Unterklassen vererbt

	public Lebewesen(int alter) //Konstruktor wird in den Unterklassen erzwungen
	{
		Alter = alter;
	}

	/// <summary>
	/// Diese Methode hat keinen Body, weil sie Abstrakt ist
	/// </summary>
	public abstract void Bewegen(int distanz);

	/// <summary>
	/// virtual: Ermöglicht, das diese Methode in Unterklasse überschrieben werden kann (Unterklassen dürfen eine spezifische Implementation haben)
	/// </summary>
	public virtual void BewegenVirtual(int distanz)
	{
		Console.WriteLine($"Lebewesen bewegt sich um {distanz}m.");
	}
}

/// <summary>
/// Mit : <Klasse> eine Vererbung herstellen
/// "Mensch ist ein Lebewesen"
/// Mensch erbt Alter und Bewegen von Lebewesen
/// </summary>
public class Mensch : Lebewesen
{
	public string Name { get; set; } //Hier können für den Mensch spezifische Member festgelegt werden

	public void Sprechen(string text)
	{
		Console.WriteLine($"{Name} sagt: {text}");
	}

	//Strg + . -> Generate Constructor
	//Neue Felder können hier einfach hinzugefügt werden
	public Mensch(int alter, string name) : base(alter) //Verkettung mit base statt this
	{
		Name = name;
	}

	/// <summary>
	/// Mithilfe des override Keywords können Methoden der Oberklasse überschrieben werden
	/// override eingeben -> Methode auswählen
	/// </summary>
	public override void BewegenVirtual(int distanz)
	{
		base.BewegenVirtual(distanz); //Mit base. können Member der Klasse darüber angegriffen werden
		Console.WriteLine($"{Name} bewegt sich um {distanz}m.");
	}

	/// <summary>
	/// Hier muss diese Methode überschrieben werden
	/// </summary>
	/// <param name="distanz"></param>
	public override void Bewegen(int distanz)
	{
        Console.WriteLine($"Mensch bewegt sich um {distanz}m.");
    }
}

/// <summary>
/// Wenn diese Klasse abstrakt ist, gibt sie Abstrakte Methoden von oben einfach weiter
/// </summary>
public abstract class Tier : Lebewesen
{
	public int AnzahlBeine { get; set; }

	public Tier(int alter, int anzBeine) : base(alter)
	{
		AnzahlBeine = anzBeine;
	}
}

public sealed class Hund : Tier
{
	public Hund(int alter, int anzBeine) : base(alter, anzBeine)
	{
	}

	public override void Bewegen(int distanz)
	{
		Console.WriteLine($"Hund bewegt sich um {distanz}m.");
	}
}

public class Katze : Tier
{
	public Katze(int alter, int anzBeine) : base(alter, anzBeine)
	{
	}

	public override void Bewegen(int distanz)
	{
		Console.WriteLine($"Katze bewegt sich um {distanz}m.");
	}
}
#endregion