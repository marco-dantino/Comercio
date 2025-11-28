<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarCompra.aspx.cs" Inherits="Comercio.GestionarCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function calcularSubtotal() {
            let cantidad = parseFloat(document.getElementById("<%= txtCantidad.ClientID %>").value) || 0;
            let precio = parseFloat(document.getElementById("<%= txtPrecioCompra.ClientID %>").value) || 0;

            let subtotal = cantidad * precio;

            document.getElementById("<%= txtSubtotal.ClientID %>").value = subtotal.toFixed(2);
        }
    </script>

    <main class="flex-1 p-6 lg:p-10 flex flex-col">

        <div class="max-w-4xl mx-auto w-full flex-grow">
            <div class="mb-8 bg-[#111827] border-2 border-solid border-sky-500 p-4">
                <h1 class="text-white text-2xl font-bold">Registrar Nueva Compra</h1>
            </div>

            <div class="bg-[#1f2937] rounded-lg shadow-md p-6 mb-8 text-left space-y-6">
                <div class="p-6">

                    <div class="grid grid-cols-1 md:grid-cols-2 gap-6">

                        <div>
                            <label for="ddlProveedor">Proveedor</label>
                            <asp:DropDownList ID="ddlProveedor" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProveedor_SelectedIndexChanged" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500 text-gray-100"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvProveedor" runat="server" ControlToValidate="ddlProveedor" InitialValue="" ErrorMessage="El proveedor es requerido." CssClass="text-red-400 text-sm" Display="Dynamic" />
                        </div>

                        <div>
                            <label for="txtFecha">Fecha</label>
                            <asp:TextBox ID="txtFecha" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500 text-gray-100" TextMode="Date" Text='<%# DateTime.Now.ToString("dd/MM/yyyy") %>'></asp:TextBox>
                        </div>

                        <div>
                            <label for="ddlProducto">Producto</label>
                            <asp:DropDownList ID="ddlProducto" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500 text-gray-100"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvProducto" runat="server" ControlToValidate="ddlProducto" InitialValue="0" ErrorMessage="La Producto es requerida." CssClass="text-red-400 text-sm" Display="Dynamic" />
                        </div>

                        <div>
                            <label for="txtCantidad">Cantidad</label>
                            <asp:TextBox oninput="calcularSubtotal()" ID="txtCantidad" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                            <asp:RequiredFieldValidator ID="rfvStockProducto" runat="server" ControlToValidate="txtCantidad" ErrorMessage="La cantidad es obligatoria." CssClass="text-red-400 text-sm" Display="Dynamic" />
                            <asp:RegularExpressionValidator ID="revCantidad" runat="server" ControlToValidate="txtCantidad" ErrorMessage="Debe ser un número entero positivo." CssClass="text-red-400 text-sm" Display="Dynamic" ValidationExpression="^\d+$" />
                        </div>

                        <div>
                            <label for="txtPrecioCompra">Precio Compra</label>
                            <asp:TextBox oninput="calcularSubtotal()" ID="txtPrecioCompra" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                            <asp:RequiredFieldValidator ID="rfvPrecioCompra" runat="server" ControlToValidate="txtPrecioCompra" ErrorMessage="El precio de compra es obligatorio." CssClass="text-red-400 text-sm" Display="Dynamic" />
                            <asp:RegularExpressionValidator ID="revPrecioCompra" runat="server" ControlToValidate="txtPrecioCompra" ErrorMessage="Debe ser un número válido." CssClass="text-red-400 text-sm" Display="Dynamic" ValidationExpression="^\d+(\.\d{1,2})?$" />
                        </div>

                        <div>
                            <label for="txtSubtotal">Subtotal</label>
                            <asp:TextBox ID="txtSubtotal" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 text-gray-100" ReadOnly="true"></asp:TextBox>
                        </div>

                        <div class=" flex gap-4">
                            <asp:Label ID="lblTotal" runat="server" />
                            <asp:Button ID="btnAgregarDetalle" runat="server" CssClass="px-4 py-2 bg-gray-600 hover:bg-gray-700 text-white rounded" Text="Agregar Detalle" OnClick="btnAgregarDetalle_Click" />

                            <asp:Button ID="btnGuardar" runat="server" CausesValidation="false" CssClass="px-4 py-2 bg-gray-600 hover:bg-gray-700 text-white rounded" Text="Guardar Compra" OnClick="btnGuardar_Click" />
                            <asp:Label ID="lblMensaje" runat="server" />

                        </div>
                    </div>
                </div>
            </div>
            <asp:GridView ID="gvDetalleCompra" runat="server" AutoGenerateColumns="False" CssClass="grid-dark"  OnRowCommand="gvDetalleCompra_RowCommand">
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
