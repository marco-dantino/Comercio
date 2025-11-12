<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Comercio.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ABLM - Usuarios
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
             <main class="flex-grow container mx-auto px-6 py-10 flex flex-col justify-center text-center">
     <div class="flex justify-between items-center mb-6">
         <h1 class="text-3xl font-bold">Gestión de Usuarios</h1>
         <asp:Label ID="lblMessage" runat="server" CssClass="text-green-400 font-medium" />
         <asp:Label ID="lblMessage2" runat="server" CssClass="text-red-400 font-medium" />
         <asp:Button ID="btnAgregaProveedor" runat="server" CssClass="bg-green-600 hover:bg-green-700 text-white font-semibold px-5 py-2 rounded-lg transition" Text="Agregar Proveedor" />

     </div>

     <div class="bg-[#1f2937] rounded-lg shadow-md p-6 mb-8 text-left space-y-6">
         <div class="grid md:grid-cols-3 gap-6">

             <div>
                 <label for="txtNombreProveedor" class="block mb-1 font-medium">Nombre</label>
                 <asp:TextBox ID="txtNombreProveedor" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                 <asp:RequiredFieldValidator ID="rfvNombreProveedor" runat="server" ControlToValidate="txtNombreProveedor" ErrorMessage="El nombre del Proveedor es obligatorio." CssClass="text-red-400 text-sm" Display="Dynamic" />
             </div>

             <div>
                 <label for="txtDireccion" class="block mb-1 font-medium">Direccion Actual</label>
                 <asp:TextBox ID="txtDireccion" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                 <asp:RequiredFieldValidator ID="rfvDireccionProveedor" runat="server" ControlToValidate="txtDireccion" ErrorMessage="La direccion es obligatoria." CssClass="text-red-400 text-sm" Display="Dynamic" />
                 <asp:RegularExpressionValidator ID="revDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Debe ser un número entero positivo." CssClass="text-red-400 text-sm" Display="Dynamic" ValidationExpression="^\d+$" />
             </div>

             <div>
                 <label for="txtEmail" class="block mb-1 font-medium">E-mail</label>
                 <asp:TextBox ID="txtEmail" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                 <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Campo obligatorio." CssClass="text-red-400 text-sm" Display="Dynamic" />
                 <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email inválido." CssClass="text-red-400 text-sm" Display="Dynamic" ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$" />
             </div>

            <div>
                <label for="ddlRol" class="block mb-1 font-medium">Rol</label>
                <asp:DropDownList ID="ddlRol" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500 text-gray-100"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvRol" runat="server" ControlToValidate="ddlRol" InitialValue="" ErrorMessage="El Rol es requerido." CssClass="text-red-400 text-sm" Display="Dynamic" />
            </div>

            <div>
                <label for="txtPassword" class="block mb-1 font-medium">Contraseña</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="La contraseña es requerida." CssClass="text-red-400 text-sm" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="La contraseña debe tener al menos 8 caracteres, una mayúscula, una minúscula, un número y un símbolo." CssClass="text-red-400 text-sm" Display="Dynamic" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&.,;:_\-])[A-Za-z\d@$!%*?&.,;:_\-]{8,}$" />
            </div>

         </div>
     </div>

     <div class="overflow-y-auto max-h-96">
         <asp:GridView ID="gvProveedors" runat="server" AutoGenerateColumns="False" CssClass="grid-dark" ShowHeaderWhenEmpty="True" EmptyDataText="No hay Proveedors registrados.">
             <Columns>

                 <asp:TemplateField HeaderText="Imagen">
                     <ItemTemplate>
                         <img src='<%# Eval("Imagen") %>'
                             alt="Imagen del Proveedor"
                             class="h-12 w-12 object-cover rounded-md border border-gray-700" />
                     </ItemTemplate>
                 </asp:TemplateField>

                 <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                 <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                 <asp:BoundField DataField="email" HeaderText="E-mail" />
                 <asp:BoundField DataField="id_rol" HeaderText="Rol" />
                 <asp:BoundField DataField="password" HeaderText="contraseña" />

                 <asp:TemplateField HeaderText="Acciones">
                     <ItemTemplate>
                         <div class="actions flex justify-left gap-4">
                             <button aria-label="Editar Proveedor" class="material-icons-outlined">edit</button>
                             <button aria-label="Eliminar Proveedor" class="material-icons-outlined">delete</button>
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
