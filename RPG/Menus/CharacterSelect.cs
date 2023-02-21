using RPG.Characters.Heroes;
using RPG.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static RPG.Common.Constants.ErrorConsants;

namespace RPG.Menus
{
    public class CharacterSelect
    {
        public static void CharacterSelection()
        {
            Console.WriteLine("Choose character type");
            Console.WriteLine("Options:");
            Console.WriteLine();
            Console.WriteLine("1) Warrior");
            Console.WriteLine();
            Console.WriteLine("2) Archer");
            Console.WriteLine();
            Console.WriteLine("3) Mage");

            int playerChoise = 0;
            try
            {
                playerChoise = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine(InvalidInputErrorMessage);
                CharacterSelect.CharacterSelection();
            }

            Character heroCharacter = CharacterCreation(playerChoise);
            if (heroCharacter != null)
            {
                InGame.Game(heroCharacter);
            }
            return;

        }

        //Creating a player character
        private static Character CharacterCreation(int playerChoise)
        {
            Character heroCharacter = null;

            if (playerChoise == 1)
            {
                heroCharacter = new Warrior();
            }
            else if (playerChoise == 2)
            {
                heroCharacter = new Archer();
            }
            else if (playerChoise == 3)
            {
                heroCharacter = new Mage();
            }
            else
            {
                Console.WriteLine(InvalidInputErrorMessage);
                CharacterSelection();
            }
            if (heroCharacter != null)
            {
                int buffPoints = 3;
                int spendPoints = 0;


                while (true)
                {
                    Console.WriteLine("Would you like to buff up your stats before starting?");
                    Console.Write("Responce (Y\\N): ");

                    try
                    {
                        char response = char.Parse(Console.ReadLine().ToUpper());
                        if (response != 'Y' && response != 'N')
                        {
                            Console.WriteLine(InvalidInputErrorMessage);
                            continue;
                        }

                        if (response == 'N')
                        {
                            break;
                        }

                        Console.WriteLine();

                        Console.WriteLine($"Remaining points: {buffPoints}");
                        Console.WriteLine();

                        Console.Write("Add to Strenght: ");
                        spendPoints = int.Parse(Console.ReadLine());
                        if (spendPoints > buffPoints)
                        {
                            Console.WriteLine("Not enough points");
                            continue;
                        }
                        heroCharacter.Strength += spendPoints;
                        buffPoints -= spendPoints;
                        if (buffPoints == 0)
                        {
                            break;
                        }
                        Console.WriteLine();

                        Console.Write("Add to Agility: ");
                        spendPoints = int.Parse(Console.ReadLine());
                        if (spendPoints > buffPoints)
                        {
                            Console.WriteLine("Not enough points");
                            continue;
                        }
                        heroCharacter.Agility += spendPoints;
                        buffPoints -= spendPoints;
                        if (buffPoints == 0)
                        {
                            break;
                        }
                        Console.WriteLine();

                        Console.Write("Add to Intelligence: ");
                        spendPoints = int.Parse(Console.ReadLine());
                        if (spendPoints > buffPoints)
                        {
                            Console.WriteLine("Not enough points");
                            continue;
                        }
                        heroCharacter.Intelligence += spendPoints;
                        buffPoints -= spendPoints;
                        if (buffPoints == 0)
                        {
                            break;
                        }
                        Console.WriteLine();

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(InvalidInputErrorMessage);
                        continue;
                    }

                }

                heroCharacter.Setup();
                SaveToDatabase.SaveHero(heroCharacter);
            }
            return heroCharacter;
        }
    }
}
