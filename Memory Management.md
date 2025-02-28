
# 🚀 Memory Management in C#

## 📌 Introduction
Memory management in C# is **automated** by the **.NET runtime (CLR - Common Language Runtime)**. It helps in **allocating, using, and freeing memory efficiently** to prevent memory leaks and improve performance.

### **Key Components of Memory Management**
✅ **Stack and Heap Memory** – Organizes data storage  
✅ **Garbage Collection (GC)** – Automatically reclaims unused memory  
✅ **Dispose and Finalize** – Explicit resource cleanup  
✅ **Value Types vs Reference Types** – Affects memory allocation  

---

## 🔹 Stack vs Heap Memory

| **Aspect**   | **Stack** | **Heap** |
|-------------|----------|----------|
| **Storage Type** | Stores **value types** and method execution details | Stores **reference types** |
| **Memory Size** | Small and fixed | Large and dynamically allocated |
| **Access Speed** | Very fast | Slower than stack |
| **Scope** | Local to the method | Global (exists until GC removes it) |

### **Example of Stack and Heap Memory Allocation**
```csharp
class Program
{
    static void Main()
    {
        int x = 10; // Stored in Stack
        Person person = new Person(); // Reference stored in Stack, Object stored in Heap
    }
}

class Person
{
    public string Name;
}
```

### **Explanation**
- `x = 10` is a **value type**, so it is stored in the **stack**.
- `Person` is a **reference type**:
  - The **reference** (`person`) is stored in the **stack**.
  - The **object** (actual data) is stored in the **heap**.

---

## 🔹 Garbage Collection (GC)

The **Garbage Collector (GC)** in C# automatically **reclaims memory** occupied by objects that are no longer accessible.

### **Generations in GC**
| **Generation** | **Description** |
|--------------|----------------|
| **Gen 0** | Newly allocated objects (short-lived) |
| **Gen 1** | Objects that survived **one** GC cycle |
| **Gen 2** | Long-lived objects (e.g., static objects, application-wide data) |

### **Forcing Garbage Collection**
Although GC runs automatically, you can force it manually (not recommended):

```csharp
GC.Collect(); // Forces garbage collection
GC.WaitForPendingFinalizers(); // Ensures finalizers execute
```

---

## 🔹 `Dispose` and `Finalize` (Explicit Resource Management)

### **Using `IDisposable` and `Dispose()`**
For objects holding **unmanaged resources (e.g., file handles, database connections)**, implement `IDisposable`.

```csharp
class FileManager : IDisposable
{
    private StreamReader reader;

    public FileManager(string path)
    {
        reader = new StreamReader(path);
    }

    public void Dispose()
    {
        reader?.Dispose(); // Release the resource
        Console.WriteLine("Resource Released");
    }
}

static void Main()
{
    using (FileManager file = new FileManager("file.txt")) 
    {
        // File operations
    } // Dispose is called automatically here
}
```

### **Using `Finalize()`**
`Finalize()` (also called destructor) is **used as a backup mechanism** but is slower than `Dispose()`.

```csharp
class Example
{
    ~Example() // Destructor
    {
        Console.WriteLine("Object destroyed by GC");
    }
}
```

### **When to Use?**
| **Method** | **Use Case** |
|------------|-------------|
| `Dispose()` | **Explicit cleanup** of unmanaged resources (files, DB connections) |
| `Finalize()` | **Fallback cleanup**, but may delay resource release |

---

## 🔹 Value Types vs Reference Types

| **Type** | **Stored In** | **Examples** |
|----------|-------------|-------------|
| **Value Type** | Stack | `int`, `char`, `float`, `struct` |
| **Reference Type** | Heap | `class`, `interface`, `array`, `string` |

### **Example**
```csharp
int a = 10;  // Value type (stack)
int b = a;   // Copy of 'a' is stored in 'b'

Person p1 = new Person();
Person p2 = p1;  // Both p1 and p2 point to the same object in heap
```

### **Key Difference**
- **Value types** store a **copy of the value**.
- **Reference types** store a **memory reference** to the object.

---

## 🔹 Memory Leaks in C# (Causes & Prevention)

### **Common Causes**
❌ **Event Handler References Not Removed**  
❌ **Static Variables Holding References**  
❌ **Unclosed Database/File Connections**  
❌ **Large Objects Without Proper Cleanup**  

### **Preventing Memory Leaks**
✅ Use `using` statements for **automatic cleanup**.  
✅ Manually call `Dispose()` on unmanaged resources.  
✅ Remove event handlers using `-=`.  
✅ Avoid excessive use of `static` variables.

---

## 🔹 Weak References (Preventing Memory Leaks)

Weak references allow the GC to **collect objects if memory is needed**.

```csharp
WeakReference<Person> weakPerson = new WeakReference<Person>(new Person());

if (weakPerson.TryGetTarget(out Person p))
{
    Console.WriteLine("Object is still accessible");
}
else
{
    Console.WriteLine("Object has been garbage collected");
}
```

---

## 📌 Summary Table

| **Concept** | **Description** |
|------------|----------------|
| **Stack Memory** | Stores value types and method execution details |
| **Heap Memory** | Stores reference types and dynamic objects |
| **Garbage Collector (GC)** | Automatically reclaims memory (Gen 0, 1, 2) |
| **Dispose()** | Explicitly releases unmanaged resources |
| **Finalize()** | Backup cleanup mechanism (not recommended for frequent use) |
| **Memory Leaks** | Caused by event handlers, static variables, or large objects |
| **Weak References** | Allow GC to reclaim memory when needed |

---

## 📌 Conclusion
- **Memory management in C# is automatic** through GC, but developers must handle **unmanaged resources** properly.
- Use **`Dispose()`** for **explicit resource cleanup**.
- Avoid **memory leaks** by **removing event handlers and disposing of resources**.
- Understand the **difference between stack and heap memory** for optimized performance.

---