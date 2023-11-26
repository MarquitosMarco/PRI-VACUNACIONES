using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeQrScanner.Models
{
    public class RegisterVaccine
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateApplied { get; set; }
        public int Status { get; set; }

        public int UserID { get; set; }
        public int PetID { get; set; }
        public int ControlVaccine {  get; set; }
    }
}
