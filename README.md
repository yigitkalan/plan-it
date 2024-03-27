# PLAN-it: A Task Management Platform

**PLAN-it** is a web-based task management platform that empowers you to organize and track your projects effectively. It provides a user-friendly interface for creating boards, columns within them, and assigning tasks with clear visibility into their status.

## Backend Technologies:

- **ASP.NET Core 7:** A modern, open-source, and cross-platform framework from Microsoft for building high-performance web applications.
- **Onion Architecture:** A layered architecture style promoting separation of concerns, testability, and maintainability. Layers include:
  - **Domain:** Encapsulates core business logic entities and their relationships.
  - **Application:** Implements application-specific features, abstractions (interfaces), DTOs (Data Transfer Objects), behaviors (services), and exceptions.
  - **Persistence:** Handles data access and persistence logic, often using a data access layer or an ORM (Object-Relational Mapping) framework.
  - **Web:** Responsible for exposing web APIs and controllers, handling user interactions, and configuration.

## Backend Design Patterns and Practices:

- **CQRS (Command Query Responsibility Segregation):** Separates read (queries) and write (commands) operations, allowing for optimizations and improved scalability.
- **Generic Repository Pattern:** Provides a reusable abstraction for data access across different data storage types (e.g., databases).
- **Global Exception Handler:** Centralizes error handling, providing a consistent and informative response to client requests in case of exceptions.
- **MediatR:** A lightweight message mediator pattern that simplifies communication between application layers and decoupling components.
- **Fluent Validation:** Enables writing clear and expressive validation rules for entities or models.
- **Identity:** Provides user authentication and authorization mechanisms.
- **Role-Based Authentication (RBAC):** Controls access to resources based on a user's assigned roles.
- **JWT (JSON Web Token) Services:** Implements secure authentication token generation, distribution, and validation.
- **AutoMapper:** Creates mapping configurations between types and enables transformation in runtime

## Database:

- **SQLite:** A lightweight, embedded relational database ideal for development due to its ease of use and no setup required.

## Frontend:

- **Next.js:** A popular React framework for building server-rendered and statically generated web applications, offering performance and SEO benefits.
- **Components:** Encapsulate reusable UI elements, promoting the DRY (Don't Repeat Yourself) principle and enhancing code maintainability.
- **Services:** Handle data fetching and communication with the backend API using methods like fetch or a dedicated library (e.g., Axios).
- **CORS (Cross-Origin Resource Sharing) Configuration:** Enables communication between frontend and backend on different domains or ports, ensuring secure API requests.
