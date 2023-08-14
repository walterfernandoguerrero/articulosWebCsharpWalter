<%@ Page Title="" Language="C#" MasterPageFile="~/walterMaestra.Master" AutoEventWireup="true" CodeBehind="comboBox.aspx.cs" Inherits="articulosWebWalter.comboBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="row">
        <div class="col">
             <h2>prueba de combobox por asphtml </h2>
            <asp:DropDownList runat="server" ID="cboClubes" CssClass="btn btn-outline-dark dropdown-toggle">
                <asp:ListItem Text="Boca" />
                <asp:ListItem Text="River" />
            </asp:DropDownList>
        </div>
        <div>
            <h2>pueba de combobox con bd Articulos listar con SP</h2>
            <asp:DropDownList runat="server" ID="cboArticulosBD" CssClass="btn btn-outline-dark dropdown-toggle">
            
            </asp:DropDownList>
            <hr />


            <h3>enlazar las Marcas con Articulos </h3>
            <asp:DropDownList runat="server" ID="ddlMarca" CssClass="btn btn-outline-dark dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged">
            </asp:DropDownList>

            <asp:DropDownList runat="server" ID="ddlFiltroMarca" CssClass="btn btn-outline-dark dropdown-toggle">
            </asp:DropDownList>


            <hr />
            <h3>enlazar las Categorias con articulos</h3>
            <asp:DropDownList runat="server" ID="ddlCategoria"
                CssClass="btn btn-outline-dark dropdown-toggle" AutoPostBack="true" 
                OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
            </asp:DropDownList>

            <asp:DropDownList runat="server" ID="ddlFiltroCat" CssClass="btn btn-outline-dark dropdown-toggle">
            </asp:DropDownList>

        </div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
               <div>
                    <hr />
                    <h3>Preseleccionar elemento de comboboxweb ddlist</h3>
                        <div class="col">
                            <asp:Label Text="Preseleccionar id de marcas" runat="server" CssClass="col-sm-1 col-form-label" />
                            <asp:TextBox runat="server"  ID="txtMarca" CssClass="form-control"/>
                            <asp:DropDownList runat="server" ID="ddlMarcaPreseleccionada" CssClass="btn btn-outline-dark dropdown-toggle" >    
                            </asp:DropDownList>
                        </div>
                        <div class="mb-3 row">
                            <div class="col">
                                <asp:Button Text="Preseleccionar" runat="server" ID="btnPreseleccionar" OnClick="btnPreseleccionar_Click" CssClass="btn btn-primary" />
                            </div>
                        </div>
             </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        
    

    </div>
</asp:Content>
