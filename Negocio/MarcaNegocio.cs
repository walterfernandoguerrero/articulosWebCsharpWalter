using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {

    public List<Marcas> Listar()// metodo
        {
            List<Marcas> marcas = new List<Marcas>();// variable tipo lista(marcas)
            AccesoDatos datos = new AccesoDatos();// variable de conexion

            try
            {
                datos.setearConsulta("select Id, Descripcion  from MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {  // agrego un elemento a mi lista, en la misma linea la instacio 

                    marcas.Add(new Marcas((int)datos.Lector["Id"], (string)datos.Lector["Descripcion"]));
                }

                return marcas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }


    }
}
