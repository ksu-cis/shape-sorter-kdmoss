using System;
using System.Linq;
using System.Collections.Generic;

namespace ShapeSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Shapes!");
            Console.WriteLine("----------------");

            List<IShape> shapes = new List<IShape>()
            {
                new Circle(4.0),
                new Rectangle(6, 7),
                new Square(5.0),
                new Circle(5.0),
                new Rectangle(2.0, 4.0),
                new Circle(3.0),
                new Square(10)
            };

            foreach (IShape shape in shapes)
            {
                Console.WriteLine($"Area of shape is {shape.Area}");
            }

            Console.WriteLine("----------------");

            // Get shapes above given area
            int minArea = 50;
            IEnumerable<IShape> filteredShapes = shapes.Where(shape => shape.Area > minArea);
            Console.WriteLine($"Shapes with an area greater than {minArea}:");

            foreach (IShape shape in filteredShapes)
            {
                Console.WriteLine($"Area of shape is {shape.Area}");
            }

            Console.WriteLine("----------------");

            // Get circles
            IEnumerable<Circle> circles = shapes.OfType<Circle>();
            Console.WriteLine($"All circles:");

            foreach (Circle circle in circles)
            {
                Console.WriteLine($"Circle with radius {circle.Radius} and area {circle.Area}");
            }

            Console.WriteLine("----------------");

            // Get circles below given area
            int maxArea = 30;
            IEnumerable<Circle> filteredCircles = circles.Where(circle => circle.Area < maxArea);
            Console.WriteLine($"Circles with area < {maxArea}:");

            foreach (Circle circle in filteredCircles)
            {
                Console.WriteLine($"Circle with radius {circle.Radius} and area {circle.Area}");
            }

            Console.WriteLine("----------------");

            // Group by even or odd
            Console.WriteLine("Grouping by area:");

            foreach (var group in shapes.GroupBy(shape => shape.Area % 2 == 0))
            {
                Console.WriteLine(group.Key ? "Even Area" : "Odd Area");

                foreach (var shape in group)
                {
                    Console.WriteLine($"Area of shape is {shape.Area}");
                }
            }

            Console.WriteLine("----------------");

            // Group by type
            Console.WriteLine("Group by type:");

            foreach (var group in shapes.GroupBy(shape => shape.GetType()))
            {
                Console.WriteLine($"Shapes of type {group.Key}:");

                foreach (var shape in group)
                {
                    Console.WriteLine($"Area of shape is {shape.Area}");
                }
            }

            Console.ReadKey();
        }
    }
}