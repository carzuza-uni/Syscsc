using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using webSyscsc.Models;
using Entity;
using Logica;

namespace webSyscsc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController: ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        public IConfiguration Configuration { get; }

        public UsuarioController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _usuarioService = new UsuarioService(connectionString);
        }

        [HttpPost]
        public ActionResult<UsuarioViewModel> post(UsuarioInputModel usuarioInput){
            Usuario usuario = MapearUsuario(usuarioInput);
            var response = _usuarioService.Guardar(usuario);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.usuario);
        }
        private Usuario MapearUsuario(UsuarioInputModel usuarioInput)
        {
            var usuario = new Usuario
            {
                TipoUsuario = usuarioInput.TipoUsuario,
                PrimerNombre = usuarioInput.PrimerNombre,
                SegundoNombre = usuarioInput.SegundoNombre,
                PrimerApellido = usuarioInput.PrimerApellido,
                SegundoApellido = usuarioInput.SegundoApellido,
                NumeroCedula = usuarioInput.NumeroCedula,
                UsuarioI = usuarioInput.UsuarioI,
                Contrasena = usuarioInput.Contrasena,
                Telefono = usuarioInput.Telefono,
                Email = usuarioInput.Email
            };
            return usuario;
        }

        [HttpGet]
        public IEnumerable<UsuarioViewModel> gets(){
            var usuarios = _usuarioService.ConsultarTodos().Select(p=> new UsuarioViewModel(p));
            return usuarios;
        }
    }
}