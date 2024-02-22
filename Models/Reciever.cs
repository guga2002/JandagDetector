using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db.Models
{
    [Table("Reciever")]
    public class Reciever:AbstractModel
    {
        [Key]
        public int Id { get; set; }

        [Column("Emr")]
        public int Emr { get; set; }

        [Column("Card")]
        public int   Card { get; set; }

        [Column("Port")]
        public int  Port { get; set; }

        [ForeignKey("Source")]
        public int ChanellSourceID { get; set; }

        public ChanellSource Source { get; set; }
    }
}
