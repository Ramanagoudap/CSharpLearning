namespace Inheritance
{
	internal class Program
	{
		/*
			Inheritance is a fundamental concept of Object-Oriented Programming (OOP) in which a child class (derived class) inherits the properties and behaviors (fields and methods) of a parent class (base class).
				
				Key Features of Inheritance:

					Code Reusability: Allows reuse of existing code in a new class.
					Extensibility: A child class can add new features or modify existing ones.
					Hierarchical Structure: Promotes a logical and organized structure of classes.
		 */
		static void Main(string[] args)
		{
			// Single Inheritance
			Dog dog = new Dog();
			dog.Eat();  // Inherited from Animal class
			dog.Bark(); // Defined in Dog class

			// Multi level inheritance
			Dog1 dog1 = new Dog1();
			dog1.Eat();  // Inherited from Animal
			dog1.Walk(); // Inherited from Mammal
			dog1.Bark(); // Defined in Dog

			// Multiple inheritance
			Bird bird = new Bird();
			bird.Fly();
			bird.Swim();
		}
	}

	class ParentClass
	{
		// Parent class properties and methods
	}

	class ChildClass : ParentClass
	{
		// Child class inherits from ParentClass
	}

}
