using ComercioDomain;
using ComercioService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceProducto service = new ServiceProducto();
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
                        listarProducto(service);
                        break;
                    case "2":
                        agregarProducto(service);
                        break;
                    case "3":
                        modificarProducto(service);
                        break;
                    case "4":
                        eliminarProducto(service);
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

        static void listarProducto(ServiceProducto service)
        {
            List<Producto> lista = service.listar();
            Console.WriteLine("\n--- LISTA DE PRODUCTOS ---");
            foreach (var p in lista)
            {
                Console.WriteLine($"ID: {p.Id} | {p.Nombre} | Stock: {p.StockActual} | Precio compra: {p.PrecioCompra} | %Ganancia: {p.Ganancia} | Marca: {p.Marca.Nombre} | Categoría: {p.Categoria.Nombre}");
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
    }
}
    
