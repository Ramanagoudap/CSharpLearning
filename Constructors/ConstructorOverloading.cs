namespace Constructors
{
	/// <summary>
	/// In C#, you can define multiple constructors with different parameter lists. 
	/// This is called constructor overloading. It allows you to create objects in different ways, depending on the provided arguments.
	/// </summary>
	class ConstructorOverloading
    {
		public string Name;
		public int Age;
		public string Address;

		// Default constructor
		public ConstructorOverloading()
		{
			Name = "Unknown";
			Age = 0;
		}

		// Parameterized constructor with name and age
		public ConstructorOverloading(string name, int age)
		{
			Name = name;
			Age = age;
		}

		// Parameterized constructor with name, age, and address
		public ConstructorOverloading(string name, int age, string address)
		{
			Name = name;
			Age = age;
			Address = address;
		}
	}
}
