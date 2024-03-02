using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission07_Fowler.Models
{
    public class Movie // Typically doesn't need a constructor. It is a mold for movies.
    {
        [Key]
        [Required]
        public int MovieId { get; set; } //Primary Key

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; } //Optional Category
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a year")]
        [Range(1888, int.MaxValue, ErrorMessage = "Enter a year 1888 or greater")] //Limits year to 1888 or greater
        public int? Year { get; set; } //The ? makes it so the default isn't a 0. It is still required tho and will give an error if not entered

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required(ErrorMessage = "Please enter if the movie was edited")]
        public int Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Please enter if the movie has been copied to Plex")]
        public int CopiedToPlex { get; set; }

        [StringLength(25, ErrorMessage = "Please keep the length of the note under 25 characters")]
        public string? Notes { get; set; } // Max length of 25 or error
    }
}