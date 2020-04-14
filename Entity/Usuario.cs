using System;

namespace Entity
{
    public class Usuario
    {
        public int TipoUsuario { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string NumeroCedula { get; set; }
        public string UsuarioI { get; set; }
        public string Contrasena { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public string TipoUsuarioNombre(){
            string[] tipo = {};
            tipo[1] = "Administrador";
            tipo[2] = "Técnico";
            return tipo[this.TipoUsuario];
        }
    }
}
