using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Mandatory2DGameFramework.worlds
{
    public class GameConfigLoader
    {

          public static GameConfig Load(string filePath)
          {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);

                int maxX = int.Parse(doc.SelectSingleNode("//MaxX").InnerText);
                int maxY = int.Parse(doc.SelectSingleNode("//MaxY").InnerText);
                string level = doc.SelectSingleNode("//Level").InnerText;

                return new GameConfig(maxX, maxY, level);
          }


    }
}
