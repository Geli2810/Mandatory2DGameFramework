using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.Strategy;

public class PowerAttack : IAttackStrategy
{
    public void Attack(Creature target)
    {
        int damage = 25;
        Console.WriteLine($"Power Attack with {damage} damage!");
        target.ReceiveHit(damage);
    }
}