using System;

public class Repository : IRepository<ITransformer>
{
    private List<ITransformer> transformers = new List<ITransformer>();

    public void Add(ITransformer transformer)
    {
        transformers.Add(transformer);
    }

    public void Remove(ITransformer transformer)
    {
        transformers.Remove(transformer);
    }

    public ITransformer Get(string name)
    {
        return transformers.FirstOrDefault(t => t.Name == name);
    }

    public IEnumerable<ITransformer> GetAll()
    {
        return transformers;
    }

    public void Update(ITransformer transformer)
    {
        var existingTransformer = Get(transformer.Name);
        if (existingTransformer != null)
        {
            existingTransformer.Faction = transformer.Faction;
            existingTransformer.Strength = transformer.Strength;
            existingTransformer.Wins = transformer.Wins;
            existingTransformer.Losses = transformer.Losses;
        }
    }
}
