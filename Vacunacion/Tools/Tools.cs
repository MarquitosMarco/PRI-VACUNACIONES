namespace Vacunacion.Tools
{
    public class Tools
    {
        public static int? GetLoggedInUserId(HttpContext context)
        {
            // Verificar si el usuario está autenticado
            if (context.User.Identity.IsAuthenticated)
            {
                // Intentar obtener el ID del usuario desde la cookie o cualquier otro mecanismo de autenticación
                // Supongamos que el ID del usuario se almacena en una claim llamada "UserId"
                var userIdClaim = context.User.FindFirst("UserId");

                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                {
                    return userId;
                }
            }

            return null; // Usuario no autenticado o ID no válido
        }
    }
}
