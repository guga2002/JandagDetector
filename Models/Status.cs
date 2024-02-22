using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace db.Models
{
    [Table("Statuss")]
    public class Status:AbstractModel
    {
        [Key]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }


        [Column("IsActive")]
        public int Isactive { get; set; }  //1 active 0 reserve -1 off

        [ForeignKey("Source")]
        public int ChanellSourceID { get; set; }

        public ChanellSource Source { get; set; }
    }
}
