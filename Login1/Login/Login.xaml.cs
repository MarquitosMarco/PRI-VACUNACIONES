namespace Login1.Login;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        // Lógica para manejar el inicio de sesión
        // Por ejemplo, puedes verificar el nombre de usuario y la contraseña aquí
    }

    private async void OnForgotPasswordTapped(object sender, EventArgs e)
    {
        // Navegar a la página de recuperación de contraseña cuando se hace clic en "Olvido su contraseña? Recuperela!"
        await Navigation.PushAsync(new CambioContraseña());
    }
}