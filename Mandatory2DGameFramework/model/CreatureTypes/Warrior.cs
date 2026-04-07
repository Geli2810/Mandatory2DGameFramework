using Mandatory2DGameFramework.LoggingFile;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Composite;
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
    public class Warrior : Creature
    {


        protected override void BeforeReceiveHit()
        {
        }

        protected override void AfterReceiveHit()
        {
            MyLogger.Instance.LogInfo($"{Name} was hit! HP remaining: {HitPoint}");
        }

        protected override void BeforeLoot()
        {
            MyLogger.Instance.LogInfo($"{Name} is about to loot...");
        }

        protected override void AfterLoot()
        {
            MyLogger.Instance.LogInfo($"{Name} looted! Attack: {Attack?.Hit}, Defence: {Defence?.ReduceHitPoint}");
        }

        protected override void OnDeath()
        {
            MyLogger.Instance.LogInfo($"{Name} has died!");
        }
    }
}

