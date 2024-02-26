namespace AliceAndBob
{
	public class Person
	{
		public Person(string name)
		{
			Name = name;
			switch (name)
			{
				case "Alice":
					GrowthRate = 0.10; // investment growth
					SetbackRate = 0.05; // investment failure
					LieDiscoveredRate = 0.05;
					SubsGrowth = 100;
					break;
				case "Bob":
					GrowthRate = 0.08;
					SetbackRate = 0.01;
					LieDiscoveredRate = 0.00;
					SubsGrowth = 50;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public double Cash { get; set; } = 100;

		public string Name { get; private set; }
		public double GrowthRate { get; private set; }
		public double SetbackRate { get; private set; }
		public double LieDiscoveredRate { get; private set; }
		public double SubsGrowth { get; private set; }

		public override string ToString()
		{
			return $"{Name}: {Math.Round(Cash * 100) / 100}";
		}
	}
}

