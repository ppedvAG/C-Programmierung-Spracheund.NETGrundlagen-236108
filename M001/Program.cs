public class Program
{
	event Action<int> Prime;

	event Action<int> Prime100;

	event Action<int, int> NoPrime;

    static void Main(string[] args)
    {
		Program program = new Program();
		program.Prime += (i) => Console.WriteLine($"Primzahl: {i}");
		program.Prime100 += (i) => Console.WriteLine($"Hundertste Primzahl: {i}");
		program.NoPrime += (i, t) => Console.WriteLine($"Keine Primzahl: {i}, Teiler: {t}");
		program.DoWork();
    }

    public void DoWork()
	{
		int counter = 0;
		for (int i = 3; ; i += 2)
		{
			if (CheckPrime(i))
			{
				counter++;
				if (counter % 100 == 0 && counter != 0)
					Prime100?.Invoke(i);
				else
					Prime?.Invoke(i);
			}
			Thread.Sleep(20);
		}
	}

	public bool CheckPrime(int num)
	{
		if (num % 2 == 0)
		{
			NoPrime?.Invoke(num, 2);
			return false;
		}

		for (int i = 3; i <= num / 2; i += 2)
		{
			if (num % i == 0)
			{
				NoPrime?.Invoke(num, i);
				return false;
			}
		}
		return true;
	}
}