<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Comercio.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Productos - ABML
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main class="flex-grow container mx-auto px-6 py-10 flex flex-col justify-center text-center">
        <div class="flex justify-between items-center mb-6">
            <h1 class="text-3xl font-bold">Gestión de Productos</h1>
            <asp:Label ID="lblMessage" runat="server" CssClass="" />
            <asp:Label ID="lblMessage2" runat="server" CssClass="" />
            <asp:Button ID="btnAgregaProducto" runat="server" CssClass="bg-green-600 hover:bg-green-700 text-white font-semibold px-5 py-2 rounded-lg transition" OnClick="btnAgregaProducto_Click" Text="Agregar Producto" />

        </div>

        <div class="bg-[#1f2937] rounded-lg shadow-md p-6 mb-8 text-left space-y-6">
            <div class="grid md:grid-cols-4 gap-6">

                <div>
                    <label for="txtNombreProducto" class="block mb-1 font-medium">Nombre</label>
                    <asp:TextBox ID="txtNombreProducto" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                    <asp:RequiredFieldValidator ID="rfvNombreProducto" runat="server" ControlToValidate="txtNombreProducto" ErrorMessage="El nombre del producto es obligatorio." CssClass="text-red-400 text-sm" Display="Dynamic" />
                </div>

                <div>
                    <label for="txtStockActual" class="block mb-1 font-medium">Stock Actual</label>
                    <asp:TextBox ID="txtStockActual" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                    <asp:RequiredFieldValidator ID="rfvStockProducto" runat="server" ControlToValidate="txtStockActual" ErrorMessage="El stock es obligatorio." CssClass="text-red-400 text-sm" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="revStockActual" runat="server" ControlToValidate="txtStockActual" ErrorMessage="Debe ser un número entero positivo." CssClass="text-red-400 text-sm" Display="Dynamic" ValidationExpression="^\d+$" />
                </div>

                <div>
                    <label for="txtPrecioCompra" class="block mb-1 font-medium">Precio Compra</label>
                    <asp:TextBox ID="txtPrecioCompra" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                    <asp:RequiredFieldValidator ID="rfvPrecioCompra" runat="server" ControlToValidate="txtPrecioCompra" ErrorMessage="El precio de compra es obligatorio." CssClass="text-red-400 text-sm" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="revPrecioCompra" runat="server" ControlToValidate="txtPrecioCompra" ErrorMessage="Debe ser un número válido." CssClass="text-red-400 text-sm" Display="Dynamic" ValidationExpression="^\d+(\.\d{1,2})?$" />
                </div>

                <div>
                    <label for="txtPorcentajeGanancia" class="block mb-1 font-medium">Porcentaje de Ganancia</label>
                    <asp:TextBox ID="txtPorcentajeGanancia" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                    <asp:RequiredFieldValidator ID="rfvPorcentajeGanancia" runat="server" ControlToValidate="txtPorcentajeGanancia" ErrorMessage="Campo obligatorio." CssClass="text-red-400 text-sm" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="RevPorcentajeGanancia" runat="server" ControlToValidate="txtPorcentajeGanancia" ErrorMessage="Debe ser un número entero positivo." CssClass="text-red-400 text-sm" Display="Dynamic" ValidationExpression="^\d+$" />
                </div>

                <div>
                    <label for="ddlMarca" class="block mb-1 font-medium">Marca</label>
                    <asp:DropDownList ID="ddlMarca" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500 text-gray-100"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvMarca" runat="server" ControlToValidate="ddlMarca" InitialValue="0" ErrorMessage="La marca es requerida." CssClass="text-red-400 text-sm" Display="Dynamic" />
                </div>

                <div>
                    <label for="ddlCategoria" class="block mb-1 font-medium">Categoría</label>
                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500 text-gray-100"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCategoria" runat="server" ControlToValidate="ddlCategoria" InitialValue="" ErrorMessage="La categoría es requerida." CssClass="text-red-400 text-sm" Display="Dynamic" />
                </div>

                <div>
                    <label for="ddlProveedor" class="block mb-1 font-medium">Proveedor</label>
                    <asp:DropDownList ID="ddlProveedor" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500 text-gray-100"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvProveedor" runat="server" ControlToValidate="ddlProveedor" InitialValue="" ErrorMessage="El proveedor es requerido." CssClass="text-red-400 text-sm" Display="Dynamic" />
                </div>

                <div>
                    <label for="txtImagenUrl" class="block mb-1 font-medium">URL Imagen</label>
                    <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                    <asp:RequiredFieldValidator ID="ddlImagenUrl" runat="server" ControlToValidate="txtImagenUrl" ErrorMessage="La Imagen es obligatoria" CssClass="text-red-400 text-sm" Display="Dynamic" />
                </div>
            </div>
        </div>

        <div class="overflow-y-auto max-h-96">
            <asp:GridView ID="gvProductos" OnRowCommand="gvProductos_RowCommand" runat="server" DataKeyNames="Id" AutoGenerateColumns="False" CssClass="grid-dark" ShowHeaderWhenEmpty="True" EmptyDataText="No hay Productos registrados.">
                <Columns>

                    <asp:TemplateField HeaderText="Imagen">
                        <ItemTemplate>
                            <img src='<%# Eval("ImagenUrl") %>'
                                alt="Imagen del producto"
                                class="h-12 w-12 object-cover rounded-md border border-gray-700" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="StockActual" HeaderText="Stock" />
                    <asp:BoundField DataField="PrecioCompra" HeaderText="Precio Compra" />
                    <asp:BoundField DataField="PrecioVenta" HeaderText="Precio Venta" />

                    <asp:TemplateField HeaderText="Ganancia">
                        <ItemTemplate>
                            <span class="text-subtle"> <%# Eval("Ganancia") %>% </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Marca">
                        <ItemTemplate>
                            <span class="text-subtle"><%# Eval("Marca.Nombre") %></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Categoria">
                        <ItemTemplate>
                            <span class="text-subtle"><%# Eval("Categoria.Nombre") %></span>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <div class="actions flex justify-left gap-4">

                                <!-- Botón Editar -->
                                <asp:LinkButton ID="btnEditar" runat="server" CommandName="Editar" CommandArgument='<%# Eval("Id") %>' CausesValidation="false" CssClass="material-icons-outlined">
                                    edit
                                </asp:LinkButton>

                                <!-- Botón Eliminar -->
                                <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' CausesValidation="false" OnClientClick="return confirm('Estás seguro de eliminar este producto?');" CssClass="material-icons-outlined text-red-500">
                                    delete
                                </asp:LinkButton>

                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
        <div class="bg-[#1e1e1e] border border-gray-800 rounded-xl shadow-md overflow-hidden">
        </div>
    </main>
</asp:Content>
