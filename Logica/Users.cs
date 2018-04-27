using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //agregamos libreria Data
using Datos; //incluimos la capa datos

namespace Logica
{
    public class Users: Conexion //herencia de conexión
    {
        private int id;
        private string nick;
        private string password;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nick
        {
            get { return nick; }
            set { nick = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        //Inicio de los métodos
        public DataSet IniciarSesion(string formNick, string formPassword)
        {
            string consultaSql = "select * from Users where nick = '"+ formNick +"' and password = '"+ formPassword +"'";
            DataSet resultadoConsulta = ConsultarSQL(consultaSql);
            return resultadoConsulta; 
        }

        public DataSet ListadoUsuarios()
        {
            // string consulta = "select * from Users";
            string consulta = "exec pa_select_all_users";
            DataSet resultadoConsulta = ConsultarSQL(consulta);
            return resultadoConsulta;
        }

        public DataSet consultar(string id)
        {
            //string consulta = "select * from Users where id ='"+ id + "'";
            string consulta = "exec pa_select_one_users '" + id + "'";
            DataSet resultadoConsulta = ConsultarSQL(consulta);
            return resultadoConsulta;
        }

        public bool CrearUsuario(string frmNick, string frmPassword )
        {
           // string consulta = "Insert into users ( nick, password ) values ('"+ frmNick + "', '"+ frmPassword + "')";

           string consulta = "exec  pa_insert_users '" + frmNick + "', '" + frmPassword + "'";
            
            bool respuesta = EjecutarSQL(consulta);
            return respuesta;
        }


        public bool ActualizarUsuario(string frmId, string frmNick, string frmPassword)
        {
            //string consulta = "Update users set nick='" + frmNick + "', password='" + frmPassword + "' where id='" + frmId + "'";
            string consulta = "exec pa_update_users '" + frmNick + "', '" + frmPassword + "', '" + frmId + "'";
            bool respuesta = EjecutarSQL(consulta);
            return respuesta;
        }


        public bool EliminarUsuario(string frmId)
        {
            //string consulta = "Delete from users where id='" + frmId + "'";
            string consulta = " exec pa_delete_users '" + frmId + "' ";
            bool respuesta = EjecutarSQL(consulta);
            return respuesta;
        }

        public DataSet FiltrarUsuarios(string text)
        {
            //string consulta = "select * from Users where nick LIKE '%"+ text + "%' or password LIKE '%" + text + "%'";
            string consulta = "exec pa_filter_users '"+ text + "', '" + text + "'";
            DataSet resultadoConsulta = ConsultarSQL(consulta);
            return resultadoConsulta;
        }

    }
}
