<%@ Page Title="" Language="C#" MasterPageFile="~/walterMaestra.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="articulosWebWalter.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Iniciamos el Proyecto</h1>
    <%--<asp:GridView ID="dgvListar" runat="server" CssClass="table table-striped table-hover">

    </asp:GridView>   esto funciona    --%>
    <div class="row row-cols-1 row-cols-md-3 g-4">
     <asp:Repeater runat="server" id="repRepetidor">
            <ItemTemplate>
                <div class="col">
                <div class="card">
                    <img src="<%#Eval("Imagen") %>" class="imagenArt" alt="Error">
                    <div class="card-body">
                        <h5 class="card-title"><%#Eval("Nombre") %></h5>
                        <p class="card-text"><%#Eval("Descripcion") %></p>
                        <%--<a href="DetallePokemon.aspx?id=<%#Eval("Id") %>">Ver Detalle</a>--%>
                        <!-- boton de ejemplo por ahora comentado-->
                        <%--<asp:button text="Ejemplo" cssclass="btn btn-primary" 
                            runat="server" id="btnEjemplo" CommandArgument='<%#Eval("Id") %>' 
                            CommandName="PokemonId" OnClick="btnEjemplo_Click"/>--%>
                    </div>
                </div>
            </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
