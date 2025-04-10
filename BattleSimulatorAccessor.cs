using System;

public class BattleSimulator : IBattleSimulator
{
    public BattleResult Battle(ITransformer transformer1, ITransformer transformer2)
    {
        Random random = new Random();
        bool transformer1Wins = random.Next(2) == 0;

        if (transformer1Wins)
        {
            transformer1.Wins++;
            transformer2.Losses++;
            return new BattleResult { Winner = transformer1, Loser = transformer2 };
        }
        else
        {
            transformer2.Wins++;
            transformer1.Losses++;
            return new BattleResult { Winner = transformer2, Loser = transformer1 };
        }
    }
}
