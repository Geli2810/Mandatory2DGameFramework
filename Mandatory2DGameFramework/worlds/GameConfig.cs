using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds
{
    public class GameConfig
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public string Level { get; set; }

        public GameConfig(int maxX, int maxY, string level)
        {
            MaxX = maxX;
            MaxY = maxY;
            Level = level;
        }
    }
}
