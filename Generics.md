# 🚀 Generics in C#

## 📌 Introduction
Generics in C# allow developers to **define classes, interfaces, and methods with type parameters**. This enables **code reusability, type safety, and performance optimization**.

### **Why Use Generics?**
✅ **Code Reusability** – Write one method or class for multiple data types.  
✅ **Type Safety** – Prevents runtime errors by ensuring type correctness at compile time.  
✅ **Performance** – Avoids boxing/unboxing overhead in value types.  

---

## 🔹 Basic Syntax of Generics
Generics use **type parameters** enclosed in `< >`.

```csharp
public class GenericClass<T>
{
    public T Value { get; set; }
}
```

Here, `T` is a **placeholder** for any data type.

---

## 🔹 Generic Classes
A **generic class** allows you to create a class that works with multiple data types.

### **Example: Generic Class**
```csharp
class Box<T>
{
    private T item;

    public void AddItem(T newItem) => item = newItem;
    public T GetItem() => item;
}

class Program
{
    static void Main()
    {
        Box<int> intBox = new Box<int>();
        intBox.AddItem(10);
        Console.WriteLine(intBox.GetItem()); // Output: 10

        Box<string> stringBox = new Box<string>();
        stringBox.AddItem("Hello");
        Console.WriteLine(stringBox.GetItem()); // Output: Hello
    }
}
```

### **Key Points**:
- `T` is a **type parameter**.
- We can use `Box<int>` or `Box<string>` **without code duplication**.

---

## 🔹 Generic Methods
A **generic method** works for multiple data types without rewriting code.

### **Example: Generic Method**
```csharp
class Utility
{
    public static void Print<T>(T message)
    {
        Console.WriteLine(message);
    }
}

class Program
{
    static void Main()
    {
        Utility.Print(100);        // Output: 100
        Utility.Print("Hello");    // Output: Hello
        Utility.Print(5.5);        // Output: 5.5
    }
}
```

### **Key Points**:
- `<T>` is **declared within the method**.
- The method can accept **any type**.

---

## 🔹 Generic Interfaces
A **generic interface** defines type flexibility while enforcing contracts.

### **Example: Generic Interface**
```csharp
interface IRepository<T>
{
    void Add(T item);
    T Get(int id);
}

class UserRepository : IRepository<string>
{
    private Dictionary<int, string> users = new Dictionary<int, string>();

    public void Add(string user) => users[users.Count] = user;
    public string Get(int id) => users.ContainsKey(id) ? users[id] : "Not Found";
}

class Program
{
    static void Main()
    {
        IRepository<string> repo = new UserRepository();
        repo.Add("Alice");
        Console.WriteLine(repo.Get(0)); // Output: Alice
    }
}
```

### **Key Points**:
- `IRepository<T>` can be used with **different types**.
- `UserRepository` **implements the generic interface**.

---

## 🔹 Constraints in Generics
We can **restrict** the types that can be used with generics.

### **Common Generic Constraints**
| **Constraint**  | **Description** |
|---------------|----------------|
| `where T : struct` | T must be a **value type** (int, float, etc.) |
| `where T : class`  | T must be a **reference type** (class, interface, etc.) |
| `where T : new()`  | T must have a **parameterless constructor** |
| `where T : BaseClass` | T must inherit from **BaseClass** |
| `where T : IInterface` | T must implement **IInterface** |

---

### **Example: Using Constraints**
```csharp
class DataProcessor<T> where T : class, new()
{
    public T CreateInstance() => new T();
}

class Program
{
    static void Main()
    {
        DataProcessor<StringBuilder> processor = new DataProcessor<StringBuilder>();
        var instance = processor.CreateInstance();
        Console.WriteLine(instance.GetType().Name); // Output: StringBuilder
    }
}
```

### **Key Points**:
- `T : class` **ensures only reference types**.
- `T : new()` **ensures a parameterless constructor is available**.

---

## 🔹 Generic Collections
C# provides **built-in generic collections** in `System.Collections.Generic`.

### **Common Generic Collections**
| **Collection** | **Description** |
|--------------|----------------|
| `List<T>`    | Dynamic array |
| `Dictionary<K, V>` | Key-value pair storage |
| `Queue<T>`   | FIFO (First In, First Out) structure |
| `Stack<T>`   | LIFO (Last In, First Out) structure |

---

### **Example: List<T>**
```csharp
List<int> numbers = new List<int> { 1, 2, 3 };
numbers.Add(4);
Console.WriteLine(numbers[2]); // Output: 3
```

### **Example: Dictionary<K, V>**
```csharp
Dictionary<int, string> users = new Dictionary<int, string>
{
    {1, "Alice"},
    {2, "Bob"}
};
Console.WriteLine(users[1]); // Output: Alice
```

---

## 📌 Summary Table

| **Feature**       | **Description** |
|------------------|----------------|
| **Generic Class** | Allows flexible type usage in classes (`class MyClass<T>`) |
| **Generic Method** | Enables type-independent methods (`void Method<T>()`) |
| **Generic Interface** | Defines contracts with generic types (`interface IRepo<T>`) |
| **Constraints** | Restricts allowed types (`where T : class`) |
| **Generic Collections** | Built-in collections (`List<T>`, `Dictionary<K,V>`) |

---

## 📌 Conclusion
- Generics **improve code reusability, type safety, and performance**.
- Use **constraints** to enforce type rules.
- Utilize **built-in generic collections** for efficiency.

---