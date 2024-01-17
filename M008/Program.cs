namespace M008;

public class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch(22, "Max");
		m.Bewegen(10); //Mensch hat Bewegen geerbt
        Console.WriteLine(m.Alter); //Mensch hat Alter geerbt

		Katze k = new Katze(3, 4);
		k.Bewegen(10); //Bewegen wurde durch Tier zu Katze weiter gereicht

		//Alle Klassen in C# erben von Object, und Object vererbt die folgenden 4 Methoden:
		k.Equals(m);
		k.GetType();
		k.GetHashCode();
		k.ToString();

		//Durch die Virtual-Override Mechanik wird hier jetzt die Implementation von Mensch verwendet
		m.BewegenVirtual(10);
		k.BewegenVirtual(10); //Nachdem weder Katze noch Tier eine Implemenation haben, wird hier die Methode aus Lebewesen verwendet
	}
}

/// <summary>
/// Das ist die Oberklasse aller Lebewesen
///      Lebewesen
///    Tier | Mensch
/// Hund | Katze
/// </summary>
public class Lebewesen
{
	public int Alter { get; set; } //Alter wird an alle Unterklassen vererbt

	public Lebewesen(int alter) //Konstruktor wird in den Unterklassen erzwungen
	{
		Alter = alter;
	}

	public void Bewegen(int distanz) //Bewegen wird auch nach unten vererbt
	{
        Console.WriteLine($"Lebewesen bewegt sich um {distanz}m.");
    }

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
}

public class Tier : Lebewesen
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
}

public class Katze : Tier
{
	public Katze(int alter, int anzBeine) : base(alter, anzBeine)
	{
	}
}