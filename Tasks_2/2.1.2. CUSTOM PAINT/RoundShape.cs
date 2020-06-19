using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._2.CUSTOM_PAINT
{

     class RoundShape : AbstractFigure
    {
        public double radius;

        public double GetСircumference()
        {
            return redouble * Math.PI * radius;
        }
        public virtual string GetInfoFigure()
        {
            return $"Радиус = {radius}. \nДлина описанной окружности = {this.GetСircumference()}";
        }

    }

    class Round : RoundShape
    {
        public double GetArea()
        {
            return Math.PI * radius * radius;

        }

        public override string GetInfoFigure()
        {
            return $"Радиус = {radius}.\nДлина описанной окружности = {this.GetСircumference()}. \nПлощадь круга = {this.GetArea()}.";
        }
    }
    class Ring : RoundShape
    {
        public double smallRadius;

        public double GetArea()
        {
            return Math.PI * (radius * radius - smallRadius * smallRadius);
        }

        public double GetSumLengths()
        {
            return base.GetСircumference() + (redouble * Math.PI * smallRadius);
        }

        public override string GetInfoFigure()
        {
            return $"Радиус = {radius}. Малый радиус: {smallRadius}.\nСумма длин внешней и внутренней окружностей = {this.GetSumLengths()}.\nПлощадь кольца = {this.GetArea()}.";
        }
    }
}
