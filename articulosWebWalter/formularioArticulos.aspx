<%@ Page Title="" Language="C#" MasterPageFile="~/walterMaestra.Master" AutoEventWireup="true" CodeBehind="formularioArticulos.aspx.cs" Inherits="articulosWebWalter.formularioArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label for="txtId" class="form-label">Id</label>
                    <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtCodigo" class="form-label">Codigo: </label>
                    <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre: </label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Descripción: </label>
                    <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="ddlMarca" class="form-label">Marca: </label>
                    <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                    <%-- <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server"></asp:DropDownList>--%>
                </div>
                <div class="mb-3">
                    <label for="ddlCategoria" class="form-label">Categoria</label>
                    <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"  ></asp:DropDownList>
                </div>
                
            </div>

            <div class="col-6">
                <div class="mb-3">
                    <label for="txtPrecio" class="form-label">Precio: </label>
                    <asp:TextBox runat="server"  ID="txtPrecio" CssClass="form-control" />
                </div>
                
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <label for="txtImagenUrl" class="form-label">Url Imagen:</label>
                            <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control"
                                AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                        </div>
                        <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"
                            runat="server" ID="imgArticulo" Width="60%" />
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div class="mb-3">
                    <br />
                    <asp:Button  Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary"  runat="server" OnClick="btnAceptar_Click" />
                    &nbsp
                    <a href="#">Cancelar</a>
                     &nbsp
                    <asp:Button Text="Inactivar" ID="btnInactivar"  CssClass="btn btn-warning" runat="server" />
                </div>

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                         <div class="row">
                    <div class="col-6">
                        <div class="mb-3">
                            <asp:Button Text="Eliminar" runat="server" ID="btnEliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                        </div>
                        <%if (confirmaEliminacion)
                            { %>
                             <div class="mb-3">
                                    <asp:CheckBox Text="Confirmar eliminacion" runat="server"  ID="chkConfirmarEliminacion"/>
                                    <asp:Button Text="Eliminar" runat="server" ID="btnconfirmarEliminar" OnClick="btnconfirmarEliminar_Click" CssClass="btn btn-outline-danger" />
                             </div>
                        <%} %>
                      </div>
                 </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            
         </div>

</asp:Content>
