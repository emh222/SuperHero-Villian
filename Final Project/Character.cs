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
        public int CurrentRoundDamage { get; set; }

        public Character(string _name, int _health, int _damageMax)
        {
            name = _name;
            health = _health;
            damageMax = _damageMax;
            attackBonus = 0;
            stillAlive = true;
        }

        public int Attack(Dice battleDice)
        {
            int damage = battleDice.Roll();
            return damage;
        }

        public void Defend(int damage)
        {
            health -= damage;
        }
    }//end of class
}//end of namespace
