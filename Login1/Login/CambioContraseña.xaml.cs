namespace Login1.Login;

public partial class CambioContraseña : ContentPage
{
	public CambioContraseña()
	{
		InitializeComponent();
	}

    private void OnConfirmButtonClicked(object sender, EventArgs e)
    {
        string newPassword = NewPasswordEntry.Text;
        string confirmPassword = ConfirmPasswordEntry.Text;
        string verificationCode = VerificationCodeEntry.Text;

        // Validar que la nueva contraseña tenga al menos 8 caracteres y al menos un número
        if (newPassword.Length < 8 || !newPassword.Any(char.IsDigit))
        {
            ErrorLabel.Text = "La contraseña debe tener al menos 8 caracteres y al menos un número.";
        }
        else if (newPassword != confirmPassword)
        {
            ErrorLabel.Text = "Las contraseñas no coinciden.";
        }
        else if (string.IsNullOrWhiteSpace(verificationCode))
        {
            ErrorLabel.Text = "Ingrese el código de verificación.";
        }
        else
        {
            // Realizar acciones para cambiar la contraseña aquí
            // Por ejemplo, puedes enviar la nueva contraseña y el código de verificación a tu servidor para su validación y cambio
            ErrorLabel.Text = "Contraseña cambiada con éxito.";
        }
    }
}