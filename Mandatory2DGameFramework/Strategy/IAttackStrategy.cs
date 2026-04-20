using Mandatory2DGameFramework.model.Cretures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Strategy
{
    // I - Interface Segregation
    public interface IAttackStrategy
    {
        void Attack(Creature attacker);
    }
}
