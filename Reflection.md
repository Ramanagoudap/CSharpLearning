
# 🔍 Reflection in C#

## 📌 Introduction
Reflection in C# is a powerful feature that allows **introspection and manipulation of metadata, types, methods, and properties at runtime**. It is part of the `System.Reflection` namespace.

### ✅ **Why Use Reflection?**
- To inspect **assemblies, types, methods, and properties** at runtime.
- To **dynamically invoke methods and access private members**.
- To create **plugin-based applications** where types are loaded dynamically.
- Used in **ORM frameworks**, **dependency injection**, **unit testing**, and **serialization**.

---

## 🔹 Namespaces Used for Reflection
| **Namespace** | **Description** |
|--------------|----------------|
| `System.Type` | Provides information about types (classes, structs, interfaces, etc.) |
| `System.Reflection` | Provides classes to inspect metadata and interact with members dynamically |
| `System.Reflection.Emit` | Used for **dynamic code generation** at runtime |

---

## 🔹 Getting Type Information (`Type` Class)
The `Type` class provides **metadata about a type** (e.g., class name, namespace, methods, properties).

### **Example: Getting Type Information**
```csharp
using System;

class Example
{
    public int Id { get; set; }
    public void Display() => Console.WriteLine("Hello Reflection!");
}

class Program
{
    static void Main()
    {
        Type type = typeof(Example); // Get type information

        Console.WriteLine($"Class Name: {type.Name}");
        Console.WriteLine($"Namespace: {type.Namespace}");
        Console.WriteLine($"Base Type: {type.BaseType}");
    }
}
```
✅ **Output:**
```
Class Name: Example
Namespace: (your namespace)
Base Type: System.Object
```

---

## 🔹 Getting Methods, Properties, and Fields
### **Example: Listing Methods and Properties**
```csharp
using System;
using System.Reflection;

class Example
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Display() => Console.WriteLine("Hello Reflection!");
}

class Program
{
    static void Main()
    {
        Type type = typeof(Example);

        Console.WriteLine("Methods:");
        foreach (MethodInfo method in type.GetMethods())
        {
            Console.WriteLine(method.Name);
        }

        Console.WriteLine("\nProperties:");
        foreach (PropertyInfo prop in type.GetProperties())
        {
            Console.WriteLine(prop.Name);
        }
    }
}
```
✅ **Output:**
```
Methods:
get_Id
set_Id
get_Name
set_Name
Display
GetType
ToString
Equals
GetHashCode

Properties:
Id
Name
```

---

## 🔹 Getting Constructors
### **Example: Listing Constructors**
```csharp
using System;
using System.Reflection;

class Example
{
    public Example() { }
    public Example(int id) { }
}

class Program
{
    static void Main()
    {
        Type type = typeof(Example);

        Console.WriteLine("Constructors:");
        foreach (ConstructorInfo ctor in type.GetConstructors())
        {
            Console.WriteLine(ctor);
        }
    }
}
```
✅ **Output:**
```
Constructors:
Void .ctor()
Void .ctor(Int32)
```

---

## 🔹 Dynamically Invoking Methods
Reflection allows us to **invoke methods dynamically** at runtime.

### **Example: Invoke a Method Using Reflection**
```csharp
using System;
using System.Reflection;

class Example
{
    public void Display() => Console.WriteLine("Reflection Method Invocation!");
}

class Program
{
    static void Main()
    {
        Type type = typeof(Example);
        object obj = Activator.CreateInstance(type); // Create instance dynamically

        MethodInfo method = type.GetMethod("Display");
        method.Invoke(obj, null); // Invoke method dynamically
    }
}
```
✅ **Output:**
```
Reflection Method Invocation!
```

---

## 🔹 Working with Fields
Reflection allows **reading and modifying private fields**.

### **Example: Access Private Fields**
```csharp
using System;
using System.Reflection;

class Example
{
    private int secretNumber = 42;
}

class Program
{
    static void Main()
    {
        Example example = new Example();
        Type type = typeof(Example);

        FieldInfo field = type.GetField("secretNumber", BindingFlags.NonPublic | BindingFlags.Instance);

        int value = (int)field.GetValue(example); // Read private field
        Console.WriteLine($"Secret Number: {value}");

        field.SetValue(example, 100); // Modify private field
        Console.WriteLine($"Updated Secret Number: {field.GetValue(example)}");
    }
}
```
✅ **Output:**
```
Secret Number: 42
Updated Secret Number: 100
```

---

## 🔹 Loading Assemblies at Runtime
Reflection can be used to **dynamically load external assemblies**.

### **Example: Load an Assembly and List Its Types**
```csharp
using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        Assembly assembly = Assembly.Load("System.Core"); // Load assembly

        Console.WriteLine($"Assembly: {assembly.FullName}");
        Console.WriteLine("Types in Assembly:");
        foreach (Type type in assembly.GetTypes())
        {
            Console.WriteLine(type.FullName);
        }
    }
}
```

---

## 🔹 Creating Objects Dynamically
We can **create objects at runtime** using `Activator.CreateInstance()`.

### **Example: Instantiate a Class Dynamically**
```csharp
using System;

class Example
{
    public Example() => Console.WriteLine("Example Class Instance Created!");
}

class Program
{
    static void Main()
    {
        Type type = typeof(Example);
        object obj = Activator.CreateInstance(type); // Create instance dynamically
    }
}
```
✅ **Output:**
```
Example Class Instance Created!
```

---

## 🔹 Practical Use Cases of Reflection
| **Use Case** | **Description** |
|-------------|----------------|
| **Plugin-Based Applications** | Dynamically load modules and classes |
| **Serialization** | Convert objects to XML/JSON |
| **Dependency Injection** | Create and inject dependencies at runtime |
| **Unit Testing** | Mock objects and test private methods |
| **ORM (Object-Relational Mapping)** | Map database tables to C# objects dynamically |

---

## 📌 Summary Table

| **Feature** | **Method Used** |
|------------|----------------|
| **Get Type Information** | `typeof(ClassName)`, `GetType()` |
| **List Methods** | `GetMethods()` |
| **List Properties** | `GetProperties()` |
| **List Fields** | `GetFields()` |
| **List Constructors** | `GetConstructors()` |
| **Invoke Methods Dynamically** | `MethodInfo.Invoke()` |
| **Access Private Members** | `BindingFlags.NonPublic` |
| **Load Assemblies** | `Assembly.Load()` |
| **Create Objects Dynamically** | `Activator.CreateInstance()` |

---

## 📌 Best Practices
✅ **Use Reflection when necessary** – It can impact performance.  
✅ **Avoid excessive use of Reflection** – Use interfaces or generics instead.  
✅ **Use `BindingFlags` carefully** – Prevent access to unintended members.  
✅ **Cache Reflection results** – Reduces performance overhead.  
✅ **Use Reflection Emit for dynamic code generation** – If needed.  

---

## 📌 Conclusion
- Reflection allows **runtime inspection and modification** of types, methods, and properties.
- It is **widely used** in **plugin systems, DI, serialization, and testing**.
- It should be **used wisely** as it **affects performance**.
- .NET provides various APIs (`System.Reflection`, `Activator`, `Assembly`) to leverage Reflection efficiently.

---