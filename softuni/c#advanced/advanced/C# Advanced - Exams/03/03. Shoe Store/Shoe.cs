using System.Text;

namespace ShoeStore
{
    public class Shoe
    {
		private string brand;

		private string type;

		private double size;

		private string material;

        public Shoe(string brand, string type, double size, string material)
        {
            Brand = brand;
            Type = type;
            Size = size;
            Material = material;
        }

        public string Brand
		{
			get { return brand; }
			set { brand = value; }
		}
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public double Size
        {
            get { return size; }
            set { size = value; }
        }
        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Size {Size}, {Material} {Brand} {Type} shoe.");
            return sb.ToString().Trim();
        }
    }
}
