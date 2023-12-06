using BarcodeQrScanner.Pages;
using BarcodeQrScanner.Services;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using System.Diagnostics;

namespace BarcodeQrScanner;

public partial class PicturePage : ContentPage
{
    string path;
    SKBitmap bitmap;
    BarcodeQRCodeService _barcodeQRCodeService;
    BarcodeQrData[] data = null;
    bool isDataReady = false;

    int _id;
    public PicturePage(string imagepath, BarcodeQRCodeService barcodeQRCodeService)
	{
		InitializeComponent();
        _barcodeQRCodeService = barcodeQRCodeService;
        path = imagepath;
        try
        {
            using (var stream = new SKFileStream(imagepath))
            {
                bitmap = SKBitmap.Decode(stream);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        DecodeFile(imagepath);
    }

    async void DecodeFile(string imagepath)
    {
        await Task.Run(() =>
        {
            data = _barcodeQRCodeService.DecodeFile(path);
            isDataReady = true;
            return Task.CompletedTask;
        });
        canvasView.InvalidateSurface();
    }

    // https://docs.microsoft.com/en-us/dotnet/api/skiasharp.views.maui.controls.skcanvasview?view=skiasharp-views-maui-2.88
    void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
    {
        if (!isDataReady)
        {
            return;
        }

        SKImageInfo info = args.Info;
        SKSurface surface = args.Surface;
        SKCanvas canvas = surface.Canvas;
        canvas.Clear();

        var imageCanvas = new SKCanvas(bitmap);

        float textSize = 18;
        float StrokeWidth = 2;

        if (DeviceInfo.Current.Platform == DevicePlatform.Android || DeviceInfo.Current.Platform == DevicePlatform.iOS)
        {
            textSize = (float)(18 * DeviceDisplay.MainDisplayInfo.Density);
            StrokeWidth = 4;
        }

        SKPaint skPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Blue,
            StrokeWidth = StrokeWidth,
        };

        SKPaint textPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Red,
            TextSize = textSize,
            StrokeWidth = StrokeWidth,
        };

        if (isDataReady)
        {
            if (data != null)
            {
                ResultLabel.Text = ""; // Limpia el texto existente

                string qrData = ""; // Variable para almacenar los datos del código QR

                foreach (BarcodeQrData barcodeQrData in data)
                {
                    qrData += barcodeQrData.text + "\n"; // Agrega los datos del código QR a la variable
                    if (DeviceInfo.Current.Platform == DevicePlatform.WinUI || DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst)
                    {
                        ResultLabel.Text += barcodeQrData.text + "\n";
                    }
                    imageCanvas.DrawText(barcodeQrData.text, barcodeQrData.points[0], textPaint);
                    imageCanvas.DrawLine(barcodeQrData.points[0], barcodeQrData.points[1], skPaint);
                    imageCanvas.DrawLine(barcodeQrData.points[1], barcodeQrData.points[2], skPaint);
                    imageCanvas.DrawLine(barcodeQrData.points[2], barcodeQrData.points[3], skPaint);
                    imageCanvas.DrawLine(barcodeQrData.points[3], barcodeQrData.points[0], skPaint);
                }

                // Ahora qrData contiene los datos del código QR que puedes utilizar como desees
                // Mostrar el mensaje en la consola de C#
                Console.WriteLine("Datos del código QR: " + qrData);

                // Mostrar el mensaje en la consola de depuración de Unity
           
                if (int.TryParse(qrData, out int parsedId))
                {
                    _id = parsedId;
                }
            }
            else
            {
                ResultLabel.Text = "No barcode QR code found";
            }
        }

        float scale = Math.Min((float)info.Width / bitmap.Width,
                                (float)info.Height / bitmap.Height);
        float x = (info.Width - scale * bitmap.Width) / 2;
        float y = (info.Height - scale * bitmap.Height) / 2;
        SKRect destRect = new SKRect(x, y, x + scale * bitmap.Width,
                                     y + scale * bitmap.Height);

        canvas.DrawBitmap(bitmap, destRect);
    }

    private void VerDatosButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new GetData(_id));
    }

    private async void Volver_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}