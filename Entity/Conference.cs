using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Main_Assessment.Entity
{
    public class Conference
    {
        
        [Key]
        public int ConferenceID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [Required]
        [ForeignKey("UserID")]
        public string UserID { get; set; }

        public User User { get; set; }
    
    }
}
