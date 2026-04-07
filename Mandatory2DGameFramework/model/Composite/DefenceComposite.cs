using Mandatory2DGameFramework.model.defence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Composite
{
    public class DefenceComposite
    {
        public List<DefenceItem> Defences { get; set; } = new List<DefenceItem>();

        public void AddDefence(DefenceItem defence)
        {
            Defences.Add(defence);
        }

        public void RemoveDefence(DefenceItem defence)
        {
            Defences.Remove(defence);
        }

        public int TotalReduceHitPoint()
        {
            return Defences.Sum(d => d.ReduceHitPoint);
        }
    }
}
