using Mandatory2DGameFramework.LoggingFile;
using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.Strategy;

public class NormalAttack : IAttackStrategy
{
    public void Attack(Creature target)
    {
        int damage = 10;
        MyLogger.Instance.LogInfo($"Normal Attack with {damage} damage!");
        target.ReceiveHit(damage);
    }
}