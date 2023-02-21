namespace RPG.Characters.Heroes
{
    internal class Warrior : Character
    {
        private readonly int warriorStrength = 3;
        private readonly int warriorAgility = 3;
        private readonly int warriorIntelligence = 0;
        private readonly int warriorRange = 1;
        private readonly char warriorSymbol = '@';
        private readonly int monsterDestroyed = 0;


        public Warrior()
        {
            this.Strength = warriorStrength;
            this.Agility = warriorAgility;
            this.Intelligence = warriorIntelligence;
            this.Range = warriorRange;
            this.Symbol = warriorSymbol;
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
