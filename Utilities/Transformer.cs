namespace BattleSimulation.Contracts
{
    public class Transformer : ITransformer
    {
        public Transformer()
        {
        }

        public Transformer(string name)
        {
            Name = name;
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Faction { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        public int Strength { get; set; }

        internal void DisplayInfo()
        {

            Console.WriteLine("Name:", Name);
            Console.WriteLine("Wins:", Wins);
            Console.WriteLine("Losses:", Losses);
        }
    }
}
