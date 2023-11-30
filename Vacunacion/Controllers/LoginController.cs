using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.Data.SqlClient;
using Vacunacion.Models;
using Vacunacion.Tools;

namespace Vacunacion.Controllers
{
    public class LoginController : Controller
    {


        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult LoginIndex()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginIndex(User user)
        {
            if (ModelState.IsValid)
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string passwordHash = HashPassword(user.Password);

                    string query = "SELECT UserId, Role FROM [User] WHERE UserName = @UserName AND Password = @PasswordHash";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", user.UserName);
                        command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                    
                                int loggedInUserId = reader.GetInt32(0);
                                string userRole = reader.GetString(1);

                                HttpContext.Session.SetInt32("UserId", loggedInUserId);
                                HttpContext.Session.SetString("UserRole", userRole);

                                TempData["MensajeBienvenida"] = "Bienvenido";

                                if (userRole == "SuperAdmin")
                                {
                                    // Redirigir a la página para super administradores
                                     //return View("~/Views/Menu/MenuSuperAdmin.cshtml");

                                    return RedirectToAction("MenuSuperAdmin", "Menu");

                                }
                                else
                                {
                                    return RedirectToAction("MenuAdmin", "Menu");
                                }
                            }
                        }
                    }
                }
            }

            // Credencial no válida, muestra un mensaje de error.
            ModelState.AddModelError(string.Empty, "Credencial no válida. Inténtalo de nuevo.");
            return View(user);
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convierte la contraseña en bytes
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Calcula el hash SHA-256 de la contraseña
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Convierte el hash en una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

    }
}
