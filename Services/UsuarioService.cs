namespace BibliotecaConsola.Services;

using BibliotecaConsola.Models;

public class UsuarioService
{
    private List<Usuario> usuarios = new List<Usuario>();

    // ─── Agregar ──────────────────────────────────────────────────────────────
    public void AgregarUsuario(Usuario usuario)
    {
        usuarios.Add(usuario);
    }

    // ─── Eliminar ─────────────────────────────────────────────────────────────
    public bool EliminarUsuario(int id)
    {
        var usuario = BuscarPorId(id);
        if (usuario != null) { usuarios.Remove(usuario); return true; }
        return false;
    }

    // ─── Obtener todos ────────────────────────────────────────────────────────
    public List<Usuario> ObtenerTodos() => usuarios;

    // ─── Búsquedas ────────────────────────────────────────────────────────────
    public Usuario? BuscarPorId(int id) =>
        usuarios.FirstOrDefault(u => u.Id == id);

    public List<Usuario> BuscarPorNombre(string nombre) =>
        usuarios.Where(u => u.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase) ||
                            u.Apellido.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();

    public Usuario? BuscarPorEmail(string email) =>
        usuarios.FirstOrDefault(u => u.Email == email);

    // ─── Ordenación ───────────────────────────────────────────────────────────
    public List<Usuario> OrdenarPorNombre() =>
        usuarios.OrderBy(u => u.Nombre).ToList();

    // ─── KPIs ─────────────────────────────────────────────────────────────────
    public int TotalUsuarios() => usuarios.Count;

    public int UsuariosActivos() => usuarios.Count(u => u.Activo);

    public int UsuariosInactivos() => usuarios.Count(u => !u.Activo);
}
