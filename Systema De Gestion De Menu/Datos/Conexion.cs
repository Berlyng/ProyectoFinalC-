using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systema_De_Gestion_De_Menu.Datos
{
    public class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private static Conexion Con = null;

        private Conexion()
        {
            this.Base = "BD_MENU";
            this.Servidor = "Berlyng";
            this.Usuario = "user_vr";
            this.Clave = "admin";
        }

        public SqlConnection CrearConexion() 
        {
            SqlConnection cadena = new SqlConnection();
            try
            {
                cadena.ConnectionString = "Server=" + this.Servidor +
                                          "Database=" + this.Base +
                                          "User Id=" + this.Usuario+
                                          "Password="+this.Clave;
            }
            catch (Exception ex)
            {
                cadena = null;
                throw ex;
            }

            return cadena;
        }

        public static Conexion GetInstancia() 
        {
            if (Con == null) 
            { 
                Con = new Conexion();
            }

            return Con;
        }

    }
}
