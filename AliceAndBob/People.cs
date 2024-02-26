namespace AliceAndBob
{
	public class People : List<Person>
	{
		public People() { }

		public void Print(int rounding = 0, bool full = false)
		{
			var people = this.OrderByDescending(p => p.Cash).ToList();
			if (full)
			{
				for (int j = 0; j < 200; j++)
				{
					Console.WriteLine(people[j]);
				}
			}
			Console.WriteLine($"% Alices in top 10: {Math.Round(((double)people.Take(10).Count(p => p.Name == "Alice") / 10) * 100, rounding)}%");
			Console.WriteLine($"% Alices in top 100: {Math.Round(((double)people.Take(100).Count(p => p.Name == "Alice") / 100) * 100, rounding)}%");
			Console.WriteLine($"% Alices in top decile: {Math.Round(((double)people.Take(people.Count / 10).Count(p => p.Name == "Alice") / (people.Count / 10)) * 100, rounding)}%");
			Console.WriteLine($"Surviving Alices' avg: {Math.Round(people.Where(p => p.Name == "Alice" && p.Cash > 0).Average(p => p.Cash), rounding)}");
			Console.WriteLine($"Surviving Bobs' avg: {Math.Round(people.Where(p => p.Name == "Bob" && p.Cash > 0).Average(p => p.Cash), rounding)}");
			Console.WriteLine($"Alices' avg: {Math.Round(people.Where(p => p.Name == "Alice").Average(p => p.Cash), rounding)}");
			Console.WriteLine($"Bobs' avg: {Math.Round(people.Where(p => p.Name == "Bob").Average(p => p.Cash), rounding)}");
		}
	}
}