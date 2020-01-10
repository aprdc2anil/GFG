using MeetingRoomScheduling;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GFGCodes
{
    public class MeetingScheduling
    {
        private static MeetingShedulingManager meetingSchedulingMngr = MeetingShedulingManager.Instance;

        public static void EntryPoint()
        {
            GenerateSeedRooms();
            GenerateSeedMeetings();
            RunTestCases();

            Console.ReadLine();
        }


        public static void GenerateSeedRooms()
        {
            //  1 "pb1", "pb2", 
            //  2 "oo1", "oo2", 
            //  4 "sr1", "sr2", "sr3", "sr4", 
            //  8 "tr1", "tr2", "tr3", "tr4", 
            // 16  "mr1", "mr2"
            // 32  "er1"

            var roomsBySize = new Dictionary<int, List<string>>()
            {
                {1, new List<string>(){ "pb1", "pb2" } },
                {2, new List<string>(){ "oo1", "oo2", "pb1" } },
                {4, new List<string>(){ "sr1", "sr2", "sr3", "sr4", "oo1" } },
                {8, new List<string>(){ "tr1", "tr2", "tr3", "tr4", "sr1" } },
                {16, new List<string>(){ "mr1", "mr2" } },
                {32, new List<string>(){ "er1" } }
            };

            foreach (var size in roomsBySize)
            {
                foreach (var meetingRoomId in size.Value)
                {
                    var isSuccess = meetingSchedulingMngr.AddMeetingRoom(size.Key, meetingRoomId);

                    if (isSuccess)
                    {
                        Console.WriteLine("{0} of size {1} is successfully added to the meeting room list", meetingRoomId, size.Key);
                    }
                    else
                    {
                        Console.WriteLine("looks like meetingroom with id {0} already exists", meetingRoomId);
                    }

                }
            }

            Console.WriteLine("-----------------seed rooms end------------------------");
        }

        public static void GenerateSeedMeetings()
        {
            var currTime = DateTime.UtcNow;
            DateTime startTime = new DateTime(currTime.Year, currTime.Month, currTime.Day, currTime.Hour + 1, 0, 0, DateTimeKind.Utc);
            DateTime endTime = startTime.AddMinutes(85);

            // reference time 12:00

            // 1 12:00 13:25
            // 1 12:00 13:25

            // 1 12:00 13:25
            // 2 12:00 13:25

            // 3 12:00 13:25
            // 3 12:00 13:25
            // 4 12:00 13:25
            // 4 12:00 13:25

            // 4 12:00 13:25
            // 5 12:00 13:25
            // 6 12:00 13:25
            // 7 12:00 13:25

            // 10 12:00 13:25           
            // 16 12:00 13:25

            // 20 12:00 13:25

            List<int> seedSizeRequests = new List<int>() {0, 33, 1, 1, 1, 2, 3, 3, 4, 4, 4, 5, 6, 7, 10, 16, 20, 16  };

            foreach (var size in seedSizeRequests)
            {
                bookHelper(startTime, endTime, size);
            }

            Console.WriteLine("-----------------seed meetings end------------------------");
        }

        public static void RunTestCases()
        {
            // test case 1 
            // since all meetings are booked , if we try for any meeting room it should fail

            Console.WriteLine("------------testcase1------------");
            var currTime = DateTime.UtcNow;
            DateTime startTime = new DateTime(currTime.Year, currTime.Month, currTime.Day, currTime.Hour + 1, 0, 0, DateTimeKind.Utc);
            DateTime endTime = startTime.AddMinutes(85);

            
            bookHelper(startTime, endTime, 8);


            // test case 2 overlapping intervals shoudld fail 
            // since all meetings are booked , if we try for any meeting room it should fail
            Console.WriteLine("---------testcase2-----------------");
            startTime = startTime.AddMinutes(25);
            
            bookHelper(startTime, endTime, 8);

            // test case 3 next meeting with preious endtime should succede
            // since all meetings are booked , if we try for any meeting room it should fail
            Console.WriteLine("------------testcase3---------------");
            startTime = endTime;

            endTime = startTime.AddMinutes(30);

            for (int j = 1; j < 35; ++j)
            {
                bookHelper(startTime, endTime, j);
            }

          
            Console.WriteLine("---------testcase4-----------------");
            startTime = startTime.AddMinutes(25);

            bookHelper(startTime, endTime, 8);

           
            Console.WriteLine("------------testcase5---------------");
            startTime = endTime;

            endTime = startTime.AddMinutes(30);

            for (int j = 8; j < 35; j=j+2)
            {
                bookHelper(startTime, endTime, j);
            }

        }

        private static void bookHelper(DateTime startTime, DateTime endTime, int size)
        {
            var availableMeetingsTask = meetingSchedulingMngr.GetAvailableMeetingRooms(startTime, endTime, size);
            var listOfAvailableMeetings = availableMeetingsTask.Result;

            if (listOfAvailableMeetings.Any())
            {
                Console.WriteLine("List of available meetings for time: {0}-{1} of size {2} are:", startTime, endTime, size);
                Console.WriteLine(string.Join(" ", listOfAvailableMeetings));
                bool isSuccess = meetingSchedulingMngr.BookMeeting(startTime, endTime, size, listOfAvailableMeetings[0], "x");

                if (isSuccess)
                {
                    Console.WriteLine("meeting IS booked for time: {0}-{1} of size {2} and meetingroomid:{3}", startTime, endTime, size, listOfAvailableMeetings[0]);
                    Console.WriteLine("Resource efficiency so far: {0}", meetingSchedulingMngr.GetResourceEfficiency());
                }
                else
                {
                    Console.WriteLine("meeting NOT booked for time: {0}-{1} of size {2} and meetingroomid:{3}", startTime, endTime, size, listOfAvailableMeetings[0]);
                }
            }
            else
            {
                Console.WriteLine("meeting rooms for time: {0}-{1} of size {2} are not available", startTime, endTime, size);
            }
        }
    }
}
