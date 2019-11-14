using ConsultoraAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultoraAPI.Data
{
    public class UsuariosDAO
    {
        private readonly string connectionString;

        public UsuariosDAO()
        {
            connectionString = "Data Source=DESKTOP-6QS5BVE\\SQLEXPRESS01;Initial Catalog=DB_Consultora;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        }

        public IEnumerable<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllUsuarios", sql);
                cmd.CommandType = CommandType.StoredProcedure;
                sql.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usuarios.Add(MapToValue(reader));
                }
                sql.Close();
                return usuarios;
            }
        }

        public void AddUsuario(Usuario usuario)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertUsuario", sql);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@password", usuario.Password);

                sql.Open();
                cmd.ExecuteNonQuery();
                sql.Close();
            }
        }
        public void Update(Usuario usuario)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateUsuario", sql);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", usuario.Id);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@password", usuario.Password);

                sql.Open();
                cmd.ExecuteNonQuery();
                sql.Close();
            }
        }

        public void DeleteUsuario(int? id)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteUsuario", sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                sql.Open();
                cmd.ExecuteNonQuery();
                sql.Close();
            }
        }



        public Usuario GetById(int? id)
        {
            var usuario = new Usuario();

            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetUsuarioById", sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                sql.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usuario = MapToValue(reader);
                }
                sql.Close();
                return usuario;
            }
        }



        private Usuario MapToValue(SqlDataReader reader)
        {
            return new Usuario()
            {
                Id = (int)reader["Id"],
                Email = reader["Email"].ToString(),
                Password = reader["Password"].ToString()
            };
        }


    }
}

