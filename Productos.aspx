<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Comercio.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Productos - ABML
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main class="flex-grow container mx-auto px-6 py-10 flex flex-col justify-center text-center">
        <div class="flex justify-between items-center mb-6">
            <h1 class="text-3xl font-bold">Gestión de Productos</h1>
            <button class="bg-primary hover:bg-red-500 text-white font-semibold py-2 px-4 rounded-lg flex items-center gap-2 transition">
                <span class="material-icons-outlined">add</span>
                <span>Agregar Producto</span>
            </button>
        </div>

        <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="10" CssClass="grid-dark">
            <Columns>

                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="stock_actual" HeaderText="Stock" />
                <asp:BoundField DataField="precio_unitario" HeaderText="Precio" />
                <asp:BoundField DataField="ganancia" HeaderText="Ganancia" />
                <asp:TemplateField HeaderText="Marca">
                    <ItemTemplate>
                        <span class="text-subtle"><%# Eval("Marca") %></span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Categoria">
                    <ItemTemplate>
                        <span class="text-subtle"><%# Eval("Categoria") %></span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <div class="actions flex justify-center gap-4">
                            <button aria-label="Editar producto" class="material-icons-outlined">edit</button>
                            <button aria-label="Eliminar producto" class="material-icons-outlined">delete</button>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
        <div class="bg-[#1e1e1e] border border-gray-800 rounded-xl shadow-md overflow-hidden">
        </div>
    </main>
</asp:Content>
