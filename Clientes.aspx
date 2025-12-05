<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Comercio.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ABML - Clientes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <main class="flex-grow container mx-auto px-6 py-10 flex flex-col justify-center text-center">
     <div class="flex justify-between items-center mb-6">
         <h1 class="text-3xl font-bold">Gestión de Clientes</h1>
         <asp:Label ID="lblMessage" runat="server" CssClass="text-green-400 font-medium" />
         <asp:Label ID="lblMessage2" runat="server" CssClass="text-red-400 font-medium" />
         <%if (UsuarioEsAdmin){%>
         <asp:Button ID="btnAgregaCliente" runat="server" OnClick="btnAgregaCliente_Click" CssClass="bg-green-600 hover:bg-green-700 text-white font-semibold px-5 py-2 rounded-lg transition" Text="Agregar Cliente" />
         <%}%>
     </div>

         <%if (UsuarioEsAdmin){%>
     <div class="bg-[#1f2937] rounded-lg shadow-md p-6 mb-8 text-left space-y-6">
         <div class="grid md:grid-cols-3 gap-6">

             <div>
                 <label for="txtDniCliente" class="block mb-1 font-medium">DNI</label>
                 <asp:TextBox ID="txtDniCliente" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                 <asp:RequiredFieldValidator ID="rfvDniCliente" runat="server" ControlToValidate="txtDniCliente" ErrorMessage="El DNI del Cliente es obligatorio." CssClass="text-red-400 text-sm" Display="Dynamic" ValidationExpression="^\d+$"/>
             </div>

             <div>
                 <label for="txtNombreCliente" class="block mb-1 font-medium">Nombre</label>
                 <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                 <asp:RequiredFieldValidator ID="rfvNombreCliente" runat="server" ControlToValidate="txtNombreCliente" ErrorMessage="El nombre del Cliente es obligatorio." CssClass="text-red-400 text-sm" Display="Dynamic" />
             </div>

             <div>
                 <label for="txtDireccion" class="block mb-1 font-medium">Direccion Actual</label>
                 <asp:TextBox ID="txtDireccion" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                 <asp:RequiredFieldValidator ID="rfvDireccionCliente" runat="server" ControlToValidate="txtDireccion" ErrorMessage="La direccion es obligatoria." CssClass="text-red-400 text-sm" Display="Dynamic" />
             </div>

             <div>
                 <label for="txtTelefono" class="block mb-1 font-medium">Teléfono</label>
                 <asp:TextBox ID="txtTelefono" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                 <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="El telefono es obligatorio." CssClass="text-red-400 text-sm" Display="Dynamic" />
             </div>

             <div>
                 <label for="txtEmail" class="block mb-1 font-medium">E-mail</label>
                 <asp:TextBox ID="txtEmail" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                 <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Campo obligatorio." CssClass="text-red-400 text-sm" Display="Dynamic" />
                 <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email inválido." CssClass="text-red-400 text-sm" Display="Dynamic" ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$" />
             </div>

         </div>
     </div>
         <%}%>

        <asp:Panel ID="panelEdit" runat="server" CssClass="fixed inset-0 bg-black/50 backdrop-blur-sm flex items-center justify-center z-40" Visible="false">
            <div class="bg-gray-900 p-6 rounded-lg shadow-xl w-full max-w-md relative z-50">
                <h3 class="text-xl font-semibold mb-4 text-white">Editar Usuario</h3>

                <label for="txtDniEdit">DNI</label>
                <asp:TextBox ID="txtDniEdit" runat="server" CssClass="w-full mb-3 p-2 rounded text-black" />
                <label for="txtNombreEdit">Nombre</label>
                <asp:TextBox ID="txtNombreEdit" runat="server" CssClass="w-full mb-3 p-2 rounded text-black" />
                <label for="txtEmailEdit">E-mail</label>
                <label for="txtDireccion">Direccion</label>
                <asp:TextBox ID="txtDireccionEdit" runat="server" CssClass="w-full mb-3 p-2 rounded text-black" />
                <label for="txtTelefonoEdit">Telefono</label>
                <asp:TextBox ID="txtTelefonoEdit" runat="server" CssClass="w-full mb-3 p-2 rounded text-black" />
                <label for="txtEmailEdit">E-mail</label>
                <asp:TextBox ID="txtEmailEdit" runat="server" CssClass="w-full mb-3 p-2 rounded text-black" />

                <div class="flex justify-end gap-3 mt-4">
                    <asp:Button ID="btnCerrarModal" runat="server" Text="Cancelar" CssClass="px-4 py-2 bg-gray-600 hover:bg-gray-700 text-white rounded" CausesValidation="false" OnClick="btnCerrarModal_Click" />
                    <asp:Button ID="btnGuardarCliente" runat="server" Text="Guardar cambios" CssClass="px-4 py-2 bg-blue-600 hover:bg-blue-700 text-white rounded" CausesValidation="false" OnClick="btnGuardarCliente_Click" />
                </div>
            </div>
        </asp:Panel>

     <div class="overflow-y-auto max-h-96">
         <asp:GridView ID="gvCliente" runat="server" OnRowCommand="gvClientes_RowCommand" AutoGenerateColumns="False" CssClass="grid-dark" ShowHeaderWhenEmpty="True" EmptyDataText="No hay Clientes registrados.">
             <Columns>

                 <asp:BoundField DataField="dni" HeaderText="DNI" />
                 <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                 <asp:BoundField DataField="direccion" HeaderText="Dirección" />
                 <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                 <asp:BoundField DataField="email" HeaderText="E-mail" />

                 <asp:TemplateField HeaderText="Acciones">
                     <ItemTemplate>
                            <div class="actions flex justify-left gap-4">

                                <!-- Botón Editar -->
                                <asp:LinkButton ID="btnEditar" runat="server" CommandName="Editar" CommandArgument='<%# Eval("Id") %>' CausesValidation="false" CssClass="material-icons-outlined">
                                    edit
                                </asp:LinkButton>

                                <!-- Botón Eliminar -->
                                <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' CausesValidation="false" OnClientClick="return confirm('Estás seguro de eliminar este Proveedor?');" CssClass="material-icons-outlined text-red-500">
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
