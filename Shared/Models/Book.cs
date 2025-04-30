using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSignalR.Shared.Models
{
    public class Book
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "Book's ISBN is required")]
        public string Isbn { get; set; }
        [Required(ErrorMessage ="Book's name required")]
        [StringLength(50, ErrorMessage = "Book name's length should be less than 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Book's author is required")]
        [StringLength(50, ErrorMessage = "Book author's length should be less than 50 characters")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Book's price is required")]
        [Range(0.01, 10000, ErrorMessage = "Book's price should be between 0.01 and 10000")]
        public double Price { get; set; }

    }
}
