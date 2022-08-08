using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.ApplicationCore.Model
{
    public class MovieCardModel
    {
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        public string Title { get; set; }
        [Column(TypeName = "Varchar")]
        public string PosterUrl { get; set; }
        
    }
}
