using System.Runtime.CompilerServices;
using PRI_Vacunaciones.Services;
namespace PRI_Vacunaciones
{
    public partial class MainPage : ContentPage
    {
        //int count = 0;

        private readonly IPerson _person;
       

        public MainPage(IPerson service)
        {

            InitializeComponent();
            _person =
               service;

            cameraView.BarCodeOptions = new()
            {
                PossibleFormats = {ZXing.BarcodeFormat.QR_CODE,ZXing.BarcodeFormat.CODE_39 }//solo para qr
            };
                
        }
        //lista de camaras disponbles y reiniciar de que esta lista para su uso
        private void OnCameraButtonClicked(object sender, EventArgs e)
        {
            
           if(cameraView.Cameras.Count > 0)
            {
                cameraView.Camera = cameraView.Cameras.First();
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    //deten la camara si ya esta en uso
                    await cameraView.StopCameraAsync();
                    //Inicia la camara
                    await cameraView.StartCameraAsync();

                });
            }
           
        }
        //Metodo que detecta el codigo
        private void cameraView_BarcodeDetected(object sender,Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                barcodeResult.Text = $"{args.Result[0].BarcodeFormat}:{args.Result[0].Text}";
            });
        }
        //Metodo para la busqueda
        private async void OnSearchButtonPressed(object sender, EventArgs e)
        {
             string searchText = searchBar.Text;
       

        //    // Realiza aquí la lógica de búsqueda basada en el texto ingresado en el SearchBar
        //    // Puedes actualizar la interfaz de usuario o realizar otras acciones según tus necesidades

            DisplayAlert("Búsqueda", $"Realizando búsqueda: {searchText}", "Aceptar");
        }
        //Button para busqueda
        private void OnSearchButtonClicked(object sender, EventArgs e)
        {
            string searchText = searchBar.Text;


            // Realiza aquí la lógica de búsqueda basada en el texto ingresado en el SearchBar
            // Puedes actualizar la interfaz de usuario o realizar otras acciones según tus necesidades

            DisplayAlert("Búsqueda", $"Realizando búsqueda: {searchText}", "Aceptar");
        }

    }
}