<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="Comercio.Categorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Categorias - ABML
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main class="flex-grow container mx-auto px-6 py-10 flex flex-col justify-center text-center">
        <div class="flex justify-between items-center mb-6">
            <h1 class="text-3xl font-bold">Gestión de Productos</h1>
            <asp:Label ID="lblMessage" runat="server" CssClass="text-green-400 font-medium" />
            <asp:Label ID="lblMessage2" runat="server" CssClass="text-red-400 font-medium" />
            <asp:Button ID="btnAgregaCategoria" runat="server" OnClick="btnAgregaCategoria_Click" CssClass="bg-green-600 hover:bg-green-700 text-white font-semibold px-5 py-2 rounded-lg transition" Text="Agregar Categoria" />

        </div>

        <div class="bg-[#1f2937] rounded-lg shadow-md p-6 mb-8 text-left space-y-6">
            <div>
                <label for="txtNombreCategoria" class="block mb-1 font-medium">Nombre Categoria</label>
                <asp:TextBox ID="txtNombreCategoria" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500" />
                <asp:RequiredFieldValidator ID="rfvNombreCategoria" runat="server" ControlToValidate="txtNombreCategoria" ErrorMessage="La categoria del producto es obligatorio." CssClass="text-red-400 text-sm" Display="Dynamic" />
            </div>
        </div>

        <asp:Panel ID="panelEdit" runat="server" CssClass="fixed inset-0 bg-black/50 backdrop-blur-sm flex items-center justify-center z-40" Visible="false">
            <div class="bg-gray-900 p-6 rounded-lg shadow-xl w-full max-w-md relative z-50">
                <h3 class="text-xl font-semibold mb-4 text-white">Editar Categoria</h3>

                <label for="txtNombreEdit">Nombre</label>
                <asp:TextBox ID="txtNombreEdit" runat="server" CssClass="w-full mb-3 p-2 rounded text-black" />

                <div class="flex justify-end gap-3 mt-4">
                    <asp:Button ID="btnCerrarModal" runat="server" Text="Cancelar" CssClass="px-4 py-2 bg-gray-600 hover:bg-gray-700 text-white rounded" CausesValidation="false" OnClick="btnCerrarModal_Click" />
                    <asp:Button ID="btnGuardarCategoria" runat="server" Text="Guardar cambios" CssClass="px-4 py-2 bg-blue-600 hover:bg-blue-700 text-white rounded" CausesValidation="false" OnClick="btnGuardarCategoria_Click" />
                </div>
            </div>
        </asp:Panel>

        <div class="overflow-y-auto max-h-96">
            <asp:GridView ID="gvCategorias" runat="server" OnRowCommand="gvCategorias_RowCommand" AutoGenerateColumns="False" CssClass="grid-dark table-fixed w-full" ShowHeaderWhenEmpty="True" EmptyDataText="No hay Categorias registradas.">
                <Columns>

                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />

                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <div class="actions flex justify-left gap-4">

                                <!-- Botón Editar -->
                                <asp:LinkButton ID="btnEditar" runat="server" CommandName="Editar" CommandArgument='<%# Eval("Id") %>' CausesValidation="false" CssClass="material-icons-outlined">
                                    edit
                                </asp:LinkButton>

                                <!-- Botón Eliminar -->
                                <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' CausesValidation="false" OnClientClick="return confirm('Estás seguro de eliminar esta Categoria?');" CssClass="material-icons-outlined text-red-500">
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
