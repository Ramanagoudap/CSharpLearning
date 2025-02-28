# C# Pattern Matching in Detail

## Introduction
Pattern matching in C# allows you to check a value against a pattern and take action based on the match. It simplifies conditional logic, making your code more readable and concise. Introduced in **C# 7.0**, it has been enhanced in later versions (C# 8.0, 9.0, 10.0, and 11.0).

## Why Use Pattern Matching?
✅ Reduces if-else and switch-case complexity  
✅ Improves readability and maintainability  
✅ Works with various data types  

## Types of Pattern Matching in C#
1. **Type Pattern (C# 7.0)**
2. **Constant Pattern (C# 7.0)**
3. **Var Pattern (C# 7.0)**
4. **Recursive Pattern (C# 8.0)**
5. **Relational Pattern (C# 9.0)**
6. **Logical Pattern (C# 9.0)**
7. **List Pattern (C# 11.0)**

---

## 1️⃣ Type Pattern (C# 7.0)
Checks whether an object is of a specific type and assigns it to a variable.

### Example:
```csharp
object obj = "Hello";

if (obj is string str)
{
    Console.WriteLine(str.ToUpper()); // Output: HELLO
}
```

---

## 2️⃣ Constant Pattern (C# 7.0)
Compares a value to a **constant**.

### Example:
```csharp
int number = 10;

switch (number)
{
    case 1:
        Console.WriteLine("One");
        break;
    case 10:
        Console.WriteLine("Ten"); // Output: Ten
        break;
    default:
        Console.WriteLine("Other");
        break;
}
```

---

## 3️⃣ Var Pattern (C# 7.0)
Assigns the value to a variable **without type checking**.

### Example:
```csharp
object obj = 100;

if (obj is var x) 
{
    Console.WriteLine($"Value: {x}"); // Output: Value: 100
}
```

---

## 4️⃣ Recursive Pattern (C# 8.0)
Pattern matching inside **nested objects**.

### Example:
```csharp
class Person
{
    public string Name { get; set; }
    public Address Location { get; set; }
}

class Address
{
    public string City { get; set; }
}

Person person = new Person { Name = "Alice", Location = new Address { City = "New York" } };

if (person is { Location: { City: "New York" } })
{
    Console.WriteLine("Person is in New York"); // Output: Person is in New York
}
```

---

## 5️⃣ Relational Pattern (C# 9.0)
Uses relational operators (`<`, `>`, `<=`, `>=`).

### Example:
```csharp
int age = 25;

string category = age switch
{
    < 18 => "Minor",
    >= 18 and < 60 => "Adult", // Matches this case
    >= 60 => "Senior",
};

Console.WriteLine(category); // Output: Adult
```

---

## 6️⃣ Logical Pattern (C# 9.0)
Combines patterns with `and`, `or`, `not`.

### Example:
```csharp
int number = 42;

if (number is > 0 and < 100)
{
    Console.WriteLine("Number is between 0 and 100"); // Output: Number is between 0 and 100
}
```

---

## 7️⃣ List Pattern (C# 11.0)
Checks patterns in **arrays or lists**.

### Example:
```csharp
int[] numbers = { 1, 2, 3 };

if (numbers is [1, 2, 3])
{
    Console.WriteLine("Exact match!"); // Output: Exact match!
}
```

---

## 📌 Summary Table

| **Pattern Type**      | **Description**                      | **Example**                   |
|----------------------|----------------------------------|------------------------------|
| **Type Pattern**    | Checks object type               | `if (obj is string s)`      |
| **Constant Pattern**| Matches specific values         | `case 10:`                  |
| **Var Pattern**     | Assigns value without type check | `if (obj is var x)`         |
| **Recursive Pattern**| Matches nested properties      | `{ Location: { City: "New York" } }` |
| **Relational Pattern**| Uses `<`, `>`, `<=`, `>=`    | `x is > 10`                 |
| **Logical Pattern** | Combines patterns             | `x is > 10 and < 50`       |
| **List Pattern**    | Matches arrays/lists          | `if (arr is [1,2,3])`       |

---

## 📌 Conclusion
- **Pattern matching** makes code more **concise and readable**.  
- **Use cases**: Type checking, range matching, object destructuring, list validation.  
- **Introduced in C# 7.0, enhanced in later versions**.  

---