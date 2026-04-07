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

    // ─── Comparación Array vs List ────────────────────────────────────────────
    public void CompararArrayVsList()
    {
        // ARRAY: tamaño fijo, no se puede agregar ni eliminar elementos
        Usuario[] arrayUsuarios = new Usuario[2];
        arrayUsuarios[0] = new Usuario(1, "Carlos", "Ramírez", "carlos@email.com", "3001234567");
        arrayUsuarios[1] = new Usuario(2, "Ana", "López", "ana@email.com", "3107654321");
        // arrayUsuarios[2] = new Usuario(...) → ERROR: índice fuera de rango

        Console.WriteLine("── Array (tamaño fijo = 2) ──────────────");
        foreach (var u in arrayUsuarios)
            Console.WriteLine(u.ResumenCorto());

        // LIST: tamaño dinámico, se puede agregar y eliminar libremente
        List<Usuario> listaUsuarios = new List<Usuario>();
        listaUsuarios.Add(new Usuario(1, "Carlos", "Ramírez", "carlos@email.com", "3001234567"));
        listaUsuarios.Add(new Usuario(2, "Ana", "López", "ana@email.com", "3107654321"));
        listaUsuarios.Add(new Usuario(3, "Pedro", "Gómez", "pedro@email.com", "3201234567"));

        Console.WriteLine("\n── List (tamaño dinámico) ───────────────");
        foreach (var u in listaUsuarios)
            Console.WriteLine(u.ResumenCorto());

        Console.WriteLine("\n── Diferencia clave ─────────────────────");
        Console.WriteLine("Array: tamaño fijo, acceso rápido por índice.");
        Console.WriteLine("List:  tamaño dinámico, métodos Add/Remove/Find.");
    }
}
