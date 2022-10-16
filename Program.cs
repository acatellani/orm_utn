// See https://aka.ms/new-console-template for more information
using Bogus;
using EfCoreUTN;
using EFCoreUTN;
using EFCoreUTN.Entities;
using Microsoft.EntityFrameworkCore;
using NHibernate;

var context = new EFUserContext();

//EFCore
var resultados = DataGenerator.GenerateFakeData(50);
//resultados.Item1.ToList().ForEach(u=> context.Roles.Add(u));
context.Roles.Add(new Rol() { Nombre = "DBAdmin"});
context.SaveChanges();


var roles = EFDemo.GetAllRoles();
//var usuario = NHDemo.GetUsuario(7);
var usuario = DataGenerator.GenerateFakeUsuario(1,roles).FirstOrDefault();
Console.WriteLine(usuario);
EFDemo.CreateUsuario(usuario);
var userDB = EFDemo.GetUsuario(usuario.Id);
Console.WriteLine(userDB);
//usuario.Nombre = "Agustin Catellani";
//usuario.Rol =  EFDemo.GetRol(1);
//var updatedUser = NHDemo.UpdateUsuario(usuario);

EFDemo.DeleteUsuario(userDB.Id);


//NHibernate 
/*
var roles = NHDemo.GetAllRoles();
//var usuario = NHDemo.GetUsuario(7);
var usuario = DataGenerator.GenerateFakeUsuario(1,roles).FirstOrDefault();
Console.WriteLine(usuario);
NHDemo.CreateUsuario(usuario);
var userDB = NHDemo.GetUsuario(usuario.Id);
Console.WriteLine(userDB);
//usuario.Nombre = "Agustin Catellani";
//usuario.Rol =  EFDemo.GetRol(1);
//var updatedUser = NHDemo.UpdateUsuario(usuario);

NHDemo.DeleteUsuario(userDB.Id);

*/
