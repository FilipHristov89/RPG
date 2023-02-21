namespace RPG.Characters.Heroes
{
    internal class Archer : Character
    {
        private readonly int archerStrength = 2;
        private readonly int archerAgility = 4;
        private readonly int archerIntelligence = 0;
        private readonly int archerRange = 2;
        private readonly char archerSymbol = '#';
        private readonly int monsterDestroyed = 0;

        public Archer()
        {
            this.Strength = archerStrength;
            this.Agility = archerAgility;
            this.Intelligence = archerIntelligence;
            this.Range = archerRange;
            this.Symbol = archerSymbol;
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
