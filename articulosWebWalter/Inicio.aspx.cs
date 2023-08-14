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
    public partial class Inicio : System.Web.UI.Page
    {
        List <Articulos> listaArt = new List <Articulos> ();
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosNegocio articulosNegocio = new ArticulosNegocio();
            listaArt = articulosNegocio.listarConSP();
            if (!IsPostBack)
            {
               //funciona la tabla 
                //dgvListar.DataSource=listaArt;
                //dgvListar.DataBind();

                //probamos reapit 
                repRepetidor.DataSource=listaArt;
                repRepetidor.DataBind();

            }
        }
    }
}