using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
	// Method overloading allows multiple methods with the same name but different parameters.
	class MathOperations
	{
		public int Add(int a, int b)
		{
			return a + b;
		}

		public double Add(double a, double b)
		{
			return a + b;
		}

		public int Add(int a, int b, int c)
		{
			return a + b + c;
		}
	}
}
