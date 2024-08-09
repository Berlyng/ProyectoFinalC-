using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Systema_De_Gestion_De_Menu.Datos;

namespace Systema_De_Gestion_De_Menu.Presentacion
{
    public partial class Menu_Items : Form
    {
        private D_MenuItems menuItems;

        public Menu_Items()
        {
            InitializeComponent();

            menuItems = new D_MenuItems();
        }

        private void Menu_Items_Load(object sender, EventArgs e)
        {
            var menus = menuItems.GetMenuItems();
            dataGridMenuItems.DataSource = menuItems;

        }

        private void lblMenu_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
