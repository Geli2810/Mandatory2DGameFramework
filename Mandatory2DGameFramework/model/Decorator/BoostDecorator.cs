using Mandatory2DGameFramework.model.attack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Decorator
{
    public class BoostDecorator : AttackItemDecorator
    {
        private int _boostAmount;

        public BoostDecorator(AttackItem attackItem, int boostAmount) : base(attackItem)
        {
            _boostAmount = boostAmount;
            Hit = _wrappedItem.Hit + _boostAmount;
        }

    }
}
