using RPG.Characters.Heroes;
using RPG.Data.Models;

namespace RPG.Data
{
    public class SaveToDatabase
    {
        //Saving the hero into the database
        public static void SaveHero(Character character)
        {
            var context = new RPGContext();

            // Uncommend this on first launch

            /*
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            */

            var hero = new Heroes()
            {
                CharacterClass = character.GetType().Name,
                CharacterStrength = character.Strength,
                CharacterAgility = character.Agility,
                CharacterIntelligence = character.Intelligence,
                CreatedOn = DateTime.Now
                
            };

            context.Add(hero);
            context.SaveChanges();
        }
    }
}
