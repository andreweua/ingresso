namespace Ingresso.Data.Classes
{
    public abstract class RepositoryBase
    {
        protected readonly ApplicationDbContext Db;

        public RepositoryBase()
        {
            this.Db = new ApplicationDbContext();
        }
    }
}
