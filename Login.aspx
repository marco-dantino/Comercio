<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Comercio.Login" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Iniciar Sesión - Sistema de Gestión</title>

    <!-- Tailwind + Google Fonts -->
    <script src="https://cdn.tailwindcss.com"></script>
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;600;700&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined" rel="stylesheet">

    <script>
        tailwind.config = {
            theme: {
                extend: {
                    colors: { primary: "#137fec" },
                    fontFamily: { sans: ["Inter", "sans-serif"] }
                }
            }
        }
    </script>
</head>

<body class="font-sans bg-gray-100">
    <div class="min-h-screen grid md:grid-cols-2">
        
        <!-- division izquierda -->
        <div class="hidden md:flex flex-col justify-center items-center bg-primary text-white relative">
            <div class="absolute inset-0 bg-[url('https://lh3.googleusercontent.com/aida-public/AB6AXuBPtcXPiQi2ffdb1LIm__rjLH6RN0fFwgioFmAOIJEtKpPGjtkTd3KJpKmYAu6koiWhHMiyLOUmHOtp9DGxO653o_hMaPN1HndXdoxAnIrQoriOiF7MoFkFG-V3ntZAs9gSOCwEzZO8gv8WRPEgrLxf78Mv1fBMmajYp8lqpgqS4_AAPhqZtF-Ezf_fmD6e2tOxDCTbXxYqJpvS66ABOy6P9sK2fKiwc2EIGs-SubgOv_d6gjnk9kWYfB-b6fEWTgnrzp2M5Ciihrh7')] bg-cover bg-center opacity-30"></div>
            <div class="relative z-10 text-center px-6">
                <div class="flex justify-center mb-6">
                    <span class="material-symbols-outlined text-5xl bg-white/20 p-4 rounded-full">store</span>
                </div>
                <h1 class="text-3xl font-bold">Sistema de Compras y Ventas</h1>
                <p class="mt-2 text-white/80">Gestión simplificada para tu negocio.</p>
            </div>
        </div>

        <!-- division derecha -->
        <div class="flex justify-center items-center p-8">
            <div class="w-full max-w-md bg-white rounded-lg shadow-md border border-gray-400 p-8 space-y-6">
                <div>
                    <h2 class="text-3xl font-bold text-gray-900">Iniciar Sesión</h2>
                    <p class="text-gray-500">Bienvenido al Sistema de Gestión</p>
                </div>

                <form runat="server" class="space-y-5">
                    <div>
                        <label class="block text-gray-700 font-medium mb-1">Usuario</label>
                        <div class="relative">
                            <span class="material-symbols-outlined absolute left-3 top-1/2 -translate-y-1/2 text-gray-400">person</span>
                            <input runat="server" id="txtUsuario" class="w-full pl-10 pr-3 py-3 border rounded-lg focus:ring-2 focus:ring-primary focus:outline-none" placeholder="Correo electrónico" />
                        </div>
                    </div>

                    <div>
                        <label class="block text-gray-700 font-medium mb-1">Contraseña</label>
                        <div class="relative">
                            <span class="material-symbols-outlined absolute left-3 top-1/2 -translate-y-1/2 text-gray-400">lock</span>
                            <input runat="server" id="txtClave" type="password" class="w-full pl-10 pr-10 py-3 border rounded-lg focus:ring-2 focus:ring-primary focus:outline-none" placeholder="Contraseña" />
                        </div>
                    </div>

                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar"
                        CssClass="w-full bg-primary text-white font-semibold py-3 rounded-lg hover:bg-blue-600 transition" />
                </form>
            </div>
        </div>
    </div>
</body>
</html>

