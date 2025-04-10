namespace BattleSimulation.Managers
{
    public interface IBattleSimulatorManager
    {
        void AddTransformer(ITransformer transformer);
        void RemoveTransformer(string name);
        BattleResult SimulateBattle(string name1, string name2);
        TransformerStats GetTransformerStats(string name);
    }
}
