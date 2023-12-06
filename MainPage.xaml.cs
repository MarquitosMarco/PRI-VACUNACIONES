using BarcodeQrScanner.Services;
using BarcodeQrScanner.ViewModels;
using BarcodeQrScanner.Pages;

namespace BarcodeQrScanner;

public partial class MainPage : ContentPage
{
    string PhotoPath = "";
    BarcodeQRCodeService _barcodeQRCodeService;

    public MainPage()
	{
		InitializeComponent();
        InitService();
        var personService = new PersonService(); // Reemplaza con tu implementación de IPerson
        var viewModel = new PersonViewModel(personService);
        BindingContext = viewModel;
    }

    async void OnTakePhotoButtonClicked(object sender, EventArgs e)
    {
        try
        {

            FileResult photo = null;
            if (DeviceInfo.Current.Platform == DevicePlatform.WinUI || DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst)
            {
                photo = await FilePicker.PickAsync();
            }
            else if (DeviceInfo.Current.Platform == DevicePlatform.Android || DeviceInfo.Current.Platform == DevicePlatform.iOS)
            {
                photo = await MediaPicker.CapturePhotoAsync();
            }

            await LoadPhotoAsync(photo);
            Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
        }
        catch (FeatureNotSupportedException fnsEx)
        {
            // Feature is not supported on the device
        }
        catch (PermissionException pEx)
        {
            // Permissions not granted
        }
        catch (Exception ex)
        {
            Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
        }
    }

    async Task LoadPhotoAsync(FileResult photo)
    {
        // canceled
        if (photo == null)
        {
            PhotoPath = null;
            return;
        }
        // save the file into local storage
        var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
        using (var stream = await photo.OpenReadAsync())
        using (var newStream = File.OpenWrite(newFile))
            await stream.CopyToAsync(newStream);

        PhotoPath = newFile;

        await Navigation.PushAsync(new PicturePage(PhotoPath, _barcodeQRCodeService));
    }

    private async void InitService()
    {
        await Task.Run(() =>
        {
            _barcodeQRCodeService = new BarcodeQRCodeService();
            try
            {
                _barcodeQRCodeService.InitSDK("DLS2eyJoYW5kc2hha2VDb2RlIjoiMTAyMzQ1OTg3LVRYbE5iMkpwYkdWUWNtOXFYMlJpY2ciLCJtYWluU2VydmVyVVJMIjoiaHR0cHM6Ly9tZGxzLmR5bmFtc29mdG9ubGluZS5jb20iLCJvcmdhbml6YXRpb25JRCI6IjEwMjM0NTk4NyIsInN0YW5kYnlTZXJ2ZXJVUkwiOiJodHRwczovL3NkbHMuZHluYW1zb2Z0b25saW5lLmNvbSIsImNoZWNrQ29kZSI6LTE3NzQzNTgzOTF9");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }

            return Task.CompletedTask;
        });
    }

    async void OnTakeVideoButtonClicked(object sender, EventArgs e)
    {
        if (DeviceInfo.Current.Platform == DevicePlatform.WinUI || DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst)
        {
            await Navigation.PushAsync(new DesktopCameraPage());
            return;
        }

            var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
        if (status == PermissionStatus.Granted)
        {
            await Navigation.PushAsync(new CameraPage());
        }
        else
        {
            status = await Permissions.RequestAsync<Permissions.Camera>();
            if (status == PermissionStatus.Granted)
            {
                await Navigation.PushAsync(new CameraPage());
            }
            else
            {
                await DisplayAlert("Permission needed", "I will need Camera permission for this action", "Ok");
            }
        }
    }


    async void TakeVideoButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewCamera());
    }

    private void OnIngresarButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new GetData(7));
    }


}

