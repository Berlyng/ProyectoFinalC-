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
    public class D_Oferta_Espcial
    {
        public void InsertSpecialOffer(OfertaEspecial ofertaEspecial)
        {
            SqlConnection connection = null;
            try
            {
                connection = Conexion.GetInstancia().CrearConexion();
                connection.Open();

                using (var command = new SqlCommand("InsertSpecialOffer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Description", ofertaEspecial.Descripcion);
                    command.Parameters.AddWithValue("@DiscountPercentage", ofertaEspecial.Porcentaje_Descuento);
                    command.Parameters.AddWithValue("@StartDate", ofertaEspecial.Fecha_Inicio);
                    command.Parameters.AddWithValue("@EndDate", ofertaEspecial.Fecha_Final);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar SpecialOffer.", ex);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void UpdateSpecialOffer(OfertaEspecial ofertaEspecial)
        {
            SqlConnection connection = null;
            try
            {
                connection = Conexion.GetInstancia().CrearConexion();
                connection.Open();

                using (var command = new SqlCommand("UpdateSpecialOffer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SpecialOfferId", ofertaEspecial.Oferta_Id);
                    command.Parameters.AddWithValue("@Description", ofertaEspecial.Descripcion);
                    command.Parameters.AddWithValue("@DiscountPercentage", ofertaEspecial.Porcentaje_Descuento);
                    command.Parameters.AddWithValue("@StartDate", ofertaEspecial.Fecha_Inicio);
                    command.Parameters.AddWithValue("@EndDate", ofertaEspecial.Fecha_Final);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar SpecialOffer.", ex);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void DeleteSpecialOffer(int specialOfferId)
        {
            SqlConnection connection = null;
            try
            {
                connection = Conexion.GetInstancia().CrearConexion();
                connection.Open();

                using (var command = new SqlCommand("DeleteSpecialOffer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SpecialOfferId", specialOfferId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar SpecialOffer.", ex);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public List<OfertaEspecial> GetAllSpecialOffers()
        {
            List<OfertaEspecial> specialOffers = new List<OfertaEspecial>();
            SqlConnection connection = null;

            try
            {
                connection = Conexion.GetInstancia().CrearConexion();
                connection.Open();

                using (var command = new SqlCommand("GetAllSpecialOffers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var specialOffer = new OfertaEspecial
                            {
                                Oferta_Id = reader.GetInt32(reader.GetOrdinal("SpecialOfferId")),
                                Descripcion = reader.GetString(reader.GetOrdinal("Description")),
                                Porcentaje_Descuento = reader.GetDecimal(reader.GetOrdinal("DiscountPercentage")),
                                Fecha_Inicio = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                Fecha_Final = reader.GetDateTime(reader.GetOrdinal("EndDate"))
                            };
                            specialOffers.Add(specialOffer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todas las ofertas especiales.", ex);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return specialOffers;
        }
    }
}

