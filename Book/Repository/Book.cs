using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Repository
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public String Name { get; set; }

        public Double Price { get; set; }
        public int Qty { get; set; }

        public virtual List<Author> Authors { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }

    }
}
