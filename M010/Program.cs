namespace M010;

internal class Program
{
	static void Main(string[] args)
	{
		Smartphone s = new Smartphone();
		Aufladen(s);

		Elektroauto e = new Elektroauto();
		Aufladen(e);

		//Hier kann auch eine Variable vom Typ IAufladbar definiert werden
		//Diese kann Smartphone und EAuto halten
		IAufladbar a = s;
		a = e;

		//new IAufladbar(); //Kann nicht erstellt werden

		//Feststellen, ob eine Klasse ein bestimmtes Interface hat
		if (s is IAufladbar)
		{

		}

		//Genauer Typvergleich funktioniert nicht, weil ein Objekt nie genau IAufladbar sein kann
		if (s.GetType() == typeof(IAufladbar))
		{

		}

		//IEnumerable
		//Basis für alle Listentypen in C#
		IEnumerable<int> x = [1, 2, 3];
		IEnumerable<int> y = new List<int>();
		IEnumerable<int> z = new Queue<int>();
		IEnumerable<int> b = new Stack<int>();
		IEnumerable<char> c = "ABC";

		//Ermöglicht, alle möglichen Collections mit Linq zu verarbeiten
	}

	/// <summary>
	/// Hier soll als Parameter nur ein Objekt erlaubt sein, welches aufladbar ist
	/// -> Hier kann das Interface verwendet werden
	/// 
	/// Hier kann jetzt Smartphone und Elektroauto übergeben werden
	/// </summary>
	static void Aufladen(IAufladbar a)
	{
		a.Aufladen(23);
	}
}

public class Elektrogeraet { }

public class Monitor : Elektrogeraet { }

public class Mixer : Elektrogeraet { }

public class Smartphone : Elektrogeraet, IAufladbar
{
	public int Akkustand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public bool WirdGeladen { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public string Akkuzustand()
	{
		throw new NotImplementedException();
	}

	public void Aufladen(int Akkustand)
	{
		throw new NotImplementedException();
	}

	public void DauerBisVoll()
	{
		throw new NotImplementedException();
	}
}

public class Elektroauto : IAufladbar
{
	public int Akkustand { get; set; }

	public bool WirdGeladen { get; set; }

	public string Akkuzustand()
	{
		return $"Der Akkustand beträgt {Akkustand}%. Der Akku wird {(!WirdGeladen ? "nicht " : " ")}geladen.";
    }

	public void Aufladen(int Akkustand)
	{
		this.Akkustand += Akkustand;
		if (this.Akkustand > 100)
			this.Akkustand = 100;
	}

	public void DauerBisVoll()
	{
        Console.WriteLine("...");
    }
}

//Jetzt sollen Smartphone und ElektroAuto die Möglichkeit bekommen aufgeladen zu werden

/// <summary>
/// Interface: Gibt eine Struktur vor, wie eine Abstrake Klasse
/// Aber: eine Klasse kann mehrere Interfaces haben im Gegensatz zur Klasse
/// Gibt die Möglichkeit, Polymorphismus zwischen mehreren unabhängigen Klassen durchzuführen
/// </summary>
public interface IAufladbar
{
	int Akkustand { get; set; }

	bool WirdGeladen { get; set; }

	void Aufladen(int Akkustand);

	string Akkuzustand();

	void DauerBisVoll();

	public void Test()
	{
		//Bad Practice
	}
}