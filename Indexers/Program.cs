using System;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

namespace Indexers
{
	internal class Program
	{
		/// <summary>
		/// An indexer in C# allows objects of a class to be indexed like arrays. It provides a way to access a class’s elements using array-like syntax instead of traditional method calls.
		/// Allow objects to be accessed like arrays.
		/// Use the this keyword.
		/// Can be overloaded.
		/// Can have different accessors(get and set).
		/// Work with one or more parameters.
		/// </summary>
		/// <param name="args"></param>
		/// 
		static void Main()
		{
			Student studentList = new Student();

			// Assign values using the indexer
			studentList[0] = "Ram";
			studentList[1] = "Riyu";
			studentList[2] = "Daya";

			// Access values using the indexer
			Console.WriteLine(studentList[0]); // Output: Alice
			Console.WriteLine(studentList[1]); // Output: Bob
			Console.WriteLine(studentList[2]); // Output: Charlie



			// Indexers with Different Data Types
			#region Indexers with Different Data Types
			EmployeeDirectory directory = new EmployeeDirectory();

			// Assign values using indexer
			directory[101] = "Ram Patil";
			directory[102] = "Riyu Patil";

			// Access values using indexer
			Console.WriteLine(directory[101]); // Output: John Doe
			Console.WriteLine(directory[102]); // Output: Jane Smith
			Console.WriteLine(directory[103]); // Output: Employee Not Found 
			#endregion


			#region Read-Only Indexers
			ReadOnlyCollection collection = new ReadOnlyCollection();

			// Access values using the indexer
			Console.WriteLine(collection[0]); // Output: One
			Console.WriteLine(collection[3]); // Output: Four
			Console.WriteLine(collection[5]); // Output: Invalid Index

			// collection[1] = "New Value"; // Error: No setter defined!
			#endregion

			#region Indexers with Multiple Parameters
			Matrix matrix = new Matrix();

			// Assign values using indexer
			matrix[0, 0] = 1;
			matrix[0, 1] = 2;
			matrix[1, 1] = 5;

			// Access values using indexer
			Console.WriteLine(matrix[0, 0]); // Output: 1
			Console.WriteLine(matrix[0, 1]); // Output: 2
			Console.WriteLine(matrix[1, 1]); // Output: 5
			#endregion

			#region Overloading Indexers
			StudentList list = new StudentList();

			// Using integer indexer
			Console.WriteLine(list[1]);  // Output: Bob

			// Using string indexer
			Console.WriteLine(list["Riyu"]);  // Output: 2
			Console.WriteLine(list["Shreedha"]);      // Output: -1
			#endregion

		}

	}

	class Student
	{
		private string[] names = new string[5]; // Internal array of student names

		// Indexer to get and set student names
		public string this[int index]
		{
			get
			{
				if (index >= 0 && index < names.Length)
					return names[index];
				throw new IndexOutOfRangeException("Index out of range");
			}
			set
			{
				if (index >= 0 && index < names.Length)
					names[index] = value;
				else
					throw new IndexOutOfRangeException("Index out of range");
			}
		}
	}

	// Indexers with Different Data Types
	class EmployeeDirectory
	{
		private Dictionary<int, string> employees = new Dictionary<int, string>();

		// Indexer to access dictionary items
		public string this[int id]
		{
			get
			{
				return employees.ContainsKey(id) ? employees[id] : "Employee Not Found";
			}
			set
			{
				employees[id] = value;
			}
		}
	}

	// Read-Only Indexers
	class ReadOnlyCollection
	{
		private string[] items = { "One", "Two", "Three", "Four", "Five" };

		// Read-only indexer
		public string this[int index]
		{
			get
			{
				if (index >= 0 && index < items.Length)
					return items[index];
				return "Invalid Index";
			}
		}
	}

	/// <summary>
	/// Works like a two-dimensional array.
	/// Uses two parameters in the indexer.
	/// </summary>
	class Matrix
	{
		private int[,] numbers = new int[3, 3];

		// Multi-dimensional indexer
		public int this[int row, int col]
		{
			get { return numbers[row, col]; }
			set { numbers[row, col] = value; }
		}
	}


	/// <summary>
	/// One indexer takes an int and returns a student’s name.
	/// Another indexer takes a string (name) and returns its index.
	/// </summary>
	class StudentList
	{
		private string[] students = { "Ram", "Riyu", "Raj", "Daya" };

		// Indexer by integer index
		public string this[int index]
		{
			get { return students[index]; }
		}

		// Indexer by name (returns index)
		public int this[string name]
		{
			get
			{
				for (int i = 0; i < students.Length; i++)
				{
					if (students[i] == name)
						return i;
				}
				return -1; // Not found
			}
		}
	}

}
