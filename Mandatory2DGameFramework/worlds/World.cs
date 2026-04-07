using Mandatory2DGameFramework.model.Cretures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds
{
    public class World
    {
        /// <summary>
        /// The maximum X and Y values of the world
        /// </summary>
        public int MaxX { get; set; }
        public int MaxY { get; set; }


        // world objects
        private List<WorldObject> _worldObjects;
        // world creatures
        private List<Creature> _creatures;

        /// <summary>
        /// Here we create the world with the given maxX and maxY, and we initialize the world objects and creatures lists.
        /// </summary>
        /// <param name="maxX">The maximum X value of the world that means the maximum width of the world</param>
        /// <param name="maxY"> The maximum Y value of the world, that means the maximum height of the world</param>
        public World(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            _worldObjects = new List<WorldObject>();
            _creatures = new List<Creature>();
        }



        /// <summary>
        /// returns a string with the values of the maxX and maxY of the world, and the lists of world objects and creatures.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{{{nameof(MaxX)}={MaxX.ToString()}, {nameof(MaxY)}={MaxY.ToString()}}}";
        }
    }
}
