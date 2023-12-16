using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMatrix_WF.Models
{
    [Table("action")]
    public class Action
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }=DateTime.Now;

        [Column("action")]
        public ActionEnum ActionType { get; set; }

        [Column("result")]
        public string Result { get; set; } = null!;


        [Column("values")]
        public List<Value> Values { get; set; } = new();
    }
}
