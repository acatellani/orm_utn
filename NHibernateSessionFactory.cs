using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace EFCoreUTN
{
    public class NHibernateSessionFactory
    {

        public ISessionFactory CreateSessionFactory()
        {

            return Fluently.Configure()
                .Database(
                  SQLiteConfiguration.Standard
                    .UsingFile("UsersDB.sqlite")
                )
                .Mappings(m =>
                  m.FluentMappings.AddFromAssemblyOf<Program>())
                .BuildSessionFactory();

        }
    }
}