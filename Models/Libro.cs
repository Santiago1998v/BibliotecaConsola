namespace BibliotecaConsola.Models;

public class Libro
{
    // ─── Propiedades ──────────────────────────────────────────────────────────
    public int    Id        { get; set; }
    public string Titulo    { get; set; }
    public string Autor     { get; set; }
    public string Isbn      { get; set; }
    public int    Anio      { get; set; }
    public bool   Disponible { get; set; }

    // ─── Constructor vacío ────────────────────────────────────────────────────
    public Libro()
    {
        Titulo     = string.Empty;
        Autor      = string.Empty;
        Isbn       = string.Empty;
        Disponible = true;
    }

    // ─── Constructor completo ─────────────────────────────────────────────────
    public Libro(int id, string titulo, string autor, string isbn, int anio)
    {
        Id         = id;
        Titulo     = titulo;
        Autor      = autor;
        Isbn       = isbn;
        Anio       = anio;
        Disponible = true;
    }

    // ─── Métodos ──────────────────────────────────────────────────────────────
    public string ResumenCorto() =>
        $"[{Id}] {Titulo} — {Autor} ({Anio})";

    public string DetalleCompleto() =>
        $"ID       : {Id}\n" +
        $"Título   : {Titulo}\n" +
        $"Autor    : {Autor}\n" +
        $"ISBN     : {Isbn}\n" +
        $"Año      : {Anio}\n" +
        $"Disponible: {(Disponible ? "Sí" : "No")}";

    // ─── ToString ─────────────────────────────────────────────────────────────
    public override string ToString() => ResumenCorto();
}