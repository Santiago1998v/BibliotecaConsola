using BibliotecaConsola.Models;

// ─── Pruebas de objetos del modelo ────────────────────────────────────────────
Console.WriteLine("═══════════════════════════════════════");
Console.WriteLine("   PRUEBAS DE CLASES DEL MODELO");
Console.WriteLine("═══════════════════════════════════════\n");

// Crear libros de prueba
Libro libro1 = new Libro(1, "Cien años de soledad", "Gabriel García Márquez", "978-0307474728", 1967);
Libro libro2 = new Libro(2, "El principito", "Antoine de Saint-Exupéry", "978-0156012195", 1943);

Console.WriteLine("── Libros ──────────────────────────────");
Console.WriteLine(libro1.ResumenCorto());
Console.WriteLine(libro2.ResumenCorto());
Console.WriteLine();

// Crear usuarios de prueba
Usuario usuario1 = new Usuario(1, "Carlos", "Ramírez", "carlos@email.com", "3001234567");
Usuario usuario2 = new Usuario(2, "Ana", "López", "ana@email.com", "3107654321");

Console.WriteLine("── Usuarios ────────────────────────────");
Console.WriteLine(usuario1.DetalleCompleto());
Console.WriteLine();
Console.WriteLine(usuario2.DetalleCompleto());
Console.WriteLine();

// Crear préstamo de prueba
Prestamo prestamo1 = new Prestamo(1, libro1, usuario1, diasPlazo: 7);

Console.WriteLine("── Préstamo ────────────────────────────");
Console.WriteLine(prestamo1.DetalleCompleto());
Console.WriteLine();

// Verificar disponibilidad del libro prestado
Console.WriteLine($"¿Libro disponible tras préstamo? {(libro1.Disponible ? "Sí" : "No")}");

// Registrar devolución
prestamo1.Devolver();
Console.WriteLine($"Estado tras devolución: {prestamo1.Estado}");
Console.WriteLine($"¿Libro disponible tras devolución? {(libro1.Disponible ? "Sí" : "No")}");

Console.WriteLine("\nPresione cualquier tecla para continuar al menú...");
Console.ReadKey();
Console.Clear();

// ─── Menú Principal ───────────────────────────────────────────────────────────
MenuPrincipal.Mostrar();

// ─── Menú Principal ───────────────────────────────────────────────────────────
static class MenuPrincipal
{
    public static void Mostrar()
    {
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║   SISTEMA DE BIBLIOTECA      ║");
            Console.WriteLine("╠══════════════════════════════╣");
            Console.WriteLine("║  1. Gestión de Libros        ║");
            Console.WriteLine("║  2. Gestión de Usuarios      ║");
            Console.WriteLine("║  3. Préstamos                ║");
            Console.WriteLine("║  4. Búsquedas y Reportes     ║");
            Console.WriteLine("║  5. Persistencia             ║");
            Console.WriteLine("║  0. Salir                    ║");
            Console.WriteLine("╚══════════════════════════════╝");

            switch (Utilidades.LeerOpcion())
            {
                case "1": MenuLibros.Mostrar();            break;
                case "2": MenuUsuarios.Mostrar();          break;
                case "3": MenuPrestamos.Mostrar();         break;
                case "4": MenuBusquedas.Mostrar();         break;
                case "5": MenuPersistencia.Mostrar();      break;
                case "0": salir = FlujoSalida.Confirmar(); break;
                default:  Utilidades.OpcionInvalida();     break;
            }
        }
    }
}

// ─── Menú Libros ──────────────────────────────────────────────────────────────
static class MenuLibros
{
    public static void Mostrar()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║      GESTIÓN DE LIBROS       ║");
            Console.WriteLine("╠══════════════════════════════╣");
            Console.WriteLine("║  1. Agregar libro            ║");
            Console.WriteLine("║  2. Editar libro             ║");
            Console.WriteLine("║  3. Eliminar libro           ║");
            Console.WriteLine("║  4. Listar libros            ║");
            Console.WriteLine("║  0. Volver                   ║");
            Console.WriteLine("╚══════════════════════════════╝");

            switch (Utilidades.LeerOpcion())
            {
                case "1": Utilidades.Accion("Agregar libro");  break;
                case "2": Utilidades.Accion("Editar libro");   break;
                case "3": Utilidades.Accion("Eliminar libro"); break;
                case "4": Utilidades.Accion("Listar libros");  break;
                case "0": volver = true;                       break;
                default:  Utilidades.OpcionInvalida();         break;
            }
        }
    }
}

// ─── Menú Usuarios ────────────────────────────────────────────────────────────
static class MenuUsuarios
{
    public static void Mostrar()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║     GESTIÓN DE USUARIOS      ║");
            Console.WriteLine("╠══════════════════════════════╣");
            Console.WriteLine("║  1. Registrar usuario        ║");
            Console.WriteLine("║  2. Editar usuario           ║");
            Console.WriteLine("║  3. Eliminar usuario         ║");
            Console.WriteLine("║  4. Listar usuarios          ║");
            Console.WriteLine("║  0. Volver                   ║");
            Console.WriteLine("╚══════════════════════════════╝");

            switch (Utilidades.LeerOpcion())
            {
                case "1": Utilidades.Accion("Registrar usuario"); break;
                case "2": Utilidades.Accion("Editar usuario");    break;
                case "3": Utilidades.Accion("Eliminar usuario");  break;
                case "4": Utilidades.Accion("Listar usuarios");   break;
                case "0": volver = true;                          break;
                default:  Utilidades.OpcionInvalida();            break;
            }
        }
    }
}

// ─── Menú Préstamos ───────────────────────────────────────────────────────────
static class MenuPrestamos
{
    public static void Mostrar()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║       GESTIÓN PRÉSTAMOS      ║");
            Console.WriteLine("╠══════════════════════════════╣");
            Console.WriteLine("║  1. Registrar préstamo       ║");
            Console.WriteLine("║  2. Registrar devolución     ║");
            Console.WriteLine("║  3. Listar préstamos         ║");
            Console.WriteLine("║  4. Préstamos vencidos       ║");
            Console.WriteLine("║  0. Volver                   ║");
            Console.WriteLine("╚══════════════════════════════╝");

            switch (Utilidades.LeerOpcion())
            {
                case "1": Utilidades.Accion("Registrar préstamo");   break;
                case "2": Utilidades.Accion("Registrar devolución"); break;
                case "3": Utilidades.Accion("Listar préstamos");     break;
                case "4": Utilidades.Accion("Préstamos vencidos");   break;
                case "0": volver = true;                             break;
                default:  Utilidades.OpcionInvalida();               break;
            }
        }
    }
}

// ─── Menú Búsquedas y Reportes ────────────────────────────────────────────────
static class MenuBusquedas
{
    public static void Mostrar()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║    BÚSQUEDAS Y REPORTES      ║");
            Console.WriteLine("╠══════════════════════════════╣");
            Console.WriteLine("║  1. Buscar libro             ║");
            Console.WriteLine("║  2. Buscar usuario           ║");
            Console.WriteLine("║  3. Reporte de préstamos     ║");
            Console.WriteLine("║  4. Reporte de devoluciones  ║");
            Console.WriteLine("║  0. Volver                   ║");
            Console.WriteLine("╚══════════════════════════════╝");

            switch (Utilidades.LeerOpcion())
            {
                case "1": Utilidades.Accion("Buscar libro");            break;
                case "2": Utilidades.Accion("Buscar usuario");          break;
                case "3": Utilidades.Accion("Reporte de préstamos");    break;
                case "4": Utilidades.Accion("Reporte de devoluciones"); break;
                case "0": volver = true;                                break;
                default:  Utilidades.OpcionInvalida();                  break;
            }
        }
    }
}

// ─── Menú Persistencia ────────────────────────────────────────────────────────
static class MenuPersistencia
{
    public static void Mostrar()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║         PERSISTENCIA         ║");
            Console.WriteLine("╠══════════════════════════════╣");
            Console.WriteLine("║  1. Guardar datos            ║");
            Console.WriteLine("║  2. Cargar datos             ║");
            Console.WriteLine("║  3. Exportar reporte         ║");
            Console.WriteLine("║  0. Volver                   ║");
            Console.WriteLine("╚══════════════════════════════╝");

            switch (Utilidades.LeerOpcion())
            {
                case "1": Utilidades.Accion("Guardar datos");    break;
                case "2": Utilidades.Accion("Cargar datos");     break;
                case "3": Utilidades.Accion("Exportar reporte"); break;
                case "0": volver = true;                         break;
                default:  Utilidades.OpcionInvalida();           break;
            }
        }
    }
}

// ─── Flujo de Salida ──────────────────────────────────────────────────────────
static class FlujoSalida
{
    public static bool Confirmar()
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║         SALIR                ║");
        Console.WriteLine("╠══════════════════════════════╣");
        Console.WriteLine("║  ¿Desea salir del sistema?   ║");
        Console.WriteLine("╚══════════════════════════════╝");

        if (Utilidades.Confirmar("Confirme su elección"))
        {
            Console.Clear();
            Console.WriteLine("  Gracias por usar el Sistema de Biblioteca.");
            Console.WriteLine("  ¡Hasta pronto!");
            Thread.Sleep(1500);
            return true;
        }
        return false;
    }
}

// ─── Utilidades compartidas ───────────────────────────────────────────────────
static class Utilidades
{
    public static string LeerOpcion()
    {
        Console.Write("\n  Seleccione una opción: ");
        return Console.ReadLine()?.Trim() ?? "";
    }

    public static void ProximaMente(string modulo)
    {
        Console.Clear();
        Console.WriteLine($"  [ {modulo} ] — módulo en construcción.");
        Pausa();
    }

    public static bool Confirmar(string mensaje)
    {
        Console.Write($"\n  {mensaje} (S/N): ");
        return Console.ReadLine()?.Trim().ToUpper() == "S";
    }

    public static void Accion(string accion)
    {
        Console.Clear();
        Console.WriteLine($"  >> Ejecutando: {accion}");
        Pausa();
    }

    public static void OpcionInvalida()
    {
        Console.WriteLine("\n  Opción no válida. Intente de nuevo.");
        Pausa();
    }

    public static void Pausa()
    {
        Console.Write("\n  Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}