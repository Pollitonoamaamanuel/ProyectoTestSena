using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUsers frmUsers = new frmUsers();
            frmUsers.ShowDialog();
            this.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult boton = MessageBox.Show("¿Esta seguro que dese cerrar sesión?", "Test",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (boton == DialogResult.Yes)
            {
                this.Hide();
                Login frmLogin = new Login();
                frmLogin.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            frmEmployees frm = new frmEmployees();
            frm.ShowDialog();
            this.Show();
        }
    }
}
