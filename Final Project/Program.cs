using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Character hero = new Character("Spiderman", 100, 25);
            Character monster = new Character("Dr. Octopus", 100, 25);
            Dice battleDice = new Dice();
            Battle cageMatch = new Battle(hero, monster, battleDice);
            cageMatch.DoBattle();


        }//end of main
    }//end of class
}//end of namespace
