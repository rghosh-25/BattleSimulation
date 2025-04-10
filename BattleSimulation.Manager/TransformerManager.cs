namespace BattleSimulation.Manager;

using System.Linq;
using BattleSimulation.Contracts;

public class TransformerManager : IRepository
{
    private IRepository repo;

    public TransformerManager(IRepository repository)
    {
        repo = repository;
    }

    public async Task<Transformer?> AddTransformer(Transformer transformer)
    {
        await repo.AddTransformer(transformer);
        return await Task.FromResult(transformer);
    }

    public async Task<Transformer?> RemoveTransformer(Transformer transformer)
    {
        var existingTransformer = repo.FirstOrDefault(t => t.Id == transformer.Id);
        if (existingTransformer != null)
        {
            repo.Remove(existingTransformer);
            return await Task.FromResult(existingTransformer);
        }
        return await Task.FromResult<Transformer?>(null);
    }

    public async Task<BattleResult?> TransformersBattleResult(Transformer player1, Transformer player2)
    {
        if (player1 == null || player2 == null)
        {
            return await Task.FromResult<BattleResult?>(null);
        }

        BattleResult result = new BattleResult();
        if (player1.Strength > player2.Strength)
        {
            player1.Wins++;
            player2.Losses++;
            result.Winner = player1;
            result.Loser = player2;
        }
        else if (player1.Strength < player2.Strength)
        {
            player2.Wins++;
            player1.Losses++;
            result.Winner = player2;
            result.Loser = player1;
        }
        else
        {
            result.IsTie = true;
        }

        return await Task.FromResult(result);
    }

    public async Task<List<string>?> GetWinLossRatio(Transformer transformer)
    {
        var existingTransformer = repo.FirstOrDefault(t => t.Id == transformer.Id);
        if (existingTransformer != null)
        {
            int totalBattles = existingTransformer.Wins + existingTransformer.Losses;
            double winRate = totalBattles > 0 ? (double)existingTransformer.Wins / totalBattles * 100 : 0;
            double lossRate = totalBattles > 0 ? (double)existingTransformer.Losses / totalBattles * 100 : 0;

            List<string> winLossRatio = new List<string>
             {
             $"Win Rate: {winRate:F2}%",
             $"Loss Rate: {lossRate:F2}%"
             };

            return await Task.FromResult(winLossRatio);
        }
        return await Task.FromResult<List<string>?>(null);
    }

    public async Task<List<string>?> GetAllTransformers()
    {
        List<string> transformerNames = repo.Select(t => t.Name).ToList();
        return await Task.FromResult(transformerNames);
    }
}
