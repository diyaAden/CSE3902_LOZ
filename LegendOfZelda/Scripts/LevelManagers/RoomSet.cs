using System.Xml;

namespace LegendOfZelda.Scripts.LevelManagers
{
    class RoomSet
    {
        private readonly string winDir = System.Environment.GetEnvironmentVariable("windir");
        private XmlReader room1;

        public RoomSet()
        {
        }
        public void LoadContent()
        {
            room1 = XmlReader.Create(winDir + "\\Room1.xml");
        }
    }
}
