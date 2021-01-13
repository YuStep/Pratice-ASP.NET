using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testir.Models
{
    public class Filter
    {
        public IEnumerable<Person> Users { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
