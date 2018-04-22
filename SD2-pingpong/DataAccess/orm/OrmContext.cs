using System.Data.Entity;
using Model;
using SQLite.CodeFirst;

namespace DataAccess.orm
{
    public class OrmContext : DbContext
    {
        public OrmContext()
            : base("DatabaseConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<OrmContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }

        public IDbSet<Game> Games { get; set; }
        public IDbSet<MatchPP> Matches { get; set; }
        public IDbSet<Tournament> Tournaments { get; set; }
        public IDbSet<User> Users { get; set; }

    }
}
