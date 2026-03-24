namespace BibliotecaConsola.Models;

// Representa un usuario registrado en el sistema de biblioteca
public class Usuario
{
    // ─── Propiedades ──────────────────────────────────────────────────────────
    public int    Id       { get; set; }
    public string Nombre   { get; set; }
    public string Apellido { get; set; }
    public string Email    { get; set; }
    public string Telefono { get; set; }
    public bool   Activo   { get; set; }

    // ─── Constructor completo ─────────────────────────────────────────────────
    public Usuario(int id, string nombre, string apellido, string email, string telefono)
    {
        Id       = id;
        Nombre   = nombre;
        Apellido = apellido;
        Email    = email;
        Telefono = telefono;
        Activo   = true; // Todo usuario inicia activo
    }

    // ─── Métodos ──────────────────────────────────────────────────────────────

    // Devuelve el nombre completo del usuario
    public string NombreCompleto() =>
        $"{Nombre} {Apellido}";

    // Devuelve todos los datos del usuario formateados
    public string DetalleCompleto() =>
        $"ID       : {Id}\n" +
        $"Nombre   : {NombreCompleto()}\n" +
        $"Email    : {Email}\n" +
        $"Teléfono : {Telefono}\n" +
        $"Activo   : {(Activo ? "Sí" : "No")}";
}