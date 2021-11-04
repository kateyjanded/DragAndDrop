using DataAcessLibrary.Models;
using FluentNHibernate.Mapping;

namespace DataAcessLibrary.Mappings
{
    public class ShapMap: ClassMap<ShapeModel>
    {
        public ShapMap()
        {
            Table("Shapes");
            Id(x => x.ID).GeneratedBy.GuidComb();
            Map(x => x.Name);
            Map(x => x.Height);
            Map(x => x.Width);
            Map(x => x.Color);
        }
    }
}
