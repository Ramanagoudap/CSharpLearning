# **C# Delegates in Detail**

## **What is a Delegate?**
A **delegate** in C# is a type that represents references to methods with a specific signature. It is similar to function pointers in C++ but is type-safe. 

### **Why Use Delegates?**
- Encapsulate methods into objects.
- Pass methods as parameters.
- Support event-driven programming.
- Enable callback mechanisms.
- Promote decoupling between components.

---

## **Syntax of Delegates**
### **Declaring a Delegate**
A delegate must match the signature of the method it will reference.

```csharp
// Define a delegate
public delegate void MyDelegate(string message);
```

### **Using a Delegate**
```csharp
using System;

class Program
{
    // Step 1: Declare a delegate
    public delegate void PrintMessage(string message);

    // Step 2: Create a method matching the delegate signature
    public static void ShowMessage(string msg)
    {
        Console.WriteLine(msg);
    }

    static void Main()
    {
        // Step 3: Instantiate the delegate
        PrintMessage del = ShowMessage;

        // Step 4: Invoke the delegate
        del("Hello, Delegates!");
    }
}
```

**Output:**
```
Hello, Delegates!
```

---

## **Types of Delegates**
### 1️⃣ **Single-Cast Delegate**
A delegate that refers to a **single** method.

```csharp
public delegate void SingleDelegate(string msg);
```
- Can hold a reference to **only one** method at a time.

### 2️⃣ **Multi-Cast Delegate**
A delegate that refers to **multiple** methods using `+=` and `-=`.

```csharp
public delegate void MultiDelegate(string msg);

class Program
{
    static void Method1(string message) => Console.WriteLine("Method1: " + message);
    static void Method2(string message) => Console.WriteLine("Method2: " + message);

    static void Main()
    {
        MultiDelegate del = Method1;
        del += Method2; // Add another method

        del("Hello");

        del -= Method1; // Remove Method1
        del("Again");
    }
}
```

**Output:**
```
Method1: Hello
Method2: Hello
Method2: Again
```

### 3️⃣ **Func, Action, and Predicate Delegates**
C# provides built-in delegates:

#### **🔹 Func Delegate**
Used for methods that **return a value**.

```csharp
Func<int, int, int> add = (a, b) => a + b;
Console.WriteLine(add(5, 10)); // Output: 15
```

#### **🔹 Action Delegate**
Used for methods that **do not return a value**.

```csharp
Action<string> greet = name => Console.WriteLine("Hello, " + name);
greet("Alice"); // Output: Hello, Alice
```

#### **🔹 Predicate Delegate**
Used for methods that **return a boolean**.

```csharp
Predicate<int> isEven = num => num % 2 == 0;
Console.WriteLine(isEven(4)); // Output: True
```

---

## **Delegates as Method Parameters**
Delegates are often used to pass methods as parameters.

```csharp
class Program
{
    public delegate void PrintDelegate(string msg);

    static void PrintUpper(string msg) => Console.WriteLine(msg.ToUpper());
    static void PrintLower(string msg) => Console.WriteLine(msg.ToLower());

    static void ProcessMessage(string message, PrintDelegate print)
    {
        print(message);
    }

    static void Main()
    {
        ProcessMessage("Hello World", PrintUpper);
        ProcessMessage("Hello World", PrintLower);
    }
}
```

**Output:**
```
HELLO WORLD
hello world
```

---

## **Delegates with Events**
Delegates are the foundation of **event handling** in C#.

```csharp
using System;

class Button
{
    public delegate void ClickHandler();
    public event ClickHandler Click; // Define an event

    public void Press()
    {
        Click?.Invoke(); // Trigger the event if any subscribers exist
    }
}

class Program
{
    static void ButtonClicked() => Console.WriteLine("Button was clicked!");

    static void Main()
    {
        Button btn = new Button();
        btn.Click += ButtonClicked; // Subscribe to event

        btn.Press(); // Output: Button was clicked!
    }
}
```

---

## **Advantages of Delegates**
✅ **Encapsulation** – Methods can be treated as first-class objects.  
✅ **Flexibility** – Enables dynamic method execution.  
✅ **Reusability** – Can be used across multiple classes.  
✅ **Event Handling** – Forms the base of event-driven programming.  

## **Limitations of Delegates**
❌ Harder to debug when multiple methods are subscribed.  
❌ Performance overhead due to invocation via references.  

---

## **Summary Table**
| Feature            | Description |
|--------------------|-------------|
| **Definition**    | A type that holds references to methods. |
| **Usage**        | Callback functions, event handling, passing methods as parameters. |
| **Types**        | Single-cast, multi-cast, built-in (`Func`, `Action`, `Predicate`). |
| **Syntax**        | `public delegate void MyDelegate(string message);` |
| **Events**       | Delegates are the foundation of events in C#. |
