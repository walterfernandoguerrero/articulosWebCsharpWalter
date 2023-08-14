<%@ Page Title="" Language="C#" MasterPageFile="~/walterMaestra.Master" AutoEventWireup="true" CodeBehind="ListaProductos.aspx.cs" Inherits="articulosWebWalter.ListaProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <h2>Lista de Productos</h2>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar por Categoria:" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control"  AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged"/>
            </div>
        </div>
    </div>
    <hr />
    <br />
    <asp:CheckBox Text="Ingresar a Filtro Avanzado" runat="server"  ID="ckbFilAv" OnCheckedChanged="ckbFilAv_CheckedChanged" AutoPostBack="true"/>
    <%      if (ckbFilAv.Checked)
            {  %>
                <div style="background-color:yellowgreen">
                    <br />
                    <hr />
                    <asp:Label Text="Filtro Avanzado" runat="server" />
                    <br />
                    <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                        <asp:ListItem Text="Precio" />
                        <asp:ListItem Text="Nombre" />
                    </asp:DropDownList>
                    <asp:DropDownList runat="server" ID="ddlCriterio">
                    </asp:DropDownList>
                    <asp:TextBox runat="server" ID="txtFiltroAv" />
                    <asp:Button Text="Filtro Avanzado" runat="server" ID="btnFiltroAvanzado" OnClick="btnFiltroAvanzado_Click" />
                    <hr />
                    <br />
                </div>
          <%} %>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
             <asp:GridView runat="server" ID="dgvArticulos" CssClass="table" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" 
                    DataKeyNames="IdArticulo" OnPageIndexChanging="dgvArticulos_PageIndexChanging"
                    AllowPaging="true" PageSize="5" >
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                        <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                        <asp:BoundField HeaderText="Precio" DataField="Precio" />
                        <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText=" ✍️" />
                    </Columns>

            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
   
    <div>
        <br />
         <asp:Button Text="Agregar Articulo" ID="btnAgregar" CssClass="btn btn-primary"  runat="server" OnClick="btnAgregar_Click" />
    </div>

</asp:Content>
