# Exception Handling in C#

## 📌 Introduction
Exception handling in C# is a mechanism that allows developers to gracefully handle runtime errors. It helps in **maintaining the flow of execution** and **preventing crashes** due to unexpected situations.

### Why Use Exception Handling?
✅ Prevents program crashes  
✅ Helps identify and debug errors  
✅ Improves code reliability and maintainability  

---

## 🚀 Keywords Used in Exception Handling

| **Keyword**    | **Description** |
|--------------|----------------|
| `try`       | Defines a block of code to monitor for exceptions |
| `catch`     | Handles the exception that occurs in the `try` block |
| `finally`   | A block that always executes, whether an exception occurs or not |
| `throw`     | Used to explicitly throw an exception |
| `throws`    | (Not in C#, exists in Java) |

---

## 🔹 Basic Exception Handling using `try` and `catch`
```csharp
try
{
    int num1 = 10, num2 = 0;
    int result = num1 / num2; // Division by zero
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("Cannot divide by zero!");
}
```
### **Explanation**:
- The `try` block contains the **risky code**.
- The `catch` block **handles the exception** gracefully.

---

## 🔹 Multiple `catch` Blocks
You can have multiple `catch` blocks to handle different exception types.

```csharp
try
{
    int[] numbers = { 1, 2, 3 };
    Console.WriteLine(numbers[5]); // Index out of range
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine("Index is out of range.");
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}
```
### **Explanation**:
- The first `catch` handles `IndexOutOfRangeException`.
- The second `catch` is a **generic exception handler**.

---

## 🔹 Using `finally` Block
The `finally` block always executes, whether an exception occurs or not.

```csharp
try
{
    Console.WriteLine("Opening file...");
    // Simulating an exception
    throw new Exception("File not found!");
}
catch (Exception ex)
{
    Console.WriteLine($"Exception: {ex.Message}");
}
finally
{
    Console.WriteLine("Closing file...");
}
```
### **Output**:
```
Opening file...
Exception: File not found!
Closing file...
```

### **When to Use `finally`?**
✅ Releasing resources (e.g., closing database connections, files)  
✅ Cleaning up memory  

---

## 🔹 Throwing Exceptions using `throw`
The `throw` statement is used to explicitly raise exceptions.

```csharp
static void CheckAge(int age)
{
    if (age < 18)
        throw new ArgumentException("Age must be 18 or above!");
}

try
{
    CheckAge(16);
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message); // Output: Age must be 18 or above!
}
```
### **Key Points**:
- `throw` is used inside the function to raise an error.
- The exception is caught in the `catch` block.

---

## 🔹 Custom Exceptions in C#
You can create your own **custom exception** by extending the `Exception` class.

```csharp
class CustomException : Exception
{
    public CustomException(string message) : base(message) { }
}

static void Validate(int value)
{
    if (value < 0)
        throw new CustomException("Negative value is not allowed!");
}

try
{
    Validate(-5);
}
catch (CustomException ex)
{
    Console.WriteLine(ex.Message); // Output: Negative value is not allowed!
}
```

### **Why Use Custom Exceptions?**
✅ Helps differentiate between different error types  
✅ Improves debugging and logging  

---

## 📌 Best Practices for Exception Handling
✔ **Use specific exception types (`catch` specific errors like `NullReferenceException`)**  
✔ **Avoid empty `catch` blocks (always log errors)**  
✔ **Use `finally` to clean up resources**  
✔ **Do not use exceptions for flow control**  
✔ **Use `throw;` to rethrow exceptions properly**  

```csharp
try
{
    throw new InvalidOperationException("Invalid operation occurred!");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine("Logging error...");
    throw; // Rethrow the original exception
}
```

---

## 📌 Summary Table

| **Concept**          | **Description** |
|---------------------|----------------|
| `try`              | Defines the block of code to monitor for exceptions |
| `catch`            | Catches and handles the exception |
| `finally`          | Executes code regardless of exception occurrence |
| `throw`            | Explicitly throws an exception |
| Multiple `catch`   | Handles different exceptions separately |
| Custom Exceptions  | Allows creation of user-defined exceptions |

---

## 📌 Conclusion
- **Exception handling** is essential for writing robust applications.
- Always **catch specific exceptions** to improve debugging.
- Use `finally` for **resource cleanup**.
- Create **custom exceptions** when needed.

---