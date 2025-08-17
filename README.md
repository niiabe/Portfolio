# My First Blazor Portfolio Project

Welcome to my first .NET Blazor project! This is a learning project designed to explore the fundamentals of building a web application with Blazor Server, Entity Framework Core, and modern .NET.

The application is a simple personal portfolio website with a password-protected admin area to manage projects.

## Features

*   **Public Portfolio:** A main page to display projects to visitors.
*   **Admin Dashboard:** A secure area for managing the portfolio content.
*   **Cookie-Based Authentication:** A simple but effective authentication system to protect the admin routes.
*   **Database Integration:** Uses SQLite and Entity Framework Core to store and manage project data.

## Technologies Used

*   **.NET 9**
*   **Blazor Server:** For building an interactive web UI with C#.
*   **Entity Framework Core:** For data access and management.
*   **SQLite:** A lightweight, file-based database for easy setup.
*   **Bootstrap:** For frontend styling.

## Getting Started

Follow these instructions to get the project running on your local machine.

### Prerequisites

*   [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) (or the version specified in `Portfolio.csproj`).

### Running the Application

1.  **Clone the repository:**
    ```bash
    git clone <your-repository-url>
    cd <your-repository-folder>
    ```

2.  **Restore dependencies:**
    This command downloads all the necessary packages for the project.
    ```bash
    dotnet restore
    ```

3.  **Run the application:**
    This command will build and run the project.
    ```bash
    dotnet run
    ```
    The application will be available at `https://localhost:XXXX` and `http://localhost:YYYY`. The exact ports will be shown in your terminal.

4.  **Access the Admin Area:**
    *   Navigate to `/login`.
    *   **Username:** `admin`
    *   **Password:** `admin123`

5.  **Populate DB with some Projects:**
    *   Click on Seed Sample Data to get some Data in the DB.
 

## Project Structure

Here's a brief overview of the key files and folders to help you navigate the codebase:

*   **`Program.cs`**: The entry point of the application. This is where services are configured (like the database, authentication, etc.) and the HTTP request pipeline is set up.

*   **`Components/`**: This is the heart of the Blazor application.
    *   **`Components/Pages/`**: Contains the routable pages of the application (e.g., the home page and admin pages).
    *   **`Components/Layout/`**: Contains the layouts for the application (e.g., `MainLayout.razor` for the public site and `AdminLayout.razor` for the admin area).
    *   **`Components/App.razor`**: The root component of the application.
    *   **`Components/Routes.razor`**: Defines how URLs are mapped to Blazor components.

*   **`Data/`**: Contains the `PortfolioDbContext.cs`, which defines the database structure using Entity Framework Core.

*   **`Models/`**: Contains the C# classes that represent your data (e.g., `Project.cs`).

*   **`Services/`**: Contains services used for business logic, like `SimpleAuthService.cs` for handling logins.

*   **`appsettings.json`**: Configuration file for the application. You can store settings like database connection strings or admin credentials here.

## Future Plans

This project was a great first step. For future projects, I plan to explore more advanced features, such as:

*   Implementing API for CRUD Operations.
*   Adding user registration and more complex role management.
*   Deploying the application to a cloud provider like Azure.
*   Writing automated tests to ensure code quality.

---

