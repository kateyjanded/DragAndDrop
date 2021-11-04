using System.Xml.Serialization;

namespace DataAcessLibrary.Models
{
    public class Triangle 
    {
        public Triangle()
        {
            Name = "Triangle";
        }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        public Properties Properties { get; set; }
    }
}
