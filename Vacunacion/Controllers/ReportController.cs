using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacunacion.Data;
using Vacunacion.Models;

namespace Vacunacion.Controllers
{
    public class ReportController : Controller
    {
        private readonly DB_Context _context;

        public ReportController(DB_Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {


            // Consulta LINQ para obtener los nombres de las vacunas y la fecha de aplicación
            var vaccineData = from registerVaccine in _context.RegisterVaccine
                              select new RegisterVaccine { Name = registerVaccine.Name, DateApplied = registerVaccine.DateApplied };

            // Convierte los resultados a una lista
            var vaccineList = vaccineData.ToList();

            // Realiza la consulta LINQ para obtener los nombres de las brigadas y el nombre de la campaña
            var brigadeData = from brigade in _context.Brigade
                              join campaign in _context.Campaign on brigade.CampaignId equals campaign.CampaignId
                              select new BrigadeCampaign { BrigadeName = brigade.Name, CampaignName = campaign.Name };

            // Convierte los resultados a una lista
            var brigadeList = brigadeData.ToList();

            var personRoles = from person in _context.Person
                              join user in _context.User on person.UserId equals user.UserId
                              select new PersonRol
                              {
                                  FullName = $"{person.Name} {person.LastName} {person.SecondLastName}",
                                  Role = user.Role
                              };



            var personRolesList = personRoles.ToList();

            // Pasar los datos a la vista
            ViewBag.Persons = personRolesList;
       

            // Pasa las listas a la vista
            ViewBag.VaccineData = vaccineList;
            ViewBag.BrigadeData = brigadeList;

            return View();
        }
        public IActionResult PersonReport()
        {
            var personRoles = from person in _context.Person
                              join user in _context.User on person.UserId equals user.UserId
                              select new PersonRol
                              {
                                  FullName = $"{person.Name} {person.LastName} {person.SecondLastName}",
                                  Role = user.Role
                              };

            var personRolesList = personRoles.ToList();

            // Pasar los datos a la vista
            ViewBag.Persons = personRolesList;

            return View("PersonReport"); // Suponiendo que tienes una vista llamada "Person.cshtml"
        }



    }
}
