namespace WaXercise.Models
{
    public class JobPeriod
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public People? People{ get; set; }
        public int PeopleId { get; set; }
        public Compagny? Compagny { get; set; }
        public int WorkId { get; set; }
    }
}
