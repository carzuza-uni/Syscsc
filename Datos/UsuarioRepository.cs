using System.Collections.Generic;
using System;
using Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Datos
{
    public class UsuarioRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Usuario> _usuarios = new List<Usuario>();

        public UsuarioRepository(ConnectionManager connection){
            _connection = connection._conexion;
        }

        public void Guardar(Usuario usuario)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into usuarios (TipoUsuario, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, NumeroCedula, Usuario, Contrasena, Telefono, Email) 
                                        values (@TipoUsuario, @PrimerNombre, @SegundoNombre, @PrimerApellido, @SegundoApellido, @NumeroCedula, @Usuario, @Contrasena, @Telefono, @Email)";
                command.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);
                command.Parameters.AddWithValue("@PrimerNombre", usuario.PrimerNombre);
                command.Parameters.AddWithValue("@SegundoNombre", usuario.SegundoNombre);
                command.Parameters.AddWithValue("@PrimerApellido", usuario.PrimerApellido);
                command.Parameters.AddWithValue("@SegundoApellido", usuario.SegundoApellido);
                command.Parameters.AddWithValue("@NumeroCedula", usuario.NumeroCedula);
                command.Parameters.AddWithValue("@Usuario", usuario.UsuarioI);
                command.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
                command.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                var filas = command.ExecuteNonQuery();
            }
        }

        public void Bloquear(Usuario usuario)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from usuarios where NumeroCedula=@NumeroCedula";
                command.Parameters.AddWithValue("@NumeroCedula", usuario.NumeroCedula);
                command.ExecuteNonQuery();
            }
        }

        public List<Usuario> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Usuario> usuarios = new List<Usuario>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from usuarios";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Usuario usuario = DataReaderMap(dataReader);
                        usuarios.Add(usuario);
                    }
                }
            }
            return usuarios;
        }

        public Usuario BuscarPorIdentificacion(string numeroCedula)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from usuarios where NumeroCedula=@NumeroCedula";
                command.Parameters.AddWithValue("@NumeroCedula", numeroCedula);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMap(dataReader);
            }
        }

        private Usuario DataReaderMap(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Usuario usuario = new Usuario();
            usuario.TipoUsuario = (int)dataReader["TipoUsuario"];
            usuario.PrimerNombre = (string)dataReader["PrimerNombre"];
            usuario.SegundoNombre = (string)dataReader["SegundoNombre"];
            usuario.PrimerApellido = (string)dataReader["PrimerApellido"];
            usuario.SegundoApellido = (string)dataReader["SegundoApellido"];
            usuario.NumeroCedula = (string)dataReader["NumeroCedula"];
            usuario.UsuarioI = (string)dataReader["Usuario"];
            usuario.Contrasena = (string)dataReader["Contrasena"];
            usuario.Telefono = (string)dataReader["Telefono"];
            usuario.Email = (string)dataReader["Email"];
            return usuario;
        }
    }
}
