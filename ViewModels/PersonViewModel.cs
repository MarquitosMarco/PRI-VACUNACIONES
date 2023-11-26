using BarcodeQrScanner.Bases;
using BarcodeQrScanner.Models;
using BarcodeQrScanner.Pages;
using BarcodeQrScanner.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BarcodeQrScanner.ViewModels
{
    public class PersonViewModel : ViewModelBases, INotifyPropertyChanged
    {

        private readonly IPerson _personService;

        private RegisterVaccine _registerVaccine = new RegisterVaccine();

        public PersonViewModel(IPerson personService)
        {
            _personService = personService;
            SearchCommand = new AsyncCommand(SearchAsync);
            SaveCommand = new AsyncCommand(SaveAsync);
            //RecoverPetIDCommand = new MvvmHelpers.Commands.Command<int>(OnRecoverPetID);
        }

        private int selectedPetID;
        public int SelectedPetID
        {
            get => selectedPetID;
            set => SetProperty(ref selectedPetID, value);
        }

        public ICommand RecoverPetIDCommand { get; private set; }

        //private async void OnRecoverPetID(int petID)
        //{
        //    SelectedPetID = petID; // Asigna el PetID seleccionado
        //    await App.Current.MainPage.Navigation.PushAsync(new CreateVaccine());
        //}

        private int _id;
        public int ID
        {
            get => _id;
            set
            {
                SetProperty(ref _id, value);
            }
        }

        private string _namePet;
        public string NamePet
        {
            get => _namePet;
            set
            {
                SetProperty(ref _namePet, value);
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                SetProperty(ref _description, value);
            }
        }

        private DateTime _dateApplied;
        public DateTime DateApplied
        {
            get => _dateApplied;
            set
            {
                SetProperty(ref _dateApplied, value);
            }
        }

        private string _status;
        public string Status
        {
            get => _status;
            set
            {
                SetProperty(ref _status, value);
            }
        }

        private DateTime _lastUpdate;
        public DateTime LastUpdate
        {
            get => _lastUpdate;
            set
            {
                SetProperty(ref _lastUpdate, value);
            }
        }

        private int _userID;
        public int UserID
        {
            get => _userID;
            set
            {
                SetProperty(ref _userID, value);
            }
        }

        private int _petID;
        public int PetID
        {
            get => _petID;
            set
            {
                SetProperty(ref _petID, value);
            }
        }

        public ICommand SaveCommand { get; }

        private async Task SaveAsync()
        {
            try
            {
                // Crear una nueva instancia de RegisterVaccine y configurar sus propiedades
                RegisterVaccine newVaccine = new RegisterVaccine
                {
                    Name = "loa",
                    Description = "dqwd",
                    DateApplied = DateTime.Now, // Configura la fecha actual o la fecha deseada
                    Status = 1,
                    UserID = 6, // ID del usuario
                    PetID = 1, // ID de la mascota seleccionada
                    ControlVaccine = 1
                };

                // Llamamos al servicio para insertar la vacuna en la base de datos
                RegisterVaccine insertedVaccine = await _personService.CreateRegisterVaccine(newVaccine);

                if (insertedVaccine != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Éxito", "Registro de vacuna exitoso.", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Error al insertar registro de vacuna.", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar registro de vacuna: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error", "Error al insertar registro de vacuna.", "OK");
            }
        }

        // Propiedades del ViewModel
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _personId;
        public string PersonID
        {
            get => _personId;
            set
            {
                if (_personId != value)
                {
                    _personId = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _ci;
        public string CI
        {
            get => _ci;
            set
            {
                if (_ci != value)
                {
                    _ci = value;
                    OnPropertyChanged();
                }
            }
        }

        private List<Person> _people;
        public List<Person> People
        {
            get => _people;
            set
            {
                if (_people != value)
                {
                    _people = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _searchCI;
        public string SearchCI
        {
            get => _searchCI;
            set
            {
                if (_searchCI != value)
                {
                    _searchCI = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _mascotaID;
        public string MascotaID
        {
            get => _mascotaID;
            set
            {
                if (_mascotaID != value)
                {
                    _mascotaID = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SearchCommand { get; private set; }

        private async Task SearchAsync()
        {
            try
            {
                List<Person> people = await _personService.GetPeopleAsync();

                // Buscar la persona por CI
                Person foundPerson = people.FirstOrDefault(p => p.CI == SearchCI);

                if (foundPerson != null)
                {
                    // Obtener el ID de la persona encontrada
                    int personId = foundPerson.PersonID;

                    // Mostrar un mensaje con el ID de la persona encontrada
                    await Application.Current.MainPage.DisplayAlert("Éxito", $"Persona Encontrada:{personId}", "OK");

                    // Redirigir a una nueva página pasando el ID de la persona como parámetro
                    await App.Current.MainPage.Navigation.PushAsync(new GetData(personId));
                }
                else
                {
                    People = people;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al realizar la búsqueda: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error", "Error al realizar la búsqueda.", "OK");
            }
        }
    }
}
