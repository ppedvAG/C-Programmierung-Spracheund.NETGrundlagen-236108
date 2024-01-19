using System.Windows;
using System.Windows.Controls;

using Microsoft.Win32;

namespace M016;

public partial class MainWindow : Window
{
	private int counter;

	public MainWindow()
	{
		InitializeComponent();
		CB.ItemsSource = new List<string>() { "Element1", "Element2", "Element3" };
		LB.ItemsSource = new List<string>() { "Element1", "Element2", "Element3" };

		Task.Run(() =>
		{
			while (true)
			{
				Dispatcher.Invoke(() => Scroller.Margin = new Thickness(Scroller.Margin.Left - 1, 0, 0, 0));
				Thread.Sleep(25);
			}
		});
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		//MainWindow mw = new MainWindow();
		//mw.ShowDialog();

		//using Microsoft.Win32;
		OpenFileDialog ofd = new OpenFileDialog();
		ofd.ShowDialog();
		TB.Text = ofd.FileName;

		SaveFileDialog sfd = new SaveFileDialog();
		sfd.ShowDialog();
		TB.Text = sfd.FileName;

		counter++;
		//TB.Text = $"Zähler: {counter}";
	}

	private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		TB.Text = e.AddedItems.OfType<string>().First(); //OfType: Filtert die Liste anhand eines Typens
	}

	private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		TB.Text = string.Join(", ", LB.SelectedItems.OfType<string>());
	}

	private void CheckBox_Checked(object sender, RoutedEventArgs e)
	{
		//Event wird beim Start des Fensters gefeuert
		if (IsInitialized)
		{
			TB.Text = $"{(sender as FrameworkElement).Name} gecheckt";
		}
	}

	private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
	{
		if (IsInitialized)
			TB.Text = $"{(sender as FrameworkElement).Name} ungecheckt";
	}

	private void MenuItem_Click(object sender, RoutedEventArgs e)
	{
		MessageBoxResult result = MessageBox.Show("Möchtest du wirklich beenden?", "Beenden?", MessageBoxButton.YesNo, MessageBoxImage.Question);
		if (result == MessageBoxResult.Yes)
			this.Close();
	}
}