namespace M007;

/// <summary>
/// Klasse: Bauplan für Objekte
/// In einer Klasse wird der Aufbau der fertigen Objekte definiert mithilfe von Feldern, Eigenschaften, Methoden, ...
/// 
/// Objekt: Komplexer Datentyp
/// Wird aus anderen komplexen Datentypen (anderen Objekten) oder einfachen Datentypen (int, string, double, ...) aufgebaut
/// Aus einer Klasse werden Objekte erstellt
/// Aus einer Klasse können beliebig viele Objekte erstellt werden
/// </summary>
public class Person
{
	//Eigenschaften: Körpergröße, Vorname, Nachname, Alter, Augenfarbe
	//Funktionen: Sprechen, Bewegen

	#region Variable
	/// <summary>
	/// Der Benutzer soll von außen diese Variable nicht direkt verändern können
	/// private: Dieser Member kann nur innerhalb der Klasse angegriffen werden, nicht außerhalb
	/// </summary>
	private string vorname;

	/// <summary>
	/// Get-Methode: Hat immer den Rückgabetyp des Felds dahinter, und gibt nur den Wert zurück
	/// </summary>
	public string GetVorname()
	{
		return vorname;
	}

	/// <summary>
	/// Set-Methode: Hat immer den Rückgabetyp void, und schreibt den neuen Wert den der Benutzer über den Parameter übergibt, in das Feld hinein
	/// Hier können Überprüfungen durchgeführt werden
	/// </summary>
	/// <param name="vorname"></param>
	public void SetVorname(string vorname)
	{
		if (vorname.All(char.IsLetter) && vorname.Length >= 3 && vorname.Length <= 15)
			//this: Greife nach oben (aus der Funktion hinaus)
			//Wird hauptsächlich verwendet, wenn ein Parameter und ein Feld gleich heißen
			this.vorname = vorname;
		else
            Console.WriteLine("Der Vorname darf nur aus Buchstaben bestehen und muss zwischen 3 und 15 Zeichen lang sein!");
    }
	#endregion

	#region Property/Eigenschaft
	private string nachname;

	/// <summary>
	/// Property:
	/// Vereinfachung von Get-/Set-Methoden mit Variable
	/// Haben Get- und Set Accessor die die Get- und Set Methoden repräsentieren
	/// Können normal beschrieben werden wie eine Variable
	/// </summary>
	public string Nachname
	{
		get
		{
			return nachname;
		}
		set
		{
			//value: Stellt den Parameter von der Set-Methode dar
			if (value.All(char.IsLetter) && value.Length >= 3 && value.Length <= 15)
				nachname = value;
			else
				Console.WriteLine("Der Nachname darf nur aus Buchstaben bestehen und muss zwischen 3 und 15 Zeichen lang sein!");
		}
	}

	//Verschiedene Arten der Properties:
	//Full Property (darüber)
	//Auto Property
	//Get-Only Property

	/// <summary>
	/// Auto Property:
	/// Macht nicht anderes als eine normale Variable
	/// Besonderheit: Die Accessoren können mit Access Modifiern versehen werden (private)
	/// </summary>
	public int Alter { get; set; }

	//Im Hintergrund werden die folgenden zwei Methoden erzeugt:
	//public int get_Alter() => alter;
	//public void set_Alter(int alter) => this.alter = alter;

	/// <summary>
	/// Dieses Property kann nun nicht von außen gesetzt werden, aber ausgelesen werden
	/// </summary>
	public int Gehalt { get; private set; }


	/// <summary>
	/// Get-Only Property: Hat keinen Setter, sondern nur einen Getter
	/// </summary>
	public string VollerName
	{
		get
		{
			return $"{vorname} {nachname}";
		}
	}

	public string VollerName2
	{
		get => $"{vorname} {nachname}"; //Expression Body: Ermöglicht, Strukturen die einzeilig sind, ohne Klammern zu definieren, und stattdessen mit einem Pfeil
	}

	public string VollerName3 => $"{vorname} {nachname}";
	#endregion

	#region Funktionen
	/// <summary>
	/// Eine Funktion in der Klasse wird am Ende auf dem fertigen Objekt verwendbar sein
	/// WICHTIG: Hier nicht static verwenden
	/// </summary>
	public void Sprechen(string text)
	{
		Console.WriteLine($"{VollerName} sagt: {text}");
	}
    #endregion

    #region Konstruktor
    public Person()
    {
        Console.WriteLine("Person wurde erstellt");
		PersonenZaehler++;
    }

	/// <summary>
	/// Konstruktor:
	/// Initialcode, der bei Erstellung des Objekts (new) ausgeführt wird
	/// Hier werden Standardwerte verlangt, die bei dem Objekt eingesetzt werden
	/// Standardmäßig wird ein leerer Konstruktor (public Person() {}) erstellt, dieser wird überschrieben wenn ein eigener Konstruktor erstellt wird
	/// </summary>
    public Person(string vorname, string nachname) : this() //Hier verketten mit dem leeren Konstruktor
    {
		//SetVorname(vorname);
		this.vorname = vorname;
		this.nachname = nachname;
    }

	/// <summary>
	/// Konstruktoren verketten:
	/// Mit : this nach einer Parameterliste können Konstruktoren miteinander verkettet werden
	/// Dieser Konstruktor ruft den verketteten Konstruktor auf, wenn er verwendet wird
	/// </summary>
	public Person(string vorname, string nachname, int alter) : this(vorname, nachname)
	{
		Alter = alter;
	}
	#endregion

	/// <summary>
	/// Destruktor: Code der beim einsammeln des Garbage Collectors ausgeführt wird
	/// z.B.: DB schließen, ...
	/// </summary>
	~Person()
	{
        Console.WriteLine("Person wurde vom GC eingesammelt");
    }

	public static int PersonenZaehler { get; set; }

	public static void PrintZaehler()
	{
        Console.WriteLine($"Es wurden {PersonenZaehler} Personen erstellt");
    }
}