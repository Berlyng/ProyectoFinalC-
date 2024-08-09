using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systema_De_Gestion_De_Menu.Entidad;

namespace Systema_De_Gestion_De_Menu.Datos
{
    public class D_Categoria
    {
        public void InsertCategory(Categoria categoria)
        {
            SqlConnection connection = null;
            try
            {
                connection = Conexion.GetInstancia().CrearConexion();
                connection.Open();

                using (var command = new SqlCommand("InsertCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre_ca", categoria.Nombre_ca);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar Category.", ex);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void UpdateCategory(Categoria category)
        {
            SqlConnection connection = null;
            try
            {
                connection = Conexion.GetInstancia().CrearConexion();
                connection.Open();

                using (var command = new SqlCommand("UpdateCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Categoria_id", category.Categoria_id);
                    command.Parameters.AddWithValue("@Nombre_ca", category.Nombre_ca);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar Category.", ex);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void DeleteCategory(int categoryId)
        {
            SqlConnection connection = null;
            try
            {
                connection = Conexion.GetInstancia().CrearConexion();
                connection.Open();

                using (var command = new SqlCommand("DeleteCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Categoria_id", categoryId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Categoria.", ex);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public List<Categoria> GetAllCategories()
        {
            List<Categoria> categories = new List<Categoria>();
            SqlConnection connection = null;

            try
            {
                connection = Conexion.GetInstancia().CrearConexion();
                connection.Open();

                using (var command = new SqlCommand("GetAllCategories", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var category = new Categoria
                            {
                                Categoria_id = reader.GetInt32(reader.GetOrdinal("Categoria_Id")),
                                Nombre_ca = reader.GetString(reader.GetOrdinal("Nombre_ca"))
                            };
                            categories.Add(category);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todas las categorías.", ex);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return categories;
        }
    }

}
    
