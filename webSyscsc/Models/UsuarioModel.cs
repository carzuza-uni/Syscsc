using Entity;

namespace webSyscsc.Models
{
    
    public class UsuarioInputModel
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
    }

    public class UsuarioViewModel : UsuarioInputModel
    {
        public UsuarioViewModel()
        {

        }
        public UsuarioViewModel(Usuario usuario)
        {
            TipoUsuario = usuario.TipoUsuario;
            PrimerNombre = usuario.PrimerNombre;
            SegundoNombre = usuario.SegundoNombre;
            PrimerApellido = usuario.PrimerApellido;
            SegundoApellido = usuario.SegundoApellido;
            NumeroCedula = usuario.NumeroCedula;
            UsuarioI = usuario.UsuarioI;
            Contrasena = usuario.Contrasena;
            Telefono = usuario.Telefono;
            Email = usuario.Email;
        }
    }
    
}