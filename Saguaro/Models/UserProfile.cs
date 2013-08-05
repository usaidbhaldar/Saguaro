using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Saguaro.Models
{

    public class UsersContext : DbContext
    {
        public UsersContext()
            : base(EnvironmentSettings.SqlConnectionString)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }


    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required(ErrorMessage="Username is required")]
        [StringLength(12, MinimumLength = 3, ErrorMessage="Username must be 3-15 characters in length")]
        public string UserName { get; set; }
        
        [DataType(DataType.EmailAddress, ErrorMessage="Please use a valid email address")]
        public string Email { get; set; }

        public string Company { get; set; }

    }
}
