namespace Constructors
{
	/// <summary>
	/// A parameterized constructor takes arguments to initialize the fields with custom values when the object is created.
	/// </summary>
	class ParameterizedConstructor
    {
		public string Name;
		public int Age;

		// Parameterized constructor
		public ParameterizedConstructor(string name, int age)
		{
			Name = name;
			Age = age;
		}
	}
}
