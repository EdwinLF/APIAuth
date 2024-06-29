using PracticaExamen.DA.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaExamen.BW.Interfaces.DA;
using PracticaExamen.BC.Modelos;
using Microsoft.EntityFrameworkCore;
using PracticaExamen.DA.Entidades;


namespace PracticaExamen.DA.Acciones
{
   public class GestionarUsuarioDA : IGestionarUsuarioDA
    {
        private readonly AdmUsuarioContext admUsuarioContext;
        public GestionarUsuarioDA(AdmUsuarioContext admUsuarioContext)
        {
            this.admUsuarioContext = admUsuarioContext;
        }

        public async Task<bool> actualiceUsuario(Usuario usuario)
        {
            var usuarioDA = admUsuarioContext.Usuarios.FirstOrDefault(u => u.CardUser == usuario.CardUser);
            if (usuarioDA != null)
            {
                usuarioDA.Name = usuario.Name;
                usuarioDA.LastName = usuario.LastName; 
                usuarioDA.CardUser = usuario.CardUser;
                usuarioDA.Email = usuario.Email;
                usuarioDA.UserBirthdate = usuario.UserBirthdate; 
                usuarioDA.PhoneNumber = usuario.PhoneNumber;
                usuarioDA.Password = usuario.Password;

                var resultado = admUsuarioContext.SaveChanges();
                return resultado >0 ? true : false;
            }
            return false; 
        }

        public async Task<bool> elimineUsuario(Usuario usuario)
        {
            var usuarioDA = admUsuarioContext.Usuarios.FirstOrDefault(u => u.CardUser == usuario.CardUser);

            if (usuarioDA != null) { 
                admUsuarioContext.Usuarios.Remove(usuarioDA);
                var resultado = admUsuarioContext.SaveChanges();
                if(resultado > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<Usuario> obtengaDatosUsuario(string cardUsuario, string password)
        {
            var usuarioDA = admUsuarioContext.Usuarios.FirstOrDefault(u => u.CardUser == cardUsuario && u.Password == password);
            if (usuarioDA is null)
                return null;

            Usuario usuario = new() { 
                CardUser = usuarioDA.CardUser,
                Password = password,
                LastName = usuarioDA.LastName,
                Name = usuarioDA.Name,
                Email = usuarioDA.Email,
                UserBirthdate = usuarioDA.UserBirthdate,
                PhoneNumber = usuarioDA.PhoneNumber,
            
            };
            return usuario;

        }

        public async Task<bool> registreUsuario(Usuario usuario)
        {
            Entidades.UsuarioDA usuarioBD = new() { 
                Name = usuario.Name,
                Email = usuario.Email,
                LastName= usuario.LastName,
                PhoneNumber= usuario.PhoneNumber,
                Password = usuario.Password,
                UserBirthdate= usuario.UserBirthdate,
                CardUser = usuario.CardUser,
            };
            admUsuarioContext.Usuarios.Add(usuarioBD);
            var resultado = admUsuarioContext.SaveChangesAsync();
            if (resultado.Result<0) {
                return false; 
            }
            return true;
           
        }
    }
}
