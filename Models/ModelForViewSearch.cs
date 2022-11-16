using System.Collections.Generic;

namespace SecureItem.Models
{
    public class ModelForViewSearch
    {
        public int dangerId { get; set; }
        public string NameOfAsset { get; set; }

        public string AssetOwner { get; set; }

        public string AssetLocation { get; set; }

        public string AssetCategory { get; set; }

        public string Danger { get; set; }

        public string DangerAncor { get; set; }

        public List<string> DangerActions { get; set; }
    }
}
