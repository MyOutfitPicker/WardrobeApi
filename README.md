# Wardrobe API

## Overview
The **Wardrobe API** is a backend service designed to manage wardrobe items and outfits. It provides endpoints for CRUD operations on wardrobe items and outfits, and can be used as a base for building wardrobe or outfit management applications.

## Features
- **Manage Items**: Create, retrieve, update, and delete wardrobe items.
- **Manage Outfits**: Create and retrieve outfits based on wardrobe items.
- **Database Support**: Uses SQLite by default but is configurable for other database providers.
- **Interactive API Documentation**: Swagger UI available for testing the API endpoints.

---

## Prerequisites
Before running the project, ensure you have the following installed:

- **.NET 6 or later**: [Download .NET](https://dotnet.microsoft.com/download)
- **SQLite tools**: For inspecting the local SQLite database.
- **IDE/Editor**: Visual Studio, Visual Studio Code, or any C#-compatible editor.

---

## Setup Instructions

### 1. Clone the Repository
```bash
git clone <repository-url>
cd WardrobeAPI
```

### 2. Install Dependencies

Restore all required NuGet packages:

```bash
dotnet restore
```

3. Apply Database Migrations
Set up the SQLite database by applying the Entity Framework migrations:

```bash
dotnet ef database update
```

4. Run the Application
Start the Wardrobe API:

```bash
dotnet run
```
