# StudBuddy

STUDBUDDY is a C# application where Students use to find other students who are
willing to study with them the same subjects they want to study, and where
teachers use to help out students seeking help in their subject.
So Student or chooses all his preferences and submit them and then be able to
find other students with similar preferences so they can contact each other to
meet and study with them or for them.

## System Users:
  - Students
  - Teachers

##  User Functionality

  - Student can select preferred studying location or locations.
  - Student can select Subject he wants to study with other students.
  - Student can select the Chapter he wants to study in the subject with other
students.
  - Student Can Review the Students or Teachers they studied with.
  - Students can search for Students or Teachers with certain preferences (The
University they go to or Their Field of Study).
  - Teachers can select the subject they want to teach.
  - Teachers can choose the price of the studying session (it can be free of charge also).
  - Teachers can choose preferred location or locations.
  - Teachers Can Review Students and add comments about them which will be useful information for other teachers
  - After a student selects all his preferences, a list of students and teachers will appear from which he can request them to accept the studying offer.
  - Teachers or students can choose which requests will they accept and they can share contact information after accepting an offer.

## Entities:
  - Students
  - Teachers
  - College
  - Faculty
  - Department
  - Course
  - Chapter
  - Reviews and ratings of Students, Teachers
  - Preferred studying spot.

## Database Schema 
![DB Schema](https://github.com/marwankefah/StudBuddy/blob/master/DB_Schema.png)
## ER Diagram
![ER Diagram](https://github.com/marwankefah/StudBuddy/blob/master/ER_Diagram.png)

 
 
### Installation
  - Build the solution and execute .exe ,using MS studio or CMD
     ``` msbuild DBapplication.sln ```
  - Start SQL server and Initiate Connection
  - Run Script DBScript.sql to automate DB creation and Dummy Data Insertion

