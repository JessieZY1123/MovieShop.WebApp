using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.ApplicationCore.Model
{
    public  class GenreModel
    {
        public int Id { get; set; }
        [Column(TypeName = "Varchar")]
        public string Name { get; set; }

    }
}
