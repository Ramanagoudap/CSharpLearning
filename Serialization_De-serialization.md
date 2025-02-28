
# 📦 Serialization and Deserialization in C#

## 📌 Introduction
**Serialization** is the process of converting an object into a format that can be **stored** (file, database) or **transmitted** (network, API).  
**Deserialization** is the reverse process, where a serialized format is **converted back into an object**.

---

## 🔹 Why Use Serialization?
✅ Save object state to a file or database.  
✅ Transfer objects between different applications over a network.  
✅ Store data in a structured format like XML or JSON.  
✅ Deep copy of objects.  

---

## 🔹 Types of Serialization in C#
| **Serialization Type** | **Format** | **Namespace** |
|------------------------|------------|--------------|
| **Binary Serialization** | Binary (Compact) | `System.Runtime.Serialization.Formatters.Binary` |
| **XML Serialization** | XML (Readable) | `System.Xml.Serialization` |
| **JSON Serialization** | JSON (Web-friendly) | `System.Text.Json` / `Newtonsoft.Json` |
| **Custom Serialization** | Any (Manual Control) | `ISerializable` |

---

# 🏗 1️⃣ Binary Serialization
🔹 **Stores data in a compact binary format.**  
🔹 **Efficient but not human-readable.**  
🔹 **Used for deep cloning and object persistence.**  

### ✅ **Example: Binary Serialization**
```csharp
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        Person person = new Person { Name = "Alice", Age = 30 };
        BinaryFormatter formatter = new BinaryFormatter();

        using (FileStream stream = new FileStream("person.dat", FileMode.Create))
        {
            formatter.Serialize(stream, person);
        }

        Console.WriteLine("Binary Serialization Complete!");
    }
}
```

### ✅ **Example: Binary Deserialization**
```csharp
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

class Program
{
    static void Main()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        using (FileStream stream = new FileStream("person.dat", FileMode.Open))
        {
            Person person = (Person)formatter.Deserialize(stream);
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }
    }
}
```
✅ **Output:**
```
Name: Alice, Age: 30
```
🚨 **⚠️ Note:** `BinaryFormatter` is obsolete in .NET 5+ due to security risks.

---

# 🏗 2️⃣ XML Serialization
🔹 **Stores objects in XML format.**  
🔹 **Human-readable and cross-platform.**  
🔹 **Does not support private fields.**  

### ✅ **Example: XML Serialization**
```csharp
using System;
using System.IO;
using System.Xml.Serialization;

[Serializable]
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        Person person = new Person { Name = "Bob", Age = 25 };
        XmlSerializer serializer = new XmlSerializer(typeof(Person));

        using (StreamWriter writer = new StreamWriter("person.xml"))
        {
            serializer.Serialize(writer, person);
        }

        Console.WriteLine("XML Serialization Complete!");
    }
}
```

### ✅ **Example: XML Deserialization**
```csharp
using System;
using System.IO;
using System.Xml.Serialization;

class Program
{
    static void Main()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Person));

        using (StreamReader reader = new StreamReader("person.xml"))
        {
            Person person = (Person)serializer.Deserialize(reader);
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }
    }
}
```
✅ **Output (XML File Content):**
```xml
<Person>
    <Name>Bob</Name>
    <Age>25</Age>
</Person>
```

---

# 🏗 3️⃣ JSON Serialization
🔹 **Popular format for APIs & Web Applications.**  
🔹 **Human-readable and lightweight.**  
🔹 **Supported via `System.Text.Json` and `Newtonsoft.Json`.**  

### ✅ **Example: JSON Serialization using `System.Text.Json`**
```csharp
using System;
using System.IO;
using System.Text.Json;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        Person person = new Person { Name = "Charlie", Age = 28 };
        string jsonString = JsonSerializer.Serialize(person);

        File.WriteAllText("person.json", jsonString);
        Console.WriteLine("JSON Serialization Complete!");
    }
}
```

### ✅ **Example: JSON Deserialization**
```csharp
using System;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        string jsonString = File.ReadAllText("person.json");
        Person person = JsonSerializer.Deserialize<Person>(jsonString);

        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
    }
}
```
✅ **Output (JSON File Content):**
```json
{
    "Name": "Charlie",
    "Age": 28
}
```

🚀 **Alternative: `Newtonsoft.Json` (More Features)**
```csharp
using Newtonsoft.Json;
```
🔹 `JsonConvert.SerializeObject(person);`  
🔹 `JsonConvert.DeserializeObject<Person>(jsonString);`

---

# 🏗 4️⃣ Custom Serialization (`ISerializable`)
🔹 **Allows full control over serialization process.**  
🔹 **Used for handling private fields.**  

### ✅ **Example: Custom Serialization**
```csharp
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
class Person : ISerializable
{
    public string Name { get; set; }
    private int age; // Private field

    public Person(string name, int age)
    {
        Name = name;
        this.age = age;
    }

    // Custom Serialization
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Name", Name);
        info.AddValue("Age", age);
    }

    // Custom Deserialization
    public Person(SerializationInfo info, StreamingContext context)
    {
        Name = info.GetString("Name");
        age = info.GetInt32("Age");
    }
}
```
✅ **This approach gives you control over how data is serialized!**

---

## 🔹 Serialization Comparison Table
| **Feature** | **Binary** | **XML** | **JSON** |
|------------|-----------|---------|---------|
| **Format** | Binary (Compact) | XML (Verbose) | JSON (Lightweight) |
| **Readability** | ❌ No | ✅ Yes | ✅ Yes |
| **Supports Private Fields?** | ✅ Yes | ❌ No | ❌ No |
| **Web-Friendly?** | ❌ No | 🟡 Partially | ✅ Yes |
| **Performance** | 🚀 Fastest | 🐢 Slow | ⚡ Fast |

---

## 🔹 Best Practices for Serialization
✅ Use **JSON** for web APIs and lightweight data exchange.  
✅ Use **Binary Serialization** only when necessary (security risk).  
✅ Use **XML Serialization** if human-readable structured data is needed.  
✅ Avoid serializing **sensitive information** (passwords, API keys).  
✅ Implement **Custom Serialization (`ISerializable`)** when dealing with private fields.  

---

## 📌 Conclusion
- **Serialization** helps store and transfer objects in various formats.
- **Deserialization** restores objects back to their original state.
- **Use JSON for APIs**, **XML for configuration**, and **Binary for performance**.
- **Custom Serialization (`ISerializable`)** provides advanced control.

---