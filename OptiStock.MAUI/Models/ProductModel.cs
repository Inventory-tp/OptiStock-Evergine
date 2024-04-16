using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiStock.MAUI.Models
{
    public class ProductModel
    {
        public Guid ID { get; set; }
        public String name { get; set; }
        public String brand { get; set; }
        public int quantity { get; set; }
        public float weigth { get; set; }
    }
}
