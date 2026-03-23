// Punto de entrada principal de la aplicación
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

static class MenuPrestamos    { public static void Mostrar() => Utilidades.ProximaMente("Préstamos"); }
static class MenuBusquedas    { public static void Mostrar() => Utilidades.ProximaMente("Búsquedas y Reportes"); }
static class MenuPersistencia { public static void Mostrar() => Utilidades.ProximaMente("Persistencia"); }
static class FlujoSalida      { public static bool Confirmar() => Utilidades.Confirmar("¿Desea salir del sistema?"); }

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