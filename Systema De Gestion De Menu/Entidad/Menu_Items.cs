using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systema_De_Gestion_De_Menu.Entidad
{
    public class Menu_Items
    {
        public int Menu_Items_Id { get; set; }
        public string Nombre_me { get; set; }
        public string Descripcion_me { get; set; }
        public decimal Precio_me { get; set; }
        public int Categoria_id { get; set; }
        public bool Activo { get; set; }

        // Navigation properties
        public Categoria Categoria { get; set; }
        public ICollection<OfertaEspecial> ofertaEspecial { get; set; }
        public ICollection<Orden> Ordenes { get; set; }
    }
}
