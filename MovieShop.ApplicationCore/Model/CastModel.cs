using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.ApplicationCore.Model
{
    public class CastModel
    {
        public int Id { get; set; }
        [MaxLength(128)]
        [Column(TypeName ="varchar")]
        public string Name { get; set; }
        [Column(TypeName = "varchar")]
        public string Gender { get; set; }
        [Column(TypeName = "varchar")]
        public string TmdbUrl { get; set; }
        [MaxLength(2084)]
        [Column(TypeName = "varchar")]
        public string ProfilePath { get; set; }
    }
}
