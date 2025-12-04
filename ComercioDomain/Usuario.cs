using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioDomain
{
    public enum RolUsuario
    {
        VENDEDOR = 1,
        ADMIN = 2
    }
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Rol Rol { get; set; }
        public RolUsuario RolUsuario { get; set; }

        public Usuario(string email, string pass, bool admin)
        {
            Email = email;
            Password = pass;
            RolUsuario = admin ? RolUsuario.ADMIN : RolUsuario.VENDEDOR;
        }

        public Usuario()
        {
        }
    }
}
