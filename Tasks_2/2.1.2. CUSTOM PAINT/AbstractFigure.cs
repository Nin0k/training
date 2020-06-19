using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._2.CUSTOM_PAINT
{
    abstract class AbstractFigure
    {
        public double x;
        public double y;

        public const int redouble = 2;

        public virtual string GetInfoPoint()
        {
            return $"Центр фигуры: x={x}, y={y}.";
        }


    }
}
