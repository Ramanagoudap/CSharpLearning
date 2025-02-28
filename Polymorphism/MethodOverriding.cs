using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
	// Method overriding allows a derived class to modify the implementation of a method in the base class using the virtual and override keywords.
	class Animal
	{
		public virtual void MakeSound()
		{
			Console.WriteLine("Animal makes a sound.");
		}
	}

	class Dog : Animal
	{
		public override void MakeSound()
		{
			Console.WriteLine("Dog barks.");
		}
	}
}
