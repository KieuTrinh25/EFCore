using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema.Repository
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey(nameof(SupplierId))]
        public virtual Supplier Supplier { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

        public int QuantityPerUnit { get; set; }
        public string UnitPrice { get; set; }
        public double UnitsInStock { get; set; }
        public double UnitsOnOrder { get;set; }
        public int ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        
    }
}
