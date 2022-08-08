using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.ApplicationCore.Entities
{
    public class MovieCast
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int CastId { get; set; }
        [MaxLength(450)]
        public string Character { get; set; }
        public Movie Movies { get; set; }
        public Cast Casts { get; set; }
    }
}
