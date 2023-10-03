using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tag1.Model;

namespace tag1.Service
{
    public interface IPersonService
    {
        Task<Person> CreatePersonAsync(Person person);
    }
}
