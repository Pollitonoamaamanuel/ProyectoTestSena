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
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu frmMenu = new Menu();
            frmMenu.ShowDialog();
        }

        public void cargarDataGrid() {
            Logica.Users consulta = new Logica.Users();
            DataSet resultado = consulta.ListadoUsuarios();

            DataTable DatosTabla = new DataTable();
            DatosTabla = resultado.Tables[0];

            dtgListado.DataSource = DatosTabla;
        }

        public void filtrarDataGrid()
        {
            Logica.Users consulta = new Logica.Users();
            DataSet resultado = consulta.FiltrarUsuarios(textBox1.Text);

            DataTable DatosTabla = new DataTable();
            DatosTabla = resultado.Tables[0];

            dtgListado.DataSource = DatosTabla;
        }

        public void Limpiar() {
            txtId.Text = "";
            txtNick.Text = "";
            txtPassword.Text = "";
            txtCPassword.Text = "";
            textBox1.Text = "";
            cargarDataGrid();
        }


        public bool validarEliminar()
        {

            //si el nick y password es distinto de vacio y el password y la confirmacion son iguales. 
            if (txtId.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public bool validarActualizar()
        {

            //si el nick y password es distinto de vacio y el password y la confirmacion son iguales. 
            if (txtId.Text != ""  && txtNick.Text != "" && txtPassword.Text != "" && txtPassword.Text == txtCPassword.Text)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool validarRegistro() {

            txtId.Text = "";
            //si el nick y password es distinto de vacio y el password y la confirmacion son iguales. 
            if ( txtNick.Text != "" && txtPassword.Text !="" && txtPassword.Text == txtCPassword.Text) {
                return true;
            } else {
                return false;
            }

        }

        // bool > devuelve verdadero o falso;
        public bool validarConsulta() {

            txtNick.Text = "";
            txtPassword.Text = "";
            txtCPassword.Text = "";

            if (txtId.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            cargarDataGrid();


            btnActualizar.Enabled = false;
            btnConsultar.Enabled = false;
            btnEliminar.Enabled = false;

        }


        private void dtgListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dtgListado.CurrentRow.Cells[0].Value.ToString();
            txtNick.Text = dtgListado.CurrentRow.Cells[1].Value.ToString();
            txtPassword.Text = dtgListado.CurrentRow.Cells[2].Value.ToString();
            txtCPassword.Text = dtgListado.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (validarConsulta())
            {
                Logica.Users obj = new Logica.Users(); // creo un objeto de la clase users
                DataSet resultado = obj.consultar( txtId.Text ); // utilizo el metodo consultar y guardo el resultado
                DataTable miTabla = new DataTable(); // defino mi datatable para leer datos
                miTabla = resultado.Tables[0]; //lleno mi datatable con el resultado de la consulta

                txtNick.Text = miTabla.Rows[0]["nick"].ToString(); //busco la fila cero y la columna nick
                txtPassword.Text = miTabla.Rows[0]["password"].ToString();
                txtCPassword.Text = miTabla.Rows[0]["password"].ToString();
            }
            else {
                MessageBox.Show("Ingresa el id para consultar");
            }

        } // cierre metodo consultar click

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (validarRegistro())
            {// true
                //registramos
                Logica.Users obj = new Logica.Users();
                bool respuesta = obj.CrearUsuario(txtNick.Text, txtPassword.Text);
                if (respuesta == true) {
                    MessageBox.Show("Se han registrado los Datos");
                    Limpiar();
                    cargarDataGrid();
                } else {
                    MessageBox.Show("Ha ocurrido un error");
                }


            }
            else {
                MessageBox.Show("Verifica los datos a registrar");
            }

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if(txtId.Text != "")
            {
                btnActualizar.Enabled = true;
                btnConsultar.Enabled = true;
                btnEliminar.Enabled = true;
                
            }
            else {
                btnActualizar.Enabled = false;
                btnConsultar.Enabled = false;
                btnEliminar.Enabled = false;

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (validarActualizar())
            {// true
                //registramos
                Logica.Users obj = new Logica.Users();
                bool respuesta = obj.ActualizarUsuario(txtId.Text, txtNick.Text, txtPassword.Text);
                if (respuesta == true)
                {
                    MessageBox.Show("Se ha actualizado con éxito");
                    Limpiar();
                    cargarDataGrid();
                }
                else
                {
                    MessageBox.Show("No se ha encontrado el usuario con ID "+txtId.Text);
                }


            }
            else
            {
                MessageBox.Show("Verifica los datos a registrar");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (validarEliminar())
            {// true
                //registramos
                Logica.Users obj = new Logica.Users();
                bool respuesta = obj.EliminarUsuario(txtId.Text);
                if (respuesta == true)
                {
                    MessageBox.Show("Se ha eliminado con éxito");
                    Limpiar();
                    cargarDataGrid();
                }
                else
                {
                    MessageBox.Show("No se ha encontrado el usuario con ID " + txtId.Text);
                }


            }
            else
            {
                MessageBox.Show("Verifica los datos a registrar");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtrarDataGrid();
        }
    }// cierre clase
}// cierre namespace

