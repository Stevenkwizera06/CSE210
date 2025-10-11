using System;
using System.Collections.Generic;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Shape Area Calculator ===");
            Console.WriteLine();

            // Test individual shape classes
            Console.WriteLine("Testing individual shapes:");
            Console.WriteLine("-------------------------");
            
            // Test Square
            Square square = new Square("Red", 5.0);
            Console.WriteLine($"Square - Color: {square.GetColor()}, Area: {square.GetArea():F2}");
            
            // Test Rectangle
            Rectangle rectangle = new Rectangle("Blue", 4.0, 6.0);
            Console.WriteLine($"Rectangle - Color: {rectangle.GetColor()}, Area: {rectangle.GetArea():F2}");
            
            // Test Circle
            Circle circle = new Circle("Green", 3.0);
            Console.WriteLine($"Circle - Color: {circle.GetColor()}, Area: {circle.GetArea():F2}");
            
            Console.WriteLine();
            Console.WriteLine("Demonstrating Polymorphism:");
            Console.WriteLine("--------------------------");
            
            // Create a list to hold different shapes
            List<Shape> shapes = new List<Shape>();
            
            // Add different types of shapes to the same list
            shapes.Add(new Square("Yellow", 7.0));
            shapes.Add(new Rectangle("Purple", 3.0, 8.0));
            shapes.Add(new Circle("Orange", 4.5));
            shapes.Add(new Square("Pink", 2.5));
            shapes.Add(new Rectangle("Cyan", 5.0, 9.0));
            
            // Iterate through the list and display their areas
            // This demonstrates polymorphism - the same method call
            // behaves differently based on the actual object type
            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"Shape - Color: {shape.GetColor()}, Area: {shape.GetArea():F2}");
            }
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
