using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.defence
{
    public class DefenceItem:WorldObject
    {
        /// <summary>
        /// The ReduceHitPoint property represents the amount of hit points to reduce when the DefenceItem is used.
        /// </summary>
        public int ReduceHitPoint { get; set; }

        /// <summary>
        /// here is the constructor for the DefenceItem class, it initializes the Name to an empty string and ReduceHitPoint to 0.
        /// </summary>
        public DefenceItem()
        {
            Name = string.Empty;
            ReduceHitPoint = 0;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(ReduceHitPoint)}={ReduceHitPoint.ToString()}}}";
        }
    }
}
