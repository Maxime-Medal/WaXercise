using System.Data;
using WaXercise.Services.Interfaces;

namespace WaXercise.Services
{
    public class PeopleService : IPeopleService
    {
        public bool IsAgeIsValid(DateTime dateOfBirth, int maxValue)
        {
            //date = date.Replace("/", "");
            //DateTime dateOfBirth = DateTime.ParseExact(date.ToString(), "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
            int age = GetAge(dateOfBirth);

            return age <= maxValue;
        }

        public int GetAge(DateTime dateOfBirth)
        {
            DateTime dateNow = DateTime.Now;

            int age = dateNow.Year - dateOfBirth.Year;

            if (dateNow < dateOfBirth.AddYears(age)) // Vérifie si l'anniversaire de cette année est déjà passé
            {
                age--;
            }

            return age;
        }

    }
}
