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


Have a Hash table with keys {dd-mm-yy}-{size}
    - List<MeetingRooms>
        - MeetingRoom
          - List of booked Intervals, in sorted by From date
             - Optimization represent this as a BST tree as mentioned in  https://github.com/aprdc2anil/GFG/blob/master/GFGCodes/DataStructure/17.NewDatastructures/NonOverlappingIntervalScheduling/MeetingSheduling.cs , BinarySearchIntervalTree class
  

While we should be able to book between any varible times , the general use case is with a tick of 5 minutes

like 13:45 to 14:50 rather than 13:48 to 14:48

hece we can represent each day as 5 minutes blocks   of 24*12 = 288 blocks (0, 287)

For simplicity represent the from to interval as follows
07-01-2020 13:45 - 14:50

13:45 - 14:50 can be represented in integer format as  13*12+9, 14*12+10 (165, 178)

with this interval we can look into the BSTIntervalTree to find a non overlapping position available or not

Even for a minute the same approach will work..in the same way

this would reduce the overall time complexity to O(logM) , where m is the total no of existed meeting in the day

flow
   for each size
      get list of meeting rooms (day,size hash) O(1)
      Parllel.ForEach(meetingroom in meetingrooms)
           CheckAvailability O(logm) , where small m is the max no of meetings in any meeting room of that day
           
      if found return here else go to next size
      





















DRAFT, inteview notes
=====================



multiple people


Multiple meeting rooms 

 different sizes


Meeting room, set of people set of time

         -> suggest a meeting room 
 
Admin   -> not possible

cost efficiency

   --> 



1


meeting rooms master data
-----------------

id , 

size 

attibutes : 

video 
timing freezes etc..



2 people 
------------
id 


3 meetings 
----------

id

day
   from
   to

size requested

meeting room id  - size 


-- > sizrequested, size provided 



mettinggeffeciency
--------------
meeting



--------
day 
   





query
----------

day,  from, to ,  >= size ,  ( algo optimization )

 ---> meeting rooms that are not blocked 




1 hr slot meeting 






Algorithm ()
{


  day 
    - from and to

      meeting rooms 

  
   MasterList - > 
       > size 
      by size 
          1,   30  --->  5 , list meeting rooms  
                    -- > day 
                        - > 8-
                               available meeting rooms  (info duplicated )
                         -> 9- 
                               available meeting rooms  (info duplicated )
                        
   
 size - > near greater prime number , 1, 2, 4, 8, 16 

    1, 3 5, 7, 11, 13, 19 
  
  day (not extended more than a day )
    with in a day , time slot should be able to vary 

   
   unit tests


  method efficiency ..... of the calculation...


}
     
    

        


      



   




    

      
 




                             
   
                    

  
   find the smallest size meeting room 

 
 


}


List<Meeting> meetings
List<MeetingRoom> 

class Meeting

{
    Id {get;set;}
    MeetingRoom room {get; set;}
    /// People {get;set;} 
    Size {}
   
}

class MeetingRoom
{
 id
 size

List<Meeting> meetings  {}
 
}










   











 


