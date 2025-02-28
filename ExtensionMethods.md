### **C# Extension Methods in Detail**

#### **What are Extension Methods?**
Extension methods in C# allow you to add new methods to existing types without modifying their source code. They are static methods that appear as instance methods on the extended type.

#### **When to Use Extension Methods?**
- When you cannot modify the original class (e.g., it's from a third-party library or a built-in .NET type).
- To enhance code readability by making utility methods available as if they were instance methods.
- To group related functionality in a separate static class.

---

### **How to Create an Extension Method**
#### **Syntax of an Extension Method**
1. The method must be **static**.
2. It must be inside a **static class**.
3. The first parameter must use the **this** keyword followed by the type it extends.

#### **Example 1: Extending `string`**
```csharp
public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string value)
    {
        return string.IsNullOrEmpty(value);
    }
}

// Usage:
string message = null;
bool result = message.IsNullOrEmpty(); // Works like an instance method
Console.WriteLine(result); // Output: True
```

---

### **Key Rules of Extension Methods**
1. **They do not modify the original class but provide additional behavior.**
2. **They must be in a static class.**
3. **If an instance method and an extension method have the same name, the instance method takes priority.**
4. **They can be called using the extended type just like instance methods.**
5. **They work with any type, including value types, reference types, interfaces, and even generic types.**

---

### **Example 2: Extending an `int` Type**
```csharp
public static class IntExtensions
{
    public static bool IsEven(this int number)
    {
        return number % 2 == 0;
    }
}

// Usage:
int num = 10;
Console.WriteLine(num.IsEven()); // Output: True
```

---

### **Example 3: Extending `List<T>`**
```csharp
using System.Collections.Generic;

public static class ListExtensions
{
    public static void PrintAll<T>(this List<T> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}

// Usage:
List<int> numbers = new List<int> { 1, 2, 3, 4 };
numbers.PrintAll();
```

---

### **Example 4: Extending an Interface**
You can extend an interface, and all implementations of that interface will automatically have access to the method.

```csharp
public interface IAnimal
{
    void Speak();
}

public class Dog : IAnimal
{
    public void Speak() => Console.WriteLine("Bark");
}

public static class AnimalExtensions
{
    public static void Describe(this IAnimal animal)
    {
        Console.WriteLine("This is an animal.");
    }
}

// Usage:
IAnimal dog = new Dog();
dog.Speak();     // Output: Bark
dog.Describe();  // Output: This is an animal.
```

---

### **Example 5: Generic Extension Methods**
```csharp
public static class GenericExtensions
{
    public static bool IsDefault<T>(this T value)
    {
        return EqualityComparer<T>.Default.Equals(value, default);
    }
}

// Usage:
int number = 0;
Console.WriteLine(number.IsDefault()); // Output: True

string text = null;
Console.WriteLine(text.IsDefault()); // Output: True
```

---

### **Limitations of Extension Methods**
- They **cannot access private or protected members** of the extended type.
- They **cannot override existing methods**; instance methods always take priority.
- If the class already has a method with the same name and signature, **the extension method will be ignored**.
- They **cannot introduce new fields or properties**.

---

### **Best Practices**
✅ **Use extension methods for utility-like operations.**  
✅ **Keep them in a dedicated static class.**  
✅ **Do not overuse them; prefer instance methods if you own the class.**  
✅ **Follow naming conventions similar to built-in methods.**  

---

### **When NOT to Use Extension Methods**
❌ When you **can modify the original class** (prefer instance methods).  
❌ When you **need to store state** (use normal class members instead).  
❌ When it makes code **less readable or ambiguous**.  

---

### **Real-World Example: LINQ**
C# LINQ methods like `.Where()`, `.Select()`, and `.OrderBy()` are implemented as extension methods on `IEnumerable<T>`.

```csharp
using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
        var evenNumbers = numbers.Where(n => n % 2 == 0);
        
        foreach (var num in evenNumbers)
        {
            Console.WriteLine(num); // Output: 2, 4
        }
    }
}
```

---

### **Summary**
| Feature               | Description |
|-----------------------|-------------|
| **Definition**        | Adds new methods to existing types without modifying them. |
| **Location**         | Must be inside a static class. |
| **Invocation**       | Called as if they were instance methods. |
| **Limitations**      | Cannot override existing methods, access private members, or introduce new fields. |
| **Common Use Cases** | Utility functions, LINQ operations, improving code readability. |