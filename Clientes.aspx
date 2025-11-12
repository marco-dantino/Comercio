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
         <asp:Button ID="btnAgregaCliente" runat="server" CssClass="bg-green-600 hover:bg-green-700 text-white font-semibold px-5 py-2 rounded-lg transition" Text="Agregar Cliente" />

     </div>

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
                 <label for="txtApellidoCliente" class="block mb-1 font-medium">Apellido</label>
                 <asp:TextBox ID="txtApellidoCliente" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                 <asp:RequiredFieldValidator ID="rfvApellidoCliente" runat="server" ControlToValidate="txtApellidoCliente" ErrorMessage="El Apellido del Cliente es obligatorio." CssClass="text-red-400 text-sm" Display="Dynamic" />
             </div>

             <div>
                 <label for="txtDireccion" class="block mb-1 font-medium">Direccion Actual</label>
                 <asp:TextBox ID="txtDireccion" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                 <asp:RequiredFieldValidator ID="rfvDireccionCliente" runat="server" ControlToValidate="txtDireccion" ErrorMessage="La direccion es obligatoria." CssClass="text-red-400 text-sm" Display="Dynamic" />
                 <asp:RegularExpressionValidator ID="revDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Debe ser un número entero positivo." CssClass="text-red-400 text-sm" Display="Dynamic" ValidationExpression="^\d+$" />
             </div>

             <div>
                 <label for="txtTelefono" class="block mb-1 font-medium">Teléfono</label>
                 <asp:TextBox ID="txtTelefono" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                 <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="El precio unitario es obligatorio." CssClass="text-red-400 text-sm" Display="Dynamic" />
                 <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Debe ser un número válido." CssClass="text-red-400 text-sm" Display="Dynamic" />
             </div>

             <div>
                 <label for="txtEmail" class="block mb-1 font-medium">E-mail</label>
                 <asp:TextBox ID="txtEmail" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                 <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Campo obligatorio." CssClass="text-red-400 text-sm" Display="Dynamic" />
                 <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email inválido." CssClass="text-red-400 text-sm" Display="Dynamic" ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$" />
             </div>

         </div>
     </div>

     <div class="overflow-y-auto max-h-96">
         <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" CssClass="grid-dark" ShowHeaderWhenEmpty="True" EmptyDataText="No hay Clientes registrados.">
             <Columns>

                 <asp:TemplateField HeaderText="Imagen">
                     <ItemTemplate>
                         <img src='<%# Eval("Imagen") %>'
                             alt="Imagen del Cliente"
                             class="h-12 w-12 object-cover rounded-md border border-gray-700" />
                     </ItemTemplate>
                 </asp:TemplateField>

                 <asp:BoundField DataField="dni" HeaderText="DNI" />
                 <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                 <asp:BoundField DataField="direccion" HeaderText="Dirección" />
                 <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                 <asp:BoundField DataField="email" HeaderText="E-mail" />

                 <asp:TemplateField HeaderText="Acciones">
                     <ItemTemplate>
                         <div class="actions flex justify-left gap-4">
                             <button aria-label="Editar Cliente" class="material-icons-outlined">edit</button>
                             <button aria-label="Eliminar Cliente" class="material-icons-outlined">delete</button>
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
