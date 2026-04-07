using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds
{
    public class WorldObject
    {
        public string Name { get; set; }
        public bool Lootable { get; set; }
        public bool Removeable { get; set; }

        /// <summary>
        /// Default constructor for WorldObject, it initializes the Name to an empty string, and sets Lootable and Removeable to false.
        /// </summary>
        public WorldObject()
        {
            Name = string.Empty;
            Lootable = false;
            Removeable = false;
        }


        /// <summary>
        /// Returns a string representation of the WorldObject, including the Name, Lootable, and Removeable properties.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Lootable)}={Lootable.ToString()}, {nameof(Removeable)}={Removeable.ToString()}}}";
        }
    }
}
