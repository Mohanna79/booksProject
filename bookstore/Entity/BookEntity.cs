using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace bookstore.Entity
{
    public class BookEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        [Required]
        public double? Price { get; set; }
        [Required]
        public int? Number { get; set; }
        public DateTime Created { get; set; }
    }
}
