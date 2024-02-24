using System.ComponentModel.DataAnnotations;

namespace Mission07_Fowler.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}