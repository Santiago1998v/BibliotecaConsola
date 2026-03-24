namespace BibliotecaConsola.Models;

// Define los posibles estados de un préstamo en el sistema
public enum EstadoPrestamo
{
    Activo,       // El libro fue prestado y aún no se devuelve
    Devuelto,     // El libro fue devuelto correctamente
    Vencido       // El plazo de devolución fue superado
}