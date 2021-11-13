using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace bookstore.Dto
{
    public class BookCreatDto
    {
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }

        public double? Price { get; set; }

        public int? Number { get; set; }
        public DateTime Created { get; set; }
    }
}
