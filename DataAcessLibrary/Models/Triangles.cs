using System.Windows.Media;
using System.Windows.Shapes;

namespace DataAcessLibrary.Models
{
    public class Triangles: Shape
    {
        protected override Geometry DefiningGeometry
        {
            get
            {
                return Geometry.Parse("M15,0 L0,15 H30z");
            }
        }
    }
}
