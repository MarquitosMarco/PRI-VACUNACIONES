namespace Login1.Login;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        // L�gica para manejar el inicio de sesi�n
        // Por ejemplo, puedes verificar el nombre de usuario y la contrase�a aqu�
    }

    private async void OnForgotPasswordTapped(object sender, EventArgs e)
    {
        // Navegar a la p�gina de recuperaci�n de contrase�a cuando se hace clic en "Olvido su contrase�a? Recuperela!"
        await Navigation.PushAsync(new CambioContrase�a());
    }
}