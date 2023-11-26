namespace BarcodeQrScanner;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //MainPage = new AppShell();

        MainPage = new NavigationPage(new LoginPage()); // Reemplaza IndexPage con el nombre de tu página
    }
}
