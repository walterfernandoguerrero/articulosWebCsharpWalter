using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace articulosWebWalter
{
    public partial class comboBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosNegocio negocioArt = new ArticulosNegocio();
            MarcaNegocio negocioMarca = new MarcaNegocio();
            CategoriaNegocio catNegocio = new CategoriaNegocio();

           
           
            try
            {
                List<Marcas> listaMarca = negocioMarca.Listar();
                List<Categorias> listaCat = catNegocio.Listar();
                if (!IsPostBack)
                {
                    //cargar un combo box con datos de BD articulos
                    List<Articulos> listarAr = negocioArt.listarConSP();
                    Session["listarAr"] = listarAr;

                    cboArticulosBD.DataSource = listarAr;
                    cboArticulosBD.DataValueField = "IdArticulo";
                    cboArticulosBD.DataTextField = "Nombre";
                    cboArticulosBD.DataBind();

                    //cargar combo marca

                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataValueField = "Id";     //nombre del objeto o sea de la clase (propiedad)
                    ddlMarca.DataTextField = "Descripcion"; //nombre de propiedad de la clase
                    ddlMarca.DataBind();

                    //voy a poner otra carga para preseleccionados
                    ddlMarcaPreseleccionada.DataSource = listaMarca;
                    ddlMarcaPreseleccionada.DataValueField = "Id";
                    ddlMarcaPreseleccionada.DataTextField = "Descripcion";
                    ddlMarcaPreseleccionada.DataBind();

                    //cargar combo de categorias
                    
                    ddlCategoria.DataSource = listaCat;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    //pre carga por ahora los quito------------------------
                    
                    //ddlFiltroMarca.DataSource = listarAr;
                    //ddlFiltroMarca.DataBind();

                    //ddlFiltroCat.DataSource = listarAr;
                    //ddlFiltroCat.DataBind();
                    //-------------------------------------------------------

                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }

            
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int id = int.Parse(ddlMarca.SelectedItem.Value);

                List<Articulos> Art;
                //pruebas
                int a;
                string b;
                int cont = 0;
                int cont1 = 0;
                Art = ((List<Articulos>)Session["listarAr"]);
                foreach (var item in Art)
                {
                    a = item.Marca.Id;
                    cont++;
                }

                //List<MyClass> result = classList.FindAll(class => class.ID == 123);
                //.FindAll(x => x.Marca.Id == id);
                
                //filtro
                List<Articulos> filtroArt = Art.FindAll(x => x.Marca.Id == id);

                //pruebas
                foreach (var item in filtroArt)
                {
                    b = item.Nombre;
                    cont1++;
                }

                //carga de ddl
                ddlFiltroMarca.DataSource = filtroArt;
                ddlFiltroMarca.DataBind();
            }
            

        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                int id = int.Parse(ddlCategoria.SelectedItem.Value);

                ddlFiltroCat.DataSource = ((List<Articulos>)Session["listarAr"]).FindAll(x => x.Categoria.Id == id);
                ddlFiltroCat.DataBind();
            }
        }

        protected void btnPreseleccionar_Click(object sender, EventArgs e)
        {
            //tomar id de caja de texto
            string id = txtMarca.Text;

            //web en texto plano 
            ddlMarcaPreseleccionada.SelectedIndex = 
            ddlMarcaPreseleccionada.Items.IndexOf(ddlMarcaPreseleccionada.Items.FindByValue(id));
        }
    }
}