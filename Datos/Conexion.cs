using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Conexion
    {
        private SqlConnection conn;
        private string mensaje;

        public string Mensaje //método publico para establecer y obtener el valor de mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        public Conexion() //método constructor: primer metodo que se ejecuta al crear un objeto
        {
            string cadenadeconexion = @"Data Source=EQUIPO1\SQLEXPRESS;Initial Catalog=My_Test;Persist Security Info=True;User ID=admin;Password=12345";
            conn = new SqlConnection(cadenadeconexion);
            // conectar con el servidor de sql y la base de datos
        }

        public DataSet ConsultarSQL(string sentenciaSQL) //método para consultar datos
        {
            try //intente
            {
                //1. abrir la conexion
                conn.Open();
                //2. Enviar la sentencia por la conexiona abierta
                SqlDataAdapter respuestaServidor = new SqlDataAdapter(sentenciaSQL, conn);
                //3. Crear el objeto de tipo DataSet donde estarán mis datos
                DataSet datos = new DataSet();
                //4. Llenar el DataSet con la respuesta del servidor
                respuestaServidor.Fill(datos, "DatosConsultados");
                //5. Devolvemos el mensaje de éxito y retornamos el DataSet
                mensaje = "Se ha consultado con éxito";
                return datos;
            }
            catch (Exception miError) //capture el error
            {
                DataSet vacio = new DataSet();
                mensaje = "No se ha podido consultar. Error: " + miError.Message;
                return vacio;
            }
            finally //finalmente
            {
                conn.Close();
            }
        }

        public bool EjecutarSQL(string sentenciaSQL)//ejecutar consultas sin recibir respuestas del servidor SQL
        {
            try
            {
                conn.Open();
                SqlCommand miConsulta = new SqlCommand(); //1. instanciar SqlCommand
                miConsulta.Connection = conn; //2. agregar la conexión abierta
                miConsulta.CommandText = sentenciaSQL; //3. Agregar la consulta sql
                miConsulta.ExecuteNonQuery(); //4. ejecutamos consulta y no recibimos resultado

                mensaje = "Se ha ejecutado la consulta con éxito";
                return true;
            }
            catch (Exception Error)
            {
                mensaje = "Se ha producido un error. Error: " + Error.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
