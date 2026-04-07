using Mandatory2DGameFramework.LoggingFile;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.model.defence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.CreatureTypes
{
    public class Goblin : Creature
    {


        protected override void AfterLoot()
        {
            MyLogger.Instance.LogInfo($"You have looted {Name} and received {HitPoint} hit points. You now have {HitPoint} hit points. You have {Attack} attack and {Defence} defence.");
        }

        protected override void AfterReceiveHit()
        {
            MyLogger.Instance.LogInfo($"You have hit {Name} and it has {HitPoint} hit points left. You have {Attack} attack and {Defence} defence.");
        }

        protected override void BeforeLoot()
        {
            MyLogger.Instance.LogInfo($"You are about to loot {Name}.........");

        }

        protected override void BeforeReceiveHit()
        {

        }

        protected override void OnDeath()
        {
            Console.WriteLine($"The creature {Name} has died.");

        }
    }
}
