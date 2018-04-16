using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public class Dice
    {
        private int sides;
        Random d = new Random();

        public Dice()
        {
            sides = 20;
        }

        public void Roll()
        {
            d.Next(0, sides);
        }
    }//end of class
}//end of namespace
