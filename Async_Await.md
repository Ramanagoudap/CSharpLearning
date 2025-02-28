# 🚀 Async and Await in C#

## 📌 Introduction
**Asynchronous programming** in C# allows execution of non-blocking code using `async` and `await`. This helps in improving **performance and responsiveness**, especially in I/O-bound operations like **file handling, database queries, and API calls**.

### **Why Use Async and Await?**
✅ **Non-blocking execution** – UI remains responsive  
✅ **Better resource utilization** – No idle waiting  
✅ **Improves performance** – Tasks run concurrently  

---

## 🔹 Understanding Async and Await

| **Keyword**   | **Description** |
|-------------|----------------|
| `async`    | Marks a method as asynchronous |
| `await`    | Pauses the execution until the asynchronous task completes |
| `Task<T>`  | Represents an asynchronous operation that returns a value |
| `Task`     | Represents an asynchronous operation that does not return a value |

---

## 🔹 Basic Example of Async and Await

```csharp
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Fetching data...");
        string data = await FetchDataAsync();
        Console.WriteLine($"Data received: {data}");
    }

    static async Task<string> FetchDataAsync()
    {
        await Task.Delay(3000); // Simulating network delay
        return "Hello, Async World!";
    }
}
```

### **Output**
```
Fetching data...
(Data fetched after 3 seconds)
Data received: Hello, Async World!
```

### **Explanation**
- `async` marks `FetchDataAsync` as an asynchronous method.
- `await Task.Delay(3000)` **pauses execution** for 3 seconds without blocking the thread.
- Execution **resumes after completion**, returning `"Hello, Async World!"`.

---

## 🔹 Task vs Task<T> vs void in Async

| **Return Type** | **Usage** |
|--------------|----------------|
| `Task`       | Use for async methods that **do not return a value** (`async Task MethodAsync()`) |
| `Task<T>`    | Use for async methods that **return a value** (`async Task<int> MethodAsync()`) |
| `void`       | Avoid using it in async methods (except for event handlers) |

### **Example**
```csharp
async Task PrintMessageAsync() // Task (no return)
{
    await Task.Delay(1000);
    Console.WriteLine("Task Completed");
}

async Task<int> GetNumberAsync() // Task<int> (returns int)
{
    await Task.Delay(1000);
    return 42;
}
```

---

## 🔹 Real-World Example: Calling an API Asynchronously

```csharp
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string result = await FetchDataFromAPIAsync();
        Console.WriteLine(result);
    }

    static async Task<string> FetchDataFromAPIAsync()
    {
        using HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/1");
        return await response.Content.ReadAsStringAsync();
    }
}
```

### **Explanation**
- `HttpClient.GetAsync()` fetches API data **without blocking the main thread**.
- `await response.Content.ReadAsStringAsync()` ensures the response is processed asynchronously.

---

## 🔹 Handling Exceptions in Async Methods

Exceptions in async methods should be **handled using try-catch**.

### **Example**
```csharp
static async Task FetchDataSafelyAsync()
{
    try
    {
        await Task.Delay(1000);
        throw new Exception("Something went wrong!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

static async Task Main()
{
    await FetchDataSafelyAsync();
}
```

### **Output**
```
Error: Something went wrong!
```

### **Key Points**
- Always **use try-catch inside the async method**.
- Do **not use try-catch outside an awaited call** as it may not catch the exception.

---

## 🔹 Running Multiple Async Tasks in Parallel

### **Using `Task.WhenAll`**
`Task.WhenAll()` executes multiple tasks **concurrently** and waits for all to complete.

```csharp
static async Task Main()
{
    Task<int> task1 = GetNumberAsync(1);
    Task<int> task2 = GetNumberAsync(2);
    
    int[] results = await Task.WhenAll(task1, task2);
    
    Console.WriteLine($"Results: {results[0]}, {results[1]}");
}

static async Task<int> GetNumberAsync(int num)
{
    await Task.Delay(2000);
    return num * 10;
}
```

### **Output**
```
(After 2 seconds)
Results: 10, 20
```

### **Key Points**
- `Task.WhenAll(task1, task2)` **runs both tasks in parallel**.
- Execution **waits for both tasks to complete** before continuing.

---

## 🔹 Avoiding Deadlocks in Async Code

Using `.Result` or `.Wait()` in async methods can **cause deadlocks**.

### **Bad Example (Causes Deadlock)**
```csharp
string data = FetchDataAsync().Result; // ❌ Never use .Result in async methods!
```

### **Solution: Always Use `await`**
```csharp
string data = await FetchDataAsync(); // ✅ Correct way
```

### **Key Points**
- Avoid `.Result` or `.Wait()` in **UI or ASP.NET applications**.
- Always **use `await` inside async methods**.

---

## 📌 Summary Table

| **Feature**     | **Description** |
|---------------|----------------|
| `async`       | Marks a method as asynchronous |
| `await`       | Waits for the completion of an async task |
| `Task`        | Represents an async operation with no return value |
| `Task<T>`     | Represents an async operation that returns a value |
| `Task.WhenAll` | Runs multiple tasks in parallel |
| Exception Handling | Use `try-catch` inside async methods |
| Avoid Deadlocks | Never use `.Result` or `.Wait()` |

---

## 📌 Conclusion
- Use `async` and `await` for **non-blocking execution**.
- Always **handle exceptions** in async methods.
- Run **multiple tasks in parallel** using `Task.WhenAll()`.
- Avoid `.Result` or `.Wait()` to **prevent deadlocks**.

---