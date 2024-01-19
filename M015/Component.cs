namespace M015;

/// <summary>
/// Diese Klasse soll eine Arbeit simulieren die länger dauert
/// Über Events wird der Status zurückgegeben
/// </summary>
internal class Component
{
	public event Action ProcessStarted;

	public event Action ProcessEnded;

	public event Action<int> Progress;

	public event Action<string> ProcessFailed;

	public bool Continue = true;

	public void DoWork()
	{
		ProcessStarted?.Invoke(); //Es könnte sein, das das Event nicht angehängt wird
		for (int i = 0; i < 10 && Continue; i++)
		{
			try
			{
				//throw new InvalidOperationException("Invalide Daten");
				Thread.Sleep(500);
				Progress?.Invoke(i); //Es könnte sein, das das Event nicht angehängt wird
			}
			catch (Exception e)
			{
				string output = e.Message + Environment.NewLine + e.StackTrace;
				ProcessFailed?.Invoke(output);
				return;
			}
		}
		ProcessEnded?.Invoke(); //Es könnte sein, das das Event nicht angehängt wird
	}
}