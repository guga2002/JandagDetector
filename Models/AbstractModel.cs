using System.ComponentModel.DataAnnotations;

namespace db.Models
{
    
    public abstract class AbstractModel
    {
        [Key]
        protected int Id { get; set; }

        protected AbstractModel()
        {
                
        }
    }
}
