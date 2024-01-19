namespace M015;

internal class ActionFunc
{
	static void Main(string[] args)
	{
		//Action, Func: Vordefinierte Delegates, die an verschiedenen Stellen in der Sprache vorkommen
		//Werden als Parameter verwendet für Methoden und Konstruktoren, um Code vom Benutzer übernehmen zu können
		//Können alles was in dem vorherigen Teil besprochen wurde


		//Action: Delegate, welches einen Methodenzeiger halten kann, der void zurückgibt und bis zu 16 Parameter hat
		//Hier werden die Parameter über die Generics angegeben
		Action<int, int> action = Addiere;
		action(3, 4);
		action?.Invoke(3, 4);

		//Über den Action Parameter kann der Benutzer der Methode jetzt entscheiden was diese tut
		DoAction(4, 8, Addiere);
		DoAction(9, 4, Subtrahiere);
		DoAction(4, 7, action);

		//Praktische Anwendungsfälle
		List<int> ints = Enumerable.Range(0, 20).ToList();
		ints.ForEach(PrintInt); //Führt die gegebene Methode für jedes Element der Liste aus
		ints.ForEach(Console.WriteLine); //Es gibt einen CW Overload der einen int als Parameter nimmt


		//Func: Delegate, welches einen Methodenzeiger halten kann, der einen bestimmten Typ zurückgibt und bis zu 16 Parameter hat
		//WICHTIG: Das letzte Generic bestimmt den Rückgabetyp
		Func<int, int, double> func = Multipliziere;
		double x = func(4, 5); //Hier bei der Func kommt ein Ergebnis heraus
		//double x2 = func?.Invoke(5, 9); //Wenn die func null ist, kommt hier null als Ergebnis heraus (double kann nicht null sein)
		double? x2 = func?.Invoke(5, 9);

		//Über den Func Parameter kann der Benutzer der Methode jetzt entscheiden was diese tut
		DoFunc(5, 8, Multipliziere);
		DoFunc(5, 2, Dividiere);
		DoFunc(6, 3, func);

		//Praktische Anwendungsfälle
		//Linq
		ints.Where(TeilbarDurch2); //Hier kann jetzt wieder ein Methodenzeiger

		//Anonyme Methoden: Methoden, für die keine separate Methode angelegt wird
		func += delegate (int x, int y) { return x + y; }; //Anonyme Methode

		func += (int x, int y) => { return x + y; }; //Kürzere Form

		func += (x, y) => { return x - y; };

		func += (x, y) => (double) x / y; //Kürzeste, häufigste Form

		//Anonyme Funktion verwenden
		DoAction(5, 9, (x, y) => Console.WriteLine(x % y)); //Modulo in der Konsole ausgeben
		DoFunc(5, 9, (x, y) => (double) x % y);
		DoFunc(5, 9, (x, y) =>
		{
			double rest = (double) x % y;
			Console.WriteLine(rest);
			return rest;
		});

		Where(ints, e => e % 2 == 0);
	}

	#region Action
	static void Addiere(int x, int y) => Console.WriteLine($"{x} + {y} = {x + y}");

	static void Subtrahiere(int x, int y) => Console.WriteLine($"{x} - {y} = {x - y}");

	static void DoAction(int x, int y, Action<int, int> action) => action?.Invoke(x, y);

	static void PrintInt(int x) => Console.WriteLine($"Die derzeitige Zahl ist {x}");
	#endregion

	#region Func
	static double Multipliziere(int x, int y) => x * y;

	static double Dividiere(int x, int y) => (double) x / y;

	static double DoFunc(int x, int y, Func<int, int, double> func) => func(x, y);

	static bool TeilbarDurch2(int x) => x % 2 == 0;
	#endregion

	//Where per Hand
	static IEnumerable<T> Where<T>(IEnumerable<T> x, Func<T, bool> predicate)
	{
		List<T> list = new List<T>();
		foreach (T item in x)
			if (predicate(item)) //Hier einfach das Delegate ausführen, und den bool in einer if verwenden
				list.Add(item);
		return list;
	}
}