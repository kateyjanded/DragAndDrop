using DataAcessLibrary.Models;

namespace DataAcessLibrary.DatabaseManager
{
    public class PersistentManager
    {
        private static PersistentManager instance;
        public PersistentManager current
        {
            get
            {
                if (instance == null)
                {
                    instance = current;
                }
                return instance;
            }
        }

       public void Save(ShapeModel model)
        {
            using (var session = FluentHelper.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    session.Save(model);
                    trans.Commit();
                }
                session.Close();
                session.Dispose();
            }
        }
    }
}
