<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="Comercio.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ABML - Marcas
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main class="flex-grow container mx-auto px-6 py-10 flex flex-col justify-center text-center">
        <div class="flex justify-between items-center mb-6">
            <h1 class="text-3xl font-bold">Gestión de Productos</h1>
            <asp:Label ID="lblMessageCat" runat="server" CssClass="text-green-400 font-medium" />
            <asp:Label ID="lblMessage2" runat="server" CssClass="text-red-400 font-medium" />
            <asp:Button ID="btnAgregaMarca" runat="server" CssClass="bg-green-600 hover:bg-green-700 text-white font-semibold px-5 py-2 rounded-lg transition" Text="Agregar Marca" />

        </div>

        <div class="bg-[#1f2937] rounded-lg shadow-md p-6 mb-8 text-left space-y-6">
            <div>
                <label for="txtNombreMarca" class="block mb-1 font-medium">Nombre Marca</label>
                <asp:TextBox ID="txtNombreMarca" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                <asp:RequiredFieldValidator ID="rfvNombreMarca" runat="server" ControlToValidate="txtNombreMarca" ErrorMessage="La marca del producto es obligatorio." CssClass="text-red-400 text-sm" Display="Dynamic" />
            </div>
        </div>

        <div class="overflow-y-auto max-h-96">
            <asp:GridView ID="gvMarcas" runat="server" AutoGenerateColumns="False" CssClass="grid-dark" ShowHeaderWhenEmpty="True" EmptyDataText="No hay Marcas registradas.">
                <Columns>


                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />

                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <div class="actions flex justify-left gap-4">
                                <button aria-label="Editar producto" class="material-icons-outlined">edit</button>
                                <button aria-label="Eliminar producto" class="material-icons-outlined">delete</button>
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
