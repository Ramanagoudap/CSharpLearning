using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
	// In single inheritance, one class derives from another class.
	// Base class
	class Animal
	{
		public void Eat()
		{
			Console.WriteLine("This animal eats food.");
		}
	}

	// Derived class
	class Dog : Animal
	{
		public void Bark()
		{
			Console.WriteLine("The dog barks.");
		}
	}

}
