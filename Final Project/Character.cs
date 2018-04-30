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
        public int CurrentRoll { get; set; }
        public int CurrentRoundDamage { get; set; }
        public int PreviousRoundHealth { get; set; }
        public bool UseBonus { get; set; }

        public Character(string _name, int _health, int _damageMax, bool _useBonus)
        {
            name = _name;
            health = _health;
            damageMax = _damageMax;
            attackBonus = 0;
            UseBonus = _useBonus;
            stillAlive = true;
        }

        public void Attack(Dice battleDice)
        {
            CurrentRoundDamage = 0;
            CurrentRoll = battleDice.Roll();
            CurrentRoundDamage = CurrentRoll;

            if (UseBonus)
                CurrentRoundDamage += attackBonus;
        }

        public void Defend(int damage)
        {
            PreviousRoundHealth = health;
            health -= damage;
        }
    }//end of class
}//end of namespace
