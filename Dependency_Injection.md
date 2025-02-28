# 🔗 Dependency Injection (DI) in C#

## 📌 Introduction
Dependency Injection (DI) is a **design pattern** used to achieve **loose coupling** between components in C#. It helps in managing dependencies efficiently by injecting them from external sources instead of creating them inside a class.

### ✅ **Why Use Dependency Injection?**
- Reduces **tight coupling** between classes.
- Improves **code reusability** and **testability**.
- Makes applications **easier to maintain** and **extend**.
- Supports **Inversion of Control (IoC)** principle.

---

## 🔹 What is Inversion of Control (IoC)?
IoC is a principle where the **control of object creation** is transferred to a central container rather than being manually handled inside a class.

🔹 **Without IoC (Tightly Coupled Code)**  
```csharp
class Service
{
    public void Display() => Console.WriteLine("Service Called");
}

class Client
{
    private Service _service = new Service(); // Direct dependency

    public void Run() => _service.Display();
}
```
❌ The `Client` class is **tightly coupled** to `Service`.  
✅ **With IoC (Using Dependency Injection)**:
```csharp
class Client
{
    private Service _service;
    
    public Client(Service service) // Inject dependency
    {
        _service = service;
    }

    public void Run() => _service.Display();
}
```
Now, `Client` **does not create** an instance of `Service`, making it more flexible.

---

## 🔹 Types of Dependency Injection in C#
There are **three main types** of DI in C#:
1. **Constructor Injection** (Recommended)
2. **Property Injection**
3. **Method Injection**

---

## 🔹 1️⃣ Constructor Injection
This is the most commonly used DI method where dependencies are **injected through the constructor**.

```csharp
public interface IService
{
    void Display();
}

public class Service : IService
{
    public void Display() => Console.WriteLine("Service Called");
}

public class Client
{
    private readonly IService _service;

    public Client(IService service) // Dependency is injected via constructor
    {
        _service = service;
    }

    public void Run() => _service.Display();
}
```
✅ **Benefits**:
- Ensures all dependencies are available at object creation.
- Makes the object immutable after creation.

---

## 🔹 2️⃣ Property Injection
Dependencies are **assigned via properties** instead of the constructor.

```csharp
public class Client
{
    public IService Service { get; set; } // Property injection

    public void Run() => Service?.Display();
}
```
✅ **When to Use?**  
- When a dependency is **optional**.  
- When we **want to set dependencies dynamically**.

❌ **Drawback**: Object **may not be fully initialized** if the dependency is not assigned.

---

## 🔹 3️⃣ Method Injection
The dependency is passed as a **method parameter**.

```csharp
public class Client
{
    public void Run(IService service) // Dependency is passed as an argument
    {
        service.Display();
    }
}
```
✅ **When to Use?**  
- When a dependency is **used only once**.  
- When the dependency **varies per method call**.

❌ **Drawback**: The class **still depends** on external services directly.

---

## 🔹 Implementing Dependency Injection in .NET Core
### **Step 1: Define Interfaces and Implementations**
```csharp
public interface IService
{
    void Display();
}

public class Service : IService
{
    public void Display() => Console.WriteLine("Hello from Service");
}
```

### **Step 2: Register Dependencies in `Program.cs`**
In **ASP.NET Core**, dependencies are managed using **the built-in DI container**.

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IService, Service>(); // Register service

var app = builder.Build();
app.Run();
```

### **Step 3: Inject Dependencies into Controllers**
```csharp
public class HomeController : Controller
{
    private readonly IService _service;

    public HomeController(IService service) // Constructor Injection
    {
        _service = service;
    }

    public IActionResult Index()
    {
        _service.Display();
        return View();
    }
}
```

---

## 🔹 Dependency Injection Scopes in .NET Core
When registering dependencies, we define their **lifetimes**.

| **Scope** | **Lifetime** | **Example Usage** |
|-----------|-------------|------------------|
| **Transient** | Created every time requested | Lightweight, stateless services |
| **Scoped** | Created once per request | Web API calls, database contexts |
| **Singleton** | Created once per application lifetime | Logging, caching |

### **Example: Registering Different Scopes**
```csharp
builder.Services.AddTransient<IService, Service>(); // New instance every time
builder.Services.AddScoped<IService, Service>();    // New instance per request
builder.Services.AddSingleton<IService, Service>(); // Single instance for the app
```

---

## 🔹 Manually Implementing Dependency Injection (Without Framework)
DI **can be implemented manually** using **Factory Pattern**.

```csharp
public class ServiceFactory
{
    public static IService CreateService() => new Service();
}

class Program
{
    static void Main()
    {
        IService service = ServiceFactory.CreateService(); // Dependency created externally
        Client client = new Client(service);
        client.Run();
    }
}
```
✅ **When to Use?**  
- When **not using .NET Core's built-in DI**.  
- When creating a **custom DI container**.

---

## 📌 Summary Table

| **Concept** | **Description** |
|------------|----------------|
| **Dependency Injection (DI)** | Injecting dependencies instead of creating them inside a class |
| **IoC (Inversion of Control)** | Shifts control of object creation to an external container |
| **Constructor Injection** | Injects dependency via constructor (**recommended**) |
| **Property Injection** | Assigns dependency via a property (**optional dependency**) |
| **Method Injection** | Passes dependency as a method argument (**short-term dependency**) |
| **Transient Scope** | Creates a new instance **every time** |
| **Scoped Scope** | Creates a new instance **per request** |
| **Singleton Scope** | Creates **one instance for the entire application** |

---

## 📌 Best Practices
✅ **Use constructor injection** whenever possible (**recommended approach**).  
✅ **Use `AddScoped` for database operations** in web applications.  
✅ **Use `AddSingleton` carefully** (avoid stateful objects).  
✅ **Remove unnecessary dependencies** to keep the code clean.  
✅ **Avoid service locators** (`IServiceProvider.GetService<T>()`) inside classes.

---

## 📌 Conclusion
- Dependency Injection improves **code maintainability and flexibility**.
- .NET Core provides a **built-in DI container** for managing dependencies.
- Using **DI scopes correctly** prevents memory leaks and performance issues.
- **Constructor Injection** is the **preferred** method for DI.

---