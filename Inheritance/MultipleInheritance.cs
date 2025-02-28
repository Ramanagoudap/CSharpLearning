using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
	// C# does not support multiple inheritance using classes but allows multiple inheritance using interfaces.
	interface IFly
	{
		void Fly();
	}

	interface ISwim
	{
		void Swim();
	}

	// Class implementing multiple interfaces
	class Bird : IFly, ISwim
	{
		public void Fly()
		{
			Console.WriteLine("Bird can fly.");
		}

		public void Swim()
		{
			Console.WriteLine("Some birds can swim.");
		}
	}

}
