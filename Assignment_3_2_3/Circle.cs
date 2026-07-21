using System;
using System.Collections.Generic;
using System.Text;

namespace CircleClassNamespace;

internal class Circle
{
    double Radius { get; set; }
    double Area { get; set; }
    double Circumference { get; set; }
    public Circle(double radius)
    {
        Radius = radius;
        Area = Math.PI * Math.Pow(radius, 2); // area = pi * r^2
        Circumference = 2 * Math.PI * radius; // circ = 2 * pi * r
    }

    // Overloading the '+' operator
    public static Circle operator +(Circle left, Circle right)
    {
        // Returns a new Square with combined side lengths
        double newArea = left.Area + right.Area;
        double newRadius = Math.Sqrt((newArea / Math.PI)); // radius = sqrt( area / pi )
        return new Circle(newRadius);
    }
    // Overloading the '-' operator
    public static Circle operator -(Circle left, Circle right)
    {
        // Returns a new Square with combined side lengths
        double newArea = left.Area - right.Area;
        double newRadius = Math.Sqrt((newArea / Math.PI)); // radius = sqrt( area / pi )
        return new Circle(newRadius);
    }

}
