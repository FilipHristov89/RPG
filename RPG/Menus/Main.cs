using RPG.Characters.Heroes;
using System.Text;

namespace RPG.Menus
{
    public class Main
    {
        public static void MainMenu()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine("Press any key to play");
            Console.ReadKey();

            CharacterSelect.CharacterSelection();
        }
    }
}
