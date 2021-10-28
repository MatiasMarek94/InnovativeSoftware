namespace InnovativeSoftware.Repositories.Models.Ckan
{
    public class Ckan<TItem>
    {
        public string Help { get; set; }
        public bool Success { get; set; }
        public CkanResult<TItem> Result { get; set; }
    }
}