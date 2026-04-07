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
}