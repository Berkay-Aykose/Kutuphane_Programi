using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KutuphaneProgrami.Data.Model
{
    public class Uye : BaseEntity
    {
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(20)]
        public String Ad { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(20)]
        public string Soyad { get; set; }


        [Column(TypeName = "char")]
        [MaxLength(11)]
        [MinLength(11)]
        public string Tc { get; set; }


        [Column(TypeName = "char")]
        [MaxLength(11)]
        [MinLength(11)]
        public string Tel { get; set; }

        [Required]
        public DateTime KayiTarihi { get; set; }


        [Column(TypeName ="nvarchar")]
        [MaxLength(50)]
        [MinLength(50)]
        public string Mail { get; set; }


        public string Sifre { get; set; }


        [Required]
        public int Ceza { get; set; }

        [Column(TypeName ="char")]
        [MaxLength(1)]
        [MinLength(1)]
        public string Yetki { get; set; }

        public virtual List<OduncKitap> OduncKitaplar { get; set; }
    }
}
