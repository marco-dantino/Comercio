using ComercioDomain;
using ComercioService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Creador funciones de activo y no activo, listar segun si estan activos.

namespace ComercioClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceProducto serviceProducto = new ServiceProducto();
            ServiceCliente serviceCliente = new ServiceCliente();
            ServiceProveedor serviceProveedor = new ServiceProveedor();

            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("===== ADMINISTRACIÓN COMERCIAL =====");
                Console.WriteLine("1 - Administracion de Productos");
                Console.WriteLine("2 - Administracion de Clientes");
                Console.WriteLine("3 - Administracion de Proveedores");
                Console.WriteLine("0 - Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        menuProductos(serviceProducto);
                        break;
                    case "2":
                        menuClientes(serviceCliente);
                        break;
                    case "3":
                        menuProveedores(serviceProveedor);
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("INVALIDO");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione una tecla...");
                    Console.ReadKey();
                }
            }
        }

        static void menuProductos(ServiceProducto serviceProducto) 
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("===== ADMINISTRACIÓN DE PRODUCTOS =====");
                Console.WriteLine("1 - Listar productos");
                Console.WriteLine("2 - Agregar producto");
                Console.WriteLine("3 - Modificar producto");
                Console.WriteLine("4 - Eliminar producto");
                Console.WriteLine("0 - Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        listarProducto(serviceProducto);
                        break;
                    case "2":
                        agregarProducto(serviceProducto);
                        break;
                    case "3":
                        modificarProducto(serviceProducto);
                        break;
                    case "4":
                        eliminarProducto(serviceProducto);
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione una tecla...");
                    Console.ReadKey();
                }
            }
        }

        static void menuClientes(ServiceCliente serviceCliente)
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("===== ADMINISTRACIÓN DE CLIENTES =====");
                Console.WriteLine("1 - Listar");
                Console.WriteLine("2 - Agregar");
                Console.WriteLine("3 - Modificar");
                Console.WriteLine("4 - Eliminar");
                Console.WriteLine("0 - Volver");
                Console.Write("Opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": 
                        listarCliente(serviceCliente); 
                        break;
                    case "2": 
                        agregarCliente(serviceCliente); 
                        break;
                    case "3": 
                        modificarCliente(serviceCliente); 
                        break;
                    case "4": 
                        eliminarCliente(serviceCliente); 
                        break;
                    case "0": 
                        volver = true; break;
                    default: Console.WriteLine("INVALIDO"); break;
                }

                if (!volver)
                {
                    Console.WriteLine("\nPresione una tecla...");
                    Console.ReadKey();
                }
            }
        }

        static void menuProveedores(ServiceProveedor serviceProveedor)
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("===== ADMINISTRACIÓN DE PROVEEDORES =====");
                Console.WriteLine("1 - Listar");
                Console.WriteLine("2 - Agregar");
                Console.WriteLine("3 - Modificar");
                Console.WriteLine("4 - Eliminar");
                Console.WriteLine("0 - Volver");
                Console.Write("Opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        listarProveedor(serviceProveedor);
                        break;
                    case "2":
                        agregarProveedor(serviceProveedor);
                        break;
                    case "3":
                        modificarProveedor(serviceProveedor);
                        break;
                    case "4":
                        eliminarProveedor(serviceProveedor);
                        break;
                    case "0":
                        volver = true; break;
                    default: Console.WriteLine("INVALIDO"); break;
                }

                if (!volver)
                {
                    Console.WriteLine("\nPresione una tecla...");
                    Console.ReadKey();
                }
            }
        }

        static void listarProducto(ServiceProducto service)
        {
            List<Producto> lista = service.listar();
            Console.WriteLine("\n--- LISTA DE PRODUCTOS ---");
            foreach (var p in lista)
            {
                Console.WriteLine($"ID: {p.Id} | {p.Nombre} | Stock: {p.StockActual} | Precio compra: {p.PrecioCompra} | %Ganancia: {p.Ganancia} | Marca: {p.Marca.Nombre} | Categoría: {p.Categoria.Nombre} | ImagenUrl: {p.ImagenUrl}");
            }
        }

        static void agregarProducto(ServiceProducto service)
        {
            Producto p = new Producto();
            Console.WriteLine("\n--- NUEVO PRODUCTO ---");
            Console.Write("Nombre: ");
            p.Nombre = Console.ReadLine();
            Console.Write("Stock actual: ");
            p.StockActual = int.Parse(Console.ReadLine());
            Console.Write("Precio de compra: ");
            p.PrecioCompra = float.Parse(Console.ReadLine());
            Console.Write("Porcentaje de ganancia: ");
            p.Ganancia = float.Parse(Console.ReadLine());

            Console.Write("ID Marca: ");
            p.Marca = new Marca { Id = int.Parse(Console.ReadLine()) };
            Console.Write("ID Categoría: ");
            p.Categoria = new Categoria { Id = int.Parse(Console.ReadLine()) };

            Console.Write("URL de nueva Imagen:");
            p.ImagenUrl = Console.ReadLine();

            p.Activo = true;

            service.agregar(p);
            Console.WriteLine("Producto agregado");
        }

        static void modificarProducto(ServiceProducto service)
        {
            Console.Write("\nIngrese el ID del producto a modificar: ");
            int id = int.Parse(Console.ReadLine());
            List<Producto> lista = service.listar();
            Producto p = lista.Find(x => x.Id == id);

            if (p == null)
            {
                Console.WriteLine("Producto no encontrado");
                return;
            }

            Console.WriteLine($"Editando {p.Nombre}:");
            Console.Write("Nuevo nombre (deje vacio para mantener): ");
            string nuevoNombre = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoNombre)) p.Nombre = nuevoNombre;

            Console.Write("Nuevo stock (actual: " + p.StockActual + "): ");
            string nuevoStock = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoStock)) p.StockActual = int.Parse(nuevoStock);

            Console.Write("Nuevo precio compra (actual: " + p.PrecioCompra + "): ");
            string nuevoPrecio = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoPrecio)) p.PrecioCompra = float.Parse(nuevoPrecio);

            Console.Write("Nuevo % ganancia (actual: " + p.Ganancia + "): ");
            string nuevoGanancia = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoGanancia)) p.Ganancia = float.Parse(nuevoGanancia);

            Console.Write("Nuevo % ganancia (actual: " + p.Marca.Id + "): ");
            string nuevaMarca = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevaMarca)) p.Marca.Id = int.Parse(nuevaMarca);

            Console.Write("Nuevo % ganancia (actual: " + p.Categoria.Id + "): ");
            string nuevaCategoria = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevaCategoria)) p.Categoria.Id = int.Parse(nuevaMarca);

            Console.Write("Nueva URL de imagen (actual: " + p.ImagenUrl + "): ");
            string nuevaImagen = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevaImagen)) p.ImagenUrl = nuevaImagen;

            service.modificar(p);
            Console.WriteLine("Producto modificado");
        }

        static void eliminarProducto(ServiceProducto service)
        {
            Console.Write("\nIngresar el ID del producto a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            service.eliminar(id);
            Console.WriteLine("Producto eliminado correctamente.");
        }

        static void listarCliente(ServiceCliente service)
        {
            List<Cliente> lista = service.listar();
            Console.WriteLine("\n--- LISTA DE CLIENTES ---");
            foreach (var c in lista)
            {
                Console.WriteLine($"ID: {c.Id} | DNI: {c.Dni} | {c.Nombre} | Tel: {c.Telefono} | Dir: {c.Direccion} | Email: {c.Email}");
            }
        }

        static void agregarCliente(ServiceCliente service)
        {
            Cliente c = new Cliente();
            Console.WriteLine("\n--- NUEVO CLIENTE ---");
            Console.Write("DNI: ");
            c.Dni = int.Parse(Console.ReadLine());
            Console.Write("Nombre: ");
            c.Nombre = Console.ReadLine();
            Console.Write("Dirección: ");
            c.Direccion = Console.ReadLine();
            Console.Write("Teléfono: ");
            c.Telefono = Console.ReadLine();
            Console.Write("Email: ");
            c.Email = Console.ReadLine();
            c.Activo = true;

            service.agregar(c);
            Console.WriteLine("Cliente agregado.");
        }

        static void modificarCliente(ServiceCliente service)
        {
            Console.Write("\nID del cliente a modificar: ");

            int id = int.Parse(Console.ReadLine());
            var lista = service.listar();
            var c = lista.Find(x => x.Id == id);

            if (c == null) 
            { 
                Console.WriteLine("No encontrado."); 
                return; 
            }

            Console.Write($"Nuevo DNI ({c.Dni}) (deje vacio para mantener): ");
            string dni = Console.ReadLine();
            if (!string.IsNullOrEmpty(dni)) c.Dni = int.Parse(dni);

            Console.Write($"Nuevo nombre ({c.Nombre}): ");
            string nom = Console.ReadLine();
            if (!string.IsNullOrEmpty(nom)) c.Nombre = nom;

            Console.Write($"Nuevo teléfono ({c.Telefono}): ");
            string tel = Console.ReadLine();
            if (!string.IsNullOrEmpty(tel)) c.Telefono = tel;

            Console.Write($"Nueva dirección ({c.Direccion}): ");
            string dir = Console.ReadLine();
            if (!string.IsNullOrEmpty(dir)) c.Direccion = dir;

            Console.Write($"Nuevo email ({c.Email}): ");
            string mail = Console.ReadLine();
            if (!string.IsNullOrEmpty(mail)) c.Email = mail;

            service.modificar(c);
            Console.WriteLine("Cliente modificado.");
        }

        static void eliminarCliente(ServiceCliente service)
        {
            Console.Write("\nID del cliente a eliminar: ");
            int id = int.Parse(Console.ReadLine());
            service.eliminar(id);
            Console.WriteLine("Cliente eliminado.");
        }

        static void listarProveedor(ServiceProveedor service)
        {
            List<Proveedor> lista = service.listar();
            Console.WriteLine("\n--- LISTA DE PROVEEDORESS ---");
            foreach (var pv in lista)
            {
                Console.WriteLine($"ID: {pv.Id} | CUIT: {pv.Cuit} | {pv.Nombre} | Tel: {pv.Telefono} | Dir: {pv.Direccion} | Email: {pv.Email}");
            }
        }

        static void agregarProveedor(ServiceProveedor service)
        {
            Proveedor pv = new Proveedor();
            Console.WriteLine("\n--- NUEVO Proveedor ---");
            Console.Write("CUIT: ");
            pv.Cuit = long.Parse(Console.ReadLine());
            Console.Write("Nombre: ");
            pv.Nombre = Console.ReadLine();
            Console.Write("Dirección: ");
            pv.Direccion = Console.ReadLine();
            Console.Write("Teléfono: ");
            pv.Telefono = Console.ReadLine();
            Console.Write("Email: ");
            pv.Email = Console.ReadLine();
            pv.Activo = true;

            service.agregar(pv);
            Console.WriteLine("Proveedor agregado.");
        }

        static void modificarProveedor(ServiceProveedor service)
        {
            Console.Write("\nID del Proveedor a modificar: ");
            int id = int.Parse(Console.ReadLine());
            var lista = service.listar();
            var pv = lista.Find(x => x.Id == id);

            if (pv == null)
            {
                Console.WriteLine("No encontrado.");
                return;
            }

            Console.Write("Nuevo CUIT (deje vacio para mantener): ");
            string cuit = Console.ReadLine();
            if (!string.IsNullOrEmpty(cuit)) pv.Cuit = int.Parse(cuit);

            Console.Write($"Nuevo nombre ({pv.Nombre}): ");
            string nom = Console.ReadLine();
            if (!string.IsNullOrEmpty(nom)) pv.Nombre = nom;

            Console.Write($"Nuevo teléfono ({pv.Telefono}): ");
            string tel = Console.ReadLine();
            if (!string.IsNullOrEmpty(tel)) pv.Telefono = tel;

            Console.Write($"Nueva dirección ({pv.Direccion}): ");
            string dir = Console.ReadLine();
            if (!string.IsNullOrEmpty(dir)) pv.Direccion = dir;

            Console.Write($"Nuevo email ({pv.Email}): ");
            string mail = Console.ReadLine();
            if (!string.IsNullOrEmpty(mail)) pv.Email = mail;

            service.modificar(pv);
            Console.WriteLine("Proveedor modificado.");
        }

        static void eliminarProveedor(ServiceProveedor service)
        {
            Console.Write("\nID del Proveedor a eliminar: ");
            int id = int.Parse(Console.ReadLine());
            service.eliminar(id);
            Console.WriteLine("Proveedor eliminado.");
        }
    }
}
    
