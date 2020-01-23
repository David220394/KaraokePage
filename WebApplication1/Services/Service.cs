using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace WebApplication1.Services
{
    public class Service
    {
        public static ListDirectory Main()
        {
            Process.Start(@"C:\Users\sylvio.brandon.david\Desktop\Karaoke\Sharepoint_Console\query.vbs");
            Thread.Sleep(10000);
            string guid = Guid.NewGuid().ToString();
            string original_path = @"C:\Users\sylvio.brandon.david\Desktop\Karaoke\Sharepoint_Console\query.xlsx";
            string duplicate_path = $@"C:\Users\sylvio.brandon.david\Desktop\Karaoke\Sharepoint_Console\query_{guid}.xlsx";

            File.Copy(original_path, duplicate_path);

            //create a list to hold all the values
            var participants = new List<Participant>();

            //read the Excel file as byte array
            byte[] bin = File.ReadAllBytes(duplicate_path);

            //create a new Excel package in a memorystream
            using (MemoryStream stream = new MemoryStream(bin))
            using (ExcelPackage excelPackage = new ExcelPackage(stream))
            {
                //loop all worksheets
                foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                {
                    //loop all rows
                    for (int i = worksheet.Dimension.Start.Row; i <= worksheet.Dimension.End.Row; i++)
                    {
                        if (i == 1)
                        {
                            continue;
                        }

                        var participant = new Participant();

                        //loop all columns in a row
                        for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column; j++)
                        {
                            if (j > 7)
                            {
                                break;
                            }

                            //add the cell data to the List
                            if (worksheet.Cells[i, j].Value != null)
                            {
                                switch (j.ToString())
                                {
                                    case "1":
                                        participant.MainParticipant = worksheet.Cells[i, j].Value.ToString();
                                        break;
                                    case "2":
                                        participant.AccompaniedBy = worksheet.Cells[i, j].Value.ToString();
                                        break;
                                    case "3":
                                        participant.Request = worksheet.Cells[i, j].Value.ToString();
                                        break;
                                    case "4":
                                        participant.DateCreated = worksheet.Cells[i, j].Value.ToString();
                                        break;
                                    case "5":
                                        participant.Played = worksheet.Cells[i, j].Value.ToString();
                                        break;
                                    case "6":
                                        participant.NumberOfLikes = (worksheet.Cells[i, j].Value.ToString() != null && !worksheet.Cells[i, j].Value.ToString().Equals("null")) ? worksheet.Cells[i, j].Value.ToString(): "-";
                                        
                                        break;
                                    case "7":
                                        var requested_timeslots = worksheet.Cells[i, j].Value.ToString().Replace("#", "").Split(';');
                                        var dic_timeslot = new Dictionary<string, int>();
                                        int count = 0;
                                        foreach (var default_timeslot in participant.TimeSlots)
                                        {
                                            count++;
                                            if (requested_timeslots.Contains(default_timeslot.Key))
                                            {
                                                dic_timeslot.Add(default_timeslot.Key, count);
                                            }
                                        }
                                        participant.TimeSlots = dic_timeslot;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        participants.Add(participant);
                    }
                }
            }


            // Algorithm


            // Order by vote
            var participants_by_vote = participants.OrderByDescending(x => x.NumberOfLikes).ToList();


            // Assign to timeslot 1
            var first_participant_timeslot = new List<Participant>();
            var first_participant_timeslot_waiting_list = new List<Participant>();

            AssignToTimeslot(first_participant_timeslot, first_participant_timeslot_waiting_list, participants_by_vote, "18:00 to 19:00");

            // Assign to timeslot 2
            var second_participant_timeslot = new List<Participant>();
            var second_participant_timeslot_waiting_list = new List<Participant>();

            AssignToTimeslot(second_participant_timeslot, second_participant_timeslot_waiting_list, participants_by_vote, "19:00 to 20:00");

            // Assign to timeslot 3
            var third_participant_timeslot = new List<Participant>();
            var third_participant_timeslot_waiting_list = new List<Participant>();

            AssignToTimeslot(third_participant_timeslot, third_participant_timeslot_waiting_list, participants_by_vote, "20:00 to 21:00");


            // Assign to timeslot 4
            var fourth_participant_timeslot = new List<Participant>();
            var fourth_participant_timeslot_waiting_list = new List<Participant>();

            AssignToTimeslot(fourth_participant_timeslot, fourth_participant_timeslot_waiting_list, participants_by_vote, "21:00 to 22:00");

            // Assign to timeslot 5
            var fifth_participant_timeslot = new List<Participant>();
            var fifth_participant_timeslot_waiting_list = new List<Participant>();

            AssignToTimeslot(fifth_participant_timeslot, fifth_participant_timeslot, participants_by_vote, "22:00 to 00:00");

            // Assign to multiple time slots
            var participants_having_more_timeslots = participants_by_vote.Where(x => x.TimeSlots.Count > 1).ToList();
            foreach (var participant_with_more_timeslot in participants_having_more_timeslots)
            {
                var timeslot_order_desc = participant_with_more_timeslot.TimeSlots.OrderByDescending(x => x.Value).ToList();

                foreach (var ts in timeslot_order_desc)
                {
                    bool addedToList = false;

                    if (ts.Value == 5)
                    {
                        addedToList = AssignMultipleToTimeSlot(fifth_participant_timeslot, fifth_participant_timeslot_waiting_list, 5, participant_with_more_timeslot);
                        if (addedToList)
                        {
                            break;
                        }
                    }
                    if (ts.Value == 4)
                    {
                        addedToList = AssignMultipleToTimeSlot(fourth_participant_timeslot, fourth_participant_timeslot_waiting_list, 4, participant_with_more_timeslot);
                        if (addedToList)
                        {
                            break;
                        }
                    }
                    if (ts.Value == 3)
                    {
                        addedToList = AssignMultipleToTimeSlot(third_participant_timeslot, third_participant_timeslot_waiting_list, 3, participant_with_more_timeslot);
                        if (addedToList)
                        {
                            break;
                        }
                    }
                    if (ts.Value == 2)
                    {
                        addedToList = AssignMultipleToTimeSlot(second_participant_timeslot, second_participant_timeslot_waiting_list, 2, participant_with_more_timeslot);
                        if (addedToList)
                        {
                            break;
                        }
                    }
                    if (ts.Value == 1)
                    {
                        addedToList = AssignMultipleToTimeSlot(first_participant_timeslot, first_participant_timeslot_waiting_list, 1, participant_with_more_timeslot);
                        break;
                    }
                }

            }

            ParticipantDirectory participantDirectory = new ParticipantDirectory()
            {
                ParticipantList1 = first_participant_timeslot.OrderByDescending(x=> x.NumberOfLikes).ToList(),
                ParticipantList2 = second_participant_timeslot.OrderByDescending(x => x.NumberOfLikes).ToList(),
                ParticipantList3 = third_participant_timeslot.OrderByDescending(x => x.NumberOfLikes).ToList(),
                ParticipantList4 = fourth_participant_timeslot.OrderByDescending(x => x.NumberOfLikes).ToList(),
                ParticipantList5 = fifth_participant_timeslot.OrderByDescending(x => x.NumberOfLikes).ToList()
            };
            WaitingListDirectory waitingListDirectory = new WaitingListDirectory()
            {
                WaitingList1 = first_participant_timeslot_waiting_list.OrderByDescending(x => x.NumberOfLikes).ToList(),
                WaitingList2 = second_participant_timeslot_waiting_list.OrderByDescending(x => x.NumberOfLikes).ToList(),
                WaitingList3 = third_participant_timeslot_waiting_list.OrderByDescending(x => x.NumberOfLikes).ToList(),
                WaitingList4 = fourth_participant_timeslot_waiting_list.OrderByDescending(x => x.NumberOfLikes).ToList(),
                WaitingList5 = fifth_participant_timeslot_waiting_list.OrderByDescending(x => x.NumberOfLikes).ToList()
            };

            ListDirectory listDirectory = new ListDirectory()
            {
                ParticipantDirectory = participantDirectory,
                WaitingListDirectory = waitingListDirectory
            };
            return listDirectory;
        }

        public static bool AssignMultipleToTimeSlot(List<Participant> result, List<Participant> waiting_list, int timeslot, Participant participant)
        {
            int limit = 11;
            bool addedToList = false;
            if (result.Count > limit)
            {
                var last_item = result.LastOrDefault();

                if (Convert.ToInt32(participant.NumberOfLikes) > Convert.ToInt32(last_item.NumberOfLikes))
                {
                    result.RemoveAt(result.Count - 1);
                    result.Add(participant);
                    waiting_list.Add(last_item);
                    addedToList = true;
                }
                else
                {
                    waiting_list.Add(participant);
                }
            }
            else
            {
                if (result.Count >= 0)
                {
                    result.Add(participant);
                    addedToList = true;
                }
            }

            return addedToList;
        }

        public static void AssignToTimeslot(List<Participant> result, List<Participant> waiting_list, List<Participant> all_participants, string timeslot)
        {
            var participants_having_only_one_timeslot = all_participants.Where(z => z.TimeSlots.Count == 1
            && z.TimeSlots.FirstOrDefault().Key == timeslot).OrderByDescending(x => x.NumberOfLikes).ToList();
            int limit = 10;

            foreach (var participant_by_vote in participants_having_only_one_timeslot)
            {
                if (result.Count < limit)
                {
                    result.Add(participant_by_vote);
                }
                else
                {
                    waiting_list.Add(participant_by_vote);
                }
            }
        }
    }
}