namespace BibliotecaConsola.Models;

public class Usuario
{
    // ─── Propiedades ──────────────────────────────────────────────────────────
    public int    Id       { get; set; }
    public string Nombre   { get; set; }
    public string Apellido { get; set; }
    public string Email    { get; set; }
    public string Telefono { get; set; }
    public bool   Activo   { get; set; }

    // ─── Constructor vacío ────────────────────────────────────────────────────
    public Usuario()
    {
        Nombre   = string.Empty;
        Apellido = string.Empty;
        Email    = string.Empty;
        Telefono = string.Empty;
        Activo   = true;
    }

    // ─── Constructor completo ─────────────────────────────────────────────────
    public Usuario(int id, string nombre, string apellido, string email, string telefono)
    {
        Id       = id;
        Nombre   = nombre;
        Apellido = apellido;
        Email    = email;
        Telefono = telefono;
        Activo   = true;
    }

    // ─── Métodos ──────────────────────────────────────────────────────────────
    public string NombreCompleto() =>
        $"{Nombre} {Apellido}";

    public string ResumenCorto() =>
        $"[{Id}] {NombreCompleto()} — {Email}";

    public string DetalleCompleto() =>
        $"ID       : {Id}\n" +
        $"Nombre   : {NombreCompleto()}\n" +
        $"Email    : {Email}\n" +
        $"Teléfono : {Telefono}\n" +
        $"Activo   : {(Activo ? "Sí" : "No")}";

    // ─── ToString ─────────────────────────────────────────────────────────────
    public override string ToString() => ResumenCorto();
}