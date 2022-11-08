using System.ComponentModel.DataAnnotations;

namespace SecureItem.Models
{
    public class IntegritySecureData
    {
        [Key]
        public int dangerId { get; set; }

        [Required]
        public string NameOfAsset { get; set; }

        [Required]
        public string AssetOwner { get; set; }

        [Required]
        public string AssetLocation { get; set; }

        [Required]
        public string AssetCategory { get; set; }

        [Required]
        public string Danger { get; set; }

        [Required]
        public string DangerAncor { get; set; }

        [Required]
        public string DangerAction { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
