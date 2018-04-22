namespace DataAccess.orm
{
    public class OrmDatabase
    {
        private static OrmContext _instance;

        public static OrmContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OrmContext();
                }
                return _instance;
            }
        }
    }
}
