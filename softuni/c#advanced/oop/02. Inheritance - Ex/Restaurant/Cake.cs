using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal CakePrice = 5M; 
        private const double Calories = 1000; 
        private const double Grams = 250; 
        public Cake(string name) : base(name, CakePrice, Grams, Calories)
        {
        }
    }
}
