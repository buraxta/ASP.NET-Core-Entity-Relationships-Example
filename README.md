# ASP.NET Core Entity Relationships Example

This repository is designed specifically to demonstrate and understand how different **entity relationships** (One-to-One, One-to-Many, Many-to-Many) work in **ASP.NET Core** applications using **Entity Framework Core**.

The primary purpose of this project is **educational** — to showcase how to implement, manage, and use these relationships in a real-world ASP.NET Core project with **DTOs (Data Transfer Objects)**, **Controllers**, and **Entity Framework Core**.

## Project Overview

The project covers the following:

- **One-to-One Relationship**: Example of entities that are related in a one-to-one manner, such as `User` and `UserProfile`.
- **One-to-Many Relationship**: Demonstrates entities with one-to-many relationships, such as `Blog` having multiple `Post` entities.
- **Many-to-Many Relationship**: Showcases a relationship where multiple entities are associated with multiple others, such as `Student` and `Course`.

The system is structured with clear and clean usage of **DTOs** and **Controllers** for each entity. These demonstrate how to efficiently transfer data between layers, ensuring that you return only the necessary data and avoid direct exposure of your internal entity models.

## Database Diagram

A database diagram is included in the repository to visually demonstrate the relationships between entities.  
<br/>
<img src="https://github.com/buraxta/ASP.NET-Core-Entity-Relationships-Example/blob/main/ss/ss.png?raw=true" />
## Key Learning Areas

- **Entity Framework Core Relationships**: Implementing One-to-One, One-to-Many, and Many-to-Many relationships using EF Core.
- **DTOs**: Using Data Transfer Objects to separate concerns and control the shape of the data being exposed via APIs.
- **API Controllers**: How to structure controllers to work with complex relationships in an API.
- **Database Schema Design**: Understanding how relationships are mapped in the database and how this affects API behavior.

## Purpose

This repository serves as a **learning resource** for:

- ASP.NET Core beginners wanting to understand entity relationships.
- Developers interested in seeing how DTOs and controllers can be effectively used with complex relationships.
- Anyone looking for an example project demonstrating how to handle different types of relationships in Entity Framework Core.

## Getting Started

1. **Clone the repository**:
    ```bash
    git clone https://github.com/buraxta/ASP.NET-Core-Entity-Relationships-Example.git
    cd asp-net-core-entity-relationships-example
    ```

2. **Setup the project**:
    - Ensure you have .NET 6 or later installed.
    - Set up the database (SQL Server by default, but can be configured for others).

3. **Run the project**:
    - Open a terminal or command prompt.
    - Navigate to the project folder.
    - Run the following command:
    ```bash
    dotnet run
    ```

4. **Access the API**:
    - The API should be available at `http://localhost:5000/`.
    - You can test the endpoints for users, blogs, posts, and courses.

## Example Usage

- **GET /users**: Fetch all users along with their profiles.
- **POST /users**: Create a new user along with their profile.
- **GET /blogs/{blogId}/posts**: Fetch posts associated with a specific blog.
- **POST /students/courses**: Enroll a student into one or more courses.


## Conclusion

This repository's main focus is on understanding and working with **entity relationships** in **ASP.NET Core**. By following the examples here, you'll gain a solid understanding of how to model and implement relationships in a real-world API with EF Core and DTOs.
