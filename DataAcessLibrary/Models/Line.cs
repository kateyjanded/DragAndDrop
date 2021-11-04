using System.Windows.Media;
using System.Windows.Shapes;

namespace DataAcessLibrary.Models
{
    public class Lines : Shape
    {
        public Lines()
        {
            Stroke = Brushes.Black;
            StrokeThickness = 1;
            Stretch = Stretch.Fill;
            Height = Y1 - Y1;
            Width = X1 - X2;
        }
        public double X1 { get; set; }
        public double Y1 { get; set; }


        public double X2 { get; set; }
        public double Y2 { get; set; }

        protected override Geometry DefiningGeometry => throw new System.NotImplementedException();
    }
}