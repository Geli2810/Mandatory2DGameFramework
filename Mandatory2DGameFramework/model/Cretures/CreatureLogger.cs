using Mandatory2DGameFramework.LoggingFile;
using Mandatory2DGameFramework.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Cretures
{
    public class CreatureLogger : IObserver
    {
        void IObserver.Update(ISubject subject, string message)
        {
            if (subject is Creature creature)
            {
                string logMessage = $"Creature: {creature.Name}, HitPoint: {creature.HitPoint}, Attack: {creature.Attack}, Defence: {creature.Defence}, Message: {message}";
                MyLogger.Instance.LogInfo(logMessage);
            }

        }
    }
}
