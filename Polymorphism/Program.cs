namespace Polymorphism
{
	internal class Program
	{
		// Polymorphism allows methods to have multiple forms. It enables method overriding and method overloading
		static void Main(string[] args)
		{
			// Method Overloading
			MathOperations math = new MathOperations();

			Console.WriteLine(math.Add(5, 10));       // Calls first method
			Console.WriteLine(math.Add(5.5, 2.3));   // Calls second method
			Console.WriteLine(math.Add(1, 2, 3));    // Calls third method

			// Method Overriding
			Animal myAnimal = new Dog();
			myAnimal.MakeSound(); // Calls Dog's overridden method
		}
	}
}
