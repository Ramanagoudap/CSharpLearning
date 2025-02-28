using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
	// Base class
	class Animal1
	{
		public void Eat()
		{
			Console.WriteLine("This animal eats food.");
		}
	}

	// Intermediate derived class
	class Mammal1 : Animal1
	{
		public void Walk()
		{
			Console.WriteLine("This mammal walks.");
		}
	}

	// Further derived class
	class Dog1 : Mammal1
	{
		public void Bark()
		{
			Console.WriteLine("The dog barks.");
		}
	}

}
