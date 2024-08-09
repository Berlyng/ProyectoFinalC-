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
    public class D_Orden
    {
        public void InsertOrder(Orden order)
        {
            SqlConnection connection = null;
            try
            {
                connection = Conexion.GetInstancia().CrearConexion();
                connection.Open();

                using (var command = new SqlCommand("InsertOrder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderDate", order.Fecha_Orden);
                    command.Parameters.AddWithValue("@TotalAmount", order.Monto_Total);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar Order.", ex);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void UpdateOrder(Orden order)
        {
            SqlConnection connection = null;
            try
            {
                connection = Conexion.GetInstancia().CrearConexion();
                connection.Open();

                using (var command = new SqlCommand("UpdateOrder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderId", order.Orden_Id);
                    command.Parameters.AddWithValue("@OrderDate", order.Fecha_Orden);
                    command.Parameters.AddWithValue("@TotalAmount", order.Monto_Total);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar Order.", ex);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void DeleteOrder(int orderId)
        {
            SqlConnection connection = null;
            try
            {
                connection = Conexion.GetInstancia().CrearConexion();
                connection.Open();

                using (var command = new SqlCommand("DeleteOrder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Order.", ex);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public List<Orden> GetAllOrders()
        {
            List<Orden> orders = new List<Orden>();
            SqlConnection connection = null;

            try
            {
                connection = Conexion.GetInstancia().CrearConexion();
                connection.Open();

                using (var command = new SqlCommand("GetAllOrders", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var order = new Orden
                            {
                                Orden_Id = reader.GetInt32(reader.GetOrdinal("OrderId")),
                                Fecha_Orden = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                                Monto_Total = reader.GetDecimal(reader.GetOrdinal("TotalAmount")),
                             
                            };
                            orders.Add(order);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todas las órdenes.", ex);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return orders;
        }
    }
}

