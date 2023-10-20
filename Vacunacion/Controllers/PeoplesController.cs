using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vacunacion.Data;
using Vacunacion.Models;
using System.Security.Cryptography;

namespace Vacunacion.Controllers
{
    public class PeoplesController : Controller
    {
        private readonly DB_Context _context;
        string role;
        public PeoplesController(DB_Context context)
        {
            _context = context;
        }

        // GET: Peoples
        public async Task<IActionResult> Index()
        {
            int numeroEntero = 1;
            string num = numeroEntero.ToString();
            return _context.Person != null ?
                        View(await _context.Person.Where(p => p.Status == num).ToListAsync()) :
                        Problem("Entity set 'DB_Context.Person'  is null.");
        }

        // GET: Peoples/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: Peoples/Create
        public IActionResult Create()
        {
            ViewBag.UserId = new SelectList(_context.User, "UserId", "UserName");
            return View();
        }

        // POST: Peoples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,CI,Name,LastName,SecondLastName,Gender,Phone,Address,Status,Email,RegisterDate,LastUpdate,UserId")] Person person)
        {
            if (ModelState.IsValid)
            {
                // Obtiene el UserId de la sesión
                int? userId = HttpContext.Session.GetInt32("UserId");
                string userRole = HttpContext.Session.GetString("UserRole"); // Agregar esta línea
                string randomUsername = GenerateRandomUsername(person.Name, person.LastName);
                string randomPassword = GenerateRandomPassword();

                if (userId.HasValue && userId > 0)
                {
                    // Asignar el UserId de la persona logueada a la persona que está siendo creada
                    person.UserId = userId.Value;
                    //person.Status = "1";
                    //person.RegisterDate = DateTime.Now;
                    // Generar un nombre de usuario aleatorio (puedes usar una función para esto

                    // Crear un nuevo usuario con los datos aleatorios

                    if (userRole == "Admin")
                    {
                        role = "Médico";
                    }
                    else
                    {
                        role = "Admin";
                    }


                    var user = new User
                    {
                        UserName = randomUsername,
                        Password = HashPassword(randomPassword),
                        Role = role
                    };

                    // Agregar el usuario a la base de datos
                    _context.User.Add(user);
                    await _context.SaveChangesAsync();

                    // Agregar la persona a la base de datos
                    _context.Person.Add(person);
                    await _context.SaveChangesAsync();

                    Send(user.UserName, randomPassword, person.Email);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Manejar errores si no se encuentra el UserId en la cookie o no se puede convertir a un valor válido.
                    // Por ejemplo, redirigir a una página de error o mostrar un mensaje de error en la vista.
                    ModelState.AddModelError(string.Empty, "Error al crear la persona. Inténtalo de nuevo.");
                }
            }
            return View(person);
        }

        // GET: Peoples/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.UserId = new SelectList(_context.User, "UserId", "UserName");
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }

            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: Peoples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonID,CI,Name,LastName,SecondLastName,Gender,Phone,Address,Status,Email,RegisterDate,LastUpdate,UserId")] Person person)
        {
            if (id != person.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: Peoples/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Peoples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Person == null)
            {
                return Problem("Entity set 'DB_Context.Person'  is null.");
            }
            var person = await _context.Person.FindAsync(id);
            if (person != null)
            {
                _context.Person.Remove(person);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
          return (_context.Person?.Any(e => e.PersonID == id)).GetValueOrDefault();
        }

        private string GenerateRandomUsername(string firstName, string lastName)
        {
            // Obtener las dos primeras letras del nombre y apellido
            string initials = (firstName.Length >= 2 ? firstName.Substring(0, 2) : firstName)
                            + (lastName.Length >= 2 ? lastName.Substring(0, 2) : lastName);

            // Buscar el número más alto actualmente en la base de datos o inicializarlo a 0 si no hay usuarios
            int maxNumber = _context.User
                .Where(u => u.UserName.StartsWith(initials))
                .Select(u => u.UserName.Substring(4)) // Extraer el número
                .AsEnumerable()
                .Select(u => int.TryParse(u, out int num) ? num : 0)
                .DefaultIfEmpty(0) // Inicializa a 0 si no hay elementos
                .Max();

            // Generar un nuevo número incrementado en 1
            int newNumber = maxNumber + 1;

            // Formatear el número con ceros a la izquierda
            string formattedNumber = newNumber.ToString("D4");

            // Combinar las iniciales y el número para formar el UserName
            string username = initials + formattedNumber;

            return username;
        }

        private string GenerateRandomPassword()
        {
            const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var random = new Random();

            // Generar una contraseña aleatoria de longitud máxima 8
            string password = new string(Enumerable.Repeat(allowedChars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return password;
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

        public string Send(string user, string password, string email)
        {
            string message = "";
            try
            {
                var person = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("colorinshopcontacto@gmail.com", "vapqpysxkwexunrc")
                };
                var emailS = new MailMessage("colorinshopcontacto@gmail.com", email);

                emailS.Subject = "Asunto: " + DateTime.Now.ToString();
                emailS.Body = "Usuario creado exitosamente\nusuario temporal es: " + user + "\ncontrasena temporal: " + password;
                person.Send(emailS);

                return message;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
