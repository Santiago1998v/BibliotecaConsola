namespace BibliotecaConsola.Models;

public class Prestamo
{
    // ─── Propiedades ──────────────────────────────────────────────────────────
    public int            Id              { get; set; }
    public Libro          Libro           { get; set; }
    public Usuario        Usuario         { get; set; }
    public DateTime       FechaPrestamo   { get; set; }
    public DateTime?      FechaDevolucion { get; set; }  // nullable
    public DateTime       FechaPlazo      { get; set; }
    public EstadoPrestamo Estado          { get; set; }

    // ─── Constructor vacío ────────────────────────────────────────────────────
    public Prestamo()
    {
        Libro           = new Libro();
        Usuario         = new Usuario();
        FechaPrestamo   = DateTime.Now;
        FechaDevolucion = null;
        Estado          = EstadoPrestamo.Activo;
    }

    // ─── Constructor completo ─────────────────────────────────────────────────
    public Prestamo(int id, Libro libro, Usuario usuario, int diasPlazo = 7)
    {
        Id              = id;
        Libro           = libro;
        Usuario         = usuario;
        FechaPrestamo   = DateTime.Now;
        FechaDevolucion = null;         // null hasta que se devuelva
        FechaPlazo      = DateTime.Now.AddDays(diasPlazo);
        Estado          = EstadoPrestamo.Activo;
        libro.Disponible = false;
    }

    // ─── Métodos ──────────────────────────────────────────────────────────────
    public void Devolver()
    {
        Estado           = EstadoPrestamo.Devuelto;
        FechaDevolucion  = DateTime.Now;  // registra cuándo se devolvió
        Libro.Disponible = true;
    }

    public bool EstaVencido() =>
        Estado == EstadoPrestamo.Activo && DateTime.Now > FechaPlazo;

    public int DiasTranscurridos() =>
        (DateTime.Now - FechaPrestamo).Days;

    public string ResumenCorto() =>
        $"[{Id}] {Libro.Titulo} → {Usuario.NombreCompleto()} | Estado: {Estado}";

    public string DetalleCompleto() =>
        $"ID              : {Id}\n" +
        $"Libro           : {Libro.Titulo}\n" +
        $"Usuario         : {Usuario.NombreCompleto()}\n" +
        $"Fecha préstamo  : {FechaPrestamo:dd/MM/yyyy}\n" +
        $"Fecha plazo     : {FechaPlazo:dd/MM/yyyy}\n" +
        $"Fecha devolución: {(FechaDevolucion.HasValue ? FechaDevolucion.Value.ToString("dd/MM/yyyy") : "Pendiente")}\n" +
        $"Días transcurridos: {DiasTranscurridos()}\n" +
        $"Vencido         : {(EstaVencido() ? "Sí" : "No")}\n" +
        $"Estado          : {Estado}";

    // ─── ToString ─────────────────────────────────────────────────────────────
    public override string ToString() => ResumenCorto();
}