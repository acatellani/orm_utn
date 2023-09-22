// See https://aka.ms/new-console-template for more information
using EfCoreUTN;
using EFCoreUTN;
using EFCoreUTN.Entities;
using Microsoft.EntityFrameworkCore;
using NHibernate;

var context = new EFUserContext();


var resultados = DataGenerator.GenerateFakeData(50);
resultados.Item1.ToList().ForEach(u=> context.Roles.Add(u));
context.Roles.Add(new Rol() { Nombre = "DBAdmin"});
resultados.Item2.ToList().ForEach(u=> context.Usuarios.Add(u));
context.SaveChanges();


//EFCore
/*
var roles = EFDemo.GetAllRoles();
var usuario = DataGenerator.GenerateFakeUsuario(1,roles).FirstOrDefault();
Console.WriteLine(usuario);
EFDemo.CreateUsuario(usuario);
var userDB = EFDemo.GetUsuario(usuario.Id);
Console.WriteLine(userDB);
usuario.Nombre = "Agustin Catellani";
usuario.Rol =  EFDemo.GetRol(1);
var updatedUser = NHDemo.UpdateUsuario(usuario);
Console.WriteLine(updatedUser);
EFDemo.DeleteUsuario(userDB.Id);
*/
//EFDemo.ConsultasVariasUsuario();


//NHibernate 
/*
var roles = NHDemo.GetAllRoles();
var usuario = DataGenerator.GenerateFakeUsuario(1,roles).FirstOrDefault();
Console.WriteLine(usuario);
NHDemo.CreateUsuario(usuario);
var userDB = NHDemo.GetUsuario(usuario.Id);
Console.WriteLine(userDB);
usuario.Nombre = "Agustin Catellani";
usuario.Rol =  NHDemo.GetRol(1);
var updatedUser = NHDemo.UpdateUsuario(usuario);
Console.WriteLine(updatedUser);
NHDemo.DeleteUsuario(userDB.Id);
*/
//var usuario = NHDemo.GetUsuario(7);
//NHDemo.ConsultasVariasUsuarioHQL();
