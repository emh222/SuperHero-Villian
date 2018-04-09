using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    class Dice
    {
        private int sides;

        public Dice()
        {
            sides = 20;
        }

        public void roll()
        {
            Random d = new Random();
            d.Next(0, sides);
        }
    }//end of class
}//end of namespace
