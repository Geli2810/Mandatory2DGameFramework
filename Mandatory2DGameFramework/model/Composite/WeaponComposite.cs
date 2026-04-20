using Mandatory2DGameFramework.LoggingFile;
using Mandatory2DGameFramework.model.attack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Composite
{
    // S - Single Responsibility
    public class WeaponComposite
    {
        public List<AttackItem> Attacks { get; set; } = new List<AttackItem>(); // List of attacks>


        public void AddAttack(AttackItem attack, int maxWeight)
        {
            if (TotalWeight() + attack.Weight <= maxWeight )
                Attacks.Add(attack);
            else
                MyLogger.Instance.LogInfo("Cannot add weapon – max weight exceeded!");
        }

        public void RemoveAttack(AttackItem attack)
        {
            Attacks.Remove(attack);
        }
        public int TotalHit()
        {
            return Attacks.Sum(a => a.Hit);
        }
        public int TotalRange()
        {
            return Attacks.Sum(a => a.Range);
        }
        public int TotalWeight()
        {
            return Attacks.Sum(a => a.Weight);
        }
        public override string ToString()
        {
            return String.Join("\n", Attacks);
        }
    }
}
