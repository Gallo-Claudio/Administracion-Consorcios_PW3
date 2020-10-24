using DataAccessLayer.Modelos;
using DataAccessLayer.Repositorio;
using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class UsuarioServicios
    {
        UsuarioRepositorio repoUsuario;

        public UsuarioServicios(ContextoEntities contexto)
        {
            ContextoEntities ctx = contexto;
            repoUsuario = new UsuarioRepositorio(ctx);
        }


        public bool VerificaEmail(string Email)
        {
            bool existe = repoUsuario.BuscaPorMail(Email) != null ? true : false;
            return existe;
        }

        public string Encriptar(string cadenaAEncriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(cadenaAEncriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public bool VerificaPassword(string Password, string Email)
        {
            Usuario usuarioParaBuscar = repoUsuario.BuscaPorMail(Email);
            string passwordUsuario = usuarioParaBuscar.Password;

            bool existe = passwordUsuario == Password ? true : false;
            return existe;
        }

        public string BuscarNombre(string Email)
        {
            Usuario usuarioParaBuscar = repoUsuario.BuscaPorMail(Email);
            string nombreUsuario = usuarioParaBuscar.Nombre;
            return nombreUsuario;
        }

        public int BuscarIdUsuario(string Email)
        {
            Usuario usuarioParaBuscar = repoUsuario.BuscaPorMail(Email);
            int IdUsuario = usuarioParaBuscar.IdUsuario;
            return IdUsuario;
        }

        public void NuevoUsuario(Usuario_VM nuevoUsuario)
        {
            string password = nuevoUsuario.Password;
            string encriptado = Encriptar(password);

            Usuario usuario = new Usuario();
            usuario.Nombre = nuevoUsuario.Nombre;
            usuario.Email = nuevoUsuario.Email;
            usuario.Password = encriptado;
            usuario.FechaRegistracion = DateTime.Now;
            repoUsuario.Alta(usuario);
        }
    }
}
