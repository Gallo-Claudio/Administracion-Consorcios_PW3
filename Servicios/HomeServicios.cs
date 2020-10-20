using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class HomeServicios
    {
        public static bool VerificaEmail(string Email)
        {
            bool existe;
            existe = Hardcodeo.usuario.Find(m => m.Email == Email) != null ? true : false;
            return existe;
        }

         public static bool VerificaPassword(string Password)
        {
            bool existe;
            existe = Hardcodeo.usuario.Find(m => m.Password == Password) != null ? true : false;
            return existe;
        }

        public static string Encriptar(string cadenaAEncriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(cadenaAEncriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public static void NuevoUsuario(Usuario_VM nuevoUsuario)
        {
            string password = nuevoUsuario.Password;
            string encriptado = Encriptar(password);

            Usuario usuario = new Usuario();
            usuario.Nombre = nuevoUsuario.Nombre;
            usuario.Email = nuevoUsuario.Email;
            usuario.Password = encriptado;
            usuario.FechaRegistracion = DateTime.Now;
            usuario.IdUsuario = UsuarioServicios.UltimoIdRegistro() + 1;
            Hardcodeo.usuario.Add(usuario);
        }
    }
}
