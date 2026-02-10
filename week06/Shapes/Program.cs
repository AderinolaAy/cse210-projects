using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create individual shapes
        Square square = new Square("Red", 5);
        Rectangle rectangle = new Rectangle("Blue", 4, 6);
        Circle circle = new Circle("Green", 3);

        // Test individual shapes
        Console.WriteLine($"Square Color: {square.GetColor()}, Area: {square.GetArea()}");
        Console.WriteLine($"Rectangle Color: {rectangle.GetColor()}, Area: {rectangle.GetArea()}");
        Console.WriteLine($"Circle Color: {circle.GetColor()}, Area: {circle.GetArea()}");

        // Create a list of shapes
        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        Console.WriteLine("\nIterating through list of shapes:");
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}, Area: {shape.GetArea()}");
        }
    }
}