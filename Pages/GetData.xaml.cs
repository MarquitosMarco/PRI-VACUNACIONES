using BarcodeQrScanner.Models;
using BarcodeQrScanner.Services;
using Newtonsoft.Json;

namespace BarcodeQrScanner.Pages;

public partial class GetData : ContentPage
{
    private string mascotaIDValue = string.Empty;
   // private List<DTOPet> personDataList;

    public GetData(int id)
    {
        InitializeComponent();
        LoadPersonData(7);


      
    }




    private async void LoadPersonData(int id)
    {
        try
        {
            var personService = new PersonService();
            var personData = await ConsumeGetPetQRAsync(id);

            if (personData != null)
            {
                // Busca los Entry's en el archivo XAML por su nombre
                //var nameEntry = (Entry)FindByName("NameEntry");
                //var petNameEntry = (Entry)FindByName("PetNameEntry");

                // Asigna los valores a los Entry's
                //nameEntry.Text = personData.ownerName; // Asegúrate de usar el nombre correcto del campo
                //petNameEntry.Text = personData.petName; // Asegúrate de usar el nombre correcto del campo
                await DisplayAlert("Encontrado", "Persona Encontrada." + personData.ownerName + " " + personData.petName, "OK");
            }
            else
            {
                await DisplayAlert("Error", "No se encontraron datos para esta persona.", "OK");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar los datos de la persona: {ex.Message}");
            await DisplayAlert("Error", "Ocurrió un error al cargar los datos de la persona.", "OK");
        }
    }

    public async Task<DTOPet> ConsumeGetPetQRAsync(int petId)
    {
        string apiUrl = "https://localhost:44313/PetPass/Pets";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/GetPetQR?id={petId}");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    DTOPet petData = JsonConvert.DeserializeObject<DTOPet>(responseContent); // Cambiamos la deserialización



                    return petData;
                }
                else
                {
                    Console.WriteLine("No se pudieron obtener los datos de las mascotas.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consumir la API: {ex.Message}");
                return null;
            }
        }
    }






    private void OnCounterClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is int mascotaID)
        {
            string mascotaIDValue = mascotaID.ToString(); // Convierte el valor a string
            DisplayAlert("MascotaID Guardado", "El valor de MascotaID es: " + mascotaIDValue, "OK");
            //Navigation.PushAsync(new CreateVaccine(personDataList,mascotaID));
        }
        else
        {
            DisplayAlert("Error", "No se ha seleccionado un elemento válido.", "OK");
        }

    }

    private async void Volver_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}