using System;

//OCP -> A software class or module should be open for extension but closed for modification

/// <summary>
/// Summary description for OCP
/// </summary>
public class Rectangle
{
	public double Width { get; set; }
	public double Height { get; set; }
}

public class Circle
{
	public double Radius { get; set; }
}

public double getArea(object[] shapes)
{
	double totalArea = 0;
	foreach (var shape in shapes)
	{
		if (shape is Rectangle)
		{
			Rectangle rectangle = (Rectangle)shape;
			totalArea += 2* (rectangle.Width + rectangle.Height);
		}
		else{
			Circle circle = (Circle)shape;
			totalArea += PI * circle.Radius * circle.Radius;
		}

		return totalArea;
	}
}

	// Now if we need to find area for another shape say trapezium, we have to add another condition .
	// OCP states that class should be opened for extension but modification.So 

	public abstract class shape{
		abstract double Area();
	}

	public class Rectangle:shape
	{
		public double Width { get; set; }
		public double Height { get; set; }

		public override Area()
		{
			return Width*Height;
		}
	} 
	public class Circle:shape
	{
		public double Radius { get; set; }
		
		public override Area()
		{
			return PI*Radius*Radius;
		}

	}

	public double getArea(shape[] shapes )
	{
		double totalArea =0;
		foreach(var shape in shapes)
		{
			totalArea = shape.Area();
		}
		return totalArea;
	}

	// now if we create class for trapezium and override the abs method Area() ,we are good to go 
	//as we don't need to alter existing functionality GetArea()