using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    class Program
    {
        static void Main()
        {
            string userSelection = CharacterCreationPrompt();
            Character[] characters = CreateCharacters(userSelection);
            Dice battleDice = new Dice(characters[0].damageMax);
            Battle cageMatch = new Battle(characters, battleDice);
            cageMatch.DoBattle();
            ReplayPrompt();
        }//end of main

        static string CharacterCreationPrompt()
        {
            Console.Clear();
            Console.WriteLine("Enter 1 to play with default characters.");
            Console.WriteLine("Enter 2 to create custom characters.");
            Console.WriteLine();
            string userSelection = GetStringInput("Enter your selection");
            return userSelection;
        }

        static string GetStringInput(string inputDescription)
        {
            Console.Write(inputDescription + ": ");
            string userInput = Console.ReadLine();
            return userInput;
        }

        static int GetIntInput(string inputDescription)
        {
            bool repeat = true;
            int userInput;

            do
            {
                Console.Write(inputDescription + ": ");
                if (!int.TryParse(Console.ReadLine(), out userInput))
                    Console.Write("Value must be an integer. ");
                else if (userInput < 0)
                    Console.Write("Value must be a positive integer. ");
                else
                    repeat = false;
            } while (repeat);

            return userInput;
        }

        //public int ValidateInput(string userEntry)
        //{
        //    int validInput;

        //    return validInput;
        //}

        static Character[] CreateCharacters(string userSelection)
        {
            Character[] charactersArray;

            if (userSelection == "1")
                charactersArray = DefaultCharacters();
            else
                charactersArray = CustomCharacters();
            return charactersArray;
        }

        static Character[] DefaultCharacters()
        {
            Character hero = new Character("Hero");
            Character monster = new Character("Monster");
            Character[] charactersArray = AddCharactersToArray(hero, monster);
            return charactersArray;
        }

        static Character[] CustomCharacters()
        {
            object[] characterSpecifications = GetCharacterSpecs("hero");
            Character hero = new Character(characterSpecifications);
            characterSpecifications = GetCharacterSpecs("monster");
            Character monster = new Character(characterSpecifications);
            Character[] charactersArray = AddCharactersToArray(hero, monster);
            return charactersArray;
        }

        static object[] GetCharacterSpecs(string characterDescription)
        {
            object[] characterSpecifications = new object[3];
            characterSpecifications[0] = GetStringInput($"Enter {characterDescription}'s name");
            characterSpecifications[1] = GetIntInput($"Enter {characterDescription}'s health");
            characterSpecifications[2] = GetIntInput($"Enter {characterDescription}'s damage maximum");
            return characterSpecifications;
        }

        static Character[] AddCharactersToArray(Character hero, Character monster)
        {
            Character[] charactersArray = new Character[2];
            charactersArray[0] = hero;
            charactersArray[1] = monster;
            return charactersArray;
        }

        //static void DisplayWinner(Battle battleName) 
        //{
        //    Console.WriteLine(battleName.winner);
        //    Console.WriteLine();
        //    //Console.Write("Press Enter to battle again.");
        //    //Console.ReadLine();
        //    //Main();
        //}

        static void ReplayPrompt()
        {
            string userChoice;

            do
            {
                Console.Write("Do you wish to battle again? Enter Y or N: ");
                userChoice = Console.ReadLine().ToUpper();
                if (userChoice == "Y")
                    Main();
                else if (userChoice == "N")
                    Environment.Exit(0);

            } while (userChoice != "Y" || userChoice != "N");
        }

    }//end of class
}//end of namespace
