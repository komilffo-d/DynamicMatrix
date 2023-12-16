using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicMatrix_WF.Models
{
    [Table("value")]
    public class Value
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Column("actionid")]
        public int ActionId { get; set; }

        [Column("number")]
        public string Number { get; set; }

        [Column("action")]
        public Action Action { get; set; } = null!;
    }
}
