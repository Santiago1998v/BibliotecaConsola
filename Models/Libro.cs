namespace BibliotecaConsola.Models;

// Representa un libro dentro del sistema de biblioteca
public class Libro
{
    // ─── Propiedades ──────────────────────────────────────────────────────────
    public int    Id       { get; set; }
    public string Titulo   { get; set; }
    public string Autor    { get; set; }
    public string Isbn     { get; set; }
    public int    Anio     { get; set; }
    public bool   Disponible { get; set; }

    // ─── Constructor completo ─────────────────────────────────────────────────
    public Libro(int id, string titulo, string autor, string isbn, int anio)
    {
        Id         = id;
        Titulo     = titulo;
        Autor      = autor;
        Isbn       = isbn;
        Anio       = anio;
        Disponible = true; // Todo libro inicia disponible
    }

    // ─── Métodos ──────────────────────────────────────────────────────────────

    // Devuelve una línea corta con los datos principales del libro
    public string ResumenCorto() =>
        $"[{Id}] {Titulo} — {Autor} ({Anio})";

    // Devuelve todos los datos del libro formateados
    public string DetalleCompleto() =>
        $"ID       : {Id}\n" +
        $"Título   : {Titulo}\n" +
        $"Autor    : {Autor}\n" +
        $"ISBN     : {Isbn}\n" +
        $"Año      : {Anio}\n" +
        $"Disponible: {(Disponible ? "Sí" : "No")}";
}