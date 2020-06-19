using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._2.CUSTOM_PAINT
{
    abstract class Polygons : AbstractFigure
    {
        public double width;
        public double height;
        public abstract double GetArea();
        public abstract double GetPerimeter();

        public string InfoFigure()
        {
            return $"Площадь = {this.GetArea()}. \nПериметр = {this.GetPerimeter()}";
        }
        
    }
    class Rectangle : Polygons
    {
        public override double GetArea()
        {
            return width * height;
        }

        public override double GetPerimeter()
        {
            return redouble * (width + height);
        }
    }

    class Square : Polygons
    {
        const int sides = 4;
        public override double GetArea()
        {
            return width * width;
        }

        public override double GetPerimeter()
        {
            return sides * width;
        }
    }

    class Triangle : Polygons
    {
        public double c;
        const double half = 0.5;
        public override double GetArea()
        {
            return half * width * height;
        }

        public override double GetPerimeter()
        {
            return width + height + c;
        }
    }
}
