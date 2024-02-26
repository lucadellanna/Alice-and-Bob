using System;
namespace AliceAndBob
{
	public static class Cycle
	{
		public static void Simulate(double SETBACK_PERCENT, Random random, People People)
		{
			foreach (var person in People)
			{
				if (random.NextDouble() <= person.SetbackRate)
				{ person.Cash *= 1 - SETBACK_PERCENT; }
				else { person.Cash *= 1 + person.GrowthRate; }
			}
		}
	}
}