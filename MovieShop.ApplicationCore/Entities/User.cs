using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MovieShop.ApplicationCore.Entities
{
    public class User: IdentityUser
    {
        [MaxLength(128)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(128)]
        [Required]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        [MaxLength(1024)]
        public string Salt { get; set; } 
        public DateTime LockoutEndDate { get; set; }
        public DateTime LastLoginDateTime { get; set; }
        public bool IsLocked { get; set; }
        public int AccessFailedCount { get; set; }
        public string ProfilePictureUrl { get; set; }

        //public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
