using System.Windows.Media;
using System.Windows.Shapes;

namespace DataAcessLibrary.Models
{
    public class Circles: Shape
    {
        protected override Geometry DefiningGeometry
        {
            get
            {
                return Geometry.Parse("M99.5,50 C99.5,77.338095 77.338095,99.5 50,99.5 C22.661905,99.5 0.5,77.338095 0.5,50 C0.5,22.661905 22.661905,0.5 50,0.5 C77.338095,0.5 99.5,22.661905 99.5,50 z");
            }
        }
    }
}
