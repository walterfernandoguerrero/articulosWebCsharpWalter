using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categorias> Listar() //metodo
        {
            List<Categorias> categorias = new List<Categorias>(); //instnacio una variable de tipo lista
            AccesoDatos datos = new AccesoDatos(); //instnacio una variable de tipo AccesoDatos

            try
            {
                datos.setearConsulta("select Id, Descripcion from CATEGORIAS");
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    categorias.Add(new Categorias((int)datos.Lector["Id"],(string)datos.Lector["Descripcion"]));
                }

                return categorias;
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
