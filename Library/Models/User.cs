using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Library.Models
{
    public class User
    {
        [Key]
        public int? user_id { get; set; }
        public string? account { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public DateTime? date_create { get; set; }
        public DateTime? last_login { get; set; }
    }


}
