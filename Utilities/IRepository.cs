namespace BattleSimulation.Contracts;

public interface IRepository
{
    void AddTransformer(Transformer transformer);

    void RemoveTransformer(string name);

    Task<BattleResult?> TransformersBattleResult(Transformer player1, Transformer player2);

    Task<List<string>?> GetWinLossRatio(Transformer transformer);

    void GetAllTransformers();
}