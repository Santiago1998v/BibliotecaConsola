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

// ─── Stubs de submenús (se implementarán en sus ramas) ────────────────────────
static class MenuLibros       { public static void Mostrar() => Utilidades.ProximaMente("Libros"); }
static class MenuUsuarios     { public static void Mostrar() => Utilidades.ProximaMente("Usuarios"); }
static class MenuPrestamos    { public static void Mostrar() => Utilidades.ProximaMente("Préstamos"); }
static class MenuBusquedas    { public static void Mostrar() => Utilidades.ProximaMente("Búsquedas y Reportes"); }
static class MenuPersistencia { public static void Mostrar() => Utilidades.ProximaMente("Persistencia"); }
static class FlujoSalida      { public static bool Confirmar() => Utilidades.Confirmar("¿Desea salir del sistema?"); }

// ─── Utilidades compartidas ───────────────────────────────────────────────────
static class Utilidades
{
    // Lee la opción del usuario mostrando el prompt
    public static string LeerOpcion()
    {
        Console.Write("\n  Seleccione una opción: ");
        return Console.ReadLine()?.Trim() ?? "";
    }

    // Muestra mensaje de módulo pendiente y espera tecla
    public static void ProximaMente(string modulo)
    {
        Console.Clear();
        Console.WriteLine($"  [ {modulo} ] — módulo en construcción.");
        Pausa();
    }

    // Solicita confirmación S/N y devuelve true si el usuario acepta
    public static bool Confirmar(string mensaje)
    {
        Console.Write($"\n  {mensaje} (S/N): ");
        return Console.ReadLine()?.Trim().ToUpper() == "S";
    }

    // Avisa que la opción no existe
    public static void OpcionInvalida()
    {
        Console.WriteLine("\n  Opción no válida. Intente de nuevo.");
        Pausa();
    }

    // Pausa hasta que el usuario presione una tecla
    public static void Pausa()
    {
        Console.Write("\n  Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}