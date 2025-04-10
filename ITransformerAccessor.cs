using System;

public interface ITransformer
{
    string Name { get; set; }
    string Faction { get; set; }
    int Strength { get; set; }
    int Wins { get; set; }
    int Losses { get; set; }
}
