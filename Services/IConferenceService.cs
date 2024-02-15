using Main_Assessment.Entity;

namespace Main_Assessment.Services
{
    public interface IConferenceService
    {
        void CreateConference(Conference conference);
        List<Conference> GetAllConferences();
        Conference GetConference(int conferenceID);
        void EditConference(int conferenceID, Conference conference);
        void DeleteConference(int conferenceID);
        bool ValidateConference(Conference conference);
        Conference GetConferenceByName(string title);
    }
}
