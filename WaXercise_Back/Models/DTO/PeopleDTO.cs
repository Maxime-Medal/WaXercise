namespace WaXercise.Models.DTO
{
    public class PeopleDTO
    {
                public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public virtual List<Compagny>? Compagnies { get; set; }

    }
}
