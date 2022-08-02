using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.ApplicationCore.Entities
{
    public class Review
    {
        [Key]
        public int MovieId { get; set; }
        public int UserId { get; set; }

        [Column(TypeName = "decimal(3,2)")]
        public decimal Rating { get; set; }
        public string ReviewText { get; set; }
        public User User { get; set; }
        public Movie Movie { get; set; }

    }
}
