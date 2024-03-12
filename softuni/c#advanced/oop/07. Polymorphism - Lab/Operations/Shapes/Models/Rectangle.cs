using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models
{
    public class Rectangle : Shape
    {
        private int height;
        private int width;

        public Rectangle(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public int Height
        {
            get { return height; }
            private set { height = value; }
        }
        public int Width
        {
            get { return width; }
            private set { width = value; }
        }

        public override double CalculateArea() => this.Width * this.Height;

        public override double CalculatePerimeter() => 2 * (this.Width + this.Height);
        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
