using System.Collections.Generic;
using System.Xml.Serialization;

namespace DataAcessLibrary.Models
{

    public class Shapes 
    {
        public override string ToString()
        {
            return "Shapes";
        }
        [XmlElement("Circle")]
        public List<Circle> Circle { get; set; }
        [XmlElement("Triangle")]
        public List<Triangle> Triangle { get; set; }
        [XmlElement("Square")]
        public List<Square> Square { get; set; }
    }
}
