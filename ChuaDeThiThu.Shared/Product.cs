using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuaDeThiThu.Shared
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "Price must be >= 0.")]
        public float Price { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be >= 0.")]
        public int Qty { get; set; }
    }
}
