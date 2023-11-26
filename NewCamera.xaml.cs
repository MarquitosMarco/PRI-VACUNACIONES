using BarcodeQrScanner.Pages;
using IronBarCode;

namespace BarcodeQrScanner;

public partial class NewCamera : ContentPage
{
    string num;
	public NewCamera()
	{
		InitializeComponent();
	}

    private async void SelectBarcode(object sender, EventArgs e)
    {
        var images = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Pick image",
            FileTypes = FilePickerFileType.Images
        });
        var imageSource = images.FullPath.ToString();
        barcodeImage.Source = imageSource;
        var result = BarcodeReader.Read(imageSource).First().Text;
        outputText.Text = result;
        num = result;

    }
    private async void CopyEditorText(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new GetDataPet(int.Parse("5")));

    }
}