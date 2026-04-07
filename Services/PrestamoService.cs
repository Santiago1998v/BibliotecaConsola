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
}
