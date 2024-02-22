using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace db.Models
{
    [Table("Desclambers")]
    public class Desclamber : AbstractModel
    {
        [Key]
        public int Id { get; set; }

        [Column("Emr")]
        public int Emr { get; set; }


        [Column("Card")]
        public int Card { get; set; }


        [Column("Port")]
        public int Port { get; set; }

        [ForeignKey("Source")]
        public int ChanellSourceID { get; set; }

        public ChanellSource Source { get; set; }
    }
}
