# Project Management System

A simple Project Management System developed using **Angular** for the frontend and **.NET Web API** for the backend with **SQL Server** as the database.

## Features

- User Management
- Project Management
- Task Management
- Login Authentication
- Search Functionality
- Add, Edit and Delete Operations
- Dashboard

## Technologies Used

### Frontend
- Angular
- TypeScript
- HTML
- SCSS

### Backend
- ASP.NET Core Web API (.NET)
- C#

### Database
- Microsoft SQL Server

## Project Structure

```
Project-Management-System/
│
├── src/                    # Angular Frontend
├── ProjectManagementAPI/   # .NET Backend
├── DataBase/               # SQL Database Script
└── README.md
```

## How to Run

### Frontend

```bash
npm install
ng serve
```

Frontend runs at:

```
http://localhost:4200
```

### Backend

Open the `ProjectManagementAPI` solution in Visual Studio and run the project.

Swagger will be available at:

```
https://localhost:7165/swagger
```

### Database

Execute the SQL script located in:

```
DataBase/ProjectManagementDB.sql
```

using Microsoft SQL Server Management Studio (SSMS).

## Author

**Ann Mariya Eldhose**