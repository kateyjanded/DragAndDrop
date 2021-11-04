using DataAcessLibrary.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.IO;

namespace DataAcessLibrary.DatabaseManager
{
    public class FluentHelper
    {
        private static string connectionstring = "..//test.db";
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure().
               Database(SQLiteConfiguration.Standard.UsingFile(connectionstring)).
               Mappings(m => m.FluentMappings.AddFromAssemblyOf<ShapMap>()).
               ExposeConfiguration(BuildSchema).BuildSessionFactory();
            return sessionFactory.OpenSession();
        }

        private static void BuildSchema(Configuration obj)
        {
            if (File.Exists(connectionstring))
            {
                var se = new SchemaExport(obj);
                se.Create(true, false);
            }
        }
        
    }
}
