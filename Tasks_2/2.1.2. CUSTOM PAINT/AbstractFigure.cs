using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._2.CUSTOM_PAINT
{
    abstract class AbstractFigure
    {
        
        private double _X { get; set; }
        private double _Y { get; set; }

        public double x
        {
            get
            {
                return _X;
            }

            set
            {
                _X = value;
            }
        }
        public double y
        {
            get
            {
                return _Y;
            }

            set
            {
                _Y = value;
            }
        }

        public const int redouble = 2;

        public virtual string GetInfoPoint()
        {
            return $"Центр фигуры: x={x}, y={y}.";
        }


    }
}
