namespace AliceAndBob
{
	public static class Test2
	{
		public static void Run()
		{
			const double SETBACK_PERCENT = 1.0;
			const double PEOPLE = 200000;
			const int ITERATIONS = 30;

			Random random = new();
			People People = new();

			for (int i = 0; i < PEOPLE; i++)
			{
				People.Add(new Person("Alice"));
				People.Add(new Person("Bob"));
			}
			for (int i = 0; i < ITERATIONS; i++)
			{
				Cycle.Simulate(SETBACK_PERCENT, random, People);
				Console.WriteLine($"Iteration {i + 1}:");
				People.Print();
				Console.WriteLine();
			}
		}
	}
}

