namespace WaXercise.Models
{
    public class Compagny
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public int PeopleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
