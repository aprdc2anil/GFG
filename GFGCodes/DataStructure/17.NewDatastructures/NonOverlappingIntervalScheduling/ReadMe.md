MeetingManager


Given a list of meeting rooms, each with specific size
Given a meeting can be booked for an interval ( from, to falling only into the same day )


Requirements

1. Provide a method to suggest an available meeting room(s) for a given interval and size (no of people attending the room ) 
2. If multiple meeting rooms available for that interval, provide only the meeting room(s) with lowest size that can fit the given size requested for the meeting.
3.Provide a method to return the occupancy efficiency of the booked meetings for each day, expandable to range in days
4. Any meeting booked for a given interval should not be overlapping with any other meeting booked for the same meeting room. 
5. If available the meeting should be scheduled between any given From to To time



Solution

Datastructure , InMemory
     
double providedCapacity; // requestedCapacity Honoured so far

double bookedCapacity; // Actual Booked Capacity So far

SortedSet<int> availableSizes; // unique meeting room sizes avaialble
     
SortedDictionary<int, SortedSet<string>> meetingRoomsBySize; // meetingroom ids by size
     
Dictionary<string, int> meetingRoomCapacity; // meetingroom capacity by meetingroomid
    
Dictionary<string, MeetingRoom> meetingRooms; meetingrooms by meeting id

MeetingRoom

   - Dictionary<string, MeetingRoomTimeLine> dailyScheduledMeetings; // meeting lime lines for this meeting room by each day
   
     - MeetingRoomTimeLine
     
         - BST (should be oprimized for log n)
                - Meeting scheduled Interval

https://github.com/aprdc2anil/GFG/blob/master/MeetingRoomScheduling/MeetingShedulingManager.cs   

Methods Supported

    - double GetResourceEfficiency
    
    - List<string> GetAvailableMeetingRooms(DateTime from, DateTime to, int requestedSize)
    
    - bool BookMeeting(DateTime from, DateTime to, int requestedSize, string meetingRoomId, string requestorId)
    
    - bool AddMeetingRoom(int roomSize, string id)
  

While we should be able to book between any varible times , the general use case is with a tick of 5 minutes

like 13:45 to 14:50 rather than 13:48 to 14:48

hece we can represent each day as 5 minutes blocks   of 24*12 = 288 blocks (0, 287)

For simplicity represent the from to interval as follows
07-01-2020 13:45 - 14:50

13:45 - 14:50 can be represented in integer format as  13*12+9, 14*12+10 (165, 178)

with this interval we can look into the BSTIntervalTree to find a non overlapping position available or not

Even for a minute the same approach will work..in the same way

flow for check availability
   
for each size

  - get list of meeting rooms (day,size hash) O(1)
  
  - Parllel.ForEach(meetingroom in meetingrooms)
  
       CheckAvailability with in the perticular meetingroom and day time line
       
       if found return here with the meeting room(s) of the minimum matched size
       
  - if no meeting room can be found look for the next size
