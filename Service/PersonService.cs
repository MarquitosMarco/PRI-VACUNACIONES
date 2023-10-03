using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using tag1.Model;

namespace tag1.Service
{
    public class PersonService : IPersonService
    {
        private readonly string _connectionString;

        public PersonService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Person> CreatePersonAsync(Person person)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string insertQuery = "INSERT INTO Person (ci, name, lastName, secondLastName, gender, phone, address, status, registerDate, lastUpdate, userID) " +
                                         "VALUES (@ci, @Nombre, @Apellido, @SegundoApellido, @Genero, @Telefono, @Direccion, @Estado, @FechaRegistro, @UltimaActualizacion, @UserID);";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.Add("@ci", SqlDbType.NVarChar).Value = person.CI;
                        command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = person.Nombre;
                        command.Parameters.Add("@Apellido", SqlDbType.NVarChar).Value = person.Apellido;
                        command.Parameters.Add("@SegundoApellido", SqlDbType.NVarChar).Value = person.SegundoApellido;
                        command.Parameters.Add("@Genero", SqlDbType.NVarChar).Value = person.Genero;
                        command.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = person.Telefono;
                        command.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = person.Direccion;
                        command.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = person.Estado;
                        command.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = person.FechaRegistro;
                        command.Parameters.Add("@UltimaActualizacion", SqlDbType.DateTime).Value = person.UltimaActualizacion;
                        command.Parameters.Add("@UserID", SqlDbType.Int).Value = person.UserID;

                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        if (rowsAffected > 0)
                        {
                            // La inserción fue exitosa
                            return person;
                        }
                        else
                        {
                            // Hubo un problema en la inserción
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones aquí
                throw ex;
            }
        }
    }
}
