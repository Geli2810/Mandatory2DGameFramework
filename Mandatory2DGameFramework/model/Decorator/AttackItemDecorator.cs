using Mandatory2DGameFramework.model.attack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Decorator
{
    public class AttackItemDecorator : AttackItem
    {

        protected AttackItem _wrappedItem;

        protected AttackItemDecorator(AttackItem attackItem)
        {
            _wrappedItem = attackItem;
            Name = attackItem.Name;
            Hit = attackItem.Hit;
            Range = attackItem.Range;
        }
    }
}
