namespace Constructors
{
	/// <summary>
	/// A static constructor is used to initialize static members of a class. It is called only once, before any instances of the class are created or any static members are accessed.
	/// It doesn't take any parameters.
	/// You can't manually call a static constructor; it is called automatically when the class is accessed for the first time.
	/// </summary>
	class StaticConstructor
	{
		public static int Count;

		// Static constructor
		static StaticConstructor()
		{
			Count = 10; // Initialize static member
		}

		public StaticConstructor()
		{
			Count++;
		}
	}
}
