using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public class Character : ICharacter
    {
        private string name;
        private int health;
        private int damageMax;
        private int attackBonus;
        private int currentRoll;
        private int currentRoundDamage;
        private int previousRoundHealth;
        private bool useBonus;

        public Character(string characterType)
        // Constructor for default characters
        {
            name = characterType;
            health = 30;
            damageMax = 10;
            attackBonus = 0;
            UseBonus = true;    // By default, the bonus is used in the first round.
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
        }

        public string Name
        {
            get { return name; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int DamageMax
        {
            get { return damageMax; }
            set { damageMax = value; }
        }

        public int AttackBonus
        {
            get { return attackBonus; }
            set { attackBonus = value; }
        }

        public int CurrentRoundDamage
        {
            get { return currentRoundDamage; }
            set { currentRoundDamage = value; }
        }

        public int CurrentRoll
        {
            get { return currentRoll; }
            set { currentRoll = value; }
        }

        public int PreviousRoundHealth
        {
            get { return previousRoundHealth; }
            set { previousRoundHealth = value; }
        }

        public bool UseBonus
        {
            get { return useBonus; }
            set { useBonus = value; }
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
    }
}
