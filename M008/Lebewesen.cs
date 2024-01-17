namespace M008;

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
