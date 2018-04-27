using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //agregamos libreria Data
using Datos; //incluimos la capa datos

namespace Logica
{
    public class Employees : Conexion
    {
        private int id;
        private string name;
        private string lastName;
        private int user;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }



        public DataSet ListadoEmployees()
        {
            string consulta = "select * from Employees";
            DataSet resultadoConsulta = ConsultarSQL(consulta);
            return resultadoConsulta;
        }

        public bool CrearEmployees(string frmName, string frmLastName, string frmUser)
        {
           
            string consulta = "Insert into employees ( name, lastName, User_id ) values ('" + frmName + "', '" + frmLastName + "', '" + frmUser + "')";
            bool respuesta = EjecutarSQL(consulta);
            return respuesta;
        }


    }
}
