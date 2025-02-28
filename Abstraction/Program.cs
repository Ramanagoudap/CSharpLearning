namespace Abstraction
{
	internal class Program
	{
		/*
		Abstraction is the concept of hiding the complex implementation details of a class and exposing only the essential features or operations. This is done using abstract classes, interfaces, and abstract methods.

		Key Points of Abstraction:

			Abstract Classes: Can have both abstract methods (without implementation) and concrete methods (with implementation). A class derived from an abstract class must implement all abstract methods.
			Interfaces: Define a contract (method signatures) but don’t provide any implementation. A class that implements an interface must implement all methods defined in the interface.
		 */
		static void Main(string[] args)
		{
			Shape circle = new Circle(5);
			Shape rectangle = new Rectangle(4, 6);

			circle.DisplayArea();  // Output: Area: 78.53981633974483
			rectangle.DisplayArea();  // Output: Area: 24
		}
	}

	// Abstract class that defines the abstract method CalculateArea
	public abstract class Shape
	{
		public abstract double CalculateArea();  // Abstract method with no body

		// Concrete method that can be used by subclasses
		public void DisplayArea()
		{
			Console.WriteLine($"Area: {CalculateArea()}");
		}
	}

	// Concrete subclass: Circle
	public class Circle : Shape
	{
		public double Radius { get; set; }

		public Circle(double radius)
		{
			Radius = radius;
		}

		// Override the abstract method with a specific implementation for Circle
		public override double CalculateArea()
		{
			return Math.PI * Radius * Radius;
		}
	}

	// Concrete subclass: Rectangle
	public class Rectangle : Shape
	{
		public double Width { get; set; }
		public double Height { get; set; }

		public Rectangle(double width, double height)
		{
			Width = width;
			Height = height;
		}

		// Override the abstract method with a specific implementation for Rectangle
		public override double CalculateArea()
		{
			return Width * Height;
		}
	}

	/*
		Abstract Class Shape: The Shape class defines an abstract method CalculateArea(), which must be implemented by any derived class. It also provides a concrete method DisplayArea() that can be reused by all derived classes.

		Concrete Subclasses Circle and Rectangle: Both Circle and Rectangle provide their specific implementation of the CalculateArea method.

		Encapsulation: The internal properties (Radius, Width, Height) are encapsulated and not directly exposed. Only the necessary methods for calculation are available to the outside world.
	 */

}
