using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Project
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Project title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a valid URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Url(ErrorMessage = "Please enter a valid URL")]
        public string ProjectLink { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}