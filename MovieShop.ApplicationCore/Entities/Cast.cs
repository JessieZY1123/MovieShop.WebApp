using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.ApplicationCore.Entities
{
    public class Cast
    {
        public int Id { get; set; }
        [MaxLength(128)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        public string TmdbUrl { get; set; }
        [MaxLength(2084)]
        public string ProfilePath { get; set; }
        public ICollection<MovieCast> MovieCasts { get; set; }

    }
}
