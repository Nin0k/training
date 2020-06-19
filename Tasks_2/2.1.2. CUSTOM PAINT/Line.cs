using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._2.CUSTOM_PAINT
{
    class Line : AbstractFigure
    {
        public double x1;
        public double y1;
        public double x2;
        public double y2;
      
        public override string GetInfoPoint()
        {
            x = (x1 + x2) / redouble;
            y = (y1 + y2) / redouble;
            return $"Центр фигуры: x={x}, y={y}. \n";
        }

        public string GetLineLength()
        {
            double lineLength = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            return $"Длина линии {lineLength}";
        }

    }
}
