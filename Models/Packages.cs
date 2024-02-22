using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace db.Models
{
    [Table("Packages")]
    public class Packages:AbstractModel
    {
        [Key]
        public int Id { get; set; }

        [Column("NameOfPackage")]
        public string Name { get; set; }

        [ForeignKey("Chanell")]
        public int ChanellID { get; set; }

        public Chanell Chanell { get; set; }
    }
}
