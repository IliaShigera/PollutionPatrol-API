# **Pollution Patrol API**

## **Overview**

Pollution Patrol is a web application designed to help volunteers and organizations fight pollution by locating and dealing with polluted zones. The app allows users to report polluted areas, find and join volunteer organizations, and track the progress of cleanup efforts. Pollution Patrol is built using .NET technologies, specifically ASP.NET Core 7 for backend API.

## **Architecture**

The Pollution Patrol API is built on ASP.NET with a modular monolith architecture using the DDD approach. It consists of an API project and several modules:

- User Access
- Pollution
- Organization
- Admin
- Support
- Monitoring
- Staff

Each module follows the clean architecture pattern with domain infrastructure and application layers.

## **Features**

### **User Access Module:**

- Register new user. Confirm the email address to complete the registration.
- Social Media Integration: Allow users to log in using their social media accounts such as Facebook, Twitter, or Google to make the registration process easier and more convenient.
- Provide a JWT token for authorization and authentication.
- Edit user data such as email, password, etc.

### **Pollution Module:**

- Report pollution: Users can report pollution by providing GPS coordinates and the type of pollution. To complete the report, users must also send evidence media files, such as short videos or photos of the affected area. They can also include a description of the pollution, its severity, and its impact on the environment and people's health.
- Review report: Real employee or an AI will review the evidence file, check the pollution type, and contact a specialist to assess the cost of cleanup and define the method of cleanup. The pollution report must be fully completed before it can be approved. The designated reviewer can reject the report at any time during the review process. Furthermore, the reviewer may request additional information or evidence to better understand the pollution and its impact on the environment.
    - Notification system: User who submitted the report will receive a notification regarding the change in report status.
    - Rejection Notification: If the pollution report has been rejected, the user who sent the report will receive a notification in the app with details about why their report was rejected. The email may include suggestions on how to improve the report or provide additional evidence to better understand the issue.
    - Approval Notification: If the pollution report has been approved, it will be marked as such in the app or website, and the user who sent the report will receive a notification in the app that their report has been approved. Then, the pollution entity will be created and filled out by a reviewer who has all the necessary information, including the type of pollution, its severity, and the source of pollution. The reviewer may also add a description, photos, and videos to provide more information about the pollution.
        - Cleanup handling: If the pollution is small, it can be cleaned up by a volunteer group. Otherwise, a specific organization should handle it because they have the necessary equipment and experience. For example, volunteer groups can tackle plastic pollution in forests, but plastic pollution in oceans or rivers should be handled by an organization. The organization may also be responsible for determining the best method of cleanup, such as using specialized equipment or chemicals.
        - Displaying pollution entities: After a new pollution entity has been created, all users and organizations can see it on the map/list and start taking action, such as organizing a volunteer group if it's a small pollution or contributing to a specific organization. Users can also leave comments, suggestions, or ideas on how to tackle the pollution, and the app or website may also provide additional resources or information on the issue.

### **Organization Module:**

- Creation and management: Stores all the organization-related features, such as organization creation and management, as well as the involvement of organizations in the cleanup process.
- Organization involvement: After a new pollution entity has been created, organizations can see it on the map/list and start taking action, such as contributing to the cleanup effort, and managing volunteers.
- Crowdfunding: Enable organizations to create crowdfunding campaigns to raise funds for cleanup efforts. Users can donate money to support the cause and track the progress of the campaign.

### **Admin Module:**

- Dashboard: Handles all the admin-related features, such as admin dashboard, admin reports, and admin permissions.
- Permission management: Admins can assign different levels of permissions to users and reviewers, such as read-only access, write access, or full control. This allows them to control who can access and modify sensitive data in the system.
- Notification management: admins can customize the notifications sent to users and organizations, such as the frequency and content of updates, and manage email templates.
- Progress tracking: The admin can track the progress of pollution cleanup by volunteers or organizations.

### Support Module:

- Create a knowledge base with articles, FAQs, and tutorials to help users troubleshoot issues.
- Allow users to submit support tickets and track their status.
- Offer live chat support with a support agent.
- Allow users to schedule a call with a support agent at a convenient time.

### Monitoring Module:

- Monitor server performance, uptime, and resource usage.
- Notify administrators when servers go down or experience high resource usage.
- Offer real-time analytics on website traffic, user behavior, and conversion rates.
- Monitor website speed and load times, identifying slow-loading pages or resources.
- Provide alerts for security issues, such as potential hacking attempts or unauthorized access.
- Monitor application logs to identify errors, bugs, and crashes.
- Monitor application logs to identify errors, bugs, and crashes.
- Allow administrators to set up custom alerts and thresholds.

### Staff

- Add new staff: The admin can add new staff to the system by providing their basic information, such as name, contact information, and job position. The system should also generate a unique ID for each staff member.
- Edit staff details: The admin can modify the staff's information, such as their contact information or job position. The system should also track any changes made to the staff's details and log the details of the user who made the changes.
- Delete staff: The admin can remove a staff member from the system if they are no longer employed by the organization. The system should also archive their details, including their previous job position and the date of their departure.
- Search staff: The admin can search for a specific staff member using their name, ID, or job position. The system should display a list of all staff members that match the search criteria and allow the admin to view their details.
- View staff details: The admin can view the staff's basic information, such as their name, contact information, and job position. The system should also display any related information, such as their reports or tasks assigned to them.
- Assign tasks: The admin can assign tasks to staff members based on their job position and availability. The system should track the status of each task and notify the staff member when a new task is assigned to them.
- Track progress: The admin can track the progress of each staff member's assigned tasks and view reports on their performance. The system should provide a dashboard that displays key metrics, such as the number of tasks completed and the time taken to complete them.
- Generate reports: The system should provide a feature that allows the admin to generate reports on staff performance, such as the number of tasks completed by each staff member or the average time taken to complete tasks.
- Manage staff permissions: The admin can manage the permissions of each staff member based on their job position and responsibilities. For example, some staff members may have access to sensitive information, while others may not. The system should provide a feature that allows the admin to manage these permissions and track any changes made to them.
- Manage payroll: The system should provide a feature that allows the admin to manage the payroll of each staff member. The admin can view each staff member's salary, track their attendance, and generate reports on payroll expenses.

## **Installation**

To run the Pollution Patrol app locally, you will need to follow these steps:

1. Clone the repository to your local machine.
2. Open the project in your preferred IDE, such as Rider or Visual Studio.
3. Install the necessary dependencies, including ASP.NET Core 7 and MS SQL, Postgres with PostGIS extension.
4. Configure your **`appsetting.json`**file or use the user-secrets manager tool. If you choose to use the user-secrets manager tool, you will need to duplicate every property from the**`appsetting.json`** file but set the actual secret value in the user-secrets manager tool. This is necessary to keep sensitive information, such as API keys and database connection strings, secure and separate from your code.
5. Set up the database and run the necessary migrations for each module.
6. Start the server and navigate to the local address in your web browser.

## **Contributing**

We welcome contributions to Pollution Patrol from developers of all skill levels. If you have an idea for a new feature or improvement, or have found a bug that needs fixing, please create a new issue in the GitHub repository. You can also submit a pull request with your changes, and we will review and merge it if it meets our standards.

## **License**

Pollution Patrol is released under the **[MIT License](https://opensource.org/licenses/MIT)**, which means that you can use, copy, modify, distribute, and sublicense the app for both commercial and non-commercial purposes, as long as you include the original copyright notice and license terms. However, the app is provided "as is" without any warranty, and the developers will not be liable for any damages or losses resulting from the use or inability to use the app.

## Contact

If you have any questions, comments, or feedback about Pollution Patrol, please feel free to contact us at […]**.** We appreciate your interest and support in our mission to fight pollution and make the world a cleaner and safer place.
