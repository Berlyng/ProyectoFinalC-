using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Systema_De_Gestion_De_Menu.Entidad
{
    public class Orden
    {
        public int Orden_Id { get; set; }
        public DateTime Fecha_Orden { get; set; }
        public decimal Monto_Total { get; set; }

        // Navigation properties
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
