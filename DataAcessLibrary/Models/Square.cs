using System.Xml.Serialization;

namespace DataAcessLibrary.Models
{
    public class Square
    {
        public Square()
        {
            Name = "Square";
        }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        public Properties Properties { get; set; }
    }
}
