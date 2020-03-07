# Student Management
Our School is managing students information: a CRUD in C# with SQL Server, Dockers, Dappers

# STUDENTS ERP
An ERP to manage the information from the school students. The school staff can create and add the information of new students, access this information, Edit the information and delete the student information once he is graduated.

This is a group project with @jmoM5 and @raimonestanyol. 

We are going to develop the CRUD in 5 different ways:
1) With SQL Server
2) With stored procedures (Transact)
3) With Entity framework - Code first
4) With Entity framework - Data first
5) With Dapper (an object mapper framework)

# Getting Started
This ERP is in C# code. We reccomend Visual Studio to check the code.

# Implementation
In this implementation, We tried to apply Single Responsibility in the classes and methods. In a first moment, after We analysed the project, I segregate the problem in tasks and classes, creating a StudentDao class and methods for the CRUD.

The data that the school staff will manage will be:

- StudentId
- StudentName
- StudentLastName
- BirthDate

## Classes:

-- frmStudent:
-- StudentDao:


# Product Backlog
Refactorize the code: Using 10x10x10 rule.
Add more information to student file (Grades, Country, Previous studies...)
Apply SOLID principles.

# Technology Stack
C# | .NET FRAMEWORK | MSTest
