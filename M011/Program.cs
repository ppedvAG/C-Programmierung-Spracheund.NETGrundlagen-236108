namespace M011;

internal class Program
{
	static void Main(string[] args)
	{
		//Generische Datentypen
		//Ersetzen alle Vorkommnisse des T mit dem in spitzen Klammern gegebenen Typen

		//List: Funktioniert wie Array, ist aber unbegrenzt groß
		List<int> list = new List<int>(); //Alle Vorkommnisse von T werden durch int ersetzt
		list.Add(1); //T wird durch int ersetzt
		list.Add(2); //T wird durch int ersetzt
		list.Add(3); //T wird durch int ersetzt

		Console.WriteLine(list[0]); //Index genau wie bei Array

		foreach (int i in list) //Iteration genau wie bei Array
		{
            Console.WriteLine(i);
        }

		List<string> strings = new List<string>(); //Diese Liste ist jetzt String-typisiert
		strings.Add("1");
		strings.Add("2");
		strings.Add("3");


		//Dictionary
		//Liste von Schlüssel-Wert Paaren/Zuordnungen
		//Schlüssel müssen eindeutig sein
		Dictionary<string, int> einwohnerzahlen = new Dictionary<string, int>();
		einwohnerzahlen.Add("Wien", 2_000_000);
		einwohnerzahlen.Add("Berlin", 3_650_000);
		einwohnerzahlen.Add("Paris", 2_160_000);

		Console.WriteLine(einwohnerzahlen["Wien"]); //Dictionary angreifen über den Schlüssel, hier kommt der Wert vom Schlüssel heraus

		foreach (KeyValuePair<string, int> kv in einwohnerzahlen) //var: Compiler ergänzt den Typen automatisch | Strg + . -> Typen generieren
		{
			Console.WriteLine($"Die Stadt {kv.Key} hat {kv.Value} Einwohner.");
		}

		if (!einwohnerzahlen.ContainsKey("Wien")) //Prüft, ob ein Key schon existiert
			einwohnerzahlen.Add("Wien", 2_000_000);
    }
}
