namespace RPG.Characters.Heroes
{
    //Base class for player characters, Added score.
    public abstract class Character : ICharacter
    {
        public virtual int Strength { get; set; }

        public virtual int Agility { get; set; }

        public virtual int Intelligence { get; set; }

        public virtual int Range { get; set; }

        public virtual char Symbol { get; set; }

        public virtual int Health { get; set; }

        public virtual int Mana { get; set; }

        public virtual int Damage { get; set; }
        
        public virtual int MonstersDestroyed { get; set; }

        public abstract void Setup();
    }
}
