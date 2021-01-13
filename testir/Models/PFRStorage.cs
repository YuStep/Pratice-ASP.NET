using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testir.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testir.Models
{
    public class PFRStorage
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Period { get; set; }

        public double Suma { get; set; }

        public int PersonId { get; set; }
        
        public Person Person { get; set; }

    }
}
