using System;

public class Transformer : ITransformer
{
    public string Name { get; set; }
    public string Faction { get; set; }
    public int Strength { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
}
