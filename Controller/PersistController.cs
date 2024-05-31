using Services;
namespace Controller
{
    public class PersistController
    {
        private PersistServices _services;
        public PersistController()
        {
            _services = new PersistServices();
        }

        public int InsertInSql(string path, string file)
        {
            return _services.InsertInSql(path, file);
        }
    }
}
