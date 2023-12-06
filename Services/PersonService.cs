using BarcodeQrScanner.Models;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Net.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeQrScanner.Services
{
    public class PersonService : IPerson
    {


        private readonly HttpClient _httpClient;
        private readonly string _connectionStringCarnetizacion = "Server=DbPetPass.mssql.somee.com; Database=DbPetPass;User=nahuubj_SQLLogin_1; Password=z5qp9mphxt; Trusted_Connection=false; Encrypt=False;";
        private readonly string _connectionStringVacunacion = "Server=DESKTOP-P03JJMU\\SQLEXPRESS; Database=BDDvacunacion;User=sa; Password=univalle; Trusted_Connection=false; Encrypt=False;";

       // private readonly string _connectionStringVacunacion = "Server=DESKTOP-P03JJMU\\SQLEXPRESS;Database=BDDvacunacion;User ID=sa;Password=univalle;Trusted_Connection=False;Encrypt=True;";



        public PersonService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44313/"); // Reemplaza con la URL correcta
        }

        public async Task<RegisterVaccine> CreateRegisterVaccine(RegisterVaccine vaccine)
        {
            using (SqlConnection connection = new SqlConnection(_connectionStringVacunacion))
            {
                await connection.OpenAsync();

                string sql = "INSERT INTO [BDDvacunacion].[dbo].[Vaccine] " +
                             "( [name], [description], [dateApplied], [status], [userID], [petID], [controlVaccine]) " +
                             "VALUES ( @Name, @Description, @DateApplied, @Status, @UserID, @PetID,@Control);";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.Parameters.AddWithValue("@Name", vaccine.Name);
                    command.Parameters.AddWithValue("@Description", vaccine.Description);
                    command.Parameters.AddWithValue("@DateApplied", vaccine.DateApplied);
                    command.Parameters.AddWithValue("@Status", vaccine.Status);
                    command.Parameters.AddWithValue("@UserID", vaccine.UserID);
                    command.Parameters.AddWithValue("@PetID", vaccine.PetID);
                    command.Parameters.AddWithValue("@Control", vaccine.ControlVaccine);

                    // Ejecuta la consulta y devuelve el ID del registro recién insertado
                    command.ExecuteNonQuery();
                }
                return vaccine;
            }
        }



        public async Task<List<Person>> GetPeopleAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("PetPass/People"); // Ruta correcta de la API GET

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(content))
                    {
                        Console.WriteLine("La respuesta del servidor está vacía.");
                        return null;
                    }

                    var people = JsonConvert.DeserializeObject<List<Person>>(content);
                    return people;
                }
                else
                {
                    Console.WriteLine($"Error al obtener la lista de personas. Código de estado HTTP: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la lista de personas: {ex.Message}");
                return null;
            }
        }



        public async Task<List<PersonData>> GetPersonAndPetData(int idPerson)
        {
            List<PersonData> dataPerson = new List<PersonData>();

            using (SqlConnection connection = new SqlConnection(_connectionStringCarnetizacion))
            {
                await connection.OpenAsync();

                // string sql = "SELECT [name], [specie],[breed],[gender] FROM [Pet] WHERE personID = @id";
                string sql = "SELECT p.[name] AS PersonName, p.[firstName], p.[lastName], " +
                "pet.[name], pet.[specie], pet.[breed], pet.[gender], pet.[petID] " +
                "FROM [Person] AS p " +
                "INNER JOIN [Pet] AS pet ON p.personID = pet.personID " +
                "WHERE p.personID = @id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Agregar el parámetro idPerson
                    command.Parameters.AddWithValue("@id", idPerson);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            PersonData personData = new PersonData
                            {
                                Name = reader.GetString(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                NamePet = reader.GetString(3),
                                Species = reader.GetString(4),
                                Breed = reader.GetString(5),
                                Gender = reader.GetString(6),
                                MascotaID = reader.GetInt32(7),
                                Visibility = true
                            };
                            dataPerson.Add(personData);
                        }
                    }
                }
            }

            return dataPerson;
        }

        public async Task<Pet> GetPetNameById(int petID)
        {
            Pet pet = null;

            using (SqlConnection connection = new SqlConnection(_connectionStringCarnetizacion))
            {
                connection.Open();

                string query = "SELECT [name] FROM [Pet] WHERE [petID] = @PetID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@PetID", petID));

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            string petName = reader["name"].ToString();
                            pet = new Pet { name = petName };
                        }
                    }
                }
            }

            return pet;
        }

        public async Task<List<DTOPet>> ConsumeGetPetQRAsync(int petId)
        {
            string apiUrl = "https://localhost:44313/PetPass/Pets"; // Reemplaza esto con la URL de tu API

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"{apiUrl}/GetPetQR?id={petId}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();

                        List<DTOPet> petList = JsonConvert.DeserializeObject<List<DTOPet>>(responseContent);

                        return petList;
                    }
                    else
                    {
                        Console.WriteLine("No se pudieron obtener los datos de las mascotas.");
                        return new List<DTOPet>();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al consumir la API: {ex.Message}");
                    return new List<DTOPet>();
                }
            }
        }

        public async Task<int> LoginAsync(string username, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionStringVacunacion))
                {
                    await connection.OpenAsync();

                    // Reemplaza 'TuTablaUsuarios' y 'TuColumnaPassword' con los nombres reales de tu tabla y columnas
                    string query = "SELECT COUNT(*) FROM Users WHERE userName = @userName AND Password = @password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@userName", username));
                        command.Parameters.Add(new SqlParameter("@password", password));

                        // ExecuteScalarAsync devuelve la primera columna de la primera fila como un objeto
                        object result = await command.ExecuteScalarAsync();

                        // Verifica el resultado y devuelve el estado apropiado
                        if (result != null && int.TryParse(result.ToString(), out int rowCount))
                        {
                            // Si rowCount es 1, el inicio de sesión es exitoso; de lo contrario, es fallido
                            return rowCount == 1 ? 1 : 0;
                        }
                        else
                        {
                            // Ocurrió un error durante la consulta o el proceso de autenticación
                            return -1;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Maneja o registra la excepción
                Console.WriteLine($"Excepción SQL: {ex.Message}");
                return -1; // o lanza la excepción si deseas propagarla
            }
        }

    }







}
