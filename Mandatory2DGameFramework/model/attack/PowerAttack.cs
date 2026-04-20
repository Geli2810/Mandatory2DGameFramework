using Mandatory2DGameFramework.LoggingFile;
using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.Strategy;
using System;

public class PowerAttack : IAttackStrategy
{
    public void Attack(Creature target)
    {
        int damage = 25;
        MyLogger.Instance.LogInfo($"Power Attack with {damage} damage!");
        target.ReceiveHit(damage);
    }
}