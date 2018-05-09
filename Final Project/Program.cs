using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    class Program
    {
        public static void Main()
        {
            string userSelection = CharacterCreationPrompt();
            Character[] characters = CreateCharacters(userSelection);
            Dice battleDice = new Dice(characters[0].damageMax);
            Battle cageMatch = new Battle(characters, battleDice);
            cageMatch.DoBattle();
            ReplayPrompt();
        }//end of main

        public static string CharacterCreationPrompt()
        {
            Console.Clear();
            Console.WriteLine("Enter 1 to play with default characters.");
            Console.WriteLine("Enter 2 to create custom characters.");
            Console.WriteLine();
            string userSelection = GetStringInput("Enter your selection: ", "1", "2");
            return userSelection;
        }

        public static string GetStringInput(string inputDescription)
        {
            Console.Write(inputDescription);
            string userInput = Console.ReadLine();
            return userInput;
        }

        public static string GetStringInput(string inputDescription, string value1, string value2)
        // Method is called when validation is necessary for the string.
        {
            string userInput;

            do
            {
                Console.Write(inputDescription);
                userInput = Console.ReadLine().ToUpper();
            } while (userInput != value1 && userInput != value2);
            
            return userInput;
        }

        public static int GetPositiveInt(string inputDescription)
        {
            int userInput;

            Console.Write(inputDescription);

            while (!(int.TryParse(Console.ReadLine(), out userInput) &&
         userInput >= 0))
            {
                Console.Write("Please enter a positive integer: ");
            }

            return userInput;
        }

        public static Character[] CreateCharacters(string userSelection)
        {
            Character[] charactersArray;

            if (userSelection == "1")
                charactersArray = DefaultCharacters();
            else
                charactersArray = CustomCharacters();
            return charactersArray;
        }

        public static Character[] DefaultCharacters()
        {
            Character hero = new Character("Hero");
            Character monster = new Character("Monster");
            Character[] charactersArray = AddCharactersToArray(hero, monster);
            return charactersArray;
        }

        public static Character[] CustomCharacters()
        {
            // Array is object type so it may contain string and int values.
            object[] characterSpecifications = GetCharacterSpecs("hero");
            Character hero = new Character(characterSpecifications);
            characterSpecifications = GetCharacterSpecs("monster");
            Character monster = new Character(characterSpecifications);
            Character[] charactersArray = AddCharactersToArray(hero, monster);
            return charactersArray;
        }

        public static object[] GetCharacterSpecs(string characterDescription)
        {
            Console.WriteLine();
            object[] characterSpecifications = new object[3];
            characterSpecifications[0] = GetStringInput($"Enter {characterDescription}'s name: ");
            characterSpecifications[1] = GetPositiveInt($"Enter {characterDescription}'s health: ");
            characterSpecifications[2] = GetPositiveInt($"Enter {characterDescription}'s damage maximum: ");
            return characterSpecifications;
        }

        public static Character[] AddCharactersToArray(Character hero, Character monster)
        {
            Character[] charactersArray = new Character[2];
            charactersArray[0] = hero;
            charactersArray[1] = monster;
            return charactersArray;
        }

        public static void ReplayPrompt()
        {
            string userChoice = GetStringInput("Do you wish to battle again? Enter Y or N: ", "Y", "N");

            if (userChoice == "Y")
                Main();
            else if (userChoice == "N")
                Environment.Exit(0);
        }

    }//end of class
}//end of namespace
