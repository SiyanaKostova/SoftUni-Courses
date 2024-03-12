using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {
        }
        public override int Age
        {
            get => base.Age;
            set
            {
                if (value <= 15)
                {
                    base.Age = value;
                }
            }
        }
    }
}
