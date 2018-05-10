using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public class Battle
    {
        private Character hero;
        private Character monster;
        private Dice battleDice;

        private string winner { get; set; }

        public Battle(Character[] characters, Dice _battleDice)
        {
            hero = characters[0];
            monster = characters[1];
            battleDice = _battleDice;
        }

        public void DoBattle()
        {
            Console.Clear();
            SetBonusValue();
            DisplayBonusValues(monster.AttackBonus, hero.AttackBonus);
            BattleLoop();
            DetermineWinner();
            DisplayWinner();
        }

        public void SetBonusValue()
        {
            monster.AttackBonus = battleDice.Roll();
            hero.AttackBonus = battleDice.Roll();
        }

        public void DisplayBonusValues(int monsterBonus, int heroBonus)
        {
            Console.WriteLine("Bonus Roll");
            Console.WriteLine($"{monster.Name} bonus attack = {monsterBonus}");
            Console.WriteLine($"{hero.Name} bonus attack = {heroBonus}");
            Console.WriteLine();
        }

        public void BattleLoop()
        {
            int roundNumber = 1;

            while (hero.Health > 0 && monster.Health > 0)
            {
                OffenseAndDefense();
                DisplayBattleStats(roundNumber);
                RemoveBonus();  // Stops bonus application after first round. Comment this line out to use bonus in every round.
                roundNumber++;
            }
        }

        public void OffenseAndDefense()
        {
            monster.Attack(battleDice);
            hero.Defend(monster.CurrentRoundDamage);
            hero.Attack(battleDice);
            monster.Defend(hero.CurrentRoundDamage);
        }

        public void DisplayBattleStats(int roundNumber)
        {
            Console.WriteLine($"Round #{roundNumber}");
            Console.WriteLine($"{monster.Name} rolls a {monster.CurrentRoll}");
            Console.WriteLine($"{hero.Name} rolls a {hero.CurrentRoll}");
            Console.Write($"{hero.Name} | Health: {hero.PreviousRoundHealth} - {monster.CurrentRoundDamage} = {hero.Health} | Damage Maximum: {hero.DamageMax} | Attack Bonus: {hero.UseBonus}\n");
            Console.Write($"{monster.Name} | Health: {monster.PreviousRoundHealth} - {hero.CurrentRoundDamage} = {monster.Health} | Damage Maximum: {monster.DamageMax} | Attack Bonus: {monster.UseBonus}\n");
            Console.WriteLine();
        }

        public void RemoveBonus()
        // Disables use of attack bonus when called
        {
            if (hero.UseBonus == true)
                hero.UseBonus = false;
            if (monster.UseBonus == true)
                monster.UseBonus = false;
        }

        public void DetermineWinner()
        {
            if (hero.Health <= 0 && monster.Health <= 0)
                winner = "The battle is a tie!";
            else if (hero.Health <= 0 && monster.Health > 0)
                winner = monster.Name + " is the winner!";
            else
                winner = hero.Name + " is the winner!";
        }

        public void DisplayWinner()
        {
            Console.WriteLine(winner);
            Console.WriteLine();
        }
    }
}
