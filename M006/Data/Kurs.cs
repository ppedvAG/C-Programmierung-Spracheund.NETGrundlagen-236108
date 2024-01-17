namespace M006.Data;

internal class Kurs
{
	public Person[] Teilnehmer;

	public Person Trainer;

	public KursTyp Typ;

	public string KursName;

	public int Dauer;

	public Kurs(string name, int dauer, KursTyp typ, Person trainer, params Person[] tn)
	{
		KursName = name;
		Dauer = dauer;
		Typ = typ;
		Trainer = trainer;
		Teilnehmer = tn;
	}
}
