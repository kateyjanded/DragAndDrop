using System;
namespace DataAcessLibrary.Models
{
    public class ShapeModel
    {
        public virtual Guid ID { get; set; }
        public virtual string Name { get; set; }
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
        public virtual string Color { get; set; }
    }
}
