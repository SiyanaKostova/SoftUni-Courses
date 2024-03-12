using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ShoeStore
{
    public class ShoeStore
    {
		private string name;
		private int storageCapacity;
        private List<Shoe> shoes;

        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes= new List<Shoe>();
        }

        public string Name
		{
			get { return name; }
			set { name = value; }
		}
        public int StorageCapacity
        {
            get { return storageCapacity; }
            set { storageCapacity = value; }
        }
        public List<Shoe> Shoes
        {
            get { return shoes; }
            set { shoes = value; }
        }
        public int Count { get { return Shoes.Count; } }

        public string AddShoe(Shoe shoe) 
        {
            
            if (Shoes.Count==storageCapacity)
            {
                return "No more space in the storage room.";
            }
             Shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }
        public int RemoveShoes(string material) 
        {
            int counter = 0;
            for (int i = 0; i < Shoes.Count; i++)
            {
                if (Shoes[i].Material == material)
                {
                    counter++;
                    Shoes.RemoveAt(i);
                }
            }
            
            return counter;         

        }
        public List<Shoe> GetShoesByType(string type) 
        { 
            List<Shoe> shoesGotByType = new List<Shoe>();
            foreach (var shoe in Shoes)
            {
                if (shoe.Type.ToLower()==type.ToLower())
                {
                    shoesGotByType.Add(shoe);
                }
            }
            return shoesGotByType;
                   
        }
        public Shoe GetShoeBySize(double size)
        {
            foreach (var shoe in Shoes)
            {
                if (shoe.Size==size)
                {
                    return shoe;
                }
            }
            return null;
        }
        public string StockList(double size, string type)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Stock list for size {size} - {type} shoes:");
            bool isFound = false;
            foreach (var shoe in Shoes)
            {
                if (shoe.Size==size && shoe.Type==type)
                {
                    isFound= true;
                    sb.AppendLine(shoe.ToString());
                }
            }
            if (isFound)
            {
                return sb.ToString().Trim();
            }
            return "No matches found!";

        }





    }
}
