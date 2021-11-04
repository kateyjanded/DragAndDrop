using System.Windows.Media;
using System.Windows.Shapes;

namespace DataAcessLibrary.Models
{
    public class Squares: Shape
    {
        protected override Geometry DefiningGeometry
        {
            get
            {
                return Geometry.Parse("M0, 0 V15 H20 V0z");
            }
        }
    }
}
