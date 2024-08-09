using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Systema_De_Gestion_De_Menu.Entidad;

namespace Systema_De_Gestion_De_Menu.Datos
{
    internal class D_MenuItems
    {
        public void InsertarMenuItems(Menu_Items menu_Items)
        {
            SqlConnection connection = null;
            try
            {
                connection = Conexion.GetInstancia().CrearConexion();
                connection.Open();

                using (var command = new SqlCommand("InsertMenuItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre_me", menu_Items.Nombre_me);
                    command.Parameters.AddWithValue("@Description", menu_Items.Descripcion_me);
                    command.Parameters.AddWithValue("@Precio_me", menu_Items.Precio_me);
                    command.Parameters.AddWithValue("@Categoria_id", menu_Items.Categoria_id);
                    command.Parameters.AddWithValue("@Activo", menu_Items.Activo);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al insertar MenuItem.", ex);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

         public List<Menu_Items> GetMenuItems()
        {
            {
                List<Menu_Items> menuItems = new List<Menu_Items>();
                SqlConnection connection = null;

                try
                {
                    connection = Conexion.GetInstancia().CrearConexion();
                    connection.Open();

                    using (var command = new SqlCommand("GetAllMenuItems", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var menuItem = new Menu_Items
                                {
                                    Menu_Items_Id = reader.GetInt32(reader.GetOrdinal("Menu_Items_Id")),
                                    Nombre_me = reader.GetString(reader.GetOrdinal("Nombre_me")),
                                    Descripcion_me = reader.GetString(reader.GetOrdinal("Descripcion_me")),
                                    Precio_me = reader.GetDecimal(reader.GetOrdinal("Precio_me")),
                                    Categoria_id = reader.GetInt32(reader.GetOrdinal("Categoria_id")),
                                    Activo = reader.GetBoolean(reader.GetOrdinal("Activo"))
                                };
                                menuItems.Add(menuItem);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    throw new Exception("Error al obtener todos los MenuItems.", ex);
                }
                finally
                {
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }

                return menuItems;
            }
        }

        public void Update_Menu_Items(Menu_Items menuItems)
        {
            SqlConnection connection = null;

            try
            {
                // Obtener la instancia de la conexión
                connection = Conexion.GetInstancia().CrearConexion();
                connection.Open();

                using (var command = new SqlCommand("UpdateMenuItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar los parámetros esperados por el procedimiento almacenado
                    command.Parameters.AddWithValue("@MenuItemId", menuItems.Menu_Items_Id);
                    command.Parameters.AddWithValue("@Name", menuItems.Nombre_me);
                    command.Parameters.AddWithValue("@Description", menuItems.Descripcion_me);
                    command.Parameters.AddWithValue("@Price", menuItems.Precio_me);
                    command.Parameters.AddWithValue("@CategoryId", menuItems.Categoria_id);
                    command.Parameters.AddWithValue("@Activo", menuItems.Activo);

                    // Ejecutar el comando
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Captura y manejo de errores con más detalle
                throw new Exception("Error al actualizar MenuItem. Detalles: " + ex.Message, ex);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }

}
