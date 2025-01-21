namespace WardrobeApi.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using WardrobeApi.Shared.Enums;

    public class ClothingItem
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = default!;

        [Required]
        public ItemType Type { get; set; } = default!;

        [MaxLength(50)]
        public string? Brand { get; set; } = default!;

        public Color? Color { get; set; }

        [MaxLength(50)]
        public string? Size { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<OutfitItem> OutfitItems { get; set; } = new List<OutfitItem>();
    }
}