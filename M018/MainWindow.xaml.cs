using M018.Models;
using System.Collections.Concurrent;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M018;

public partial class MainWindow : Window
{
	string url = "http://www.gutenberg.org/files/54700/54700-0.txt";

	public MainWindow()
	{
		InitializeComponent();
		NorthwindContext context = new();
		DG.ItemsSource = context.Customers.Where(e => e.Country == "UK").ToList();
	}

	private async void Button_Click(object sender, RoutedEventArgs e)
	{
		//Nicht asynchron
		//Task<HttpResponseMessage> resp = client.GetAsync(url);
		//resp.Wait();
		//if (resp.Result.IsSuccessStatusCode)
		//{
		//	TB.Text = resp.Result.Content.ReadAsStringAsync().Result;
		//}

		using HttpClient client = new HttpClient();
		Task<HttpResponseMessage> resp = client.GetAsync(url); //Starte die Aufgabe
		TB.Text = "Request gestartet"; //Zwischenschritt
		HttpResponseMessage message = await resp; //Warte darauf, das der Request fertig ist
		if (message.IsSuccessStatusCode)
		{
			Task<string> text = message.Content.ReadAsStringAsync(); //Starte die Aufgabe
			TB.Text = await text; //Warte auf das Ergebnis
								  //TB.Text = await message.Content.ReadAsStringAsync();
		}

		//X Textdateien laden
		string[] pfade = Directory.GetFiles("");
		List<Task<string>> readTasks = new();
		foreach (string str in pfade)
		{
			readTasks.Add(File.ReadAllTextAsync(str));
		}
		await Task.WhenAll(readTasks);
	}

	private async void Button_Click_1(object sender, RoutedEventArgs e)
	{
		//Datenbank

		//Zwei Möglichkeiten
		//Einfache Datenbankverbindung
		//EntityFramework
		//Microsoft.EntityFrameworkCore
		//Microsoft.EntityFrameworkCore.Design
		//Microsoft.EntityFrameworkCore.Tools
		//VS Extension: EF Core Power Tools

		Progress.Value = 0;

		using SqlConnection conn = new("Server=WIN10-LK3;Database=Demo;Trusted_Connection=True;");
		Task open = conn.OpenAsync();
		TB.Text = "Verbindung wird geöffnet";
		await open;

		TB.Text = "Verbindung hergestellt";

		using SqlCommand command = conn.CreateCommand();
		//command.Connection = conn;
		command.CommandText = "SELECT COUNT(*) FROM KundenUmsatz";

		Task<object> anzRows = command.ExecuteScalarAsync();
		TB.Text = "Zähle Anzahl Zeilen";
		await anzRows;
		Gesamt.Text = "50000";// (await anzRows).ToString();
		Progress.Maximum = 50000;// int.Parse(Gesamt.Text);

		using SqlCommand selectAll = conn.CreateCommand();
		//command.Connection = conn;
		selectAll.CommandText = "SELECT TOP 50000 * FROM KundenUmsatz";

		TB.Text = "SELECT *";
		SqlDataReader reader = await selectAll.ExecuteReaderAsync();
		List<KundenUmsatz> rows = new();

		Stopwatch sw = Stopwatch.StartNew();
		while (await reader.ReadAsync())
		{
			object[] columns = new object[reader.FieldCount];
			reader.GetValues(columns);

			KundenUmsatz ku = new KundenUmsatz() { CustomerID = columns[0].ToString(), CompanyName = columns[1].ToString(), ContactName = columns[2].ToString() };
			rows.Add(ku);
			AnzGeladen.Text = rows.Count.ToString();
			Progress.Value++;
		}
		TB.Text = (sw.ElapsedMilliseconds / 1000.0).ToString() + "s";

		DG.ItemsSource = rows;
	}
}