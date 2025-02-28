namespace Constructors
{
	/*
		Constructor chaining is when one constructor calls another constructor in the same class or in the base class using this or base.

			this() calls another constructor in the same class.
			base() calls a constructor from the base class.
	 */
	class ConstructorChaining
	{
		public string Name;
		public int Age;

		// Constructor chaining: Default constructor calls parameterized constructor
		public ConstructorChaining() : this("Unknown", 0) { }

		// Parameterized constructor
		public ConstructorChaining(string name, int age)
		{
			Name = name;
			Age = age;
		}
	}
}
