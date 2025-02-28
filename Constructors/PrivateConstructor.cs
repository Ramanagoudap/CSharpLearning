namespace Constructors
{
	/// <summary>
	/// A private constructor is a constructor that cannot be accessed directly from outside the class. 
	/// Private constructors are used in certain design patterns, such as the Singleton pattern, or when you want to restrict how objects of a class are created.
	/// 
	/// Private constructors are primarily used in the following scenarios:
	///		Singleton Pattern: Ensures that only one instance of a class is created.
	///		Static Classes: A static class cannot have instances, and private constructors can enforce this.
	///		Factory Methods: Restrict object creation to certain methods or factories.
	///		Preventing Direct Instantiation: You may want to prevent direct instantiation of a class, but still allow access through specific methods.
	/// </summary>

	/*
		 Singleton Pattern

			The Singleton pattern is a design pattern that restricts the instantiation of a class to only one object. This is useful when you need a single point of access to a resource (e.g., database connection, logging).

			In C#, a private constructor ensures that only one instance of the class can be created, and the instance is made accessible via a static method.
	 */
	public class Singleton
	{
		// Private static field to hold the single instance of the class
		private static Singleton instance;

		// Private constructor to prevent direct instantiation
		private Singleton()
		{
			Console.WriteLine("Singleton instance created.");
		}

		// Public method to provide access to the single instance
		public static Singleton GetInstance()
		{
			if (instance == null)
			{
				instance = new Singleton();
			}
			return instance;
		}

		public void ShowMessage()
		{
			Console.WriteLine("This is a message from the Singleton class.");
		}
	}

}
