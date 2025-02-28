namespace Encapsulation
{
	internal class Program
	{
		/*
		 Encapsulation is the bundling of data (fields) and the methods (functions) that operate on the data into a single unit (class). 
		It also means restricting access to the inner workings of an object, exposing only what is necessary through access modifiers and properties.

		Key Points of Encapsulation:

			Access Modifiers: C# uses public, private, protected, and internal to control access to members of a class.
				private: The member is accessible only within the same class.
				public: The member is accessible from any other class.
				protected: The member is accessible within the same class or in derived classes.
				internal: The member is accessible only within the same assembly.
		 */
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
		}
	}

	public class BankAccount
	{
		// Private field, cannot be accessed directly outside the class
		private decimal balance;

		// Public property with custom getter and setter (encapsulation)
		public decimal Balance
		{
			get { return balance; } // Only provides read access
			private set { balance = value; } // Allows writing only within the class
		}

		// Constructor to initialize the bank account
		public BankAccount(decimal initialBalance)
		{
			if (initialBalance < 0)
				throw new ArgumentException("Initial balance cannot be negative.");
			Balance = initialBalance;
		}

		// Public method to deposit money (encapsulating the logic)
		public void Deposit(decimal amount)
		{
			if (amount <= 0)
				throw new ArgumentException("Deposit amount must be greater than zero.");
			Balance += amount;
		}

		// Public method to withdraw money (encapsulating the logic)
		public bool Withdraw(decimal amount)
		{
			if (amount <= 0)
				throw new ArgumentException("Withdrawal amount must be greater than zero.");

			if (amount > Balance)
			{
				Console.WriteLine("Insufficient funds!");
				return false;
			}

			Balance -= amount;
			return true;
		}
	}

	/*
		Private Field (balance): This variable stores the account balance. It’s not directly accessible from outside the class. This ensures that the balance can only be modified through controlled methods.

		Public Property (Balance): The property provides controlled access to the balance field. The get accessor allows reading the balance, but the set accessor is private, meaning it can only be changed within the class (not directly from outside).
    
		Methods (Deposit, Withdraw): These methods manage the balance safely and encapsulate the logic for depositing and withdrawing money.
	 */

	/*
		Benefits of Encapsulation:

			Control: You can control how data is accessed and modified (e.g., validating inputs).
			Protection: The internal state is protected from unintended external modification.
			Maintainability: Changes to internal implementation won’t affect other parts of the code because the class exposes only necessary functionality.
	 */
}
