# 📂 File Handling in C#

## 📌 Introduction
File handling in C# is used to **read, write, append, and manage files** on the system. The `System.IO` namespace provides various classes for file operations.

### **Common File Handling Classes**
| **Class** | **Description** |
|----------|----------------|
| `File` | Provides static methods for file operations |
| `FileInfo` | Provides instance methods for file operations |
| `StreamReader` | Reads text files line by line |
| `StreamWriter` | Writes text files line by line |
| `FileStream` | Reads/Writes files in binary format |
| `BinaryReader` | Reads primitive data types from a file |
| `BinaryWriter` | Writes primitive data types to a file |

---

## 🔹 Creating and Writing to a File
### **Using `File.WriteAllText()`**
Writes text directly to a file.

```csharp
using System.IO;

class Program
{
    static void Main()
    {
        string path = "example.txt";
        File.WriteAllText(path, "Hello, File Handling!");
        Console.WriteLine("File created and text written.");
    }
}
```

### **Using `StreamWriter` (Efficient for Multiple Writes)**
```csharp
using System.IO;

class Program
{
    static void Main()
    {
        using (StreamWriter writer = new StreamWriter("example.txt"))
        {
            writer.WriteLine("Hello, World!");
            writer.WriteLine("This is C# File Handling.");
        }
        Console.WriteLine("File written successfully.");
    }
}
```

✅ **Advantages of StreamWriter**  
- **Better for large files** (writes line by line)  
- **Supports appending** (`new StreamWriter("file.txt", true)`)  

---

## 🔹 Reading a File
### **Using `File.ReadAllText()`**
Reads the entire file as a string.

```csharp
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string content = File.ReadAllText("example.txt");
        Console.WriteLine("File Content: " + content);
    }
}
```

### **Using `StreamReader` (Efficient for Large Files)**
```csharp
using System;
using System.IO;

class Program
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("example.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
```

✅ **Why Use StreamReader?**  
- **More efficient** for large files (reads line by line).  
- **Avoids memory issues** with large text data.  

---

## 🔹 Appending Text to a File
### **Using `File.AppendAllText()`**
```csharp
File.AppendAllText("example.txt", "\nAppended text.");
```

### **Using `StreamWriter` (Appending Mode)**
```csharp
using (StreamWriter writer = new StreamWriter("example.txt", true))
{
    writer.WriteLine("Appending new line.");
}
```

✅ **Using `true` in `StreamWriter` enables appending.**  

---

## 🔹 Checking If a File Exists
```csharp
if (File.Exists("example.txt"))
{
    Console.WriteLine("File exists.");
}
else
{
    Console.WriteLine("File not found.");
}
```

---

## 🔹 Deleting a File
```csharp
if (File.Exists("example.txt"))
{
    File.Delete("example.txt");
    Console.WriteLine("File deleted.");
}
```

---

## 🔹 Working with `FileInfo`
The `FileInfo` class provides **instance-based file operations**.

```csharp
FileInfo fileInfo = new FileInfo("example.txt");

if (fileInfo.Exists)
{
    Console.WriteLine($"File Size: {fileInfo.Length} bytes");
    Console.WriteLine($"Created On: {fileInfo.CreationTime}");
}
```

✅ **Why Use FileInfo?**  
- Provides additional metadata like size, creation time, last access time, etc.  
- Supports **better object-oriented design** over static `File` methods.  

---

## 🔹 Binary File Handling (Reading & Writing)
### **Writing Binary Data (`BinaryWriter`)**
```csharp
using System;
using System.IO;

class Program
{
    static void Main()
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open("data.bin", FileMode.Create)))
        {
            writer.Write(100);
            writer.Write(3.14);
            writer.Write("Binary File Example");
        }
    }
}
```

### **Reading Binary Data (`BinaryReader`)**
```csharp
using System;
using System.IO;

class Program
{
    static void Main()
    {
        using (BinaryReader reader = new BinaryReader(File.Open("data.bin", FileMode.Open)))
        {
            int intValue = reader.ReadInt32();
            double doubleValue = reader.ReadDouble();
            string text = reader.ReadString();

            Console.WriteLine($"Integer: {intValue}, Double: {doubleValue}, Text: {text}");
        }
    }
}
```

✅ **Why Use BinaryWriter & BinaryReader?**  
- **Efficient for structured data** (e.g., images, serialized objects).  
- **More compact** than text files.  

---

## 🔹 FileStream (Low-Level File Handling)
FileStream allows **reading and writing at the byte level**.

### **Example: Writing to a File using `FileStream`**
```csharp
using System.IO;

class Program
{
    static void Main()
    {
        using (FileStream fs = new FileStream("file.txt", FileMode.Create, FileAccess.Write))
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes("Hello, FileStream!");
            fs.Write(data, 0, data.Length);
        }
    }
}
```

### **Example: Reading from a File using `FileStream`**
```csharp
using System;
using System.IO;

class Program
{
    static void Main()
    {
        using (FileStream fs = new FileStream("file.txt", FileMode.Open, FileAccess.Read))
        {
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, data.Length);
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(data));
        }
    }
}
```

✅ **Why Use FileStream?**  
- **More control over file reading/writing**.  
- **Used for large file processing** (e.g., video streaming, large logs).  

---

## 📌 Summary Table

| **Operation** | **Method** |
|--------------|-----------|
| **Create & Write File** | `File.WriteAllText()`, `StreamWriter` |
| **Read File** | `File.ReadAllText()`, `StreamReader` |
| **Append to File** | `File.AppendAllText()`, `StreamWriter (true)` |
| **Check if File Exists** | `File.Exists()` |
| **Delete File** | `File.Delete()` |
| **Get File Info** | `FileInfo` |
| **Binary Write** | `BinaryWriter` |
| **Binary Read** | `BinaryReader` |
| **Low-Level Read/Write** | `FileStream` |

---

## 📌 Best Practices
✅ **Use `using` statements** for `StreamReader`, `StreamWriter`, and `FileStream` to automatically close resources.  
✅ **Check file existence** before reading/writing.  
✅ **Use `FileInfo` for metadata operations** (size, creation time, etc.).  
✅ **Use binary file handling** for structured data (images, database files).  
✅ **Avoid frequent disk access** (batch process instead).  

---

## 📌 Conclusion
- C# provides multiple ways to **read, write, and manage files** efficiently.
- **Text-based handling** (`StreamWriter`, `StreamReader`) is useful for log files and configurations.
- **Binary handling** (`BinaryWriter`, `BinaryReader`) is suitable for structured data storage.
- **Low-level handling** (`FileStream`) gives more control over file operations.

---