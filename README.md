# CatalogAPI - .NET Core Web API with MongoDB

A greenfield ASP.NET Core Web API project demonstrating CRUD operations with MongoDB.

## Features
- ASP.NET Core 6 Web API
- MongoDB.Driver integration
- Repository pattern for data access abstraction
- Dependency Injection with DI container
- Swagger API documentation for easy testing
- Well-structured, clean and ready to extend

## Requirements
- .NET 6 SDK or later
- MongoDB running locally or Atlas connection string configured

## Getting Started
1. Clone this repository
2. Update `appsettings.json` with your MongoDB connection string
3. Build and run the project:
4. Access Swagger UI: `https://localhost:<port>/swagger`

## API Endpoints
- `GET /api/catalog` - Get all items
- `GET /api/catalog/{id}` - Get item by ID
- `POST /api/catalog` - Create new item
- `PUT /api/catalog/{id}` - Update item by ID
- `DELETE /api/catalog/{id}` - Delete item by ID

## Extend
Feel free to add authentication, validation, or enrich entity schema.

---

This project showcases foundational skills in .NET Core and MongoDB integration for backend development.
