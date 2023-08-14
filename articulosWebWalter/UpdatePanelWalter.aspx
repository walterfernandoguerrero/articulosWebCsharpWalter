<%@ Page Title="" Language="C#" MasterPageFile="~/walterMaestra.Master" AutoEventWireup="true" CodeBehind="UpdatePanelWalter.aspx.cs" Inherits="articulosWebWalter.UpdatePanelWalter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="form-group">
                <div class="row">
                    <div class="col">
                        <asp:Label Text="text" runat="server" ID="lblNombre" />
                    </div>
                    <div class="col">
                        <asp:TextBox AutoPostBack="true" runat="server" ID="txtNombre" OnTextChanged="txtNombre_TextChanged" CssClass="form-control" />
                    </div>
                    <div class="col">
                        <asp:Button Text="Aceptar" CssClass="form-control" runat="server" ID="btnAceptar" OnClick="btnAceptar_Click" />
                    </div>
                </div>
            </div>
           
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel runat="server">
        <%--Cargador de imagenes--%>
        <ContentTemplate>
             <hr />
            <div class="mb-3 row">
                     <div class="col">
                         <asp:TextBox AutoPostBack="true" runat="server"  ID="txtUrlImagen" OnTextChanged="txtUrlImagen_TextChanged" CssClass="form-control"/>
                    </div>
                    <div class="col" >
                        <asp:Button Text="Cargar Imagen" runat="server" ID="btnCargar" OnClick="btnCargar_Click" CssClass="btn btn-primary"/>
                    </div>
                <div class="mb-3 row">
                    <div class="col">
                        <img src="<%=urlImagen %>" alt="Alternate Text" width="50%" />
                    </div>
                </div> 
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
