using System;

class Program
{
    static void Main(string[] args)
    {
        var shapes = new List<Shape>();

        var shape1 = new Square("Orange", 5);
        shapes.Add(shape1);

        var shape2 = new Rectangle("Green", 2, 4);
        shapes.Add(shape2);

        var shape3 = new Circle("Red", 10);
        shapes.Add(shape3);

        foreach (var shape in shapes)
        {
            var color = shape.GetColor();
            var area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}