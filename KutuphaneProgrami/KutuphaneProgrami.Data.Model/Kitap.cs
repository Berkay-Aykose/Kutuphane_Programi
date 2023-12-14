using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneProgrami.Data.Model
{
    public class Kitap : BaseEntity
    {
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(20)]
        public string Ad { get; set; }

        [Required] // boş bırakılamaz
        [Column(TypeName ="nvarchar")] //veri tipi
        [MaxLength(20)] // veri tepinin max uzunluğu
        public string SiraNo { get; set; }

        [Required]
        public int Adet { get; set; }

        [Required]
        public DateTime EklenmeTarihi { get; set; }

        [Required]
        public int YazarId { get; set; }

        public virtual Yazar Yazar { get; set; }

        public virtual List<Kategori> Kategoriler { get; set; }
        public virtual List<OduncKitap> OduncKitaplar { get; set; }
    }
}
