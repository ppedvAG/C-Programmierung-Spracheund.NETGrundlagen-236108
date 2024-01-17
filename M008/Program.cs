namespace M008;

public class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch(22, "Max");
		m.Bewegen(10); //Mensch hat Bewegen geerbt
        Console.WriteLine(m.Alter); //Mensch hat Alter geerbt

		Katze k = new Katze(3, 4);
		k.Bewegen(10); //Bewegen wurde durch Tier zu Katze weiter gereicht

		//Alle Klassen in C# erben von Object, und Object vererbt die folgenden 4 Methoden:
		k.Equals(m);
		k.GetType();
		k.GetHashCode();
		k.ToString();

		//Durch die Virtual-Override Mechanik wird hier jetzt die Implementation von Mensch verwendet
		m.BewegenVirtual(10);
		k.BewegenVirtual(10); //Nachdem weder Katze noch Tier eine Implemenation haben, wird hier die Methode aus Lebewesen verwendet
	}
}
