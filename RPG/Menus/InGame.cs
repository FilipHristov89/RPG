using RPG.Characters.Heroes;
using System.Text;

using static RPG.Common.Constants.ErrorConsants;
using static RPG.Common.Constants.TargetConstants;

namespace RPG.Menus
{
    public class InGame
    {
        //Board ranges, symbol and creation
        private const int numberOfRows = 10;
        private const int numberOfCols = 10;
        private const char boardSymbol = '▒';
        private static char[,] board = new char[numberOfRows, numberOfCols];
        public static void Game(Character heroCharacter)
        {
            //Player position
            int playerRow = 1;
            int playerCol = 1;

            //Collection of enemies
            Dictionary<int, Monster> enemies = new Dictionary<int, Monster>();
            int index = 0;
            Monster monster = GetMonster(numberOfRows, numberOfCols, playerRow, playerCol);
            enemies.Add(index, monster);
            index++;

            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                if (heroCharacter.Health <= 0)
                {
                    break;
                }
                Console.WriteLine($"Health: {heroCharacter.Health}  Mana: {heroCharacter.Mana}");
                Console.WriteLine();

                BoardSetup(heroCharacter,
                    boardSymbol,
                    playerRow,
                    playerCol,
                    enemies,
                    board);

                BoardDraw(board);

                int heroAction = 0;

                //Catching potesial invalid input without throwing errors
                try
                {
                    heroAction = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine(InvalidInputErrorMessage);
                    continue;
                }

                //Player attacks
                if (heroAction == 1)
                {
                    bool enemyIsInRange = false;
                    foreach (var enemy in enemies)
                    {
                        for (int i = playerRow - heroCharacter.Range; i <= playerRow + heroCharacter.Range; i++)
                        {
                            for (int j = playerCol - heroCharacter.Range; j <= playerCol + heroCharacter.Range; j++)
                            {
                                bool inRange = i >= 0 && i < board.GetLength(0) && j >= 0 && j < board.GetLength(1);

                                if (!inRange)
                                {
                                    continue;
                                }

                                if (board[i, j] == enemy.Value.Symbol)
                                {
                                    if (enemy.Value.PositionRow == i && enemy.Value.PositionCol == j)
                                    {
                                        Console.WriteLine($"{enemy.Key}) target with remaining blood {enemy.Value.Health}!");
                                        enemyIsInRange = true;
                                    }
                                }
                            }
                        }
                    }

                    if (!enemyIsInRange)
                    {
                        Console.WriteLine(NoTargetMessage);
                    }
                    else
                    {
                        Console.WriteLine(TargetsChoise);

                        try
                        {
                            heroAction = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine(InvalidInputErrorMessage);
                            continue;
                        }

                        if (enemies.Keys.Any(x => x == heroAction))
                        {

                            enemies[heroAction].Health -= heroCharacter.Damage;
                            Console.WriteLine($"You attacked enemy {heroAction} for {heroCharacter.Damage}");

                            if (enemies[heroAction].Health <= 0)
                            {
                                enemies.Remove(heroAction);
                                heroCharacter.MonstersDestroyed++;
                                Console.WriteLine($"Enemy {heroAction} is destroyed!");
                            }
                        }
                    }
                }
                else if (heroAction == 2)
                {
                    //Player movement
                    Console.Write(MovementChoise);

                    string direction = Console.ReadLine().ToUpper();

                    bool validInput = direction == "W"
                        || direction == "S"
                        || direction == "D"
                        || direction == "A"
                        || direction == "E"
                        || direction == "Q"
                        || direction == "X"
                        || direction == "Z";

                    if (!validInput)
                    {
                        Console.WriteLine(InvalidInputErrorMessage);
                        continue;
                    }


                    if (direction == "W")
                    {
                        if (isOutSide(playerRow + 1, playerCol, board))
                        {
                            Console.WriteLine(HeroOUtOfBoundsErrorMessage);
                            continue;
                        }
                        playerRow += 1;
                    }

                    if (direction == "S")
                    {
                        if (isOutSide(playerRow - 1, playerCol, board))
                        {
                            Console.WriteLine(HeroOUtOfBoundsErrorMessage);
                            continue;
                        }
                        playerRow -= 1;
                    }

                    if (direction == "D")
                    {
                        if (isOutSide(playerRow, playerCol + 1, board))
                        {
                            Console.WriteLine(HeroOUtOfBoundsErrorMessage);
                            continue;
                        }
                        playerCol += 1;
                    }

                    if (direction == "A")
                    {
                        if (isOutSide(playerRow, playerCol - 1, board))
                        {
                            Console.WriteLine(HeroOUtOfBoundsErrorMessage);
                            continue;
                        }
                        playerCol -= 1;
                    }

                    if (direction == "E")
                    {
                        if (isOutSide(playerRow + 1, playerCol + 1, board))
                        {
                            Console.WriteLine(HeroOUtOfBoundsErrorMessage);
                            continue;
                        }
                        playerRow += 1;
                        playerCol += 1;
                    }

                    if (direction == "Q")
                    {
                        if (isOutSide(playerRow + 1, playerCol - 1, board))
                        {
                            Console.WriteLine(HeroOUtOfBoundsErrorMessage);
                            continue;
                        }
                        playerRow += 1;
                        playerCol -= 1;
                    }

                    if (direction == "X")
                    {
                        if (isOutSide(playerRow - 1, playerCol + 1, board))
                        {
                            Console.WriteLine(HeroOUtOfBoundsErrorMessage);
                            continue;
                        }
                        playerRow -= 1;
                        playerCol += 1;
                    }

                    if (direction == "Z")
                    {
                        if (isOutSide(playerRow - 1, playerCol - 1, board))
                        {
                            Console.WriteLine(HeroOUtOfBoundsErrorMessage);
                            continue;
                        }
                        playerRow -= 1;
                        playerCol -= 1;
                    }
                }

                BoardSetup(heroCharacter,
                    boardSymbol,
                    playerRow,
                    playerCol,
                    enemies,
                    board);

                MonsterActions(heroCharacter, playerRow, playerCol, enemies, monster);

                monster = GetMonster(numberOfRows, numberOfCols, playerRow, playerCol);
                enemies.Add(index, monster);
                index++;
            }

            Exit.GameOver(heroCharacter.MonstersDestroyed);
        }

        private static void MonsterActions(Character heroCharacter, int playerRow, int playerCol, Dictionary<int, Monster> enemies, Monster monster)
        {
            foreach (var enemy in enemies)
            {
                //Enemy attacks
                bool monsterAttacked = false;

                for (int i = enemy.Value.PositionRow - 1; i <= enemy.Value.PositionRow + 1; i++)
                {
                    for (int j = enemy.Value.PositionCol - 1; j <= enemy.Value.PositionCol + 1; j++)
                    {
                        bool inRange = i > 0 && i < board.GetLength(0) && j > 0 && j < board.GetLength(1);

                        if (!inRange)
                        {
                            continue;
                        }

                        if (board[i, j] == heroCharacter.Symbol)
                        {
                            Console.WriteLine($"The monster attacked you for {monster.Damage} damage!");
                            heroCharacter.Health -= enemy.Value.Damage;
                            monsterAttacked = true;
                            break;
                        }
                    }
                }
                // Enemy movement if no player in range
                if (!monsterAttacked)
                {
                    if (playerRow < enemy.Value.PositionRow)
                    {
                        enemy.Value.PositionRow -= 1;
                    }
                    if (playerRow > enemy.Value.PositionRow)
                    {
                        enemy.Value.PositionRow += 1;
                    }
                    if (playerCol < enemy.Value.PositionCol)
                    {
                        enemy.Value.PositionCol -= 1;
                    }
                    if (playerCol > enemy.Value.PositionCol)
                    {
                        enemy.Value.PositionCol += 1;
                    }
                }

            }
        }

        //Player movement range check
        private static bool isOutSide(int playerRow, int playerCol, char[,] board)
        {
            return playerRow < 0 || playerCol < 0 || playerRow >= board.GetLength(0) || playerCol >= board.GetLength(1);
        }

        //Player and monsters setup on the board
        private static void BoardSetup(ICharacter heroCharacter, char boardSymbol, int playerRow, int playerCol, Dictionary<int, Monster> enemies, char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (row == playerRow && col == playerCol)
                    {
                        board[row, col] = heroCharacter.Symbol;
                        continue;
                    }
                    board[row, col] = boardSymbol;

                    foreach (var monster in enemies)
                    {
                        if (row == monster.Value.PositionRow && col == monster.Value.PositionCol)
                        {
                            board[row, col] = monster.Value.Symbol;
                            continue;
                        }
                    }
                }
            }
        }

        //Printing the board
        private static void BoardDraw(char[,] board)
        {
            for (int row = board.GetLength(0) - 1; row >= 0; row--)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col]);
                }
                Console.WriteLine();
            }


            Console.WriteLine("Choose action");
            Console.WriteLine("1) Attack");
            Console.WriteLine("2) Move");

        }

        //Creating a monster
        private static Monster GetMonster(int numberOfRows, int numberOfCols, int playerRow, int playerCol)
        {
            var randomNumber = new Random();
            int monsterStrenght = randomNumber.Next(1, 3);
            int monsterAgility = randomNumber.Next(1, 3);
            int monsterIntelligence = randomNumber.Next(1, 3);
            int monsterStartingRow = randomNumber.Next(0, numberOfRows);
            int monsterStartingCol = randomNumber.Next(0, numberOfCols);

            if (monsterStartingRow == playerRow && monsterStartingCol == playerCol)
            {
                monsterStartingRow = randomNumber.Next(0, numberOfRows);
                monsterStartingCol = randomNumber.Next(0, numberOfCols);
            }

            Monster monster = new Monster()
            {
                Strength = monsterStrenght,
                Agility = monsterAgility,
                Intelligence = monsterIntelligence,
                PositionRow = monsterStartingRow,
                PositionCol = monsterStartingCol
            };
            monster.Setup();

            return monster;
        }
    }
}
