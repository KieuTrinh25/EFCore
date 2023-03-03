using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Repository
{
    public class OrderItem : BaseEntity
    {
        public int IdBook { get; set; }
        public int IdOrder { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }

        [ForeignKey("IdOrder")]
        public virtual Order Order { get; set; }
        [ForeignKey("IdBook")]
        public virtual Book Book { get; set; }

    }
}
