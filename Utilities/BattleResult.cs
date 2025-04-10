namespace BattleSimulation.Contracts;

public class BattleResult
{
    public Transformer? Winner { get; set; }
    public Transformer? Loser { get; set; }
    public bool IsTie { get; set; }
}