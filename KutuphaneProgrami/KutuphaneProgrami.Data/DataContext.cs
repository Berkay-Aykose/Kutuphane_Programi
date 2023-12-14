using KutuphaneProgrami.Data.Model;
using System.Data.Entity;

namespace KutuphaneProgrami.Data
{
    public class DataContext : DbContext
    {

        public DataContext() : base("DataContext")
        {

        }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<OduncKitap> OduncKitaplar { get; set; }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        
    }
}
