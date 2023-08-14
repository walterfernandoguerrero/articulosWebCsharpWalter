using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace articulosWebWalter
{
    public partial class formularioArticulos : System.Web.UI.Page
    {
        public bool confirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            confirmaEliminacion = false;
            try
            {
                if(!IsPostBack) //no olvidar sino no cargan cambios de comboboxweb jiji.. 
                {
                    CategoriaNegocio negCat = new CategoriaNegocio();
                    List<Categorias> listCat = negCat.Listar();
                    MarcaNegocio negMar = new MarcaNegocio();
                    List<Marcas> listMarc = negMar.Listar();

                    ddlCategoria.DataSource = listCat;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    ddlMarca.DataSource = listMarc;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                }

                //configuracion de modificacion------------------------------------------------------------

                if (Request.QueryString["id"] != null && !IsPostBack) //controlar el postback grrr
                {
                    //traer el objeto de base de datos 
                    ArticulosNegocio negocio = new ArticulosNegocio();

                    // hice un nuevo metodo que agrega a la consulta de base de datos un and con [A.id = id] 
                    // este metodo recibe un string que viene de el redireccionamiento de la pagina listas 
                    List<Articulos> listaArt = negocio.ListarPorID(Request.QueryString["id"].ToString());
                    Articulos seleccionado = listaArt[0];

                    //precargar los datos 
                    txtId.Text = seleccionado.IdArticulo.ToString();
                    txtCodigo.Text = seleccionado.Codigo.ToString();
                    txtNombre.Text = seleccionado.Nombre.ToString();
                    txtDescripcion.Text=seleccionado.Descripcion.ToString();
                    txtImagenUrl.Text = seleccionado.Imagen;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    //cargar los combo box

                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();

                    //forzar el evento de imagen 
                    txtImagenUrl_TextChanged(sender, e);





                }
                
            }
            catch (Exception ex)
            {
                Session.Add("error",ex); 
                throw;
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                int id1= int.Parse(ddlMarca.SelectedValue);
                
                Articulos nuevo = new Articulos();
                ArticulosNegocio negocio = new ArticulosNegocio();
                nuevo.Codigo=txtCodigo.Text;
                nuevo.Nombre=txtNombre.Text;
                nuevo.Descripcion=txtDescripcion.Text;
                nuevo.Imagen = txtImagenUrl.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                nuevo.Marca = new Marcas();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
               //nuevo.Marca.Id= int.Parse(ddlMarca.SelectedItem.Value);

                nuevo.Categoria = new Categorias();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                // nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedItem.Value);    

                //dar inteligencia a  mi boton aceptar

                string idUrl = Request.QueryString["id"]; //si tiene id en url

                if(idUrl != null)
                {
                    //deberia cargar el Id al objeto
                    nuevo.IdArticulo=int.Parse(idUrl);
                    negocio.ModificarConSp(nuevo);
                }
                else
                {
                    negocio.AgregarConSP(nuevo);
                }

                Response.Redirect("ListaProductos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
            

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmaEliminacion = true;
        }

        protected void btnconfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(chkConfirmarEliminacion.Checked){
                    ArticulosNegocio negocio = new ArticulosNegocio();
                    negocio.Eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ListaProductos.aspx", false);
                }
               
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}