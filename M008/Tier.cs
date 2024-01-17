namespace M008;

public class Tier : Lebewesen
{
	public int AnzahlBeine { get; set; }

	public Tier(int alter, int anzBeine) : base(alter)
	{
		AnzahlBeine = anzBeine;
	}
}
