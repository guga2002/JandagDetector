
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace db.Models
{
    [Table("Chanells")]
    public class Chanell:AbstractModel
    {
        [Key]
        public int Id { get; set; }
        [Column("NameOfChanell")]
        public string Name { get; set; }

        public List<ChanellSource> Sources { get; set; }

        public List<Packages> Packages { get; set; }
    }
}
