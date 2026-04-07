using Mandatory2DGameFramework.model.attack;

public class Pistol : AttackItem
{
    public Pistol()
    {
        Hit = 10;
        Range = 50;
        Weight = 5;
    }
    public override string ToString()
    {
        return $"Pistol (Hit: {Hit}, Range: {Range}, Weight: {Weight})";
    }
}