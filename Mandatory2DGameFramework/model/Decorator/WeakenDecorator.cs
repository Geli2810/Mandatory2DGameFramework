using Mandatory2DGameFramework.model.attack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Decorator
{
    public class WeakenDecorator : AttackItemDecorator
    {
        private int _weakenAmount;

        public WeakenDecorator(AttackItem attackItem, int weakenAmount) : base(attackItem)
        {
            _weakenAmount = weakenAmount;
            Hit = Math.Max(0, _wrappedItem.Hit - _weakenAmount); // Hit kan ikke gå under 0
        }
    }
}
