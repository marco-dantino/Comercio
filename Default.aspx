<%@ Page Title="Gestión multriproposito - Bienvenida" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Comercio._Default" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">
    Gestión multriproposito - Bienvenida
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="flex-grow container mx-auto px-6 py-16 flex flex-col items-center justify-center text-center">
    <div class="max-w-7xl mx-auto text-center">
        <h2 class="text-3xl sm:text-4xl font-semibold text-slate-300 mb-12">Bienvenido de nuevo</h2>
        <div class="grid grid-cols-1 md:grid-cols-3 gap-6 lg:gap-8">
            <%if (UsuarioEsAdmin){%>
            <a class="group block p-6 sm:p-8 bg-gradient-to-r from-gray-700 to-gray-900 border border-slate-700 rounded-xl shadow-lg hover:shadow-2xl transition-transform transform hover:scale-105" href="GestionarCompra.aspx">
                <div class="flex justify-center mb-4">
                    <span class="material-icons-outlined text-primary text-5xl sm:text-6xl">
                        shopping_cart
                    </span>
                </div>
                <h3 class="text-xl font-bold text-white mb-2 text-center">Gestionar Compras</h3>
                <p class="text-sm text-slate-400">
                    Registra nuevas compras y administra tus proveedores.
                </p>
            </a>
            <%} else { %>
            <a class="group block p-6 sm:p-8 bg-gradient-to-r from-gray-700 to-gray-900 border border-slate-700 rounded-xl shadow-lg hover:shadow-2xl transition-transform transform hover:scale-105">
                <div class="flex justify-center mb-4">
                        <span class="material-icons-outlined text-primary text-5xl sm:text-6xl">
                            person
                        </span>
                </div>
                <h3 class="text-xl font-bold text-white mb-2 text-center">¡Bienvenido!</h3>
                <p class="text-sm text-slate-400 text-center">
                    <%= NombreUsuario %>
                </p>
            </a>
            <%}%>
            
            <a class="group block p-6 sm:p-8 bg-gradient-to-r from-gray-700 to-gray-900 border border-slate-700 rounded-xl shadow-lg hover:shadow-2xl transition-transform transform hover:scale-105" href="GestionarVenta.aspx">
                <div class="flex justify-center mb-4">
                    <span class="material-icons-outlined text-primary text-5xl sm:text-6xl">
                        sell
                    </span>
                </div>
                <h3 class="text-xl font-bold text-white mb-2 text-center">Gestionar Ventas</h3>
                <p class="text-sm text-slate-400">
                    Crea nuevas ventas, gestiona clientes y productos.
                </p>
            </a>

            <a class="group block p-6 sm:p-8 bg-gradient-to-r from-gray-700 to-gray-900 border border-slate-700 rounded-xl shadow-lg hover:shadow-2xl transition-transform transform hover:scale-105" href="Facturacion.aspx">
                <div class="flex justify-center mb-4">
                    <span class="material-icons-outlined text-primary text-5xl sm:text-6xl">
                        receipt_long
                    </span>
                </div>
                <h3 class="text-xl font-bold text-white mb-2 text-center">Ver Facturación</h3>
                <p class="text-sm text-slate-400">
                    Consulta y exporta los informes de facturación.
                </p>
            </a>
        </div>
    </div>
    </main>
    
</asp:Content>
