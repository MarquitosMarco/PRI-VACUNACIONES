using BarcodeQrScanner.Services;

namespace BarcodeQrScanner;

public partial class LoginPage : ContentPage
{

    PersonService ps;
    static int salida;

    public LoginPage()
	{
		InitializeComponent();
	}


    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {

        ps = new PersonService();
        salida = await ps.LoginAsync(txtUsername.Text, txtPassword.Text);

        if (salida > 0)
        {
            displayLabel.Text = "Entro al login";


            await Navigation.PushAsync(new MainPage());

        }
        else if (salida == 0)
        {
            displayLabel.Text = "No hay usuarios";
        }
        else { displayLabel.Text = "Error"; ; }




    }




    // Assuming this is the method where you are calling LoginAsync
    public async Task CompruebaLogin()
    {
        ps = new PersonService();   
        // Other code...

                    
                    salida = await ps.LoginAsync(txtUsername.Text, txtPassword.Text);
        string SALIDAmIA = salida.ToString();


        // Rest of your code...
    }

}