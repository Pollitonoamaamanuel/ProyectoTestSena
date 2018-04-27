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
    public partial class frmEmployees : Form
    {
        public frmEmployees()
        {
            InitializeComponent();
        }

        public void cargarDataGrid() {

            Logica.Employees consulta = new Logica.Employees();
            DataSet resultado = consulta.ListadoEmployees();

            DataTable DatosTabla = new DataTable();
            DatosTabla = resultado.Tables[0];

            dtgListado.DataSource = DatosTabla;

        }


        public void ComboUsers()
        {
            Logica.Users consulta = new Logica.Users();
            DataSet resultado = consulta.ListadoUsuarios();

            DataTable DatosCombo = new DataTable();
            DatosCombo = resultado.Tables[0];

            cmbUsers.DisplayMember = "nick";
            cmbUsers.ValueMember = "id";
            cmbUsers.DataSource = DatosCombo;
        }

        private void frmEmployees_Load(object sender, EventArgs e)
        {
            ComboUsers();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (validarRegistro())
            {// true
                //registramos
                Logica.Employees obj = new Logica.Employees();
                bool respuesta = obj.CrearEmployees(txtName.Text, txtName.Text, cmbUsers.SelectedValue.ToString());
                if (respuesta == true)
                {
                    MessageBox.Show("Se han registrado los Datos");
                  
                    cargarDataGrid();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error");
                }


            }
            else
            {
                MessageBox.Show("Verifica los datos a registrar");
            }
        }

        public bool validarRegistro()
        {

            txtId.Text = "";
            
            if (txtLastName.Text != "" && txtName.Text != "" && cmbUsers.SelectedValue.ToString() != "")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
