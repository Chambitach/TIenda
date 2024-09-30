namespace TIenda.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; } // Clave primaria
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }
    }
}
