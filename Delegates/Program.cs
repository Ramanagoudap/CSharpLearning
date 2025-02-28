namespace Delegates
{
	internal class Program
	{
		/*
		 A delegate in C# is a type that represents references to methods with a specific signature. It is similar to function pointers in C++ but is type-safe.
		Why Use Delegates?

			Encapsulate methods into objects.
			Pass methods as parameters.
			Support event-driven programming.
			Enable callback mechanisms.
			Promote decoupling between components.

		syntax:
		A delegate must match the signature of the method it will reference.
			public delegate void MyDelegate(string message);

		Types of Delegates:
			Single-Cast Delegate: 
				A delegate that refers to a single method.
				Can hold a reference to only one method at a time.

			Multi-Cast Delegate:
				A delegate that refers to multiple methods using += and -=.

			Built In Delegates:
				Func: Represents a method that returns a value.
				Action: Represents a method that does not return a value.
				Predicate: Represents a method that returns a boolean.

		Advantages of Delegates
			Encapsulation – Methods can be treated as first-class objects.
			Flexibility – Enables dynamic method execution.
			Reusability – Can be used across multiple classes.
			Event Handling – Forms the base of event-driven programming.	
		
		Limitations of Delegates
			Harder to debug when multiple methods are subscribed.
			Performance overhead due to invocation via references.
		 */

		#region Single-Cast Delegate
		// Step 1: Declare a delegate
		public delegate void PrintMessage(string message);

		// Step 2: Create a method matching the delegate signature
		public static void ShowMessage(string msg)
		{
			Console.WriteLine(msg);
		}
		#endregion

		#region Multi-cast delegates

		public delegate void MultiDelegate(string msg);
		static void Method1(string message) => Console.WriteLine("Method1: " + message);
		static void Method2(string message) => Console.WriteLine("Method2: " + message);

		#endregion

		static void Main(string[] args)
		{
			#region Calling Single-Cast Delegate
			// Step 3: Instantiate the delegate
			PrintMessage del = ShowMessage;

			// Step 4: Invoke the delegate
			del("Hello, Delegates!");
			#endregion

			#region Calling Multi-cast delegates
			MultiDelegate multiDel = Method1;
			multiDel += Method2; // Add another method

			multiDel("Hello");

			multiDel -= Method1; // Remove Method1
			multiDel("Again");
			#endregion

			#region Calling Buil-In-Delegates
			BuiltInDelegates builtInDelegates = new BuiltInDelegates();
			Console.WriteLine(builtInDelegates.add(5, 10)); // Output: 15
			builtInDelegates.greet("Alice"); // Output: Hello, Alice
			Console.WriteLine(builtInDelegates.isEven(4)); // Output: True
			#endregion


			#region Calling Delegates As Method Parameters

			DelegatesAsMethodParameters.ProcessMessage("Hello World", DelegatesAsMethodParameters.PrintUpper);
			DelegatesAsMethodParameters.ProcessMessage("Hello World", DelegatesAsMethodParameters.PrintLower);
			#endregion

			#region Delegates With Events

			static void ButtonClicked() => Console.WriteLine("Button was clicked!");

			Button btn = new Button();
			btn.Click += ButtonClicked; // Subscribe to event

			btn.Press(); // Output: Button was clicked!


			#endregion
		}
	}
}
