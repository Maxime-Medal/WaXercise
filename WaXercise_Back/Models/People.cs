namespace WaXercise.Models
{
    public class People
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Compagny>? Compagnies { get; set; }
        //public List<JobPeriod>? JobsPeriods { get; set; }
    }
}
