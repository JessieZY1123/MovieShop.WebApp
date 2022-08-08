using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieShop.ApplicationCore.Model
{
    public class MovieModel
    {
        public int Id { get; set; }

        [MaxLength(256)]
        [Column(TypeName = "Varchar")]
        [Required]
        public string Title { get; set; }
        [Column(TypeName = "Varchar")]
        [Required]
        public string Overview { get; set; }

        [MaxLength(512)]
        [Column(TypeName = "Varchar")]
        [Required]
        public string Tagline { get; set; }
        public decimal Budget { get; set; }
        public decimal Revenue { get; set; }

        [MaxLength(2084)]
        [Column(TypeName = "Varchar")]
        public string ImdbUrl { get; set; }
        [MaxLength(2084)]
        [Column(TypeName = "Varchar")]
        public string TmdbUrl { get; set; }
        [MaxLength(2084)]
        [Column(TypeName = "Varchar")]
        public string PosterUrl { get; set; }
        [MaxLength(2084)]
        [Column(TypeName = "Varchar")]
        public string BackdropUrl { get; set; }
        [MaxLength(64)]
        [Column(TypeName = "Varchar")]
        public string OriginalLanguage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RunTime { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? CreatedBy { get; set; }
        public IEnumerable<CastModel> Casts { get; set; }
        public IEnumerable<GenreModel> Genres { get; set; }
    }
}
