## Municipal Services Application for South Africa
### Programming 3B Part 3
The Municipal Services Application is designed to streamline citizen interaction with municipal services in South Africa.


### Prerequisites
**Before compiling or running, ensure you have:**
1.	Visual Studio 2022 (or later) installed
   
2. Workload: “.NET Desktop Development”
   - .NET Framework 4.7.2 or later
3.	A Windows PC environment
   
**How to Compile and Run the Application**

1. Clone the Repository

Alternatively, download the project as a ZIP file and extract it.

2.	Open the Project
- Launch Visual Studio 2022 or later
- Select File > Open > Project/Solution
- Browse to the folder and open the solution file
- MunicipalServicesApp.sln

3.	Restore Dependencies
Visual Studio automatically restores required NuGet Packages

5.	Build the Project
-	Choose Build > Build Solution
-	Wait until the Build succeeded message appears in the Output window

**How to Run the Application**
1.	In Visual Studio, press the play button run the program.
2.	The Main Menu opens.
   
**How to Use the Software**

***Main Menu***

-	Displays the three core features. And a login for the Staff/Employees.
-	Users should only be able to Report Issues, view and filter Local Events & Announcements by category or date and view recommended events and view their reported issues statuses (pending, in progress or resolved), search for reports by using Request IDs and view the report status graph.
-	Admin, only once logged in, should be able to view the report issues page, add, view and filter Local Events & Announcements and view recommended events, view and edit the status of user submitted reports. They can also log out

  
Set Login Credentials:
   -	Username: admin
   -	Password: password123
  
   -	Username: employee
   -	Password: employee123
 
***Report Issues***

(From Part 1)
Users report municipal problems with location, category, and description.
-	Allows users to submit municipal issues.
-	Fill in location, category, and description.
-	Attach an image or document and submit.
-	Confirmation messages show on successful submission.
-	Generates a unique Request ID.
-	Progress bar indicator.


  
***Local Events and Announcements***

(From Part 2)

Displays a list of upcoming local events in an organised, card-style layout.

Admin: Add a title, choose if it’s an Announcement or Event, description, category, date and a photo (optional- if a photo is not added a default image will be used.)

Search Bar: Filter events by category or date.
  
Data Structures Used:
  -	SortedDictionary - sort events by date
  -	Dictionary - store event details for quick lookup
  -	HashSet - maintain unique categories and dates
  -	PriorityQueue - manage recent events by date
  -	HashTable- Record search frequency
    
Recommendation Feature: 

After a search, the system suggests related events based on user preferences using frequency tracking or events within +/- 7 days of the searched events. New announcement and events will be recommended as well.

***Service Request Status***

Displays all reported issues.

- Users can search Reports by Request ID using Binary Search Trees (BST).
- Admins and employees can update issue statuses (Pending, In Progress or Resolved).
- Reports are ordered using Heaps (latest issues appear first), so that the user can see if their earliest reports have been addressed.
- Report statuses are also displayed using Graphs, just to show the user exactly how many issued reports’ have been tended to. 

  
## Technologies Used
- C# (.NET 8 / .NET Core MVC Framework)
-	Razor Views / HTML / CSS / JavaScript
-	Entity Framework Core (Database context)
-	SQLite DB (for data storage)
-	Visual Studio 2022 

### YouTube Video:
https://www.youtube.com/watch?v=wVRQzUTbGdE
