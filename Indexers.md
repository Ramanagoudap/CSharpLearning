# **Indexers and Extension Methods in C# (Detailed Explanation)**

## **1. What is an Indexer?**
An **indexer** in C# allows objects of a class to be indexed like arrays. It provides a way to access a class’s elements using **array-like syntax** instead of traditional method calls.

### **Key Features of Indexers**
- Allow objects to be accessed like arrays.
- Use the `this` keyword.
- Can be overloaded.
- Can have different accessors (`get` and `set`).
- Work with one or more parameters.

---

## **2. Syntax of an Indexer**
An indexer is defined using the `this` keyword followed by a parameter list inside square brackets (`[]`).

```csharp
class ClassName
{
    private DataType[] array = new DataType[size]; // Internal storage

    public DataType this[int index]  // Indexer declaration
    {
        get { return array[index]; }  // Getter
        set { array[index] = value; } // Setter
    }
}
```

---

## **3. Example of a Simple Indexer**
### **Example: Creating an Indexer for a Custom Class**
```csharp
using System;

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

class Program
{
    static void Main()
    {
        Student studentList = new Student();

        // Assign values using the indexer
        studentList[0] = "Alice";
        studentList[1] = "Bob";
        studentList[2] = "Charlie";

        // Access values using the indexer
        Console.WriteLine(studentList[0]); // Output: Alice
        Console.WriteLine(studentList[1]); // Output: Bob
        Console.WriteLine(studentList[2]); // Output: Charlie
    }
}
```

---

## **4. Extension Methods in C#**
### **What are Extension Methods?**
Extension methods allow you to **add new methods** to existing types **without modifying their definition**. They enable extending the functionality of classes, including built-in .NET types, third-party libraries, or your own custom classes.

### **Key Features of Extension Methods**
- Defined as **static methods** in **static classes**.
- Use the `this` keyword in the first parameter to specify the type being extended.
- Can be called as if they were instance methods of the extended type.
- Useful for adding functionality to sealed classes like `string`, `int`, etc.

---

## **5. Syntax of an Extension Method**
```csharp
public static class ExtensionClass
{
    public static ReturnType MethodName(this ExtendedType obj, Parameters)
    {
        // Method body
    }
}
```

### **Example: Extending the `string` Class**
```csharp
using System;

static class StringExtensions
{
    // Extension method to count words in a string
    public static int WordCount(this string str)
    {
        return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }
}

class Program
{
    static void Main()
    {
        string sentence = "Hello world, how are you?";
        Console.WriteLine(sentence.WordCount()); // Output: 5
    }
}
```

### **Explanation:**
- `WordCount` is an extension method for the `string` type.
- It splits the string by spaces and punctuation and counts the words.
- The method is called like a built-in method on any `string` instance.

---

## **6. Extension Methods for Custom Classes**
You can create extension methods for your own classes as well.

### **Example: Adding an Extension Method to a Class**
```csharp
using System;

class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
}

static class EmployeeExtensions
{
    public static void DisplayInfo(this Employee emp)
    {
        Console.WriteLine($"Employee: {emp.Name}, Age: {emp.Age}");
    }
}

class Program
{
    static void Main()
    {
        Employee emp = new Employee { Name = "John Doe", Age = 30 };
        emp.DisplayInfo(); // Output: Employee: John Doe, Age: 30
    }
}
```

### **Explanation:**
- `DisplayInfo` is an extension method for the `Employee` class.
- The method prints the employee's name and age.
- It is used as if it were part of the `Employee` class.

---

## **7. When to Use Extension Methods?**
✅ When you want to **add functionality** to an existing type **without modifying its source code**.  
✅ When you work with **sealed classes** like `string`, `DateTime`, `Math`, etc.  
✅ When you need **reusable utility methods** for commonly used types.  
✅ When you want to improve **code readability and maintainability**.  

---

## **8. Summary**
✅ **Indexers** allow objects to be accessed like arrays using `this[]`.  
✅ **Extension Methods** let you **add new methods** to existing types **without modifying them**.  
✅ Both features improve **code flexibility** and **usability**.  

Would you like more examples or further explanations? 🚀

