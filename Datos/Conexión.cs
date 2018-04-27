using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;//Libtrerias para trabajar SQLServer

namespace Datos
{
    public class Conexión
    {
        private SqlConnection conn;
        private string mensaje;

        public string Mensaje
         { // método público para establecer y obtener el valor del mensaje
                get { return mensaje; }
                set { mensaje = value; }
         }

        public Conexión()// método constructor
         {
             string cadenaConexion = @"Data Source=EQUIPO1\SQLEXPRESS;Initial Catalog=My_Test;User ID=admin;Password=12345";
             conn = new SqlConnection(cadenaConexion);
             // conectar con el servidor de sql y la Base de Datos
         }

        public DataSet consultarSQL (string sentenciaSQL)
        {//metodo para consultar datos
            try //intente 
            {
                //1. Abrir la conexión
                conn.Open();
                //2. Enviar la sentencia por la conexión abierta
                SqlDataAdapter respuestaServidor = new SqlDataAdapter(sentenciaSQL, conn);
                //3. Crear el objeto de tipo DataSet donde estarán mis datos
                DataSet datos = new DataSet();
                //4. Llenar el DataSet con la respuesta del servidor
                respuestaServidor.Fill(datos,"DatosConsultados");
                //5. Devolvemos el mensaje de éxito y retomamos el DataSet
                mensaje = "Se ha consultado con éxito";
                return datos; 
            }

            catch(Exception miError) //capture el error
            {
                DataSet vacio = new DataSet();
                mensaje = "No se ha podido consultar.Error:" + miError.Message;
                return vacio;
            }

            finally // finalmente
            {
                conn.Close();
            }

            
        }

        public bool EjecutarSQL ( string sentenciaSql)
        {// ejecutar sentencias sin recibir 
            //respuestas del servidorSQL 
            try
            {
                conn.Open();
                SqlCommand miConsulta = new SqlCommand(); // 1.Instanciar sqlComand
                miConsulta.Connection = conn;// 2. agregar la conexión abierta
                miConsulta.CommandText = sentenciaSql;//3. agregar la consulta sql
                miConsulta.ExecuteNonQuery (); // 4. ajecutamos consulta y no recibimos resultado   

                mensaje = " se ha ejecutado consulta con éxito";
                return true;
            } 
            catch (Exception Error)
            {
                mensaje = "Se ha producido un error.Error" + Error.Message;
                return false;
            }
            finally
            {

            }
        }
    }
}
