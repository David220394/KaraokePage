﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult Test()
        {
            UserModel data = new UserModel()
            {
                Peroid1 = new List<Model>(),
                Peroid2 = new List<Model>(),
                Peroid3 = new List<Model>(),
                Peroid4 = new List<Model>()
            };
            ListDirectory list = Service.Main();

            List<Participant> first_participant_timeslot = new List<Participant>();
            for (int i = 0; i < 10; i++)
            {
                first_participant_timeslot.Add(new Participant()
                {
                    MainParticipant = "Qwerty Q",
                    NumberOfLikes = "10",
                    Request = "Qwerty"
                });
            }

            //List<Participant> second_participant_timeslot = new List<Participant>();
            //for (int i = 0; i < 10; i++)
            //{
            //    second_participant_timeslot.Add(new Participant()
            //    {
            //        MainParticipant = "Qwerty Q",
            //        NumberOfLikes = "10",
            //        Request = "Qwerty"
            //    });
            //}

            //List<Participant> third_participant_timeslot = new List<Participant>();
            //for (int i = 0; i < 10; i++)
            //{
            //    third_participant_timeslot.Add(new Participant()
            //    {
            //        MainParticipant = "Qwerty Q",
            //        NumberOfLikes = "10",
            //        Request = "Qwerty"
            //    });
            //}

            //List<Participant> fourth_participant_timeslot = new List<Participant>();
            //for (int i = 0; i < 10; i++)
            //{
            //    fourth_participant_timeslot.Add(new Participant()
            //    {
            //        MainParticipant = "Qwerty Q",
            //        NumberOfLikes = "10",
            //        Request = "Qwerty"
            //    });
            //}

            //List<Participant> fifth_participant_timeslot = new List<Participant>();
            //for (int i = 0; i < 10; i++)
            //{
            //    fifth_participant_timeslot.Add(new Participant()
            //    {
            //        MainParticipant = "Qwerty Q",
            //        NumberOfLikes = "10",
            //        Request = "Qwerty"
            //    });
            //}


            List<Participant> first_participant_timeslot_waiting_list = new List<Participant>();
            for (int i = 0; i < 10; i++)
            {
                first_participant_timeslot_waiting_list.Add(new Participant()
                {
                    MainParticipant = "Qwerty Q",
                    NumberOfLikes = "10",
                    Request = "Qwerty"
                });
            }
            //list.ParticipantDirectory.ParticipantList1 = first_participant_timeslot;
            //list.WaitingListDirectory.WaitingList1 = first_participant_timeslot_waiting_list;
            //List<Participant> second_participant_timeslot_waiting_list = new List<Participant>();
            //for (int i = 0; i < 10; i++)
            //{
            //    second_participant_timeslot_waiting_list.Add(new Participant()
            //    {
            //        MainParticipant = "Qwerty Q",
            //        NumberOfLikes = "10",
            //        Request = "Qwerty"
            //    });
            //}

            //List<Participant> third_participant_timeslot_waiting_list = new List<Participant>();
            //for (int i = 0; i < 10; i++)
            //{
            //    third_participant_timeslot_waiting_list.Add(new Participant()
            //    {
            //        MainParticipant = "Qwerty Q",
            //        NumberOfLikes = "10",
            //        Request = "Qwerty"
            //    });
            //}

            //List<Participant> fourth_participant_timeslot_waiting_list = new List<Participant>();
            //for (int i = 0; i < 10; i++)
            //{
            //    fourth_participant_timeslot_waiting_list.Add(new Participant()
            //    {
            //        MainParticipant = "Qwerty Q",
            //        NumberOfLikes = "10",
            //        Request = "Qwerty"
            //    });
            //}

            //List<Participant> fifth_participant_timeslot_waiting_list = new List<Participant>();
            //for (int i = 0; i < 10; i++)
            //{
            //    fifth_participant_timeslot_waiting_list.Add(new Participant()
            //    {
            //        MainParticipant = "Qwerty Q",
            //        NumberOfLikes = "10",
            //        Request = "Qwerty"
            //    });
            //}

            //ParticipantDirectory participantDirectory = new ParticipantDirectory()
            //{
            //    ParticipantList1 = first_participant_timeslot,
            //    ParticipantList2 = second_participant_timeslot,
            //    ParticipantList3 = third_participant_timeslot,
            //    ParticipantList4 = fourth_participant_timeslot,
            //    ParticipantList5 = fifth_participant_timeslot
            //};
            //WaitingListDirectory waitingListDirectory = new WaitingListDirectory()
            //{
            //    WaitingList1 = first_participant_timeslot_waiting_list,
            //    WaitingList2 = second_participant_timeslot_waiting_list,
            //    WaitingList3 = third_participant_timeslot_waiting_list,
            //    WaitingList4 = fourth_participant_timeslot_waiting_list,
            //    WaitingList5 = fifth_participant_timeslot_waiting_list
            //};

            //ListDirectory list = new ListDirectory()
            //{
            //    ParticipantDirectory = participantDirectory,
            //    WaitingListDirectory = waitingListDirectory
            //};
            //List<Model> users = new List<UserModel>();
            //using (var sr = new StreamReader(new FileStream(@"C:\Users\User\source\repos\WebApplication1\WebApplication1\Test.txt", FileMode.Open, FileAccess.Read, FileShare.Read)))
            //{
            //    string line;

            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        string[] splits = line.Split(',');
            //        if (splits.Length > 1)
            //        {
            //            data.Peroid1.Add(new Model
            //            {
            //                name = splits[0],
            //                song = splits[1]
            //            }
            //            );
            //        }
            //    }
            //}

            //using (var sr = new StreamReader(new FileStream(@"C:\Users\User\source\repos\WebApplication1\WebApplication1\Test2.txt", FileMode.Open, FileAccess.Read, FileShare.Read)))
            //{
            //    string line;

            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        string[] splits = line.Split(',');
            //        if (splits.Length > 1)
            //        {
            //            data.Peroid2.Add(new Model
            //            {
            //                name = splits[0],
            //                song = splits[1]
            //            }
            //            );
            //        }
            //    }
            //}

            //using (var sr = new StreamReader(new FileStream(@"C:\Users\User\source\repos\WebApplication1\WebApplication1\Test3.txt", FileMode.Open, FileAccess.Read, FileShare.Read)))
            //{
            //    string line;

            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        string[] splits = line.Split(',');
            //        if (splits.Length > 1)
            //        {
            //            data.Peroid3.Add(new Model
            //            {
            //                name = splits[0],
            //                song = splits[1]
            //            }
            //            );
            //        }
            //    }
            //}

            //using (var sr = new StreamReader(new FileStream(@"C:\Users\User\source\repos\WebApplication1\WebApplication1\Test4.txt", FileMode.Open, FileAccess.Read, FileShare.Read)))
            //{
            //    string line;

            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        string[] splits = line.Split(',');
            //        if (splits.Length > 1)
            //        {
            //            data.Peroid4.Add(new Model
            //            {
            //                name = splits[0],
            //                song = splits[1]
            //            }
            //            );
            //        }
            //    }
            //}

            DateTime time = DateTime.Now;
            DateTime timeFrame1 = new DateTime(2020, 01, 24, 20, 00, 00);
            DateTime timeFrame2 = new DateTime(2020, 01, 24, 20, 00, 00);
            if (time > timeFrame2)
            {
                list.ParticipantDirectory.ParticipantList1 = list.ParticipantDirectory.ParticipantList3;
                list.ParticipantDirectory.ParticipantList2 = list.ParticipantDirectory.ParticipantList4;
                list.ParticipantDirectory.ParticipantList3 = list.ParticipantDirectory.ParticipantList5;
                list.WaitingListDirectory.WaitingList1 = list.WaitingListDirectory.WaitingList3;
                list.WaitingListDirectory.WaitingList2 = list.WaitingListDirectory.WaitingList4;
                list.WaitingListDirectory.WaitingList3 = list.WaitingListDirectory.WaitingList5;
            }
            else if (time > timeFrame1)
            {
                list.ParticipantDirectory.ParticipantList1 = list.ParticipantDirectory.ParticipantList2;
                list.ParticipantDirectory.ParticipantList2 = list.ParticipantDirectory.ParticipantList3;
                list.ParticipantDirectory.ParticipantList3 = list.ParticipantDirectory.ParticipantList4;
                list.WaitingListDirectory.WaitingList1 = list.WaitingListDirectory.WaitingList2;
                list.WaitingListDirectory.WaitingList2 = list.WaitingListDirectory.WaitingList3;
                list.WaitingListDirectory.WaitingList3 = list.WaitingListDirectory.WaitingList4;
            }

            return Json(list);
        }
    }

public class UserModel
{
    public List<Model> Peroid1 { get; set; }
    public List<Model> Peroid2 { get; set; }
    public List<Model> Peroid3 { get; set; }
    public List<Model> Peroid4 { get; set; }
}

public class Model
{
    public string name { get; set; }
    public string song { get; set; }
}

}