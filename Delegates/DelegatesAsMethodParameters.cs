namespace Delegates
{
	/// <summary>
	/// Delegates are often used to pass methods as parameters.
	/// </summary>
	public class DelegatesAsMethodParameters
	{
		public delegate void PrintDelegate(string msg);

		public static void PrintUpper(string msg) => Console.WriteLine(msg.ToUpper());
		public static void PrintLower(string msg) => Console.WriteLine(msg.ToLower());

		public static void ProcessMessage(string message, PrintDelegate print)
		{
			print(message);
		}
	}
}
