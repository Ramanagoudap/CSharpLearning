
# 🧵 Task, Thread, and Multi-threading in C#

## 📌 Introduction
C# provides multiple ways to perform **concurrent programming**, which allows multiple tasks to run simultaneously to improve application performance. The three primary mechanisms for concurrency in C# are:
1. **Thread (`System.Threading.Thread`)**
2. **Task (`System.Threading.Tasks.Task`)**
3. **Multi-threading (`System.Threading`)**

---

## 🔹 1️⃣ What is a Thread?
A **thread** is the smallest unit of execution in a process. Every C# program has at least one thread (the **main thread**), and additional threads can be created for parallel execution.

### ✅ **Creating a Thread**
```csharp
using System;
using System.Threading;

class Program
{
    static void PrintNumbers()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Thread: {i}");
            Thread.Sleep(1000); // Simulate work
        }
    }

    static void Main()
    {
        Thread thread = new Thread(PrintNumbers);
        thread.Start(); // Start new thread

        Console.WriteLine("Main thread is running...");
    }
}
```
✅ **Output:**
```
Main thread is running...
Thread: 1
Thread: 2
Thread: 3
Thread: 4
Thread: 5
```
---

## 🔹 2️⃣ Multi-threading in C#
Multi-threading allows running multiple **threads concurrently** to improve performance, particularly for CPU-intensive tasks.

### ✅ **Example: Running Multiple Threads**
```csharp
using System;
using System.Threading;

class Program
{
    static void Task1()
    {
        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"Task1: {i}");
            Thread.Sleep(1000);
        }
    }

    static void Task2()
    {
        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"Task2: {i}");
            Thread.Sleep(1000);
        }
    }

    static void Main()
    {
        Thread t1 = new Thread(Task1);
        Thread t2 = new Thread(Task2);

        t1.Start();
        t2.Start();

        t1.Join(); // Wait for t1 to complete
        t2.Join(); // Wait for t2 to complete

        Console.WriteLine("Main thread finished execution.");
    }
}
```
✅ **Output (Interleaved Execution)**
```
Task1: 1
Task2: 1
Task1: 2
Task2: 2
Task1: 3
Task2: 3
Main thread finished execution.
```
---

## 🔹 3️⃣ Task-based Asynchronous Pattern (TAP)
The **Task Parallel Library (TPL)** provides a more efficient way to run **asynchronous and parallel** tasks using the `Task` class.

### ✅ **Creating and Running a Task**
```csharp
using System;
using System.Threading.Tasks;

class Program
{
    static void PrintNumbers()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Task: {i}");
            Task.Delay(1000).Wait(); // Simulate work
        }
    }

    static void Main()
    {
        Task task = Task.Run(PrintNumbers);
        task.Wait(); // Wait for task to complete

        Console.WriteLine("Main method finished.");
    }
}
```
✅ **Output:**
```
Task: 1
Task: 2
Task: 3
Task: 4
Task: 5
Main method finished.
```
---

## 🔹 4️⃣ Running Multiple Tasks in Parallel
The `Task` class allows running multiple tasks asynchronously.

### ✅ **Example: Running Multiple Tasks**
```csharp
using System;
using System.Threading.Tasks;

class Program
{
    static void Task1() => Console.WriteLine("Task 1 Executed");
    static void Task2() => Console.WriteLine("Task 2 Executed");

    static void Main()
    {
        Task t1 = Task.Run(Task1);
        Task t2 = Task.Run(Task2);

        Task.WaitAll(t1, t2); // Wait for all tasks to complete
        Console.WriteLine("All tasks completed.");
    }
}
```
✅ **Output (Execution Order May Vary)**
```
Task 1 Executed
Task 2 Executed
All tasks completed.
```
---

## 🔹 5️⃣ Difference Between Thread and Task

| Feature | `Thread` | `Task` |
|---------|---------|--------|
| Namespace | `System.Threading` | `System.Threading.Tasks` |
| Creation | `new Thread(() => { })` | `Task.Run(() => { })` |
| Lightweight? | ❌ No | ✅ Yes |
| Thread Pool | ❌ No (Creates new threads) | ✅ Yes (Uses ThreadPool) |
| Async Support | ❌ No | ✅ Yes (with `async` and `await`) |
| Exception Handling | ❌ Complex | ✅ Easier |

---

## 🔹 6️⃣ Task with Async & Await (Recommended)
C# provides **`async` and `await`** for writing non-blocking, asynchronous code.

### ✅ **Example: Async Task Execution**
```csharp
using System;
using System.Threading.Tasks;

class Program
{
    static async Task PrintNumbersAsync()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Async Task: {i}");
            await Task.Delay(1000); // Non-blocking delay
        }
    }

    static async Task Main()
    {
        await PrintNumbersAsync();
        Console.WriteLine("Main method finished.");
    }
}
```
✅ **Output:**
```
Async Task: 1
Async Task: 2
Async Task: 3
Async Task: 4
Async Task: 5
Main method finished.
```
---

## 🔹 7️⃣ Thread Synchronization (Locking)
When multiple threads access shared data, **race conditions** may occur. Use **locks** to prevent this.

### ✅ **Example: Using `lock` for Thread Safety**
```csharp
using System;
using System.Threading;

class Program
{
    static int counter = 0;
    static object lockObject = new object();

    static void Increment()
    {
        for (int i = 0; i < 5; i++)
        {
            lock (lockObject) // Prevents race conditions
            {
                counter++;
                Console.WriteLine($"Counter: {counter}");
            }
            Thread.Sleep(100);
        }
    }

    static void Main()
    {
        Thread t1 = new Thread(Increment);
        Thread t2 = new Thread(Increment);

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine("Final Counter: " + counter);
    }
}
```
✅ **Output:**
```
Counter: 1
Counter: 2
Counter: 3
...
Final Counter: 10
```
---

## 📌 Summary

| Feature | Thread | Task | Multi-threading |
|---------|--------|------|----------------|
| Creation | `new Thread()` | `Task.Run()` | Multiple `Thread` instances |
| Thread Pool | ❌ No | ✅ Yes | ❌ No |
| Async Support | ❌ No | ✅ Yes | ❌ No |
| Exception Handling | ❌ Manual | ✅ Easier | ❌ Manual |
| Performance | 🟡 Medium | 🟢 High | 🟡 Medium |

---

## 📌 Best Practices
✅ **Use `Task` over `Thread`** – More efficient and uses thread pool.  
✅ **Use `async/await`** for non-blocking operations.  
✅ **Use `lock`, `Monitor`, or `Mutex`** to avoid race conditions.  
✅ **Use `Parallel.ForEach`** for processing collections in parallel.  
✅ **Avoid creating too many threads** – Use **thread pools** for better performance.

---

## 📌 Conclusion
- **Threads** provide basic concurrency but are manually managed.
- **Tasks** simplify concurrency using the **Task Parallel Library (TPL)**.
- **Multi-threading** improves performance for CPU-bound tasks.
- **Use `async/await`** for better **scalability and responsiveness**.

---