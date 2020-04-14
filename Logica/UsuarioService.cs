using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class UsuarioService
    {
        private readonly ConnectionManager conexion;
        private readonly UsuarioRepository repository;

        public UsuarioService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repository = new UsuarioRepository(conexion);
        }

        public GuardarUsuarioResponse Guardar(Usuario usuario){
            try{
                conexion.Open();
                repository.Guardar(usuario);
                conexion.Close();
                return new GuardarUsuarioResponse(usuario);
            }catch(Exception e){ 
                return new GuardarUsuarioResponse($"Error de la aplicacion: {e.Message}");
            }finally{
               conexion.Close(); 
            }
        }

        public List<Usuario> ConsultarTodos(){
            try{
                conexion.Open();
                var usuarios = repository.ConsultarTodos();
                conexion.Close();
                return usuarios;
            }catch(Exception e){
                
            }
            return null;
        }
    }

    public class GuardarUsuarioResponse 
    {
        public GuardarUsuarioResponse(Usuario usuario)
        {
            Error = false;
            Usuario usuario1 = usuario;
        }
        public GuardarUsuarioResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Usuario usuario { get; set; }
    }
}
