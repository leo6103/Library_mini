using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int? book_id { get; set; }
        public string? book_title { get; set; }
        public string? book_description { get; set; }
        public int? pages { get; set; }
        public string? book_desc { get; set; }
        public string? author { get; set; }
        public string? publisher { get; set; }
        public string? cover { get; set; }
        public int? available { get; set; }
    }

}