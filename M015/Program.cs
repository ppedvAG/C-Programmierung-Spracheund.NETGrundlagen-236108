namespace M015;

internal class Program
{
	public delegate void Vorstellungen(string name); //Definition von Delegate, kann erstellt werden (new) und kann Methodenzeiger halten

	static void Main(string[] args)
	{
		Vorstellungen v = new Vorstellungen(VorstellungDE); //Erstellung des Delegates mit Initialmethode
		v("Max"); //Ausführen des Delegates

		v += VorstellungDE; //Weitere Methode anhängen mit +=
		v("Tim");

		v += VorstellungEN;
		v += VorstellungEN;
		v += VorstellungEN;
		v += VorstellungEN;
		v("Leo");

		v -= VorstellungDE;
		v -= VorstellungDE;
		v -= VorstellungDE; //Wenn eine Methode abgenommen wird, die nicht mehr an dem Delegate angehängt ist, passiert nix
		v("Max");

		v -= VorstellungEN;
		v -= VorstellungEN;
		v -= VorstellungEN;
		v -= VorstellungEN; //Wenn die letzte Methode abgenommen wird, ist das Delegate null
							//v("Tim");

		if (v is not null)
			v("Tim");

		//Null propagation: Wenn das Objekt nicht null ist, führe den Code aus, sonst überspringe den Code danach
		v?.Invoke("Tim");

		foreach (Delegate dg in v.GetInvocationList()) //Alle Methoden des Delegates iterieren
		{
            Console.WriteLine(dg.Method.Name);
        }
	}

	static void VorstellungDE(string name)
	{
        Console.WriteLine($"Hallo mein Name ist {name}");
    }

	static void VorstellungEN(string name)
	{
		Console.WriteLine($"Hello my name is {name}");
	}
}