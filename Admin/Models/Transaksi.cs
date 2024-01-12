namespace Admin.Models
{
    public class Transaksi
    {
        public int Id { get; set; }
        public string? NamaPembeli { get; set; }

        public string? Status { get; set; }
        public int TotalBeli { get; set; }

        public int TotalHarga { get; set; }

        public DateTime ReleaseDate { get; set; }

    }
}
    