namespace RPG.Characters.Heroes
{
    public class Mage : Character
    {
        private readonly int mageStrength = 2;
        private readonly int mageAgility = 1;
        private readonly int mageIntelligence = 3;
        private readonly int mageRange = 3;
        private readonly char mageSymbol = '*';
        private readonly int monsterDestroyed = 0;

        public Mage()
        {
            this.Strength = mageStrength;
            this.Agility = mageAgility;
            this.Intelligence = mageIntelligence;
            this.Range = mageRange;
            this.Symbol = mageSymbol;
            this.MonstersDestroyed = monsterDestroyed;
        }

        public override int Strength { get; set; }

        public override int Agility { get; set; }

        public override int Intelligence { get; set; }

        public override int Range { get; set; }

        public override char Symbol { get; set; }

        public override int Health { get; set; }

        public override int Mana { get; set; }

        public override int Damage { get; set; }

        public override int MonstersDestroyed { get; set; }

        public override void Setup()
        {
            this.Health = this.Strength * 5;
            this.Mana = this.Intelligence * 3;
            this.Damage = this.Agility * 2;
        }
    }
}
