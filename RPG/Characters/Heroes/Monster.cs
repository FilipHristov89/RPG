namespace RPG.Characters.Heroes
{
    internal class Monster : ICharacter
    {

        private readonly int enemyRange = 1;
        private readonly char enemySymbol = '◙';

        public Monster ()
        {
            this.Range = enemyRange;
            this.Symbol = enemySymbol;
        }

        public int Strength { get; set; }

        public int Agility { get; set; }

        public int Intelligence { get; set; }

        public int Range { get; set; }

        public char Symbol { get; set; }

        public int Health { get; set; }

        public int Mana { get; set; }

        public int Damage { get; set; }

        public int PositionRow { get; set; }

        public int PositionCol { get; set; }

        public void Setup()
        {
            this.Health = this.Strength * 5;
            this.Mana = this.Intelligence * 3;
            this.Damage = this.Agility * 2;
        }
    }
}
