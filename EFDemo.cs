using System;
using EfCoreUTN;
using EFCoreUTN.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreUTN
{

    public static class EFDemo
    {

        //DataGenerator.GenerateFakeDataEFCore(50, context);

        public static IList<Rol> GetAllRoles()
        {

            var context = new EFUserContext();
            return (from r in context.Roles
                    select r).ToList();

        }

        public static Rol GetRol(int rolId)
        {
            var context = new EFUserContext();
            return (from r in context.Roles
                    where r.Id == rolId
                    select r).FirstOrDefault();
        }

        public static Usuario CreateUsuario(Usuario user)
        {

            var context = new EFUserContext();
            user.Rol = context.Roles.FirstOrDefault(r=> r.Id== user.Rol.Id);
            context.Usuarios.Add(user);
            context.SaveChanges();
            return user;

        }

        public static Usuario GetUsuario(int id)
        {
            var context = new EFUserContext();

            return (from u in context.Usuarios.Include(u=> u.Domicilios).Include(u=>u.Rol)
                    where u.Id == id
                    select u).FirstOrDefault();

        }

        public static Usuario UpdateUsuario(Usuario user)
        {

            var context = new EFUserContext();
            var usuarioDB = (from u in context.Usuarios
                             where u.Id == user.Id
                             select u).FirstOrDefault();

            var newRole = (from r in context.Roles
                           where r.Id == user.Rol.Id
                           select r).FirstOrDefault();

            usuarioDB.Nombre = user.Nombre;
            usuarioDB.Rol = newRole;

            context.SaveChanges();

            return usuarioDB;

        }

        public static void DeleteUsuario(int usuarioId)
        {

            var context = new EFUserContext();
            var usuario = context.Usuarios.Include(u=>u.Domicilios).FirstOrDefault(u => u.Id == usuarioId);
            
            context.Usuarios.Remove(usuario);
            context.SaveChanges();

        }

        public static void ConsultasVariasUsuario()
        {

            var context = new EFUserContext();

            var consulta1 = from u in context.Usuarios.Include(us => us.Domicilios).Include(us => us.Rol)
                            where u.Domicilios.Count > 2
                            select u;

            consulta1.ToList().ForEach(u => Console.WriteLine(u.ToString()));

            var consulta2 = (from u in context.Usuarios.Include(us => us.Domicilios).Include(us => us.Rol)
                             from d in u.Domicilios
                             where d.Numero > 5000
                             select u);

            consulta2.ToList().ForEach(u => Console.WriteLine(u.ToString()));

            var consulta3 = (from u in context.Usuarios
                             where u.Id == 15
                             select u).FirstOrDefault();


        }
        /*var newUser = new Usuario()
        {
            Rol = rol.FirstOrDefault(),
            Nombre = "UTN NEW USER",
            Domicilios = new List<Domicilio>() {
                new Domicilio() {
                    Calle = "Lavaisse",
                    Numero = 3584
                }
            }
        };

        context.Usuarios.Add(newUser);
        context.SaveChanges();



*/
    }

}