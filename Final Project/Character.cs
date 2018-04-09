using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    class Character : ICharacter
    {
        private int health, damageMax, attackBonus;

        public Character()
        {
            health = 200;
        }

        public void attack()
        {
            throw new NotImplementedException();
        }

        public void defend(int damage)
        {
            throw new NotImplementedException();
        }
    }//end of class
}//end of namespace
