using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Services
{
    public class Participant
    {
        public string MainParticipant { get; set; }
        public string AccompaniedBy { get; set; }
        public string Request { get; set; }
        public string DateCreated { get; set; }
        public string Played { get; set; }
        public string NumberOfLikes { get; set; }
        public Dictionary<string, int> TimeSlots { get; set; } = new Dictionary<string, int>
        {
            { "18:00 to 19:00", 1},
            { "19:00 to 20:00", 2},
            { "20:00 to 21:00", 3},
            { "21:00 to 22:00", 4},
            { "22:00 to 00:00", 5}
        };

    }

    public class ParticipantDirectory
    {
        public List<Participant> ParticipantList1 { get; set; }
        public List<Participant> ParticipantList2 { get; set; }
        public List<Participant> ParticipantList3 { get; set; }
        public List<Participant> ParticipantList4 { get; set; }
        public List<Participant> ParticipantList5 { get; set; }
    }

    public class WaitingListDirectory
    {
        public List<Participant> WaitingList1 { get; set; }
        public List<Participant> WaitingList2 { get; set; }
        public List<Participant> WaitingList3 { get; set; }
        public List<Participant> WaitingList4 { get; set; }
        public List<Participant> WaitingList5 { get; set; }
    }

    public class ListDirectory
    {
        public ParticipantDirectory ParticipantDirectory { get; set; }
        public WaitingListDirectory WaitingListDirectory { get; set; }

    }
}
