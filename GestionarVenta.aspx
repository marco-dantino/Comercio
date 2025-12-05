<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarVenta.aspx.cs" Inherits="Comercio.GestionarVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main class="flex-1 p-6 lg:p-10 flex flex-col">

    <div class="max-w-4xl mx-auto w-full flex-grow">
        <div class="mb-8 bg-[#111827] border-2 border-solid border-sky-500 p-4">
            <h1 class="text-white text-2xl font-bold">Registrar Nueva Venta</h1>
            <asp:Label ID="lblMessage" runat="server" CssClass="text-green-400 font-medium" />
        </div>

        <div class="bg-[#1f2937] rounded-lg shadow-md p-6 mb-8 text-left space-y-6">
            <div class="p-6">

                <div class="grid grid-cols-1 md:grid-cols-2 gap-6">

                    <div>
                        <label for="ddlCliente">Cliente</label>
                        <asp:DropDownList ID="ddlCliente" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500 text-gray-100"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCliente" runat="server" ControlToValidate="ddlCliente" InitialValue="" ErrorMessage="El Cliente es requerido." CssClass="text-red-400 text-sm" Display="Dynamic" />
                    </div>

                    <div>
                        <label for="txtFecha">Fecha</label>
                        <asp:TextBox ID="txtFecha" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500 text-gray-100" TextMode="Date" Text='<%# DateTime.Now.ToString("dd/MM/yyyy") %>' min="1900-01-01" max="2100-12-31">></asp:TextBox>
                    </div>

                    <div>
                        <label for="ddlProducto">Producto</label>
                        <asp:DropDownList ID="ddlProducto" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500 text-gray-100"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvProducto" runat="server" ControlToValidate="ddlProducto" InitialValue="0" ErrorMessage="La Producto es requerida." CssClass="text-red-400 text-sm" Display="Dynamic" />
                    </div>

                    <div>
                        <label for="txtCantidad">Cantidad</label>
                        <asp:TextBox ID="txtCantidad" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                        <asp:RequiredFieldValidator ID="rfvStockProducto" runat="server" ControlToValidate="txtCantidad" ErrorMessage="La cantidad es obligatoria." CssClass="text-red-400 text-sm" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revCantidad" runat="server" ControlToValidate="txtCantidad" ErrorMessage="Debe ser un número entero positivo." CssClass="text-red-400 text-sm" Display="Dynamic" ValidationExpression="^\d+$" />
                    </div>

                    <div class="flex gap-4">
                        <asp:Label ID="lblTotal" runat="server" />
                        <asp:Button ID="btnAgregarDetalle" runat="server" CssClass="px-4 py-2 bg-gray-600 hover:bg-gray-700 text-white rounded" Text="Agregar Detalle" OnClick="btnAgregarDetalle_Click" />

                        <asp:Button ID="btnGuardar" runat="server" CausesValidation="false" CssClass="px-4 py-2 bg-gray-600 hover:bg-gray-700 text-white rounded" Text="Guardar Venta" OnClick="btnGuardar_Click" />
                        <asp:Label ID="lblMensaje" runat="server" />

                    </div>
                </div>
            </div>
        </div>
        <asp:GridView ID="gvDetalleVenta" runat="server" AutoGenerateColumns="False" CssClass="grid-dark"  OnRowCommand="gvDetalleVenta_RowCommand">
            <Columns>
                <asp:BoundField DataField="Producto.Nombre" HeaderText="Producto" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Container.DataItemIndex %>' CausesValidation="false" OnClientClick="return confirm('Estás seguro de eliminar este Detalle?');" CssClass="material-icons-outlined text-red-500">
                            delete
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</main>
</asp:Content>
