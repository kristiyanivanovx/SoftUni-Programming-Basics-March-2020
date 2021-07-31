namespace RealEstates.Models
{
    public class PropertyTag
    {
        public int PropertyId { get; set; }

        public Property Property { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }
    }
}
