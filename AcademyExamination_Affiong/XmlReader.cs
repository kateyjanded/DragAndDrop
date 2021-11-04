using AcademyExamination_Affiong.Views;
using DataAcessLibrary.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace AcademyExamination_Affiong
{
    public  class XmlReader
    {
        private string File;
        public ObservableCollection<TreeViewItem> Items;
        public XmlReader()
        {
            Items = new ObservableCollection<TreeViewItem>();
        }
        public XmlReader(string FileName): this()
        {
            File = FileName;
        }
        public SoftwareAcademy ReadFile()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(SoftwareAcademy), new XmlRootAttribute("SoftwareAcademyExamination"));
            TextReader reader = new StreamReader(File);
            var soft = (SoftwareAcademy)deserializer.Deserialize(reader);
            reader.Close();
            return soft;
        }
        public void Writer( List<DragThumb> thumbs)
        {
            SoftwareAcademy sf = new SoftwareAcademy();
            sf.Shapes = new Shapes();
            sf.Shapes.Circle = new List<Circle>();
            sf.Shapes.Triangle = new List<Triangle>();
            sf.Shapes.Square = new List<Square>();
            foreach (DragThumb item in thumbs)
            {
                if (item.Shape.GetType() == typeof(Circles))
                {
                    Circle circle = new Circle();
                    circle.Properties = new DataAcessLibrary.Models.Properties() { Height = item.Shape.Height, Color = item.Shape.Fill.ToString(), Width = item.Shape.Width };
                    sf.Shapes.Circle.Add(circle);
                }
                else if (item.Shape.GetType() == typeof(Triangles))
                {
                    Triangle circle = new Triangle();
                    circle.Properties = new DataAcessLibrary.Models.Properties() { Height = item.Shape.Height, Color = item.Shape.Fill.ToString(), Width = item.Shape.Width };
                    sf.Shapes.Triangle.Add(circle);
                }
                else
                {
                    Square circle = new Square();
                    circle.Properties = new DataAcessLibrary.Models.Properties() { Height = item.Shape.Height, Color = item.Shape.Fill.ToString(), Width = item.Shape.Width };
                    sf.Shapes.Square.Add(circle);
                }
            }
            XmlSerializer x = new XmlSerializer(sf.GetType());
            FileStream f = new FileStream(@"C: \Users\affiong.asuquo\Documents\ASCII_Files\newfile", FileMode.Create);
            x.Serialize(f, sf);
        }
    }
}
