using System;

public interface IBattleSimulator
{
    BattleResult Battle(ITransformer transformer1, ITransformer transformer2);
}
