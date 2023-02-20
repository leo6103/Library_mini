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
    public class DataUser
    {

        public string? account { get; set; }
        public string? password { get; set; }
        public string? error_account { get; set; }
        public string? error_password { get; set; }
        public int? user_id { get; set; }
    }
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
    public class DataBook
    {
        public List<char> bookletter;
        public List<Book> bookdata;
        public int total;
        public List<string> url;
    }
}
