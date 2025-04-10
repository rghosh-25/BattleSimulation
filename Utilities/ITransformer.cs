namespace BattleSimulation.Contracts;

public interface ITransformer
{
        Guid Id { get; set; }
        string? Name { get; set; }
        string? Faction { get; set; }
        int Wins { get; set; }
        int Losses { get; set; }

}
