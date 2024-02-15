using Main_Assessment.Database;
using Main_Assessment.Entity;

namespace Main_Assessment.Services
{
    public class ConferenceService:IConferenceService
    {
        private readonly MyContext _context;

        public ConferenceService(MyContext context)
        {
            _context = context;
        }

        public void CreateConference(Conference conference)
        {
            try
            {
                _context.Conferences.Add(conference);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteConference(int conferenceID)
        {
            Conference conference = _context.Conferences.Find(conferenceID);
            if (conference != null)
            {
                _context.Conferences.Remove(conference);
                _context.SaveChanges();
            }
        }

        public void EditConference(int conferenceID, Conference conference)
        {
            var existingConference = _context.Conferences.Find(conferenceID);
            if (existingConference != null)
            {
                existingConference.Title = conference.Title;
                existingConference.Description = conference.Description;
                existingConference.Date = conference.Date;
                existingConference.Location = conference.Location;
                existingConference.UserID = conference.UserID;

                _context.Conferences.Update(existingConference);
                _context.SaveChanges();
            }
        }

        public List<Conference> GetAllConferences()
        {
            return _context.Conferences.ToList();
        }

        public Conference GetConference(int conferenceID)
        {
            return _context.Conferences.Find(conferenceID);
        }

        public bool ValidateConference(Conference conference)
        {
           
            if (string.IsNullOrWhiteSpace(conference.Title))
            {
                return false;
            }

            return true;
        }
        public Conference GetConferenceByName(string title)
        {
            try
            {
                return _context.Conferences.FirstOrDefault(c => c.Title.ToUpper() == title.ToUpper());
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving conference by name", ex);
            }
        }


    }
}
