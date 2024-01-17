namespace M008;

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
