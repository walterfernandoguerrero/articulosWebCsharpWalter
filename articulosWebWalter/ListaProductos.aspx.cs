using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;



namespace articulosWebWalter
{
    public partial class ListaProductos : System.Web.UI.Page
    {
        public bool verFiltro2 { get; set; }
        ArticulosNegocio negocio = new ArticulosNegocio();
 
        protected void Page_Load(object sender, EventArgs e)
        {
            //lista va sin posback para separar por 5 filas cada pagina si es sin session
           
                Session.Add("listaArticulos", negocio.listarConSP());
                dgvArticulos.DataSource = Session["listaArticulos"];
                dgvArticulos.DataBind();

            if (!IsPostBack)
            {

                verFiltro2 = ckbFilAv.Checked;
            }
                
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("formularioArticulos.aspx");
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("formularioArticulos.aspx?id=" + id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulos> listaArt = (List<Articulos>)Session["listaArticulos"];
            List<Articulos> listaFiltrada = listaArt.FindAll(x => x.Categoria.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnFiltroAvanzado_Click(object sender, EventArgs e)
        {
            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                dgvArticulos.DataSource = negocio.filtrarAvanzado(ddlCampo.Text, ddlCriterio.Text, txtFiltroAv.Text);
                
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void ckbFilAv_CheckedChanged(object sender, EventArgs e)
        {
            verFiltro2=ckbFilAv.Checked;
            //txtFiltro.Enabled = !verFiltro2;
        }
    }
}