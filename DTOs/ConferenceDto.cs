using System.ComponentModel.DataAnnotations;

namespace Main_Assessment.DTOs
{
    public class ConferenceDto
    {
        public int ConferenceID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string UserID { get; set; }
    }
}
