using System;
using System.Collections.Generic;

// 1. Интерфейс IAnimal и классы Dog, Cat
public interface IAnimal
{
    string Name { get; set; }
    void MakeSound();
}

public class Dog : IAnimal
{
    public string Name { get; set; }

    public Dog(string name)
    {
        Name = name;
    }

    public void MakeSound()
    {
        Console.WriteLine($"{Name} says: Woof woof!");
    }
}

public class Cat : IAnimal
{
    public string Name { get; set; }

    public Cat(string name)
    {
        Name = name;
    }

    public void MakeSound()
    {
        Console.WriteLine($"{Name} says: Meow meow!");
    }
}

// 2. Интерфейс IShape и классы Circle, Rectangle, Triangle
public interface IShape
{
    double Area { get; }
    double Perimeter { get; }
}

public class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Area => Math.PI * Radius * Radius;

    public double Perimeter => 2 * Math.PI * Radius;
}

public class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double Area => Width * Height;

    public double Perimeter => 2 * (Width + Height);
}

public class Triangle : IShape
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public double Area
    {
        get
        {
            double s = Perimeter / 2;
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }
    }

    public double Perimeter => SideA + SideB + SideC;
}

// 3. Интерфейс IComparable<T> и классы Student, Book
public interface IComparable<T>
{
    int CompareTo(T other);
}

public class Student : IComparable<Student>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }

    public Student(string name, int age, double grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
    }

    public int CompareTo(Student other)
    {
        int gradeComparison = other.Grade.CompareTo(Grade);
        if (gradeComparison != 0)
            return gradeComparison;

        int nameComparison = Name.CompareTo(other.Name);
        if (nameComparison != 0)
            return nameComparison;

        return Age.CompareTo(other.Age);
    }

    public override string ToString()
    {
        return $"{Name}, Age: {Age}, Grade: {Grade}";
    }
}

public class Book : IComparable<Book>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }

    public Book(string title, string author, decimal price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    public int CompareTo(Book other)
    {
        int authorComparison = Author.CompareTo(other.Author);
        if (authorComparison != 0)
            return authorComparison;

        int titleComparison = Title.CompareTo(other.Title);
        if (titleComparison != 0)
            return titleComparison;

        return Price.CompareTo(other.Price);
    }

    public override string ToString()
    {
        return $"{Title} by {Author}, Price: {Price:C}";
    }
}

// Главный класс программы с методом Main
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Демонстрация интерфейсов и классов ===\n");

        // Демонстрация IAnimal
        Console.WriteLine("1. Демонстрация IAnimal:");
        Console.WriteLine("-----------------------");
        IAnimal dog = new Dog("Рекс");
        IAnimal cat = new Cat("Мурка");

        dog.MakeSound();
        cat.MakeSound();

        // Демонстрация IShape
        Console.WriteLine("\n2. Демонстрация IShape:");
        Console.WriteLine("----------------------");
        IShape circle = new Circle(5);
        IShape rectangle = new Rectangle(4, 6);
        IShape triangle = new Triangle(3, 4, 5);

        Console.WriteLine($"Круг - Площадь: {circle.Area:F2}, Периметр: {circle.Perimeter:F2}");
        Console.WriteLine($"Прямоугольник - Площадь: {rectangle.Area:F2}, Периметр: {rectangle.Perimeter:F2}");
        Console.WriteLine($"Треугольник - Площадь: {triangle.Area:F2}, Периметр: {triangle.Perimeter:F2}");

        // Демонстрация IComparable<Student>
        Console.WriteLine("\n3. Демонстрация IComparable<Student>:");
        Console.WriteLine("-----------------------------------");
        List<Student> students = new List<Student>
        {
            new Student("Анна", 20, 4.5),
            new Student("Борис", 22, 4.2),
            new Student("Анна", 19, 4.5),
            new Student("Виктор", 21, 4.8)
        };

        Console.WriteLine("До сортировки:");
        foreach (var student in students)
        {
            Console.WriteLine($"  {student}");
        }

        students.Sort();

        Console.WriteLine("\nПосле сортировки (по убыванию оценки, затем по имени и возрасту):");
        foreach (var student in students)
        {
            Console.WriteLine($"  {student}");
        }

        // Демонстрация IComparable<Book>
        Console.WriteLine("\n4. Демонстрация IComparable<Book>:");
        Console.WriteLine("--------------------------------");
        List<Book> books = new List<Book>
        {
            new Book("Война и мир", "Лев Толстой", 1500m),
            new Book("Анна Каренина", "Лев Толстой", 1200m),
            new Book("Преступление и наказание", "Федор Достоевский", 1000m),
            new Book("Мастер и Маргарита", "Михаил Булгаков", 1800m)
        };

        Console.WriteLine("До сортировки:");
        foreach (var book in books)
        {
            Console.WriteLine($"  {book}");
        }

        books.Sort();

        Console.WriteLine("\nПосле сортировки (по автору, затем по названию и цене):");
        foreach (var book in books)
        {
            Console.WriteLine($"  {book}");
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}