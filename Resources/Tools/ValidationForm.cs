using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace tag1.Resources.Tools
{
    public class ValidationForm
    {
        public static List<string> ValidatePassword(string username, string password, string newPassword, string confirmedPassword)
        {
            List<string> errors = new List<string>();

            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(username))
                errors.Add("El campo de usuario no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(password))
                errors.Add("El campo de contraseña actual no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                errors.Add("El campo de nueva contraseña no puede estar vacío.");
            }else if (newPassword.Length < 8)
            {
                errors.Add("La nueva contraseña debe tener al menos 8 caracteres.");
            }else if (!Regex.IsMatch(newPassword, @"^(?=.*[A-Z])(?=.*\d).+$"))
                errors.Add("La nueva contraseña debe contener al menos una letra mayúscula y un número.");

         

            return errors;
        }
        public static List<string> Validate_New_Password( string newPassword, string confirmedPassword)
        {
            List<string> errors = new List<string>();
            if (string.IsNullOrWhiteSpace(confirmedPassword))
            {
                errors.Add("El campo de confirmar contraseña no puede estar vacío.");
            }else if (newPassword != confirmedPassword)
                errors.Add("La nueva contraseña y la confirmación no coinciden.");
            return errors;
        }
    }
}
