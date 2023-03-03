#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Wedding_Planner.Models;
public class Wedding
{
    [Key]
    public int WeddingId { get; set; }
    [Required]
    public int Creator { get; set; }
    [Required(ErrorMessage = "Wedder One Details is required!")]
    [MinLength(2, ErrorMessage = "At least 2 characters required")]
    public string WedderOne { get; set; }
    [Required(ErrorMessage = "Wedder Two Details is required!")]
    [MinLength(2, ErrorMessage = "At least 2 characters required")]
    public string WedderTwo { get; set; }

    [Required(ErrorMessage = "This is not a valid date")]
    public DateTime Date { get; set; }
    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; }
    public List<Association> GuestList { get; set; } = new List<Association>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}