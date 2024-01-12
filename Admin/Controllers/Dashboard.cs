using Admin.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Admin.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AdminContext _context; // Sesuaikan dengan DbContext Anda

        public DashboardController(AdminContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listOfApplicants = _context.Karir.ToList(); // Ambil data pelamar dari DbContext Anda

            int jumlahPelamar = listOfApplicants.Count; // Hitung jumlah pelamar

            // Ambil data produk dan transaksi (contoh yang sudah ada sebelumnya)
            var listOfProducts = _context.Produk.ToList();
            int totalProduk = listOfProducts.Sum(p => p.TotalProduk);

            var listOfTransactions = _context.Transaksi.ToList();
            int totalTransaksi = listOfTransactions.Sum(t => t.TotalHarga);
            int jumlahTransaksi = listOfTransactions.Count;

            ViewBag.TotalProduk = totalProduk;
            ViewBag.TotalTransaksi = totalTransaksi;
            ViewBag.JumlahTransaksi = jumlahTransaksi;
            ViewBag.JumlahPelamar = jumlahPelamar; // Kirim jumlah pelamar ke tampilan

            return View(listOfProducts); // Kirimkan data produk ke tampilan
        }

    }
}
