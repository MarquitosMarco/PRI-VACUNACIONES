using BarcodeQrScanner.Models;
using BarcodeQrScanner.Pages;
using BarcodeQrScanner.Services;
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

        PersonService ps = new PersonService();


        try
        {
            // Reemplaza con el ID de la mascota que deseas obtener
            int petId = _id;

            // Llama al método para obtener la lista de DTOPet
            List<DTOPet> petList = await ps.ConsumeGetPetQRAsync(petId);

            // Realiza las actualizaciones de la interfaz de usuario con los datos recuperados
            if (petList != null && petList.Count > 0)
            {
                DTOPet pet = petList[0];

                PetNameLabel.Text = pet.petName;
                OwnerNameLabel.Text = pet.ownerName;
                CILabel.Text = pet.ci;
                SpecieLabel.Text = pet.specie;
                BreedLabel.Text = pet.breed;
                GenderLabel.Text = pet.gender;
                DescriptionLabel.Text = pet.description;

                var imageSources = new List<string>();

                // Asegúrate de que pet.photos contenga al menos 4 elementos antes de acceder a ellos.
                if (pet.photos != null && pet.photos.Count >= 0)
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
        catch (Exception ex)
        {
            // Maneja cualquier excepción que pueda ocurrir durante la solicitud
            // Puedes loguear el error, enviar notificaciones, etc.
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private async void CopyEditorText(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new CreateVaccine(_id));

    }
}