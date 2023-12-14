using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneProgrami.Data.Model
{
    public class Kategori : BaseEntity
    {
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(20)]
        public String Ad { get; set; }
        public virtual List<Kitap> Kitaplar { get; set; }
    }
}
