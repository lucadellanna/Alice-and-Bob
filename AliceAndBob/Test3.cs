namespace AliceAndBob
{
	public static class Test3
	{
		public static void Run()
		{
			// Each day, they make an ad campaing that might generate X sales (absolute) but Y% of failure.
			const int DAYS = 100;
			const int EXPERIMENTS = 1000000;
			const double SETBACK = 0.2;
			Random random = new();
			int[] n = new int[DAYS]; // Stores how often Alice is wealthier than Bob on a given day
			double[] a = new double[DAYS]; // Stores Alices' wealth
			double[] b = new double[DAYS]; // Stores Bobs' wealth
			var j = 0;
			for (int i = 0; i < EXPERIMENTS; i++)
			{
				j++; // To track progress
				if (j == EXPERIMENTS / 10000)
				{ j = 0; Console.SetCursorPosition(0, 0); Console.WriteLine($"Progress: {((double)i / EXPERIMENTS):P2}."); }

				People People = new() { new Person("Alice"), new Person("Bob") };
				People[0].Cash = 0; People[1].Cash = 0;
				for (int d = 0; d < DAYS; d++)
				{
					foreach (var person in People)
					{
						if (random.NextDouble() < person.LieDiscoveredRate)
						{ person.Cash *= SETBACK; }
						else { person.Cash += person.SubsGrowth; }
					}
					if (People.OrderByDescending(p => p.Cash).First().Name == "Alice")
					{ n[d]++; }
					a[d] += People[0].Cash;
					b[d] += People[1].Cash;
				}
			}
			for (int d = 0; d < DAYS; d++)
			{
				Console.WriteLine($"The % of experiments where Alice is the top earner after {d + 1} days is {((double)n[d] / EXPERIMENTS):P2}");
			}
			Console.WriteLine();
			Console.WriteLine("Alice's followers day after day:");
			for (int d = 0; d < DAYS; d++) { Console.WriteLine(Math.Round(a[d] / EXPERIMENTS, 0)); }
			Console.WriteLine("Bob's followers day after day:");
			for (int d = 0; d < DAYS; d++) { Console.WriteLine(Math.Round(b[d] / EXPERIMENTS, 0)); }
		}
	}
}