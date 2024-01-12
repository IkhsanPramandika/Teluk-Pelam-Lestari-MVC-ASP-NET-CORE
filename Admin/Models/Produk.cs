using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class Produk
    {
        public int Id { get; set; }
        public string? Nama { get; set; }

        public string? Status { get; set; }
        public int TotalProduk { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
