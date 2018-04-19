using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public class Battle
    {
        Character hero, monster;
        Dice battleDice;

        public string winner { get; set; }

        public Battle(Character _hero, Character _monster, Dice _battleDice)
        {
            hero = _hero;
            monster = _monster;
            battleDice = _battleDice;
        }

        public void DoBattle()
        {
            int roundNumber = 1;

            while (hero.health > 0 && monster.health > 0)
            {
                monster.CurrentRoundDamage = monster.Attack(battleDice);
                hero.Defend(monster.CurrentRoundDamage);
                hero.CurrentRoundDamage = hero.Attack(battleDice);
                monster.Defend(hero.CurrentRoundDamage);
                DisplayBattleStats(roundNumber);
                roundNumber++;
            }

            //while (hero.health > 0 && monster.health > 0)
            //{
            //    hero.health -= 20;
            //    monster.health -= 25;
            //    DisplayBattleStats(roundNumber);
            //    roundNumber++;
            //}

            DetermineWinner();
        }

        public void DisplayBattleStats(int roundNumber)
        {
            Console.WriteLine($"Round #{roundNumber}");
            Console.WriteLine($"{monster.name} rolls a {monster.CurrentRoundDamage}");
            Console.WriteLine($"{hero.name} rolls a {hero.CurrentRoundDamage}");
            Console.Write($"{hero.name} - Health: {hero.health} - Damage Maximum: {hero.damageMax} - Attack Bonus: True\n");
            Console.Write($"{monster.name} - Health: {monster.health} - Damage Maximum: {monster.damageMax} - Attack Bonus: True\n");
            Console.WriteLine();
        }

        public void DetermineWinner()
        {
            if (hero.health <= 0 && monster.health <= 0)
                winner = "The battle is a tie!";
            else if (hero.health <= 0 && monster.health > 0)
                winner = monster.name + " is the winner!";
            else
                winner = hero.name + " is the winner!";
        }
    }
}
