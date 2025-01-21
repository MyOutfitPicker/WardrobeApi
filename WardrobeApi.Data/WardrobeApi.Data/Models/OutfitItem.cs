namespace WardrobeApi.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    [Keyless]
    public class OutfitItem
    {
        [ForeignKey("Outfit")]
        [Required]
        public int OutfitId { get; set; }

        public Outfit Outfit { get; set; } = default!;

        [ForeignKey("ClothingItem")]
        [Required]
        public int ClothingItemId { get; set; } = default!;

        public ClothingItem ClothingItem { get; set; } = default!;
    }
}