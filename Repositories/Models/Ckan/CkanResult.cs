using System.Collections.Generic;

namespace InnovativeSoftware.Repositories.Models.Ckan
{
    public class CkanResult<TItem>
    {
        public string Sql { get; set; }
        public ICollection<CkanField> Fields { get; set; }
        public ICollection<TItem> Records { get; set; }
    }
}