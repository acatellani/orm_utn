using System.Reflection.Metadata;
using System.Globalization;
using NHibernate;
using EFCoreUTN.Entities;
using NHibernate.Linq;

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

        public static void ConsultasVariasUsuarioHQL()
        {

            using (ISession session = sessionFactory.OpenSession())
            {

                var consulta1 = session.CreateQuery("from Usuario as us where us.Id = ?")
                .SetInt32(0, 15)
                .List<Usuario>();
                Console.WriteLine(consulta1.FirstOrDefault());

                //var consulta2 = session.CreateQuery("from Usuario as us where (SELECT count(dom) from Domicilio as dom WHERE dom.UsuarioId = us.Id) > :cantidad")

                var consulta2 = session.CreateQuery("from Usuario as us where size(us.Domicilios) > :cantidad")
                .SetInt32("cantidad", 2)
                .List<Usuario>();
                consulta2.ToList().ForEach(u => Console.WriteLine(u));

                var consulta3 = session.CreateQuery("select distinct us from Usuario as us inner join us.Domicilios as dom where dom.Numero > 5000 order by us.Id")
                .List<Usuario>();

                consulta3.ToList().ForEach(u => Console.WriteLine(u));

            }
        }

        public static void ConsultasVariasUsuario()
        {

            using (ISession session = sessionFactory.OpenSession())
            {

                var consulta1 = session.Query<Usuario>()
                                .Where(u => u.Id == 15)
                                .FirstOrDefault();
                Console.WriteLine(consulta1);

                var consulta2 = session.Query<Usuario>()
                                .Where(u => u.Domicilios.Count > 2);

                consulta2.ToList().ForEach(u => Console.WriteLine(u.ToString()));

                var consulta3 = session.Query<Usuario>()
                                 .Where(u => u.Domicilios.Any(d => d.Numero > 5000))
                                 .OrderBy(u => u.Id)
                                 .Distinct();

                consulta3.ToList().ForEach(u => Console.WriteLine(u.ToString()));

            }
        }

    }
}