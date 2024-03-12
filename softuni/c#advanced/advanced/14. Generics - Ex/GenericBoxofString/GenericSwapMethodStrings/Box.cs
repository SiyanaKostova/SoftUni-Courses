using System.Text;

namespace GenericSwapMethodStrings
{

    public class Box<T>
    {
        private List<T> items { get; set; }

        public Box()
        {
            items = new List<T>();
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            (items[secondIndex], items[firstIndex]) = (items[firstIndex], items[secondIndex]);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T item in items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

