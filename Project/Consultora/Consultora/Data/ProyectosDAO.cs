using ConsultoraAPI.Models.Entities;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

//https://www.c-sharpcorner.com/article/crud-operations-using-asp-net-core-and-ado-net/

namespace ConsultoraAPI.Data
{
    public class ProyectosDAO
    {
        private readonly string connectionString;

        public ProyectosDAO()
        {
            connectionString = "Data Source=.;Initial Catalog=DB_Consultora;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        }

        public IEnumerable<Proyecto> GetAll()
        {
            List<Proyecto> proyectos = new List<Proyecto>();

            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllProyects", sql);
                cmd.CommandType = CommandType.StoredProcedure;
                sql.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    proyectos.Add(MapToValue(reader));
                }
                sql.Close();
                return proyectos;
            }
        }

        public void AddProyect(Proyecto proyecto)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertProyecto", sql);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@titulo", proyecto.Titulo);
                cmd.Parameters.AddWithValue("@descripcion", proyecto.Descripcion);

                sql.Open();
                cmd.ExecuteNonQuery();
                sql.Close();
            }
        }

        public void Update(Proyecto proyecto)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateProyecto", sql);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", proyecto.Id);
                cmd.Parameters.AddWithValue("@titulo", proyecto.Titulo);
                cmd.Parameters.AddWithValue("@descripcion", proyecto.Descripcion);

                sql.Open();
                cmd.ExecuteNonQuery();
                sql.Close();
            }
        }

        public void DeleteProyecto(int? id)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteProyecto", sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id",id);
                sql.Open(); 
                cmd.ExecuteNonQuery();
                sql.Close();
            }
        }

        public Proyecto GetById(int? id)
        {
            var proyecto = new Proyecto();

            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetProyectById", sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                sql.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   proyecto=MapToValue(reader);
                }
                sql.Close();
                return proyecto;
            }
        }



        private Proyecto MapToValue(SqlDataReader reader)
        {
            return new Proyecto()
            {
                Id = (int)reader["Id"],
                Titulo = reader["Titulo"].ToString(),
                Descripcion = reader["Descripcion"].ToString()
            };
        }


    }
}
