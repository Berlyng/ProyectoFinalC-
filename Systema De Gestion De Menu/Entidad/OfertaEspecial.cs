using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Systema_De_Gestion_De_Menu.Entidad
{
    public class OfertaEspecial
    {
        public int Oferta_Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Porcentaje_Descuento { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Final { get; set; }

        // Navigation property
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
