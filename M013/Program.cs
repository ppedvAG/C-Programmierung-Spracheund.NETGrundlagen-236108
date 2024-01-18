namespace M013;

internal class Program
{
	static void Main(string[] args)
	{
		//In einem Programm können unvorhersehbare Fehler passieren
		//z.B. Verbindungsabbruch, ...

		//Alle Exceptions loggen
		AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
		//throw new TestException("Zahl darf nicht 0 sein");

		try //Rechtsklick um Code, Snippet, Surround With, try(f)
		{
			string str = Console.ReadLine(); //Fehler: Konsole kann nicht geöffnet werden, User gibt mehr als 2GB an Text ein
			int x = int.Parse(str); //Fehler: Null-Wert, Buchstaben, Zu große/kleine Zahl

			if (x == 0)
				throw new TestException("Zahl darf nicht 0 sein"); //Exception verursachen
		}
		catch (FormatException e) //Buchstaben/keine Zahl
		{
			Console.WriteLine("Keine Zahl eingegeben");
		}
		catch (OverflowException e) //Zu kleine/große Zahl
		{
			Console.WriteLine("Zahl zu klein/groß");
			Console.WriteLine(e.Message); //C# interne Nachricht
			Console.WriteLine(e.StackTrace); //StackTrace: Zurückverfolgung, wo im Code der Fehler aufgetreten ist
		}
		catch (Exception e) //Alle anderen Fehler
		{
			Console.WriteLine("Anderer Fehler");
		}
		finally
		{
			Console.WriteLine("Parsen abgeschlossen");
		}
	}

	private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		Exception ex = (Exception) e.ExceptionObject;
		File.WriteAllText("Log.txt", $"{ex.Message}\n{ex.StackTrace}");
	}
}

public class TestException : Exception
{
	public TestException(string? message) : base(message)
	{

	}
}