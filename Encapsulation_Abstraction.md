## **1. Encapsulation in C#**
Encapsulation is the **bundling of data** (fields) and the methods (functions) that operate on the data into a **single unit** (class). It also means restricting access to the inner workings of an object, exposing only what is necessary through **access modifiers** and **properties**.

### **Key Points of Encapsulation:**
- **Access Modifiers**: C# uses `public`, `private`, `protected`, and `internal` to control access to members of a class.
  - **private**: The member is accessible only within the same class.
  - **public**: The member is accessible from any other class.
  - **protected**: The member is accessible within the same class or in derived classes.
  - **internal**: The member is accessible only within the same assembly.
  
### **A. Example of Encapsulation**

Let’s create a `BankAccount` class where the balance is encapsulated and cannot be modified directly.

```csharp
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
```

### **Explanation:**
- **Private Field (`balance`)**: This variable stores the account balance. It’s **not directly accessible** from outside the class. This ensures that the balance can only be modified through controlled methods.
- **Public Property (`Balance`)**: The property provides **controlled access** to the `balance` field. The `get` accessor allows reading the balance, but the `set` accessor is **private**, meaning it can only be changed within the class (not directly from outside).
- **Methods (`Deposit`, `Withdraw`)**: These methods manage the balance safely and encapsulate the logic for depositing and withdrawing money.

### **B. Benefits of Encapsulation:**
1. **Control**: You can control how data is accessed and modified (e.g., validating inputs).
2. **Protection**: The internal state is protected from unintended external modification.
3. **Maintainability**: Changes to internal implementation won’t affect other parts of the code because the class exposes only necessary functionality.

---

## **2. Abstraction in C#**
Abstraction is the **concept of hiding the complex implementation** details of a class and exposing only the essential features or operations. This is done using **abstract classes**, **interfaces**, and **abstract methods**.

### **Key Points of Abstraction:**
- **Abstract Classes**: Can have both abstract methods (without implementation) and concrete methods (with implementation). A class derived from an abstract class must implement all abstract methods.
- **Interfaces**: Define a contract (method signatures) but don’t provide any implementation. A class that implements an interface must implement all methods defined in the interface.

### **A. Example of Abstraction with Abstract Class**

Let’s create a `Shape` class where different shapes (Circle, Rectangle) have their own implementation of calculating the area.

```csharp
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

class Program
{
    static void Main()
    {
        Shape circle = new Circle(5);
        Shape rectangle = new Rectangle(4, 6);

        circle.DisplayArea();  // Output: Area: 78.53981633974483
        rectangle.DisplayArea();  // Output: Area: 24
    }
}
```

### **Explanation:**
- **Abstract Class `Shape`**: The `Shape` class defines an abstract method `CalculateArea()`, which **must be implemented** by any derived class. It also provides a concrete method `DisplayArea()` that can be reused by all derived classes.
- **Concrete Subclasses `Circle` and `Rectangle`**: Both `Circle` and `Rectangle` provide their specific implementation of the `CalculateArea` method.
- **Encapsulation**: The internal properties (`Radius`, `Width`, `Height`) are encapsulated and not directly exposed. Only the necessary methods for calculation are available to the outside world.

### **B. Abstraction with Interfaces**

An interface is similar to an abstract class but can only define method signatures and properties (without any implementation). A class can implement multiple interfaces, unlike abstract classes where only single inheritance is allowed.

```csharp
// Defining an interface
public interface IDrawable
{
    void Draw();
}

// Concrete class implementing the interface
public class Circle : IDrawable
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Circle");
    }
}

public class Square : IDrawable
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Square");
    }
}

class Program
{
    static void Main()
    {
        IDrawable drawable1 = new Circle();
        IDrawable drawable2 = new Square();

        drawable1.Draw();  // Output: Drawing a Circle
        drawable2.Draw();  // Output: Drawing a Square
    }
}
```

### **Explanation:**
- **Interface `IDrawable`**: It defines a `Draw` method that all classes implementing it must provide. It doesn’t have any implementation details itself, which is why it serves as an abstraction.
- **Concrete Classes**: Both `Circle` and `Square` implement the `IDrawable` interface, meaning they must provide their own implementation of `Draw`.

### **C. Benefits of Abstraction:**
1. **Simplicity**: It simplifies interaction with objects by hiding their complexity.
2. **Flexibility**: Different implementations can be easily substituted, especially with interfaces.
3. **Maintainability**: You can change the internal workings of an object without affecting code that uses it.

---

## **Key Differences Between Encapsulation and Abstraction**

| **Concept**          | **Encapsulation**                                  | **Abstraction**                                    |
|----------------------|----------------------------------------------------|----------------------------------------------------|
| **Definition**        | Encapsulation is the bundling of data and methods. | Abstraction is hiding the complex implementation details. |
| **Purpose**           | Protect internal state and control access.        | Simplify the interface and hide complexity.        |
| **Access Control**    | Uses access modifiers (`private`, `public`, etc.). | Defines what can be accessed, often through abstract methods or interfaces. |
| **Focus**             | How data is stored and accessed.                  | What functionality is exposed and how it behaves.  |
| **Example**           | Private fields, properties, and methods.           | Abstract classes, interfaces, and abstract methods. |

---

### **Summary**
- **Encapsulation** focuses on **hiding the internal state** of objects and controlling access to it through methods and properties. It allows you to protect data from unintended modifications.
- **Abstraction** focuses on **hiding complexity** by exposing only necessary functionality. It simplifies the interface while allowing flexibility in implementation.

Both principles are important for building **clean, maintainable, and scalable software** in C#. 