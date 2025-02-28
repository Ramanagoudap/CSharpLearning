namespace Delegates
{
	class BuiltInDelegates
	{
		/// <summary>
		/// Func Delegate
		/// Used for methods that return a value.
		/// </summary>
		public Func<int, int, int> add = (a, b) => a + b;

		/// <summary>
		/// Action Delegate
		/// Used for methods that do not return a value.
		/// </summary>
		public Action<string> greet = name => Console.WriteLine("Hello, " + name);

		/// <summary>
		/// Predicate Delegate
		/// Used for methods that return a boolean.
		/// </summary>
		public Predicate<int> isEven = num => num % 2 == 0;
	}
}
