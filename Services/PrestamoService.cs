namespace BibliotecaConsola.Services;

using BibliotecaConsola.Models;

public class PrestamoService
{
    private List<Prestamo> prestamos = new List<Prestamo>();

    // ─── Agregar ──────────────────────────────────────────────────────────────
    public void AgregarPrestamo(Prestamo prestamo)
    {
        prestamos.Add(prestamo);
    }

    // ─── Eliminar ─────────────────────────────────────────────────────────────
    public bool EliminarPrestamo(int id)
    {
        var prestamo = BuscarPorId(id);
        if (prestamo != null) { prestamos.Remove(prestamo); return true; }
        return false;
    }

    // ─── Obtener todos ────────────────────────────────────────────────────────
    public List<Prestamo> ObtenerTodos() => prestamos;

    // ─── Búsquedas ────────────────────────────────────────────────────────────
    public Prestamo? BuscarPorId(int id) =>
        prestamos.FirstOrDefault(p => p.Id == id);

    public List<Prestamo> BuscarPorEstado(EstadoPrestamo estado) =>
        prestamos.Where(p => p.Estado == estado).ToList();

    // ─── Ordenación ───────────────────────────────────────────────────────────
    public List<Prestamo> OrdenarPorFechaPlazo() =>
        prestamos.OrderBy(p => p.FechaPlazo).ToList();

    // ─── KPIs ─────────────────────────────────────────────────────────────────
    public int TotalPrestamos() => prestamos.Count;

    public int PrestamosActivos() =>
        prestamos.Count(p => p.Estado == EstadoPrestamo.Activo);

    public int PrestamosVencidos() =>
        prestamos.Count(p => p.EstaVencido());

    public int PrestamosDevueltos() =>
        prestamos.Count(p => p.Estado == EstadoPrestamo.Devuelto);

    public double PromedioDiasPrestamo() =>
        prestamos.Count == 0 ? 0 : prestamos.Average(p => p.DiasTranscurridos());
        // ─── Comparación Array vs List ────────────────────────────────────────────
    public void CompararArrayVsList()
    {
        // ARRAY: tamaño fijo, no se puede agregar ni eliminar elementos
        Prestamo[] arrayPrestamos = new Prestamo[2];
        arrayPrestamos[0] = new Prestamo(1, new Libro(1, "Cien años de soledad", "García Márquez", "123", 1967), new Usuario(1, "Carlos", "Ramírez", "carlos@email.com", "300"), 7);
        arrayPrestamos[1] = new Prestamo(2, new Libro(2, "El principito", "Saint-Exupéry", "456", 1943), new Usuario(2, "Ana", "López", "ana@email.com", "310"), 7);
        // arrayPrestamos[2] = new Prestamo(...) → ERROR: índice fuera de rango

        Console.WriteLine("── Array (tamaño fijo = 2) ──────────────");
        foreach (var p in arrayPrestamos)
            Console.WriteLine(p.ResumenCorto());

        // LIST: tamaño dinámico, se puede agregar y eliminar libremente
        List<Prestamo> listaPrestamos = new List<Prestamo>();
        listaPrestamos.Add(new Prestamo(1, new Libro(1, "Cien años de soledad", "García Márquez", "123", 1967), new Usuario(1, "Carlos", "Ramírez", "carlos@email.com", "300"), 7));
        listaPrestamos.Add(new Prestamo(2, new Libro(2, "El principito", "Saint-Exupéry", "456", 1943), new Usuario(2, "Ana", "López", "ana@email.com", "310"), 7));
        listaPrestamos.Add(new Prestamo(3, new Libro(3, "Don Quijote", "Cervantes", "789", 1605), new Usuario(3, "Pedro", "Gómez", "pedro@email.com", "320"), 14));

        Console.WriteLine("\n── List (tamaño dinámico) ───────────────");
        foreach (var p in listaPrestamos)
            Console.WriteLine(p.ResumenCorto());

        Console.WriteLine("\n── Diferencia clave ─────────────────────");
        Console.WriteLine("Array: tamaño fijo, acceso rápido por índice.");
        Console.WriteLine("List:  tamaño dinámico, métodos Add/Remove/Find.");
    }
}
