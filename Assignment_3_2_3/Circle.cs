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
    public override string ToString() // print the area of circle
    {
        return Area.ToString();
    }

    // overloading the '+' operator ----------------
    public static Circle operator +(Circle left, Circle right)
    {
        // returns a new circle with combined area
        double newArea = left.Area + right.Area;
        double newRadius = Math.Sqrt((newArea / Math.PI)); // radius = sqrt( area / pi )
        return new Circle(newRadius);
    }
    // overloading the '-' operator ----------------
    public static Circle operator -(Circle left, Circle right)
    {
        // returns a new circle with difference of areas
        double newArea = left.Area - right.Area;
        if (newArea < 0)
        {
            newArea *= -1; // if left circle is smaller than right circle, ensure newArea is positive rather than negative
        }
        double newRadius = Math.Sqrt((newArea / Math.PI)); // radius = sqrt( area / pi )
        return new Circle(newRadius);
    }
}
