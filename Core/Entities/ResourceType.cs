namespace Core.Entities
{
    public class ResourceType : BaseEntity
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public int HoursPerWeek { get; set; }
    }
}