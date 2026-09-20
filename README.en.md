# TourismBI - Tourism Platform

![status](https://img.shields.io/badge/status-prototype-orange)
![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)


[Ð‘ÑŠÐ»Ð³Ð°Ñ€ÑÐºÐ¸](README.md) | English

`TourismBI` is the initial prototype of a tourism platform intended to bring together tourist attractions, users, reviews, favorite places, and data for future BI analysis.

This version contains the original state of the project, started in 2025, before the redesign of the user model, roles, and architecture.

## Status

The project has a `prototype` status. This version is intended for learning and is not suitable for real-world use.

## Technologies

- C#
- .NET 10
- Visual Studio
- BCrypt.Net-Next
- Git
- SQL Server â€” used to create a local database that is not included in this repository

## Structure

`TourismBI.Domain` contains the initial domain models and rules:

- `User`
- `Tourist`
- `TouristPlace`
- `Review`
- `Signal`
- `UserRole`
- interfaces for password hashing and validation
- initial domain services and validation constants

`TourismBI.Application` contains an initial attempt to implement a password hashing service using BCrypt.

In its original form, the user model is based on an abstract `User` base class. The planned roles are:

- tourist;
- tourism business representative or tourist site owner;
- public institution representative;
- administrator.

Each user can have only one `UserRole` value.

The administrator is intended to restrict user access when necessary, while the other roles receive different permissions according to their responsibilities within the platform.

The initial prototype provides its own password management through `IPasswordHasher` and BCrypt.

## Project Goal

The main goal of TourismBI is to evolve into a real ASP.NET Core MVC platform for tourists, tourism business representatives, and public institutions.

The platform should provide a foundation for collecting, managing, and analyzing tourism data. At the same time, it serves as a practical application of OOP, ASP.NET Core, Entity Framework Core, security, and software architecture concepts.

Future versions are planned to include:

- an ASP.NET Core MVC Web application;
- ASP.NET Core Identity for registration, sign-in, passwords, and assigned roles;
- separation of the Identity account from the user's domain profile;
- support for multiple roles per user;
- a process for requesting, verifying, and approving privileged roles;
- user profiles for tourists, business representatives, and public institutions;
- a catalog of tourist attractions;
- searching and filtering of tourist attractions;
- adding and archiving favorite places;
- publishing, editing, and moderating reviews;
- preservation of important change history through statuses and soft deletion;
- EF Core and migrations for database management;
- data import from reliable official and open data sources;
- a future analytics and BI module;
- configuration of sensitive values through environment variables;
- automated tests and project verification through GitHub Actions.

## Architectural Direction

The initial model uses inheritance to represent user roles:

```text
User
â””â”€â”€ Tourist
```

Future versions will transition to ASP.NET Core Identity.

The Identity account will be separated from the domain profile, while assigned roles will be managed through a many-to-many relationship between users and roles.

```text
ApplicationUser * â”€â”€â”€â”€â”€â”€â”€ * IdentityRole
        â”‚
        â””â”€â”€ UserProfile
```

## Project Version

The initial prototype is preserved with the following Git tag:

```text
v0.1-prototype
```

This tag serves as a baseline for comparison with future versions of the project.

## Limitations

Version `v0.1-prototype` has the following limitations:

- an ASP.NET Core MVC Web project has not yet been created;
- controllers and views have not yet been implemented;
- there is no completed EF Core `DbContext`;
- EF Core migrations for recreating the database are missing;
- `TouristPlace` and `Review` are incomplete initial models;
- `Tourist` attempts to modify `PasswordHash`, but its `set` accessor is inaccessible;
- `Tourist.cs` contains a syntax error caused by an extra closing brace;
- authentication and authorization do not yet use ASP.NET Core Identity;
- the model supports only one role per user;
- there is no process for requesting, verifying, and approving roles.

The purpose of this version and its preserved limitations is to show the project's actual starting point and make its subsequent development visible.
