using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testir.Models;
namespace testir
{
    public class SampleData
    {
        public static void Initialize(PersonContext context)
        {
            //Инициализация базовых данных
            if (!context.Persones.Any())
            {
                Person prs1 = new Person { Surname = "Ivanov", Name = "Ivan", Patronymic = "Ivanovich", BirthDate = DateTime.Parse("12.01.2001"), Snils = "123-456-789-12" };
                Person prs2 = new Person { Surname = "Olegov", Name = "Oleg", Patronymic = "Olegovich", BirthDate = DateTime.Parse("13.02.1982"), Snils = "123-456-789-13" };
                context.Persones.Add(prs1);
                context.Persones.Add(prs2);
                context.SaveChanges();

                context.Storages.Add(new PFRStorage { Period = 10, Suma = 123.32,PersonId = prs1.Id });
                context.Storages.Add(new PFRStorage { Period = 9, Suma = 132.11, PersonId = prs2.Id });

                context.SaveChanges();

            }
        }
    }
}
