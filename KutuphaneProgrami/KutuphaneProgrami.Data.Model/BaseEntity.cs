using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KutuphaneProgrami.Data.Model
{
    public class BaseEntity
    {

        [Key]
        public int Id { get; set; }
   
    }
}
