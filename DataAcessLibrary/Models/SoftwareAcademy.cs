using System.Xml.Serialization;

namespace DataAcessLibrary.Models
{
    public class SoftwareAcademy
    {
        [XmlElement ("Shapes")]
        public Shapes Shapes { get; set; }
        public override string ToString()
        {
            return "Software Academy";
        }
    }
}
