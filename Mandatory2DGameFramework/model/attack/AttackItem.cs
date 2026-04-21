using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.attack
{
    public abstract class AttackItem : WorldObject
    {
        public string  Name { get; set; }
        public int Hit { get; set; }
        public int Range { get; set; }
        public int Weight { get; set; }


        /// <summary>
        /// Constructor for AttackItem, it initializes the Name to an empty string, Hit to 0, and Range to 0.
        /// </summary>
        public AttackItem()
        {
            Name = string.Empty;
            Hit = 0;
            Range = 0;
            Weight = 0;
        }


        public static AttackItem operator + (AttackItem a, AttackItem b)
        {
            return new Sword
            {
                Name = $"{a.Name} + {b.Name}",
                Hit = a.Hit + b.Hit,
                Range = Math.Max(a.Range, b.Range),
                Weight = a.Weight + b.Weight
            };
        }

        public override string ToString()
        {
            return $"Name: {Name}, Hit: {Hit}, Range: {Range}, Weight: {Weight}";
        }
    }
}
