namespace M008;

public class AccessModifier
{
	public string Name { get; set; } //Kann überall gesehen werden (auch außerhalb vom Projekt)

	internal int Alter { get; set; } //Kann überall gesehen werden (aber nur innerhalb des Projekts)

	private string Adresse { get; set; } //Kann nur innerhalb der Klasse gesehen werden

	///////////////////////////////////////////////////////////////////////////////////////////////
	
	protected int ID { get; set; } //Kann nur innerhalb der Klasse gesehen werden und auch in Unterklassen (auch außerhalb vom Projekt)

	protected private string Description { get; set; } //Kann nur innerhalb der Klasse gesehen werden und auch in Unterklassen (aber nur innerhalb des Projekts)

	protected internal string Author { get; set; } //Kann überall gesehen werden (aber nur innerhalb des Projekts) und zusätzlich in Unterklassen außerhalb des Projekts
}