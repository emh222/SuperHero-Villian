using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public class Character : ICharacter
    {
        public int health { get; set; }
        public int damageMax { get; set; }
        public int attackBonus { get; set; }
        public string name { get; }
        public bool stillAlive { get; set; }

        public Character(string _name, int _health, int _damageMax)
        {
            name = _name;
            health = _health;
            damageMax = _damageMax;
            attackBonus = 0;
            stillAlive = true;
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
