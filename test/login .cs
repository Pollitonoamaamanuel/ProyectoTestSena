using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lógica; // agregamos la caja lógicas para poder usar las clases de la capa lógica
using Datos;// agregamos la capa datos para poder usar las clases de la cpa de datos 


namespace test
{
    public partial class From1 : Form
    {
        public From1()
        {
            InitializeComponent();
        }

        public void validar()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) | string.IsNullOrEmpty(txtPassword.Text))
            {
                //si algun campo esta vacio, maestrac muestra mensaje de error
                
              MessageBox.Show("Ingresa ambos datos"," Error");
            }
            else
            {
                try
                {

                    //De lo contrario iniciamos sesión mediante la capa lógica 
                    Lógica.Users objetoUsuario = new Lógica.Users();
                    DataSet Result = objetoUsuario.IniciarSesión(txtUsuario.Text, txtPassword.Text);
                    DataTable DatosResultantes = Result.Tables["DatosConsultados"];

                    int numeroRegistro = DatosResultantes.Rows.Count;

                    if (numeroRegistro == 0)
                    {
                        MessageBox.Show("Aceso Denegado.");
                    }
                    else
                    {
                        MessageBox.Show("Bienvenido, " + DatosResultantes.Rows[0]["nick"].ToString());
                        this.Hide();
                        Menu ventana = new Menu();
                        ventana.ShowDialog();
                        this.Show();
                          
                    }
                }
                catch (Exception Error)
                {
                    MessageBox.Show("Error!" + Error.Message);
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            validar();
        }
    }
}
