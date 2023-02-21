namespace RPG.Menus
{
    public static class Exit
    {
        public static void GameOver(int monstersDestroyed)
        {
            //Ending the game and printing the score
            Console.WriteLine("Game over!");
            Console.WriteLine();
            Console.WriteLine("Cogratulation!");
            Console.WriteLine();
            string monsters = monstersDestroyed == 1 ? "monster" : "monsters";
            Console.WriteLine($"You managed to destroy {monstersDestroyed} {monsters}!");
        }
    }
}
