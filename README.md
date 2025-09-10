Municipal Services Application-PROG7312 POE Part 1  

Overview  


This project is included in the PROG7312 Portfolio of Evidence (Part 1).  
It is a C# ASP.NET Core MVC application designed for citizens to:  

- Report municipal problems (with or without attachments).
  
- View placeholders for future features, such as Local Events and Service Request Status.  

- Navigate through an intuitive main menu that includes onboarding assistance (progress bar and descriptions).  

- All information is stored in Hashtables rather than arrays/lists, showcasing knowledge of data structures.  


Requirements  

Make sure you have the following before running the project:  


- Visual Studio 2022 or a later version.  

- .NET 8 SDK (already set in this project).  

- Git (only necessary if cloning from GitHub; not required if you received a ZIP file).  


How to Compile & Run 


1. Extract the ZIP  

- Unzip the project folder (AmanAdams.ST10290748.PROG7312.POE.zip).  

- Confirm that the folder structure remains unchanged.  


2. Open in Visual Studio  

- Double-click the .sln file (AmanAdams.ST10290748.PROG7312.POE.sln).  

- This action will launch the complete solution in Visual Studio.  


3. Restore Dependencies  

- NuGet packages will be restored automatically by Visual Studio.  

- If prompted, agree to install the necessary packages.  


4. Set Startup Project  

- In Solution Explorer, right-click on the project AmanAdams.ST10290748.PROG7312.POE.  

- Choose Set as Startup Project.  


5. Run the Application  

- Press F5 (Debug → Start Debugging).  

- The application will compile and run at https://localhost:xxxx (port designated by Visual Studio).  


How to Use the Application:  


Main Menu  

Shows three buttons:  

- Report Issues (active)  

- Local Events (Coming Soon)  

- Service Request Status (Coming Soon)  


Report an Issue  

1. Input a location.  

2. Choose a category (Roads, Sanitation, Utilities, Safety, Other).  

3. Enter a description.  

4. You may optionally upload a file (photo or document).  

5. A progress bar will update as you fill in the fields.  

6. Click Submit to report the issue.  


Success Page  

- Following submission, a confirmation message will appear.  

- A button provides the option to return to the main menu.  


Navigation  

- The navigation bar is visible but inactive.  

- You must utilize the main menu buttons for navigation.  


File Uploads  

- Files uploaded are stored in wwwroot/uploads/.  

- The file path is recorded in the issue record (using Hashtable).  


Technical Notes  

- The application implements Hashtables in Models (IssueRepositoryModel).  

- No external database is necessary (all information is kept in memory).  

- Controllers do not contain business logic, which is managed by Service/Repository models.  


Youtube Video Link: 

https://youtu.be/BIeDD951GSw?si=WwpisYQP0NehK05T
