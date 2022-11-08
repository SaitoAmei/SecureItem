using System.ComponentModel.DataAnnotations;

namespace SecureItem.Models
{
    public class DataModel
    {
        public int dangerId { get; set; }

        public string NameOfAsset { get; set; }

        public string AssetOwner { get; set; }

        public string AssetLocation { get; set; }

        public string AssetCategory { get; set; }

        public string Danger { get; set; }

        public string DangerAncor { get; set; }

        public string DangerAction { get; set; }
    }
}

