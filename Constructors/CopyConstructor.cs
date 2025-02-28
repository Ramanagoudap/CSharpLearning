namespace Constructors
{
	/// <summary>
	/// A copy constructor is a special constructor that initializes a new object as a copy of an existing object of the same class.
	/// </summary>
	class CopyConstructor
	{

		public string Name;
		public int Age;

		// Copy constructor
		public CopyConstructor(ParameterizedConstructor other)
		{
			Name = other.Name;
			Age = other.Age;
		}
	}
}
