using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica; //agregamos la capa lógica para poder usar las clases de esta capa
using Datos; //agregamos la capa de datos para poder usar las clases de la capa datos

namespace Test
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public void validar()
        {
            if ( string.IsNullOrEmpty(txtUser.Text) | string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Ingresa ambos datos");
            }
            else
            {
                try
                {
                    Logica.Users objetoUsuario = new Logica.Users();
                    DataSet Resul = objetoUsuario.IniciarSesion(txtUser.Text, txtPassword.Text);
                    DataTable DatosResultantes = Resul.Tables["DatosConsultados"];

                    int numeroRegistros = DatosResultantes.Rows.Count;

                    if (numeroRegistros == 0)
                    {
                        MessageBox.Show("Acceso Denegado.");
                    }
                    else
                    {
                        MessageBox.Show("Bienvenido, " + DatosResultantes.Rows[0]["nick"].ToString());
                        this.Hide();
                        Menu ventana = new Test.Menu();
                        ventana.ShowDialog();
                        this.Show();
                    }
                }
                catch(Exception Error)
                {
                    MessageBox.Show("Error! " + Error.Message);
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            validar();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                validar();
            }
        }
    }
}
