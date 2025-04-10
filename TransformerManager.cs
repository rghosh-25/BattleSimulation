using System;

public class TransformerManager
{
    private IRepository<ITransformer> repository;

    public TransformerManager(IRepository<ITransformer> repository)
    {
        this.repository = repository;
    }

    public void AddTransformer(ITransformer transformer)
    {
        repository.Add(transformer);
    }

    public void RemoveTransformer(string name)
    {
        repository.Remove(name);
    }

    public string Battle(ITransformer transformer1, ITransformer transformer2)
    {
        if (transformer1.Strength > transformer2.Strength)
        {
            transformer1.NumberOfWins++;
            transformer2.NumberOfLosses++;
            repository.Update(transformer1);
            repository.Update(transformer2);
            return $"{transformer1.Name} wins!";
        }
        else if (transformer1.Strength < transformer2.Strength)
        {
            transformer2.NumberOfWins++;
            transformer1.NumberOfLosses++;
            repository.Update(transformer1);
            repository.Update(transformer2);
            return $"{transformer2.Name} wins!";
        }
        else
        {
            return "It's a tie!";
        }
    }

    public string GetWinLossRate(ITransformer transformer)
    {
        int totalBattles = transformer.NumberOfWins + transformer.NumberOfLosses;
        double winRate = totalBattles > 0 ? (double)transformer.NumberOfWins / totalBattles * 100 : 0;
        return $"{transformer.Name} has a win rate of {winRate:F2}%";
    }

    public IEnumerable<ITransformer> GetTransformers()
    {
        return repository.GetAll();
    }
}
