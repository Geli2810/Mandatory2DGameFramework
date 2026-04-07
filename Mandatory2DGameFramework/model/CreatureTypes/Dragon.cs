using Mandatory2DGameFramework.LoggingFile;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.CreatureTypes
{
    public class Dragon : Creature
    {

        protected override void AfterLoot()
        {
            MyLogger.Instance.LogInfo($"The {Name} has been hit." + HitPoint + " hitpoints left." + Attack.Name + " has been looted." + Defence.Name + " has been looted.");

        }

        protected override void AfterReceiveHit()
        {
            MyLogger.Instance.LogInfo($"The {Name} has been hit. " + HitPoint + " hitpoints left. " + Attack?.Name + " attack. " + Defence?.Name + " defence.");
        }

        protected override void BeforeLoot()
        {
            MyLogger.Instance.LogInfo($"The {Name} has been looted.");
        }



        protected override void BeforeReceiveHit()
        {
        }

        protected override void OnDeath()
        {
            MyLogger.Instance.LogInfo($"The {Name} has died.");
        }
    }
}
