namespace RealEstates.Services.Interfaces
{
    public interface ITagService
    {
        void Add(string name, int? importance = null);

        void BulkTagToPropertiesRelation();
    }
}
