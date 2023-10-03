using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using tag1.Base;
using tag1.Model;
using tag1.Service;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace tag1.ViewModel
{

    public class PersonViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private readonly IPersonService _personService;

        public PersonViewModel()
        {
            // Configura la cadena de conexión aquí. Reemplaza "TU_CADENA_DE_CONEXION" con la cadena real.
            string connectionString = "Server=LAPTOP-9UAT53QV\\SQLEXPRESS; Database=PRIVacunaciones;User=sa; Password=Univalle; Trusted_Connection=true; Encrypt=False;"; // Tu cadena de conexión a SQL Server

            _personService = new PersonService(connectionString);
            CreatePersonCommand = new Command(async () => await CreatePersonAsync());
        }


        private string _nombre;
        public string Nombre
        {
            get => _nombre;
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged(nameof(Nombre));
                }
            }
        }

        private string _apellido;
        public string Apellido
        {
            get => _apellido;
            set
            {
                if (_apellido != value)
                {
                    _apellido = value;
                    OnPropertyChanged(nameof(Apellido));
                }
            }
        }

        private string _segundoApellido;
        public string SegundoApellido
        {
            get => _segundoApellido;
            set
            {
                if (_segundoApellido != value)
                {
                    _segundoApellido = value;
                    OnPropertyChanged(nameof(SegundoApellido));
                }
            }
        }

        private string _genero;
        public string Genero
        {
            get => _genero;
            set
            {
                if (_genero != value)
                {
                    _genero = value;
                    OnPropertyChanged(nameof(Genero));
                }
            }
        }

        private string _Ci;
        public string CI
        {
            get => _Ci;
            set
            {
                if (_Ci != value)
                {
                    _Ci = value;
                    OnPropertyChanged(nameof(CI));
                }
            }
        }

        private string _telefono;
        public string Telefono
        {
            get => _telefono;
            set
            {
                if (_telefono != value)
                {
                    _telefono = value;
                    OnPropertyChanged(nameof(Telefono));
                }
            }
        }

        private string _direccion;
        public string Direccion
        {
            get => _direccion;
            set
            {
                if (_direccion != value)
                {
                    _direccion = value;
                    OnPropertyChanged(nameof(Direccion));
                }
            }
        }

        private string _estado;
        public string Estado
        {
            get => _estado;
            set
            {
                if (_estado != value)
                {
                    _estado = value;
                    OnPropertyChanged(nameof(Estado));
                }
            }
        }

        private DateTime _fechaRegistro;
        public DateTime FechaRegistro
        {
            get => _fechaRegistro;
            set
            {
                if (_fechaRegistro != value)
                {
                    _fechaRegistro = value;
                    OnPropertyChanged(nameof(FechaRegistro));
                }
            }
        }

        private DateTime _ultimaActualizacion;
        public DateTime UltimaActualizacion
        {
            get => _ultimaActualizacion;
            set
            {
                if (_ultimaActualizacion != value)
                {
                    _ultimaActualizacion = value;
                    OnPropertyChanged(nameof(UltimaActualizacion));
                }
            }
        }

        private int _userID;
        public int UserID
        {
            get => _userID;
            set
            {
                if (_userID != value)
                {
                    _userID = value;
                    OnPropertyChanged(nameof(UserID));
                }
            }
        }

        public ICommand CreatePersonCommand { get; private set; }

        private async Task CreatePersonAsync()
        {


            var nuevaPersona = new Person
            {
                CI = CI,
                Nombre = Nombre,
                Apellido = Apellido,
                SegundoApellido = SegundoApellido,
                Genero = Genero,
                Telefono = Telefono,
                Direccion = Direccion,
                Estado = Estado,
                FechaRegistro = DateTime.Now,
                UltimaActualizacion = DateTime.Now,
                UserID = 1
            };

            // No hay errores de validación, intenta crear la persona
            Person createdPerson = await _personService.CreatePersonAsync(nuevaPersona);

            if (createdPerson != null)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Persona creada correctamente.", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo crear la persona. Inténtalo de nuevo.", "OK");
            }
        }
    }

   



}
