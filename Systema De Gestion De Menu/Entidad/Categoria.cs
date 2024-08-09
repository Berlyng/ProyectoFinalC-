using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Systema_De_Gestion_De_Menu.Entidad
{
    public class Categoria
    {
        public int Categoria_id { get; set; }
        public string Nombre_ca { get; set; }

        // Navigation property
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
