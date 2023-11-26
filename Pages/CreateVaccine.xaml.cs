using BarcodeQrScanner.Models;
using BarcodeQrScanner.Services;

namespace BarcodeQrScanner.Pages;

public partial class CreateVaccine : ContentPage
{
    private PersonService _personService;
  
    public event EventHandler<List<PersonData>> PersonDataUpdated;

    int _peId;
    public CreateVaccine( int peId)
    {
        InitializeComponent();

        _personService = new PersonService();
  
        _peId = peId;

        LoadNamePet(_peId);

    }

    private async void LoadNamePet(int campaignId)
    {
      

        var campaign = await _personService.GetPetNameById(campaignId);

        if (campaign != null)
        {
            // Asigna los detalles de la campaña a los controles del formulario de edición.
            NamePet.Text = campaign.name;
       

        }
    }

    private async void GuardarRegistro_Clicked(object sender, EventArgs e)
    {
        // Crea un objeto de tipo RegisterVaccine con los datos que deseas guardar
        RegisterVaccine registro = new RegisterVaccine
        {
 
            Name = NamePet.Text,
            Description = Description.Text,
            DateApplied = DateTime.Now, 
            Status = 1, 
            UserID = 1, 
            PetID = _peId, 
            ControlVaccine = 1
        };

        // Llama al método para crear el registro de la vacuna
        RegisterVaccine result = await _personService.CreateRegisterVaccine(registro);

        if (result != null)
        {
            await DisplayAlert("Éxito", "El registro de la vacuna se ha guardado correctamente.", "OK");
  
          
            await Navigation.PopAsync();
        
        }
        else
        {
            await DisplayAlert("Error", "No se pudo guardar el registro de la vacuna.", "OK");
            // Maneja el caso en que no se pudo guardar el registro
        }
    }

    private async void Volver_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }



}