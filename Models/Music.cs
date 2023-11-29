using System.ComponentModel.DataAnnotations;
namespace MusicShopStore.Models
{
    public class Music
    {
        public required int MusicId { get; set; }

        public required string Title { get; set; }

        public required string Artist { get; set; }

        public required string Genre { get; set; }

        public required decimal Price { get; set; }

    }
}
