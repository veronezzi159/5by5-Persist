using Repository;
namespace Services
{
    public class PersistServices
    {
        private PersistRepository _repository;
        public PersistServices()
        {
            _repository = new PersistRepository();
        }

        public int InsertInSql(string path, string file)
        {
            return _repository.InsertInSql(path, file);
        }
    }
}
