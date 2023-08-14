using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;


namespace Negocio
{
    public class ArticulosNegocio
    {
        public List<Articulos> Listar1()
        {
            List<Articulos> lista1 = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Id as IdMarca, M.Descripcion as Marca," +
                    " C.Id as IdCategoria, C.Descripcion as Categoria, A.ImagenUrl, A.Precio from ARTICULOS" +
                    " A inner join CATEGORIAS C on A.IdCategoria = C.Id inner join MARCAS M on A.IdMarca = M.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read()) //  si me conecte recorro el lector cargado en memoria
                {
                    Articulos aux = new Articulos();

                    aux.IdArticulo = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Imagen= (string)datos.Lector["ImagenUrl"];

                    //son de tipo clases nececito instanciar el objeto tiene una sobrecarga o dos
                    // aux.Marca = new Marcas((string)datos.Lector["Marca"]);
                    aux.Marca = new Marcas();
                    aux.Marca.Id=(int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    
                    aux.Categoria = new Categorias((int)datos.Lector["IdCategoria"],(string)datos.Lector["Categoria"]);

                    aux.Precio = (decimal)datos.Lector["Precio"];//con decimal acepta money

                    lista1.Add(aux);
                }

            //select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Id as IdMarca, M.Descripcion as Marca,
            //C.Id as IdCategoria, C.Descripcion as Categoria, A.ImagenUrl, A.Precio
            //from ARTICULOS A inner join CATEGORIAS C on A.IdCategoria = C.Id inner join MARCAS M on A.IdMarca = M.Id
                return lista1;
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

        
        public void Agregar(Articulos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into  ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio)" +
                    "Values(@codigo,@nombre,@desc,@idmarca,@idcat,@urlImg,@precio)");
                datos.agregarParametro("@codigo",nuevo.Codigo);
                datos.agregarParametro("@nombre", nuevo.Nombre);
                datos.agregarParametro("@desc", nuevo.Descripcion);
                datos.agregarParametro("@idmarca", nuevo.Marca.Id);
                datos.agregarParametro("@idcat", nuevo.Categoria.Id);
                datos.agregarParametro("@urlImg", nuevo.Imagen);
                datos.agregarParametro("@precio", nuevo.Precio);
                datos.ejecutarAccion();
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

        public void Modificar(Articulos modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo=@codigo, Nombre=@nombre, Descripcion=@desc, " +
                    "IdMarca=@idmarca, IdCategoria=@idcat, ImagenUrl=@urlImg, Precio=@precio where Id=@Id");
                datos.agregarParametro("@codigo", modificar.Codigo);
                datos.agregarParametro("@nombre", modificar.Nombre);
                datos.agregarParametro("@desc", modificar.Descripcion);
                datos.agregarParametro("@idmarca", modificar.Marca.Id);
                datos.agregarParametro("@idcat", modificar.Categoria.Id);
                datos.agregarParametro("@urlImg", modificar.Imagen);
                datos.agregarParametro("@precio", modificar.Precio);
                datos.agregarParametro("@Id", modificar.IdArticulo);
                datos.ejecutarAccion();

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

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from ARTICULOS where Id="+id);
                datos.ejecutarAccion();
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
        //---------------Stored prosedure-----------------------------------------------
        
        //listar con Stored
        public List<Articulos> listarConSP()
        {
            List<Articulos> lista1 = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //datos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Id as IdMarca, M.Descripcion as Marca," +
                //    " C.Id as IdCategoria, C.Descripcion as Categoria, A.ImagenUrl, A.Precio from ARTICULOS" +
                //    " A inner join CATEGORIAS C on A.IdCategoria = C.Id inner join MARCAS M on A.IdMarca = M.Id");

                datos.setearProcedimento("storedListar");//el nombre de procedimiento en la base de datos...

                datos.ejecutarLectura();

                while (datos.Lector.Read()) //  si me conecte recorro el lector cargado en memoria
                {
                    Articulos aux = new Articulos();

                    aux.IdArticulo = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Imagen = (string)datos.Lector["ImagenUrl"];

                    //son de tipo clases nececito instanciar el objeto tiene una sobrecarga o dos

                    //aux.Marca = new Marcas((string)datos.Lector["Marca"]);

                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];//nombre entre""del campo de la base pero escrita en la consulta SQL[ M.id as IdMarca ]
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categorias();
                    aux.Categoria.Id =(int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion=((string)datos.Lector["Categoria"]);

                    aux.Precio = (decimal)datos.Lector["Precio"];//con decimal acepta money

                    lista1.Add(aux);
                }

                //select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Id as IdMarca, M.Descripcion as Marca,
                //C.Id as IdCategoria, C.Descripcion as Categoria, A.ImagenUrl, A.Precio
                //from ARTICULOS A inner join CATEGORIAS C on A.IdCategoria = C.Id inner join MARCAS M on A.IdMarca = M.Id
                return lista1;
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

        public void AgregarConSP(Articulos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //datos.setearConsulta("insert into  ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio)" +
                //    "Values(@codigo,@nombre,@desc,@idmarca,@idcat,@urlImg,@precio)");

                //@codigo varchar(50),
                //@nombre varchar(50),
                //@desc varchar(150),
                //@idMarca int,
                //@idCategoria int,
                //@imgUrl varchar(1000),
                //@precio money

                datos.setearProcedimento("storedAltaArticulo");

                datos.agregarParametro("@codigo", nuevo.Codigo);
                datos.agregarParametro("@nombre", nuevo.Nombre);
                datos.agregarParametro("@desc", nuevo.Descripcion);
                datos.agregarParametro("@idMarca", nuevo.Marca.Id);
                datos.agregarParametro("@idCategoria", nuevo.Categoria.Id);
                datos.agregarParametro("@imgUrl", nuevo.Imagen);
                datos.agregarParametro("@precio", nuevo.Precio);
                datos.ejecutarAccion();
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

        public List<Articulos> ListarPorID(string id)
        {
            List<Articulos> lista1 = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Id as IdMarca, M.Descripcion as Marca," +
                    " C.Id as IdCategoria, C.Descripcion as Categoria, A.ImagenUrl, A.Precio from ARTICULOS" +
                    " A inner join CATEGORIAS C on A.IdCategoria = C.Id inner join MARCAS M on A.IdMarca = M.Id and A.Id = " + id);
                datos.ejecutarLectura();

                while (datos.Lector.Read()) //  si me conecte recorro el lector cargado en memoria
                {
                    Articulos aux = new Articulos();

                    aux.IdArticulo = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Imagen = (string)datos.Lector["ImagenUrl"];

                    //son de tipo clases nececito instanciar el objeto tiene una sobrecarga o dos
                    // aux.Marca = new Marcas((string)datos.Lector["Marca"]);
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categorias((int)datos.Lector["IdCategoria"], (string)datos.Lector["Categoria"]);

                    aux.Precio = (decimal)datos.Lector["Precio"];//con decimal acepta money

                    lista1.Add(aux);
                }

                //select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Id as IdMarca, M.Descripcion as Marca,
                //C.Id as IdCategoria, C.Descripcion as Categoria, A.ImagenUrl, A.Precio
                //from ARTICULOS A inner join CATEGORIAS C on A.IdCategoria = C.Id inner join MARCAS M on A.IdMarca = M.Id
                return lista1;
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

        public List<Articulos> filtrarAvanzado(string campo, string criterio, string filtro)
        {
            List<Articulos> lista1 = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta;
                consulta="select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Id as IdMarca, M.Descripcion as Marca," +
                    " C.Id as IdCategoria, C.Descripcion as Categoria, A.ImagenUrl, A.Precio from ARTICULOS" +
                    " A inner join CATEGORIAS C on A.IdCategoria = C.Id inner join MARCAS M on A.IdMarca = M.Id and ";

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "A.Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "A.Precio < " + filtro;
                            break;
                        default:
                            consulta += "A.Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "E.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "E.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "E.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }

                /*if (estado == "Activo")
                    consulta += " and P.Activo = 1";
                else if (estado == "Inactivo")
                    consulta += " and P.Activo = 0";*/

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read()) //  si me conecte recorro el lector cargado en memoria
                {
                    Articulos aux = new Articulos();

                    aux.IdArticulo = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Imagen = (string)datos.Lector["ImagenUrl"];

                    //son de tipo clases nececito instanciar el objeto tiene una sobrecarga o dos
                    // aux.Marca = new Marcas((string)datos.Lector["Marca"]);
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categorias((int)datos.Lector["IdCategoria"], (string)datos.Lector["Categoria"]);

                    aux.Precio = (decimal)datos.Lector["Precio"];//con decimal acepta money

                    lista1.Add(aux);
                }

                //select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Id as IdMarca, M.Descripcion as Marca,
                //C.Id as IdCategoria, C.Descripcion as Categoria, A.ImagenUrl, A.Precio
                //from ARTICULOS A inner join CATEGORIAS C on A.IdCategoria = C.Id inner join MARCAS M on A.IdMarca = M.Id
                return lista1;
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

        public void ModificarConSp(Articulos modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimento("storedModificarArticulos");
                datos.agregarParametro("@codigo", modificar.Codigo);
                datos.agregarParametro("@nombre", modificar.Nombre);
                datos.agregarParametro("@desc", modificar.Descripcion);
                datos.agregarParametro("@idmarca", modificar.Marca.Id);
                datos.agregarParametro("@idcat", modificar.Categoria.Id);
                datos.agregarParametro("@urlImg", modificar.Imagen);
                datos.agregarParametro("@precio", modificar.Precio);
                datos.agregarParametro("@Id", modificar.IdArticulo);
                datos.ejecutarAccion();

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
