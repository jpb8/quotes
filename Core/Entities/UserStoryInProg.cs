namespace Core.Entities
{
    public class UserStoryInProg
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Division { get; set; }
        public string ServiceDiscipline { get; set; }
        public decimal Discovery { get; set; }
        public decimal Design { get; set; }
        public decimal Implementation { get; set; }
        public decimal Test { get; set; }
        public string ResourceType { get; set; }
    }
}