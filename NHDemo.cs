using System.Reflection.Metadata;
using System.Globalization;
using NHibernate;
using EFCoreUTN.Entities;

namespace EFCoreUTN
{

    public static class NHDemo
    {

        private static ISessionFactory sessionFactory = (new NHibernateSessionFactory()).CreateSessionFactory();

        public static IList<Rol> GetAllRoles()
        {

            using (var session = sessionFactory.OpenSession())
            {
                return session.CreateQuery("from Rol as r").List<Rol>();
            }

        }

        public static Rol GetRol(int rolId)
        {
            using (var session = sessionFactory.OpenSession())
            {
                return session.Get<Rol>(rolId);
            }
        }


        public static Usuario CreateUsuario(Usuario user)
        {

            using (var session = sessionFactory.OpenSession())
            {
                user.Rol = session.Get<Rol>(user.Rol.Id);
                session.Save(user);
                session.Flush();

            }
            return user;
        }

        public static Usuario GetUsuario(int id)
        {
            using (var session = sessionFactory.OpenSession())
            {
                var usuario = session.CreateQuery("from Usuario u inner join fetch u.Domicilios inner join fetch u.Rol where u.Id = :id")
                .SetParameter("id", id)
                .List<Usuario>()
                .FirstOrDefault();
                return usuario;
            }

        }

        public static Usuario UpdateUsuario(Usuario user)
        {

            using (var session = sessionFactory.OpenSession())
            {
                var usuarioDB = session.CreateQuery("from Usuario u inner join fetch u.Domicilios inner join fetch u.Rol where u.Id = :id")
                .SetParameter("id", user.Id)
                .List<Usuario>()
                .FirstOrDefault();
                var rolDB = session.Get<Rol>(user.Rol.Id);
                usuarioDB.Nombre = user.Nombre;
                usuarioDB.Rol = rolDB;
                session.Flush();
                session.Save(usuarioDB);

                return usuarioDB;
            }

        }

        public static void DeleteUsuario(int usuarioId)
        {

            using (var session = sessionFactory.OpenSession())
            {
                var user = session.Get<Usuario>(usuarioId);
                session.Delete(user);
                session.Flush();
            }

        }

        public static void ConsultasVariasUsuario()
        {

            using (ISession session = sessionFactory.OpenSession())
            {

                var consulta4 = session.CreateQuery("from Rol as rol where rol.Id > ?")
                .SetInt32(0, 2)
                .List<Rol>();

                consulta4.ToList().ForEach(u => Console.WriteLine(u.ToString()));

                var consulta5 = session.CreateQuery("from Usuario as us inner join fetch us.Domicilios where us.Id = :id")
                .SetInt32("id", 5)
                .List<Usuario>();

                consulta5.ToList().ForEach(u => u.ToString());

            }
        }

    }
}