namespace BattleSimulation.Contracts;

public class Repository : IRepository
{

    private List<Transformer> transformers = new List<Transformer>();

    private readonly Dictionary<string, (int Wins, int Losses)> transformerRecords;

    public async Task<List<string>?> GetWinLossRatio(Transformer transformer)
    {
        if (transformer == null || string.IsNullOrEmpty(transformer.Name))
        {
            return null;
        }

        if (transformerRecords.TryGetValue(transformer.Name, out var record))
        {
            var winLossRatio = new List<string>
             {
             $"Wins: {record.Wins}",
             $"Losses: {record.Losses}",
             $"Win/Loss Ratio: {(record.Losses == 0 ? record.Wins : (double)record.Wins / record.Losses):0.00}"
             };
            return await Task.FromResult(winLossRatio);
        }
        else
        {
            return null;
        }
    }

    public void AddTransformer(Transformer transformer)
    {
        transformers.Add(transformer);
        Console.WriteLine($"{transformer.Name} added.");
    }

    public void RemoveTransformer(string name)
    {
        var transformer = transformers.Find(t => t.Name == name);
        if (transformer != null)
        {
            transformers.Remove(transformer);
            Console.WriteLine($"{name} removed.");
        }
        else
        {
            Console.WriteLine($"{name} not found.");
        }
    }

    public void GetAllTransformers()
    {
        foreach (var transformer in transformers)
        {
            transformer.DisplayInfo();
        }
    }

}
