<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Facturacion.aspx.cs" Inherits="Comercio.Facturacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/2.5.1/jspdf.umd.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf-autotable/3.5.25/jspdf.plugin.autotable.min.js"></script>

    <main class="flex-grow container mx-auto px-6 py-10 flex flex-col justify-center text-center">
        <div class="flex justify-between items-center mb-6">
            <h1 class="text-3xl font-bold">Facturacion</h1>
            <asp:Label ID="lblMessage" runat="server" CssClass="text-green-400 font-medium" />
            <div>
                <asp:Button ID="btnListar" runat="server" CssClass="bg-green-600 hover:bg-green-700 text-white font-semibold px-5 py-2 rounded-lg transition" OnClick="btnListar_Click" Text="Listar todo" />
                <asp:Button ID="btnBuscarNombre" runat="server" CssClass="bg-green-600 hover:bg-green-700 text-white font-semibold px-5 py-2 rounded-lg transition" OnClick="btnBuscarNombre_Click" Text="Buscar por Nombre" />
                <asp:Button ID="btnBuscar" runat="server" CssClass="bg-green-600 hover:bg-green-700 text-white font-semibold px-5 py-2 rounded-lg transition" OnClick="btnBuscar_Click" Text="Buscar Por Fecha" />

                <script>
                    const detalles = <%= JsonDetalles %>;
                    function generarPDF() {
                        const { jsPDF } = window.jspdf;
                        const doc = new jsPDF();

                        doc.setFontSize(18);
                        doc.text("Factura de Venta", 14, 20);

                        doc.setFontSize(12);
                        doc.text("Fecha: " + new Date().toLocaleDateString(), 14, 30);

                        //datos tb
                        let body = detalles.map(d => [
                            d.Producto.Nombre,
                            d.Cantidad,
                            d.PrecioUnitario,
                            (d.Cantidad * d.PrecioUnitario).toFixed(2)
                        ]);

                        doc.autoTable({
                            head: [['Producto', 'Cantidad', 'Precio', 'Subtotal']],
                            body: body,
                            startY: 40
                        });

                        // total
                        let total = body.reduce((acc, x) => acc + parseFloat(x[3]), 0);
                        doc.text("TOTAL: $" + total.toFixed(2), 14, doc.lastAutoTable.finalY + 15);

                        doc.save("Factura_" + numeroFactura + "pdf");
                    }
                </script>

            </div>
        </div>

        <div class="bg-[#1f2937] rounded-lg shadow-md p-6 mb-8 text-left space-y-6">
            <div class="grid grid-cols-3 md:grid-cols-3 gap-6 items-end">

                <div class="relative w-full">
                    <label for="">Buscar Factura</label>
                    <label class="material-icons-outlined absolute left-3 top-1/2 -translate-y-1/8">search</label>
                    <asp:TextBox ID="txtFactura" runat="server" placeholder="Nº de factura..." CssClass="w-full pl-12 pr-4 py-2 bg-gray-900 border border-gray-700 rounded-md text-white focus:ring-primary focus:border-primary" />
                </div>

                <div>
                    <label for="txtFechaDesde">Fecha Desde</label>
                    <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500 text-gray-100" TextMode="Date" Text='<%# DateTime.Now.ToString("dd/MM/yyyy") %>' min="1900-01-01" max="2100-12-31"></asp:TextBox>
                </div>

                <div>
                    <label for="txtFechaHasta">Fecha Hasta</label>
                    <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="w-full bg-[#111827] border border-gray-700 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-red-500 text-gray-100" TextMode="Date" Text='<%# DateTime.Now.ToString("dd/MM/yyyy") %>' min="1900-01-01" max="2100-12-31"></asp:TextBox>
                </div>

            </div>
        </div>

        <div class="overflow-y-auto max-h-96">
            <asp:GridView ID="gvFacturas" runat="server" AutoGenerateColumns="False" CssClass="grid-dark" ShowHeaderWhenEmpty="True" EmptyDataText="No hay Ventas registradas.">
                <Columns>

                    <asp:BoundField DataField="NumeroFactura" HeaderText="NumeroFactura" />
                    <asp:BoundField DataField="DetallesCliente.Nombre" HeaderText="Cliente" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="Total" HeaderText="Total" />

                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <div class="actions flex justify-left gap-4">

                                <!-- Botón Editar -->
                                <asp:LinkButton ID="btnImprimir" runat="server" CommandName="Imprimir" CommandArgument='<%# Eval("NumeroFactura") %>' CausesValidation="false" CssClass="material-icons-outlined">
                                    print
                                </asp:LinkButton>

                                <!-- Botón Eliminar -->
                                <asp:LinkButton ID="btnPDF" runat="server" CommandName="PDF" CommandArgument='<%# Eval("NumeroFactura") %>' OnClick="btnPDF_Click" CausesValidation="false" CssClass="material-icons-outlined text-red-500">
                                    picture_as_pdf
                                </asp:LinkButton>

                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </main>
</asp:Content>
