## Municipal Services Application for South Africa
### Programming 3B Part 2
The Municipal Services Application is designed to streamline citizen interaction with municipal services in South Africa.

### It allows users to:
**1)	Report issues (Part 1)** 
- Input a location.
- Choose a category (Roads, Sanitation, Utilities, Safety, Other).
- Enter a description.
- You may optionally upload a file (photo or document).
- A progress bar will update as you fill in the fields.
- Click Submit to report the issue.

**2)	View local events and announcements (Part 2)**
- Adding and displaying local events and announcements.
- Searching and filtering by category and date.
- Sorting events by priority (date order).
- Generating recommendations based on user search patterns.
- Authentication for Admin/Employee login before adding events. 

**3)	Track service-request status (to be implemented in Part 3)**
This version focuses on collaboration and advanced data structures to manage and recommend local events efficiently.

### Prerequisites
**Before compiling or running, ensure you have:**
1.	Visual Studio 2022 (or later) installed
   
2. Workload: “.NET Desktop Development”
   - .NET Framework 4.7.2 or later
3.	A Windows PC environment
   
**How to Compile the Application**
1. Clone the Repository
Open your terminal or Git Bash and run:
git clone https://github.com/<your-username>/<your-repo-name>.git
Alternatively, download the project as a ZIP file and extract it.

1.	Open the Project
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

Main Menu
- Displays the three core features. And a login for the Staff/Employees.
- Users should only be able to Report Issues, view and filter Local Events & Announcements by category or date and view recommended events. 
- Admin, only once logged in, should be able to view the report issues page, add, view and filter Local Events & Announcements and view recommended events.
  
- Set Credentials:
   -	Username: admin
   -	Password: password123
              OR 
   -	Username: employee
   -	Password: employee123
 

Report Issues
(From Part 1)
- Allows users to submit municipal issues.
- Fill in location, category, and description.
-	Attach an image or document and submit.
-	Confirmation messages show on successful submission.

  
Local Events and Announcements
(New for Part 2)
-	Displays a list of upcoming local events in an organised, card-style layout.
-	Admin: Add a title, choose if it’s an Announcement or Event, description, category, date and a photo (optional- if a photo is not added a default image will be used.)
-	Search Bar: Filter events by category or date.
  
-	Data Structures Used:
  -	SortedDictionary - sort events by date
  -	Dictionary - store event details for quick lookup
  -	HashSet - maintain unique categories and dates
  -	PriorityQueue - manage recent events by date
  -	HashTable- Record search frequency
    
-	Recommendation Feature: After a search, the system suggests related events based on user preferences using frequency tracking.
  
- Technologies Used
- C# (.NET 8 / .NET Core MVC Framework)
-	Razor Views / HTML / CSS / JavaScript
-	Entity Framework Core (Database context)
-	SQLite LocalDB (for data storage)
-	Visual Studio 2022 

### YouTube Video:
https://www.youtube.com/watch?v=wd0GbxzC7qg
