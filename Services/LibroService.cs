namespace BibliotecaConsola.Services;

using BibliotecaConsola.Models;

public class LibroService
{
    private List<Libro> libros = new List<Libro>();

    // ─── Agregar ──────────────────────────────────────────────────────────────
    public void AgregarLibro(Libro libro)
    {
        libros.Add(libro);
    }

    // ─── Eliminar ─────────────────────────────────────────────────────────────
    public bool EliminarLibro(int id)
    {
        var libro = BuscarPorId(id);
        if (libro != null) { libros.Remove(libro); return true; }
        return false;
    }

    // ─── Obtener todos ────────────────────────────────────────────────────────
    public List<Libro> ObtenerTodos() => libros;

    // ─── Búsquedas ────────────────────────────────────────────────────────────
    public Libro? BuscarPorId(int id) =>
        libros.FirstOrDefault(l => l.Id == id);

    public List<Libro> BuscarPorTitulo(string titulo) =>
        libros.Where(l => l.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase)).ToList();

    public List<Libro> BuscarPorAutor(string autor) =>
        libros.Where(l => l.Autor.Contains(autor, StringComparison.OrdinalIgnoreCase)).ToList();

    public Libro? BuscarPorIsbn(string isbn) =>
        libros.FirstOrDefault(l => l.Isbn == isbn);

    // ─── Ordenación ───────────────────────────────────────────────────────────
    public List<Libro> OrdenarPorTitulo() =>
        libros.OrderBy(l => l.Titulo).ToList();

    public List<Libro> OrdenarPorAnio() =>
        libros.OrderBy(l => l.Anio).ToList();

    // ─── KPIs ─────────────────────────────────────────────────────────────────
    public int TotalLibros() => libros.Count;

    public int LibrosDisponibles() => libros.Count(l => l.Disponible);

    public int LibrosPrestados() => libros.Count(l => !l.Disponible);

    // ─── Comparación Array vs List ────────────────────────────────────────────
    public void CompararArrayVsList()
    {
        // ARRAY: tamaño fijo, no se puede agregar ni eliminar elementos
        Libro[] arrayLibros = new Libro[3];
        arrayLibros[0] = new Libro(1, "Cien años de soledad", "García Márquez", "123", 1967);
        arrayLibros[1] = new Libro(2, "El principito", "Saint-Exupéry", "456", 1943);
        arrayLibros[2] = new Libro(3, "Don Quijote", "Cervantes", "789", 1605);
        // arrayLibros[3] = new Libro(...) → ERROR: índice fuera de rango

        Console.WriteLine("── Array (tamaño fijo = 3) ──────────────");
        foreach (var l in arrayLibros)
            Console.WriteLine(l.ResumenCorto());

        // LIST: tamaño dinámico, se puede agregar y eliminar libremente
        List<Libro> listaLibros = new List<Libro>();
        listaLibros.Add(new Libro(1, "Cien años de soledad", "García Márquez", "123", 1967));
        listaLibros.Add(new Libro(2, "El principito", "Saint-Exupéry", "456", 1943));
        listaLibros.Add(new Libro(3, "Don Quijote", "Cervantes", "789", 1605));
        listaLibros.Add(new Libro(4, "1984", "Orwell", "101", 1949)); // sin límite

        Console.WriteLine("\n── List (tamaño dinámico) ───────────────");
        foreach (var l in listaLibros)
            Console.WriteLine(l.ResumenCorto());

        Console.WriteLine("\n── Diferencia clave ─────────────────────");
        Console.WriteLine("Array: tamaño fijo, acceso rápido por índice.");
        Console.WriteLine("List:  tamaño dinámico, métodos Add/Remove/Find.");
    }
}