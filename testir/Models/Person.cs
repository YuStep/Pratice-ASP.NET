using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace testir.Models
{
    public class Person
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Surname { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Patronymic { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [RegularExpression(@"^\d{3}-\d{3}-\d{3}-\d{2}$")]
        [Required]
        public string Snils { get; set; }

        public List<PFRStorage> PFRStorages { get; set; }

        public Person() { 
            PFRStorages = new List<PFRStorage>(); 
        }
    }
}
