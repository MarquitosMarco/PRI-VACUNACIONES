namespace Tag_Uno;

using System.Formats.Asn1;
using System.Timers;
using Tag_Uno.Resources.Tools;

public partial class MainPage : ContentPage
{
    private int failedLoginAttempts = 0; // Contador de intentos fallidos
    private bool isLoginButtonDisabled = false;
    private string user1 = "nando";
    private string password = "123";

    public MainPage()
	{
        InitializeComponent();


    }

    private async void IngresarButton_Clicked(object sender, EventArgs e)
    {

        if (isLoginButtonDisabled)
        {
            await DisplayAlert("Máximo de Intentos", "Por favor, espere 30 segundos antes de intentar de nuevo.", "OK");
            return;
        }

        // Realiza la lógica de autenticación aquí
        // Simplemente compara el usuario y la contraseña ingresados con los válidos
        string nombreUsuarioIngresado = name_user_Entry.Text;
        string contraseñaIngresada = password_Entry.Text;
        string lugar = myPicker.SelectedItem as string;
        string mensaje;

        List<string> errors = ValidationForm.ValidateForm(nombreUsuarioIngresado, contraseñaIngresada, lugar);
        if (errors.Count > 0)
        {
            mensaje = string.Join("\n", errors);
            validationLabel.Text = mensaje;
        }
        else
        {

            if (nombreUsuarioIngresado == user1 && contraseñaIngresada == password)
            {
                await DisplayAlert("Éxito", "¡Bienvenido!", "OK");
                name_user_Entry.Text = "";
                password_Entry.Text = "";
                myPicker.SelectedItem = null;
                validationLabel.Text = "";
                failedLoginAttempts = 0;
            }

            else
            {
                failedLoginAttempts++;
                validationLabel.Text = "";
                name_user_Entry.Text = "";
                password_Entry.Text = "";
                myPicker.SelectedItem = null;
                await DisplayAlert("Error", "Credenciales incorrectas. Intentos restantes: " + (3 - failedLoginAttempts), "OK");

                if (failedLoginAttempts >= 3)
                {
                    validationLabel.Text = "";
                    // Si se han superado los tres intentos fallidos, bloquea el botón utilizando la función BloquearBotonDuranteTiempo
                    await DisplayAlert("Error", "Intentelo de nuevo dentro de 30sg", "OK");
                    TimeSpan tiempoDeBloqueo = TimeSpan.FromSeconds(30); // 30 segundos de bloqueo
                    await BloquearBotonDuranteTiempo(tiempoDeBloqueo);
                    failedLoginAttempts = 0;
                    name_user_Entry.Text = "";
                    password_Entry.Text = "";
                    myPicker.SelectedItem = null;

                }
            }

        }

    }

    private async Task BloquearBotonDuranteTiempo(TimeSpan tiempoDeBloqueo)
    {
        // Deshabilita el botón de inicio de sesión
        isLoginButtonDisabled = true;
        IngresarButton.IsEnabled = false;

        // Espera el tiempo de bloqueo
        await Task.Delay(tiempoDeBloqueo);

        // Habilita el botón de inicio de sesión después de que haya pasado el tiempo de bloqueo
        isLoginButtonDisabled = false;
        IngresarButton.IsEnabled = true;
    }



   
}

