using BarcodeQrScanner.Models;
using BarcodeQrScanner.Pages;
using System;

namespace BarcodeQrScanner;

public partial class GetDataPet : ContentPage
{
    int _id;
    public GetDataPet(int id)
    {
        InitializeComponent();
        _id = id;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Llama al servicio web para obtener los datos de la mascota
        int petId = _id; // Reemplaza con el ID de la mascota que deseas obtener

        using (HttpClient client = new HttpClient())
        {
            string apiUrl = "https://localhost:44313/PetPass/Pets/GetPetQR?id=" + petId; // Reemplaza con la URL de tu servicio
            string json = await client.GetStringAsync(apiUrl);

            // Deserializa el JSON en un objeto DTOPet
            DTOPet pet = Newtonsoft.Json.JsonConvert.DeserializeObject<DTOPet>(json);

            // Actualiza los elementos de la interfaz de usuario con los datos recuperados
            PetNameLabel.Text = pet.petName;
            OwnerNameLabel.Text = pet.ownerName;
            CILabel.Text = pet.ci;
            SpecieLabel.Text = pet.specie;
            BreedLabel.Text = pet.breed;
            GenderLabel.Text = pet.gender;
            DescriptionLabel.Text = pet.description;

            var imageSources = new List<string>();

            // Asegúrate de que pet.photos contenga al menos 4 elementos antes de acceder a ellos.
            if (pet.photos.Count >= 4)
            {
                imageSources.Add(pet.photos[0]);
                imageSources.Add(pet.photos[1]);
                imageSources.Add(pet.photos[2]);
                imageSources.Add(pet.photos[3]);

                // Asigna las imágenes a los elementos Image
                Image1.Source = ImageSource.FromUri(new Uri(imageSources[0]));
                Image2.Source = ImageSource.FromUri(new Uri(imageSources[1]));
                Image3.Source = ImageSource.FromUri(new Uri(imageSources[2]));
                Image4.Source = ImageSource.FromUri(new Uri(imageSources[3]));
            }
        }
    }

    private async void CopyEditorText(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new CreateVaccine(_id));

    }
}