using M006.Data; //using: Namespace importieren, Typen aus anderen Namespaces verwendbar machen

namespace M006;

internal class Program
{
	static void Main(string[] args)
	{
		//Neues Objekt erstellen mit dem new Keyword
		Person p = new Person(); //Hier wird ein Speicherbereich im RAM reserviert, in diesem wird das Objekt mit seinen Werten abgelegt
		p.SetVorname("Max"); //Hier wird auf das spezifische p Objekt zugegriffen, und der Vorname wird gesetzt
		p.Nachname = "Mustermann"; //Hier wird der Nachname gesetzt, ohne dafür eine Methode verwenden zu müssen
            Console.WriteLine(p.VollerName);
		p.Sprechen("Hallo"); //Auf der spezifischen Person p (auf dem Objekt) wird jetzt sprechen ausgeführt

		Person p2 = new Person("Max", "Muster"); //Hier werden Vor- und Nachname als Standardwerte gesetzt
		Person p3 = new Person("Max", "Muster", 33); //Hier werden jetzt beide Konstruktoren verwendet

		//Namespaces
		//Organisationseinheiten, mit denen Klassen, Enums, Interfaces, ... gruppiert werden können

		//Beispiele:
		//Console: System
		//File: System.IO
		//HttpClient: System.Net.Http
		//Stopwatch: System.Diagnostics
		//Mit using können diese Namespaces und ihre dazugehörigen Typen importiert werden

		//Assozation von Objekten
		//Referenzierung von Objekten in anderen Objekten
		//-> Verschachtelung von Objekten

		//Verschachtelung von String:
		//string besteht aus char[]
		//char[] besteht aus chars
		//chars sind ints
		//Ein int besteht aus 4 Byte

		//Kurs erstellen
		Person trainer = new Person("", "", 25);
		Person ns = new Person("", "", 27);
		Person cm = new Person("", "", 35);
		Person ad = new Person("", "", 26);
		Person es = new Person("", "", 32);
		Kurs k = new Kurs("C# Grundkurs", 4, KursTyp.Online, trainer, ns, cm, ad, es);
	}
}