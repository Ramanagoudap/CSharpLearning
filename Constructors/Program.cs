namespace Constructors
{
	internal class Program
	{
		/// <summary>
		/// A constructor is a special method that is automatically called when an object is created. It initializes an object.
		/// Name: The constructor must have the same name as the class.
		/// No Return Type: Unlike regular methods, constructors do not have a return type(not even void).
		/// Automatic Invocation: The constructor is automatically called when a new object of the class is created.
		/// </summary>
		static void Main(string[] args)
		{
			// Default Constructor
			DefaultConstructor defaultConstructor = new DefaultConstructor();
			Console.WriteLine($"Name: {defaultConstructor.Name}, Age: {defaultConstructor.Age}");
			// Output: Name: Unknown, Age: 0

			// Parameterized Constructor
			ParameterizedConstructor parameterizedConstructor = new ParameterizedConstructor("Ram", 30);
			Console.WriteLine($"Name: {parameterizedConstructor.Name}, Age: {parameterizedConstructor.Age}");
			// Output: Name: Alice, Age: 30


			// Copy Constructor
			CopyConstructor copyConstructor = new CopyConstructor(parameterizedConstructor); // Copy constructor
			Console.WriteLine($"Name: {copyConstructor.Name}, Age: {copyConstructor.Age}");
			// Output: Name: Bob, Age: 25


			// Static Constructor
			Console.WriteLine(StaticConstructor.Count); // Static constructor is called first
			StaticConstructor obj1 = new StaticConstructor();
			Console.WriteLine(StaticConstructor.Count); // Output: 11

			// Private Constructor

			// You can't directly create an object of Singleton class using `new Singleton()`.
			Singleton singleton1 = Singleton.GetInstance();
			singleton1.ShowMessage(); // Output: This is a message from the Singleton class.

			// If you try to create another instance, you'll get the same instance.
			Singleton singleton2 = Singleton.GetInstance();
			Console.WriteLine(ReferenceEquals(singleton1, singleton2)); // Output: True



			//Constructor Overloading
			ConstructorOverloading constructorOverloading1 = new ConstructorOverloading();
			ConstructorOverloading constructorOverloading2 = new ConstructorOverloading("Alice", 30);
			ConstructorOverloading constructorOverloading3 = new ConstructorOverloading("Bob", 25, "123 Street");

			Console.WriteLine($"{constructorOverloading1.Name}, {constructorOverloading1.Age}");
			Console.WriteLine($"{constructorOverloading2.Name} ,  {constructorOverloading2.Age}");
			Console.WriteLine($"{constructorOverloading3.Name}, {constructorOverloading3.Age}, {constructorOverloading3.Address}");


			// Constructor Chaining
			ConstructorChaining constructorChaining = new ConstructorChaining(); // Calls default constructor which chains to parameterized constructor
			Console.WriteLine($"{constructorChaining.Name} ,  {constructorChaining.Age}"); // Output: Unknown, 0

		}

		/*
			In C#, destructors are special methods used to clean up an object when it is destroyed. Destructors are less commonly used, because C# relies on garbage collection to manage memory.

				A destructor has the same name as the class but with a tilde (~) before it.
				A destructor cannot be called explicitly and cannot have parameters.
				Destructors are automatically called when the object is no longer referenced.
		 */
	}
}