namespace WardrobeApi.Data.Models.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using WardrobeApi.Shared.Enums;

    public class ClothingItemDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = default!;

        [Required]
        public ItemType Type { get; set; } = default!;

        [MaxLength(50)]
        public string? Brand { get; set; } = default!;

        public Color? Color { get; set; }

        [MaxLength(50)]
        public string? Size { get; set; }
    }
}
