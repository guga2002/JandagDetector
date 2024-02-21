
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageLIbrary.Models
{
    [Table("Chanells")]
    public class Chanell
    {
        [Key]
        public int ID { get; set; }

        public int EmrCode { get; set; }
        public string ChanellName { get; set; }

        public int Card { get; set; }

        public int Port { get; set; }

        public string? ErrorMesage { get; set; }

        public override string ToString()
        {
            return $"<span style=\"color:#000000; font-size: 25px;\">{ChanellName}</span> -> <span style=\"color:red; font-size: 25px;\">{ErrorMesage}</span>";
        }

    }
}
