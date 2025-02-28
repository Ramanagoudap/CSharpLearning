## **Inheritance and Polymorphism in C# (Detailed Explanation)**

### **1. What is Inheritance?**
Inheritance is a fundamental concept of **Object-Oriented Programming (OOP)** in which a **child class (derived class)** inherits the properties and behaviors (fields and methods) of a **parent class (base class)**. 

### **Key Features of Inheritance:**
- **Code Reusability**: Allows reuse of existing code in a new class.
- **Extensibility**: A child class can add new features or modify existing ones.
- **Hierarchical Structure**: Promotes a logical and organized structure of classes.

### **Syntax of Inheritance in C#**
```csharp
class ParentClass
{
    // Parent class properties and methods
}

class ChildClass : ParentClass
{
    // Child class inherits from ParentClass
}
```

---

### **2. Types of Inheritance in C#**
C# supports **single inheritance and multi-level inheritance** but does not support **multiple inheritance (i.e., inheriting from multiple base classes directly)**. Instead, multiple inheritance is achieved using interfaces.

#### **A. Single Inheritance**
In single inheritance, one class derives from another class.

##### **Example:**
```csharp
// Base class
class Animal
{
    public void Eat()
    {
        Console.WriteLine("This animal eats food.");
    }
}

// Derived class
class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("The dog barks.");
    }
}

// Usage
class Program
{
    static void Main()
    {
        Dog dog = new Dog();
        dog.Eat();  // Inherited from Animal class
        dog.Bark(); // Defined in Dog class
    }
}
```
### **Output**
```
This animal eats food.
The dog barks.
```

---

#### **B. Multi-Level Inheritance**
A class can inherit from another derived class, creating a **chain of inheritance**.

##### **Example:**
```csharp
// Base class
class Animal
{
    public void Eat()
    {
        Console.WriteLine("This animal eats food.");
    }
}

// Intermediate derived class
class Mammal : Animal
{
    public void Walk()
    {
        Console.WriteLine("This mammal walks.");
    }
}

// Further derived class
class Dog : Mammal
{
    public void Bark()
    {
        Console.WriteLine("The dog barks.");
    }
}

// Usage
class Program
{
    static void Main()
    {
        Dog dog = new Dog();
        dog.Eat();  // Inherited from Animal
        dog.Walk(); // Inherited from Mammal
        dog.Bark(); // Defined in Dog
    }
}
```
### **Output**
```
This animal eats food.
This mammal walks.
The dog barks.
```

---

#### **C. Hierarchical Inheritance**
When multiple classes inherit from a **single base class**.

##### **Example:**
```csharp
// Base class
class Animal
{
    public void Eat()
    {
        Console.WriteLine("Animals need food.");
    }
}

// Derived classes
class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("Dog barks.");
    }
}

class Cat : Animal
{
    public void Meow()
    {
        Console.WriteLine("Cat meows.");
    }
}

// Usage
class Program
{
    static void Main()
    {
        Dog dog = new Dog();
        Cat cat = new Cat();

        dog.Eat();
        dog.Bark();

        cat.Eat();
        cat.Meow();
    }
}
```

### **Output**
```
Animals need food.
Dog barks.
Animals need food.
Cat meows.
```

---

#### **D. Multiple Inheritance via Interfaces**
C# **does not support multiple inheritance** using classes but allows multiple inheritance using interfaces.

##### **Example:**
```csharp
interface IFly
{
    void Fly();
}

interface ISwim
{
    void Swim();
}

// Class implementing multiple interfaces
class Bird : IFly, ISwim
{
    public void Fly()
    {
        Console.WriteLine("Bird can fly.");
    }

    public void Swim()
    {
        Console.WriteLine("Some birds can swim.");
    }
}

// Usage
class Program
{
    static void Main()
    {
        Bird bird = new Bird();
        bird.Fly();
        bird.Swim();
    }
}
```
### **Output**
```
Bird can fly.
Some birds can swim.
```

---

## **3. Polymorphism in C#**
Polymorphism allows methods to have **multiple forms**. It enables **method overriding and method overloading**.

### **A. Method Overloading (Compile-time Polymorphism)**
Method overloading allows multiple methods with the **same name** but **different parameters**.

##### **Example:**
```csharp
class MathOperations
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public double Add(double a, double b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}

// Usage
class Program
{
    static void Main()
    {
        MathOperations math = new MathOperations();

        Console.WriteLine(math.Add(5, 10));       // Calls first method
        Console.WriteLine(math.Add(5.5, 2.3));   // Calls second method
        Console.WriteLine(math.Add(1, 2, 3));    // Calls third method
    }
}
```
### **Output**
```
15
7.8
6
```

---

### **B. Method Overriding (Run-time Polymorphism)**
Method overriding allows a **derived class to modify the implementation of a method** in the base class using the `virtual` and `override` keywords.

##### **Example:**
```csharp
class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound.");
    }
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Dog barks.");
    }
}

// Usage
class Program
{
    static void Main()
    {
        Animal myAnimal = new Dog();
        myAnimal.MakeSound(); // Calls Dog's overridden method
    }
}
```
### **Output**
```
Dog barks.
```

---

### **C. Abstract Classes and Polymorphism**
Abstract classes allow method definitions that must be implemented by derived classes.

##### **Example:**
```csharp
abstract class Shape
{
    public abstract void Draw();  // Abstract method with no implementation
}

class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a Circle.");
    }
}

class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a Rectangle.");
    }
}

// Usage
class Program
{
    static void Main()
    {
        Shape shape1 = new Circle();
        Shape shape2 = new Rectangle();

        shape1.Draw();
        shape2.Draw();
    }
}
```
### **Output**
```
Drawing a Circle.
Drawing a Rectangle.
```

---

## **4. Key Differences Between Inheritance and Polymorphism**
| **Feature**       | **Inheritance** | **Polymorphism** |
|-------------------|----------------|------------------|
| **Definition**    | Allows a child class to inherit from a parent class | Allows multiple methods to have different behaviors |
| **Types**        | Single, Multi-level, Hierarchical, Multiple (via interfaces) | Method Overloading (compile-time) and Method Overriding (run-time) |
| **Keywords Used** | `:` for inheritance | `virtual`, `override`, `abstract` |
| **Purpose**       | Code reuse, extending functionality | Achieves dynamic behavior and flexibility |

---

### **Conclusion**
- **Inheritance** helps in reusing code and establishing a class hierarchy.
- **Polymorphism** allows methods to have multiple forms through **method overloading** and **method overriding**.
- **Abstract classes and interfaces** provide flexible designs while supporting polymorphism.

Would you like any additional examples or explanations? 🚀