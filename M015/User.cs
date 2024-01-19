namespace M015;

internal class User
{
	static void Main(string[] args)
	{
		Component comp = new(); //Target-Typed new: Ergänzt den Typen bei new von links
		comp.ProcessStarted += Comp_ProcessStarted;
		comp.ProcessEnded += Comp_ProcessEnded;
		comp.Progress += Comp_Progress;
		comp.ProcessFailed += Comp_ProcessFailed;
		Task.Run(comp.DoWork);

		ConsoleKeyInfo info = Console.ReadKey();
		if (info.Key == ConsoleKey.Q)
			comp.Continue = false;
	}

	private static void Comp_ProcessStarted()
	{
		Console.WriteLine("Prozess gestartet");
		//Hier kann der User frei entscheiden was bei dem Event passiert
		//z.B. Log, DB, UI, API, Handybenachrichtigung, ...
	}

	private static void Comp_ProcessEnded()
	{
		Console.WriteLine("Prozess beendet");
	}

	private static void Comp_Progress(int obj)
	{
		Console.WriteLine($"Fortschritt: {obj}");
	}

	private static void Comp_ProcessFailed(string obj)
	{
		Console.WriteLine(obj);
	}
}