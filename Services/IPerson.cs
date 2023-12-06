using BarcodeQrScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeQrScanner.Services
{
    public interface IPerson
    {
        Task<List<Person>> GetPeopleAsync();
        Task<List<PersonData>> GetPersonAndPetData(int idPerson);
        Task<RegisterVaccine> CreateRegisterVaccine(RegisterVaccine person);
        Task<Pet> GetPetNameById(int petID);
     
    }
}
