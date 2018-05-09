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

        public Character(string characterType)
        // Constructor for default characters
        {
            name = characterType;
            health = 30;
            damageMax = 10;
            attackBonus = 0;
            UseBonus = true;    // By default, the bonus is used in the first round.
            stillAlive = true;  // Will be updated to false when health <= 0.
        }

        public Character(object[] characterSpecifications)
        // Constructor for custom characters
        {
            // Cast operators are necessary to avoid an explicit type conversion error.
            name = (string)characterSpecifications[0];
            health = (int)characterSpecifications[1];
            damageMax = (int)characterSpecifications[2];
            attackBonus = 0;
            UseBonus = true;    // By default, the bonus is used in the first round.
            stillAlive = true;  // Will be updated to false when health <= 0.
        }

        public void Attack(Dice battleDice)
        {
            CurrentRoundDamage = 0;
            CurrentRoll = battleDice.Roll();
            CurrentRoundDamage = CurrentRoll;

            if (UseBonus)
            {
                CurrentRoundDamage += attackBonus;
            }
        }

        public void Defend(int damage)
        {
            PreviousRoundHealth = health;
            health -= damage;
        }
    }//end of class
}//end of namespace
