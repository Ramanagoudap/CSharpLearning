namespace Constructors
{
	/// <summary>
	/// A default constructor is one that takes no arguments.If no constructor is explicitly defined, the compiler automatically provides a default constructor.
	/// </summary>
	public class DefaultConstructor
	{
		public string Name;
		public int Age;

		// Default constructor
		public DefaultConstructor()
		{
			Name = "Ram";
			Age = 35;
		}
	}
}
///In this example, when an object of Person is created, the default constructor is invoked, setting Name to "Unknown" and Age to 0.
