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
            string userSelection = CharacterCreationPrompt();
            Character[] characters = CreateCharacters(userSelection);
            Dice battleDice = new Dice(characters[0].damageMax);
            Battle cageMatch = new Battle(characters, battleDice);
            cageMatch.DoBattle();
            DisplayWinner(cageMatch);
        }//end of main

        static string CharacterCreationPrompt()
        {
            Console.Clear();
            Console.WriteLine("Enter 1 to play with default characters.");
            Console.WriteLine("Enter 2 to create custom characters.");
            Console.WriteLine();
            string userSelection = GetUserInput("Enter your selection");
            return userSelection;
        }

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
            string[] characterSpecifications = GetCharacterSpecs("hero");
            Character hero = new Character(characterSpecifications);
            characterSpecifications = GetCharacterSpecs("monster");
            Character monster = new Character(characterSpecifications);
            Character[] charactersArray = AddCharactersToArray(hero, monster);
            return charactersArray;
        }

        static string[] GetCharacterSpecs(string characterDescription)
        {
            string[] characterSpecifications = new string[3];
            characterSpecifications[0] = GetUserInput($"Enter {characterDescription}'s name");
            characterSpecifications[1] = GetUserInput($"Enter {characterDescription}'s health");
            characterSpecifications[2] = GetUserInput($"Enter {characterDescription}'s damage maximum");
            return characterSpecifications;
        }

        static Character[] AddCharactersToArray(Character hero, Character monster)
        {
            Character[] charactersArray = new Character[2];
            charactersArray[0] = hero;
            charactersArray[1] = monster;
            return charactersArray;
        }

        static string GetUserInput(string inputDescription)
        {
            Console.Write(inputDescription + ": ");
            string userInput = Console.ReadLine();
            return userInput;
        }

        static void DisplayWinner(Battle battleName) 
        {
            Console.WriteLine(battleName.winner);
            Console.WriteLine();
            Console.Write("Press Enter to battle again.");
            Console.ReadLine();
            CharacterCreationPrompt();
        }
    }//end of class
}//end of namespace
