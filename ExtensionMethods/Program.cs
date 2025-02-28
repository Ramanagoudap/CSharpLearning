namespace ExtensionMethods
{
	internal class Program
	{
		/*
		Extension methods in C# allow you to add new methods to existing types without modifying their source code. They are static methods that appear as instance methods on the extended type.
		
		When to Use Extension Methods?

			When you cannot modify the original class (e.g., it's from a third-party library or a built-in .NET type).
			To enhance code readability by making utility methods available as if they were instance methods.
			To group related functionality in a separate static class.

		Syntax of an Extension Method

			The method must be static.
			It must be inside a static class.
			The first parameter must use the this keyword followed by the type it extends.

		Key Rules of Extension Methods

			They do not modify the original class but provide additional behavior.
			They must be in a static class.
			If an instance method and an extension method have the same name, the instance method takes priority.
			They can be called using the extended type just like instance methods.
			They work with any type, including value types, reference types, interfaces, and even generic types.

		Limitations of Extension Methods

			They cannot access private or protected members of the extended type.
			They cannot override existing methods; instance methods always take priority.
			If the class already has a method with the same name and signature, the extension method will be ignored.
			They cannot introduce new fields or properties.
		 */
		static void Main(string[] args)
		{
			// Extending string
			string? message = null;
			bool result = message.IsNullOrEmpty(); // Works like an instance method
			Console.WriteLine(result); // Output: True

			// Extending an int Type
			int num = 10;
			Console.WriteLine(num.IsEven()); // Output: True


			// Extending List<T>
			List<int> numbers = new List<int> { 1, 2, 3, 4 };
			numbers.PrintAll();

			// Extending an Interface
			IAnimal dog = new Dog();
			dog.Speak();     // Output: Bark
			dog.Describe();  // Output: This is an animal.

			// Generic Extension Methods
			int number = 0;
			Console.WriteLine(number.IsDefault()); // Output: True
			string text = null;
			Console.WriteLine(text.IsDefault()); // Output: True
		}


	}

	// Extending string
	public static class StringExtensions
	{
		public static bool IsNullOrEmpty(this string value)
		{
			return string.IsNullOrEmpty(value);
		}
	}

	// Extending an int Type
	public static class IntExtensions
	{
		public static bool IsEven(this int number)
		{
			return number % 2 == 0;
		}
	}


	// Extending List<T>
	public static class ListExtensions
	{
		public static void PrintAll<T>(this List<T> list)
		{
			foreach (var item in list)
			{
				Console.WriteLine(item);
			}
		}
	}

	// Extending an Interface
	public interface IAnimal
	{
		void Speak();
	}

	public class Dog : IAnimal
	{
		public void Speak() => Console.WriteLine("Bark");
	}

	public static class AnimalExtensions
	{
		public static void Describe(this IAnimal animal)
		{
			Console.WriteLine("This is an animal.");
		}
	}

	// Generic Extension Methods
	public static class GenericExtensions
	{
		public static bool IsDefault<T>(this T value)
		{
			return EqualityComparer<T>.Default.Equals(value, default);
		}
	}
}
