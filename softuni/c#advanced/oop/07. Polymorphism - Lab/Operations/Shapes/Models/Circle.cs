using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models
{
    public class Circle : Shape
    {
        private int radius;

        public Circle(int radius)
        {
            Radius = radius;
        }

        public int Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public override double CalculateArea() => Math.PI * Radius * Radius;

        public override double CalculatePerimeter() => Math.PI * Radius * 2;
        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
