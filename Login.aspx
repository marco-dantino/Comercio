<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Comercio.Login" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Iniciar Sesión - Sistema de Gestión</title>

    <script src="https://cdn.tailwindcss.com"></script>
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;600;800&display=swap" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined" rel="stylesheet" />

    <style>
        body {
            font-family: 'Inter', sans-serif;
        }
    </style>
</head>

<body class="bg-black text-gray-100">

    <div class="grid min-h-screen md:grid-cols-2">

        <!-- Panel Izquierdo -->
        <div class="hidden md:flex flex-col justify-center items-center bg-black relative">
            <div class="absolute inset-0 bg-[url('https://lh3.googleusercontent.com/aida-public/AB6AXuBPtcXPiQi2ffdb1LIm__rjLH6RN0fFwgioFmAOIJEtKpPGjtkTd3KJpKmYAu6koiWhHMiyLOUmHOtp9DGxO653o_hMaPN1HndXdoxAnIrQoriOiF7MoFkFG-V3ntZAs9gSOCwEzZO8gv8WRPEgrLxf78Mv1fBMmajYp8lqpgqS4_AAPhqZtF-Ezf_fmD6e2tOxDCTbXxYqJpvS66ABOy6P9sK2fKiwc2EIGs-SubgOv_d6gjnk9kWYfB-b6fEWTgnrzp2M5Ciihrh7')] bg-cover bg-center opacity-10"></div>
            <div class="relative z-10 text-center px-6">
                <div class="flex justify-center mb-6">
                    <span class="material-symbols-outlined text-red-500 text-5xl bg-white/10 p-4 rounded-full border border-red-500/30">store</span>
                </div>
                <h1 class="text-3xl font-bold">Sistema de Compras y Ventas</h1>
                <p class="mt-2 text-gray-400">Gestión simplificada para tu negocio.</p>
            </div>
        </div>

        <!-- Panel Derecho -->
        <div class="flex items-center justify-center p-8 bg-black">
            <div class="w-full max-w-md border border-gray-800 rounded-xl p-8 shadow-xl space-y-6">
                <div>
                    <h2 class="text-3xl font-bold">Iniciar Sesión</h2>
                    <p class="text-gray-400 text-sm">Bienvenido al Sistema de Gestión</p>
                </div>

                <form runat="server" class="space-y-5">
                    <div>
                        <label class="block text-sm font-medium mb-2">Usuario</label>
                        <div class="relative">
                            <span class="material-symbols-outlined absolute left-3 top-1/2 -translate-y-1/2 text-gray-500">person</span>
                            <input runat="server" id="txtUsuario" type="text" placeholder="Correo electrónico"
                                class="w-full pl-10 pr-3 py-3 bg-gray-800 border border-gray-700 rounded-lg text-gray-100 focus:ring-2 focus:ring-red-600 placeholder:text-gray-500 focus:outline-none" />
                        </div>
                    </div>

                    <div>
                        <label class="block text-sm font-medium mb-2">Contraseña</label>
                        <div class="relative">
                            <span class="material-symbols-outlined absolute left-3 top-1/2 -translate-y-1/2 text-gray-500">lock</span>
                            <input runat="server" id="txtClave" type="password" placeholder="Contraseña" class="w-full pl-10 pr-10 py-3 bg-gray-800 border border-gray-700 rounded-lg text-gray-100 focus:ring-2 focus:ring-red-600 placeholder:text-gray-500 focus:outline-none" />
                        </div>
                    </div>

                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="w-full bg-red-600 hover:bg-red-700 text-white font-semibold py-3 rounded-lg transition" />
                </form>

                <p class="text-center text-sm text-gray-400">
                    ¿No tienes una cuenta?
          <a href="#" class="text-red-500 hover:underline">Regístrate aquí</a>
                </p>
            </div>
        </div>

    </div>
</body>
</html>
