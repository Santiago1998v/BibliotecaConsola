namespace BibliotecaConsola.Models;

// Representa un préstamo de un libro a un usuario
public class Prestamo
{
    // ─── Propiedades ──────────────────────────────────────────────────────────
    public int           Id           { get; set; }
    public Libro         Libro        { get; set; }
    public Usuario       Usuario      { get; set; }
    public DateTime      FechaPrestamo  { get; set; }
    public DateTime      FechaDevolucion { get; set; }
    public EstadoPrestamo Estado       { get; set; }

    // ─── Constructor completo ─────────────────────────────────────────────────
    public Prestamo(int id, Libro libro, Usuario usuario, int diasPlazo = 7)
    {
        Id              = id;
        Libro           = libro;
        Usuario         = usuario;
        FechaPrestamo   = DateTime.Now;
        FechaDevolucion = DateTime.Now.AddDays(diasPlazo);
        Estado          = EstadoPrestamo.Activo;

        // El libro deja de estar disponible al prestarse
        libro.Disponible = false;
    }

    // ─── Métodos ──────────────────────────────────────────────────────────────

    // Registra la devolución del libro y actualiza su disponibilidad
    public void Devolver()
    {
        Estado           = EstadoPrestamo.Devuelto;
        Libro.Disponible = true;
    }

    // Verifica si el préstamo está vencido y actualiza el estado
    public bool VerificarVencimiento()
    {
        if (Estado == EstadoPrestamo.Activo && DateTime.Now > FechaDevolucion)
        {
            Estado = EstadoPrestamo.Vencido;
            return true;
        }
        return false;
    }

    // Devuelve un resumen corto del préstamo
    public string ResumenCorto() =>
        $"[{Id}] {Libro.Titulo} → {Usuario.NombreCompleto()} | Estado: {Estado}";

    // Devuelve todos los datos del préstamo formateados
    public string DetalleCompleto() =>
        $"ID          : {Id}\n" +
        $"Libro       : {Libro.Titulo}\n" +
        $"Usuario     : {Usuario.NombreCompleto()}\n" +
        $"Fecha préstamo  : {FechaPrestamo:dd/MM/yyyy}\n" +
        $"Fecha devolución: {FechaDevolucion:dd/MM/yyyy}\n" +
        $"Estado      : {Estado}";
}