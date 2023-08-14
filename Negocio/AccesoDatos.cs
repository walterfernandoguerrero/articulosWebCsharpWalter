using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoDatos //acceso a base de datos general para todas las consultas asi no  escribo varias lineas 
    {
        //propiedades con objetos de manejo de Base de datos SQL Server
        private SqlConnection conexion; //varible
        private SqlCommand comando;
        private SqlDataReader lector = null;

    public AccesoDatos()//constructor con dos varibles instanciadas
        {
            conexion = new SqlConnection("data source =.\\SQLEXPRESS; initial catalog=CATALOGO_WEB_DB; integrated security=sspi");
            comando = new SqlCommand();

        }

    //pido consulta SQL(que viene de afuera de la clase)  pero todavia ninguna accion ni leer ni escribir ni borrar etc.
    public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

    //----- Nuevo setear con Stored Procedure
    public void setearProcedimento(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

    //genero las acciones que impactan en la base de datos

    public void ejecutarLectura()// leo la base de Datos
        {
            comando.Connection = conexion; // busco mi base de datos para conectarme 
            conexion.Open(); // abro la base de datos
            lector = comando.ExecuteReader();// ejecuto mi lectura 
        }

    public void ejecutarAccion() // para agregar, modificar o borrar registros de la bd
        {
            comando.Connection = conexion; // busco mi base de datos para conectarme 
            conexion.Open(); // abro la base de datos
            comando.ExecuteNonQuery(); //ejecuto escritura
        }

    public void agregarParametro(string nombre, object valor) //para no concatenar sino pasar datos por parametros @
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

    public SqlDataReader Lector //property ?no la entiendo bien
        {
            get { return lector; }
        }
        
    public void cerrarConexion() // cierre del lector y  la conexion 
        {
            if(lector!=null)
            {
                lector.Close();
            }
            conexion.Close();
        }

    }// termina la clase 
}
