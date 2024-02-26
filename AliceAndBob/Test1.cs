using AliceAndBob;

public static class Test1 // WHO IS WEALTHIER BETWEEN TWO?
{
	const double TRIALS = 1000000;
	const int TRIAL_LENGHT = 2;
	const double SETBACK_PERCENT = 1.0;

	public static void Run()
	{
		Random random = new();
		var n = 0;
		for (int i = 0; i < TRIALS; i++)
		{
			People People = new()
	{
		new Person("Alice"),
		new Person("Bob")
	};
			for (int j = 0; j < TRIAL_LENGHT; j++)
			{
				Cycle.Simulate(SETBACK_PERCENT, random, People);
			}
			if (People.OrderByDescending(p => p.Cash).First().Name == "Alice")
			{ n++; }
		}
		Console.WriteLine($"Alice is wealthier {Math.Round((double)(n / TRIALS) * 100),2}% of times.");
	}
}