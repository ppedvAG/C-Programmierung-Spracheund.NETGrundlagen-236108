using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace M014;

internal class Program
{
	static void Main(string[] args)
	{
		//Dateimanagement
		//3 Klassen: File, Directory, Path

		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Spezielle Ordner finden
		string folderPath = Path.Combine(desktop, "M014"); //Hier wird nur der Pfad erstellt
		string filePath = Path.Combine(folderPath, "Test.txt");

		//Ordner erstellen
		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		//Stream
		//Pipe zu einer externen Resource
		//z.B. File, DB, API, ...
		//Müssen manuell geschlossen werden

		//StreamWriter
		//Wrapper für FileStream der Streams vereinfacht
		StreamWriter sw = new StreamWriter(filePath); //Hier wird die Datei erstellt
		sw.WriteLine("Test1");
		sw.WriteLine("Test2");
		sw.WriteLine("Test3"); //Hier sind die Inhalte noch im Stream aber nicht im File
		sw.Flush(); //Inhalt schreiben
		sw.Close();

		using (StreamWriter sw2 = new StreamWriter(filePath))
		{
			sw2.WriteLine("Test1");
			sw2.WriteLine("Test2");
			sw2.WriteLine("Test3");
		} //hier wird .Dispose() aufgerufen, der StreamWriter macht auch Flush automatisch

		using StreamWriter sw3 = new StreamWriter(filePath);
		sw3.WriteLine("Test1");
		sw3.WriteLine("Test2");
		sw3.WriteLine("Test3");
		//Wird am Ende der Methode automatisch geschlossen

		using StreamReader sr = new StreamReader(filePath);
		string str = sr.ReadToEnd(); //Liest das gesamte File ein als ein String
		string[] zeilen = str.Split(Environment.NewLine);

		List<string> lines = [];
		while (!sr.EndOfStream)
			lines.Add(sr.ReadLine());

		File.WriteAllText(filePath, "Test1\nTest2\nTest3");
		string read = File.ReadAllText(filePath);

		File.WriteAllLines(filePath, zeilen);
		string[] readLines = File.ReadAllLines(filePath);

		//Tools -> NuGet-Packages Manager -> Manage Package for Solution

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		//System.Text.Json
		string json = JsonSerializer.Serialize(fahrzeuge);

		JsonSerializer.Deserialize<Fahrzeug[]>(json);

		//Newtonsoft.Json
		//string json2 = JsonConvert.SerializeObject(fahrzeuge);

		//JsonConvert.DeserializeObject<Fahrzeug[]>(json2);
	}
}

[DebuggerDisplay("Marke: {Marke}, MaxV: {MaxV}")]
public class Fahrzeug
{
	public int MaxV { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int maxV, FahrzeugMarke marke)
	{
		MaxV = maxV;
		Marke = marke;
	}
}

public enum FahrzeugMarke { Audi, BMW, VW }