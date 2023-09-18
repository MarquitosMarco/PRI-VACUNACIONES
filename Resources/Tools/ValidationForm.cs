using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tag_Uno.Resources.Tools
{
    class ValidationForm
    {
        public static List<string> ValidateForm(string user, string password, string lugar)
        {
            List<string> errores = new List<string>();

         

            if (string.IsNullOrWhiteSpace(user))
            {
                errores.Add("El campo Usuario es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                errores.Add("El campo de Contraseña es obligatorio.");
            }


            if (string.IsNullOrWhiteSpace(lugar))
            {
                errores.Add("El campo de Lugar es obligatorio.");
            }

            // Continúa con las validaciones para los otros campos y agrega mensajes de error según sea necesario.

            return errores;
        }

        public static List<string> ValidatePassword(string user, string password, string newpassword, string confirmedpassword)
        {
            List<string> errores = new List<string>();



            if (string.IsNullOrWhiteSpace(user))
            {
                errores.Add("El campo Usuario es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                errores.Add("El campo de Contraseña es obligatorio.");
            }


            if (string.IsNullOrWhiteSpace(newpassword))
            {
                errores.Add("El campo de Nueva contraseña es obligatorio.");
            }
           
            
            if (!password.Any(char.IsDigit))
            {
                errores.Add("La contraseña nueva debe de contener un numero minimamente.");
            }
            if (!password.Any(char.IsUpper))
            {
                errores.Add("La contraseña nueva debe de contener una letra mayuscula minimamente.");
            }
            if (!string.IsNullOrEmpty(password) && password.Contains(" "))
            {
                errores.Add("La contraseña no debe contener espacios");
            }

            // Continúa con las validaciones para los otros campos y agrega mensajes de error según sea necesario.

            return errores;
        }

        public static List<string> Validate_New_Password(  string newpassword, string confirmedpassword)
        {
            List<string> errores = new List<string>();

            if (newpassword != confirmedpassword)
            {
                errores.Add("La contraseña nueva no coincide con la de confirmacion.");

            }
            if (string.IsNullOrWhiteSpace(confirmedpassword))
            {
                errores.Add("El campo de Confirmar contraseña  es obligatorio.");
            }

            return errores;
        }
    }
}
