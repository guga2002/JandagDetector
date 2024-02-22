
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace db.Models
{
    [Table("ChanellSources")]
    public class ChanellSource: AbstractModel
    {
        [Key]
        public int Id { get; set; }

        [Column("Source Name")]
        public string Name { get; set; }


        [Column("FormatOfSource")]
        public string Format { get; set; }


        [Column("SourceStrean")]
        public string SourceStream { get; set; }

        [ForeignKey("chanell")]
        public int ChanellId { get; set; }

        public Chanell chanell { get; set; }

        public Desclamber Desclamber { get; set; }

        public Reciever Reciever { get; set; }

        public Status Status { get; set; }

        public Transcoder Transcoder { get; set; }
    }
}
