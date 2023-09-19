using tag1.Resources.Tools;

namespace tag1;

public partial class MainPage : ContentPage
{
    string user1 = "nando";
    string password1 = "123";
   

    public MainPage()
	{
		InitializeComponent();
       
    }
    private async void Validate_Clicked(object sender, EventArgs e)
    {
        // Obtener los valores de los campos
        string username = name_user_Entry.Text;
        string password = password_Entry.Text;
        string newPassword = new_password_Entry.Text;
        string confirmedPassword = confirmed_password_Entry.Text;

        // Realizar la validación utilizando la clase PasswordValidator
        List<string> validationErrors = ValidationForm.ValidatePassword(username, password, newPassword, confirmedPassword);

        if (validationErrors.Count > 0)
        {
            // Mostrar los errores en el label de validación
            validationLabel.Text = string.Join(Environment.NewLine, validationErrors);
        }
        else if (user1 != username)
        {
            validationLabel.Text = "No se encuentra ningún usuario en la BDD.";
        }
        else if (password1 != password)
        {
            validationLabel.Text = "Contraseña Incorrecta.";
        }
        else if (user1 == username && password1 == password)
        {
            validationLabel.Text = "";
            await DisplayAlert("Contraseña Valida", "Confirme la contraseña", "OK");
            confirmed_password_Entry.IsEnabled = true;
            ButtonRegister.IsEnabled = true;
        }
    }
    private async void Register_Clicked(object sender, EventArgs e)
    {
        string newPassword = new_password_Entry.Text;
        string confirmedPassword = confirmed_password_Entry.Text;
        List<string> validationErrors = ValidationForm.Validate_New_Password(newPassword, confirmedPassword);

        // Verificar si hubo errores de validación
        if (validationErrors.Count > 0)
        {
            // Mostrar los errores en el label de validación
            validationLabel.Text = string.Join(Environment.NewLine, validationErrors);

        }
        else
        {
            validationLabel.Text = null;
            await DisplayAlert("Exito", "Contraseña actualizada", "OK");
            name_user_Entry.Text = null;
            password_Entry.Text = null;
            new_password_Entry.Text = null;
            confirmed_password_Entry.Text = null;
        }
    }


}

