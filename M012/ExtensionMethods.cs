namespace M012;

public static class ExtensionMethods
{
	public static int Quersumme(this int x)
	{
		return x.ToString().Sum(e => (int) char.GetNumericValue(e));
	}

	public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> x)
	{
		return x.OrderBy(e => Random.Shared.Next());
	}
	
	//SQL IN
	//string s = "Hallo"; if (s.In("1", "2", "3"))
	//int x = 4; if (x.In(1, 2, 3, 4))
	public static bool In<T>(this T obj, params T[] values)
	{
		return values.Contains(obj);
	}

	public static bool In<T>(this IEnumerable<T> x, params T[] values)
	{
		foreach (T v in values)
			if (x.Contains(v))
				return true;
		return false;
	}
}
