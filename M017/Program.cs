namespace M017;

internal class Program
{
	static async void Main(string[] args)
	{
		//Async/Await
		//Parallele Programmierung

		//Wenn eine Async Methode gestartet wird, wird diese im Hintergrund gestartet
		//(nur wenn die Methode einen Task oder Task<T> zurückgibt)

		//3 Schritte Plan:
		//Aufgabe starten (async Methode aufrufen) und diesen Rückgabewert in einer Variable speichern
		//(optional) Zwischenschritte (UI Updates, Parallele Arbeiten, ...)
		//Auf das Ergebnis der Aufgabe warten

		//Asynchrone Klassen
		//StreamWriter und StreamReader
		//HttpClient
		//SqlConnection, SqlCommand
		//EF

		//Wenn eine Methode mit async endet, ist diese generell eine Aufgabe
		using StreamWriter sw = new StreamWriter("File.txt");
		Task t = sw.WriteLineAsync("Hallo"); //Dieses WriteLine würde jetzt im Hintergrund laufen
        Console.WriteLine("Starte Schreibprozess");
		await t; //Warte auf das Ende der Aufgabe t
    }
}
