using System.Xml.Serialization;

namespace DataAcessLibrary.Models
{

    public class Circle
    {
        public Circle()
        {
            Name = "Cicle";
        }

        [XmlAttribute("Name")]
        public string Name { get; set; }
        public Properties Properties { get; set; }
    }
}