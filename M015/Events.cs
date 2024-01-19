namespace M015;

internal class Events
{
	//Events: Statischer Punkt, an den Methoden angehängt werden können
	//Events bestehen immer aus einem Delegate
	//Events können nicht instanziert werden

	//Zweiseitige Entwicklung: Entwicklerseite, Anwenderseite
	//Entwickler: Event definieren, Event ausführen
	//Anwender: Methode an das Event anhängen

	//Beispiel: Click-Event
	//Entwickler: event EventHandler Click; Event ausführen wenn der User mit dem Mauszeiger im Button ist, linksklickt, kein UI Element über dem Button ist, ...
	//Anwender: Definiert, was bei dem Click Event passiert

	/// <summary>
	/// EventHandler: Delegate, das ein object zurückgibt (sender von dem das Event gekommen ist) und beliebige Daten über EventArgs zurückgeben kann
	/// </summary>
	public event EventHandler TestEvent;

	public event EventHandler<TestEventArgs> ArgsEvent;

	public event EventHandler<int> IntEvent;

	static void Main(string[] args) => new Events().Start();

	public void Start()
	{
		//Anwenderseite
		TestEvent += Events_TestEvent; //Benutzerdefinierte Methode anhängen

		//Entwicklerseite
		TestEvent?.Invoke(this, EventArgs.Empty); //Event ausführen mit dem Objekt selbst als Sender, und keinen Daten
												  //Es kann sein, das der User das Event nicht anhängt -> Null Check


		//Anwenderseite
		ArgsEvent += Events_ArgsEvent;

		//Entwicklerseite
		ArgsEvent?.Invoke(this, new TestEventArgs() { Status = "ArgsEvent aufgerufen" }); //Event mit Daten


		//Anwenderseite
		IntEvent += Events_IntEvent;

		//Entwicklerseite
		IntEvent?.Invoke(this, 5);
	}

	private void Events_TestEvent(object? sender, EventArgs e)
	{
        Console.WriteLine("TestEvent aufgerufen");
    }

	private void Events_ArgsEvent(object? sender, TestEventArgs e)
	{
		Console.WriteLine(e.Status);
	}

	private void Events_IntEvent(object? sender, int e)
	{
		Console.WriteLine(e);
	}
}

public class TestEventArgs : EventArgs
{
	public string Status { get; set; }
}
