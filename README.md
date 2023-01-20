<h2 align="center">
Up School .NET Development Graduation Project
</h3>
<h3 align="center">
This repo includes my project I developed as Up School graduation project.
<br/>
<br/>
<img height="100" width="100" src="https://i.pinimg.com/originals/e7/b9/f7/e7b9f765e3e589e4d445ec3f7069106a.gif" />
</h3>

# Intro

The project topic selection is left to the individuals, however, the desired features in the project content are as follows:
- AspNet Core 3.1 / 5.0 / 6.0 / 7.0
- N Tier Architecture
- Entity Layer
- Data Access Layer
- Business Layer
- Presentation Layer
- DTO Layer
- API Layer
- Identity
- Fluent Validation
- DI Container
- Reporting 
- Dynamic Schedule (A To-Do List on Admin Panel)
- SignalR (Instant Dashboard)
- CQRS 
- Unit Of Work
- Dynamic data extraction from a source like Rapid API.
- SQL Trigger
- Json Web Token

# About

<img width="1233" alt="image" src="https://user-images.githubusercontent.com/107196935/213699163-9e274b70-b984-4388-a7d4-dc41a991339d.png">

A software development training web app similar to [Udemy](https://www.udemy.com/), where users can access educational content in various categories, add courses to the cart and purchase, view the profiles of content producers and filter courses accordingly.

In addition, adding courses with the admin panel, assigning courses to content producers, adding categories, creating campaigns, displaying notifications, displaying data via instant dashboard, creating a to-do list and performing CRUD operations on this list, creating user documents in Excel and also as PDF, consume APIs and with the help of APIs doing translations or searching the internet.

Also, creating a role, assigning a role to users, viewing the communication messages received on the site and replying to them by e-mail, getting informed automatically when a new contact message received.

## Built With

- C#
- .NET Core 5.0
- N Tier Architecture
- Entity Framework
- Fluent API
- JSON Web Token
- SignalR
- HTML, CSS
- JavaScript, Ajax, jQuery
- External API's
- Fluent Validation
- Auto Mapper

## Project Layers

In project I used N Tier architecture and also all of the required layers are provided.

<img width="276" alt="image" src="https://user-images.githubusercontent.com/107196935/213684327-08cc7b52-a297-482b-8f10-c57d6c5f8ee2.png">

## Identity

Project contains Identity framework. User can:

- Register
- Sign In
- Sign Out
- E-Mail Confirm
- Forgot Password operations
- Reset Password via user page
- Access role based pages

<img width="900" alt="image" src="https://user-images.githubusercontent.com/107196935/213691302-f4a84e0e-1444-44b6-b4ec-7cd795542264.png">
<img width="900" alt="image" src="https://user-images.githubusercontent.com/107196935/213694744-2347a625-3e52-47d5-93f1-d33cb994d703.png">
All forms input fields are able to validate the inputs.
<img width="900" alt="image" src="https://user-images.githubusercontent.com/107196935/213695477-0f535ebb-84fe-44dd-86b6-6be5c3bb90e4.png">

## Fluent Validation

Fluent Validation is used in input fields.
<img width="900" alt="image" src="https://user-images.githubusercontent.com/107196935/213712284-0b4062ed-5b36-4af8-8fec-5e9ae74e2266.png">

## DI Container

<img width="900" alt="image" src="https://user-images.githubusercontent.com/107196935/213712711-b7765cf5-1a20-4821-8ff4-3ff37a0d1b62.png">

## Reporting

At Admin Panel, admin can list the users and get the user list data as Excel and download their individual info as PDF. **iTextSharp** and. **ClosedXml** are used.
<img width="900" alt="image" src="https://user-images.githubusercontent.com/107196935/213713685-97a4cd68-c27a-4a35-ac92-b32360e0b0b9.png">
<img width="900" alt="image" src="https://user-images.githubusercontent.com/107196935/213714611-5cf7368b-54f5-4b84-9049-bc6243e8f9b2.png">
<img width="900" alt="image" src="https://user-images.githubusercontent.com/107196935/213715439-bea4c7fc-cc7d-4c24-b7de-2a783d770699.png">

## Dynamic Schedule (To-Do List)

In this part, I benefited heavily from **jQuery** and **Ajax** technologies. The user can update the status, view the details of the list items and delete the list item by performing the requests without refreshing the page.
<img width="1273" alt="image" src="https://user-images.githubusercontent.com/107196935/213717207-a4000d8a-9247-42e2-aaa6-d258d40a3bcf.png">


## Courses

Courses are listed dynamically and be filtered by instructor.
<img width="900" alt="image" src="https://user-images.githubusercontent.com/107196935/213711052-2d3adcac-c9aa-4ed0-81a1-748961dd9116.png">
<img width="900" alt="image" src="https://user-images.githubusercontent.com/107196935/213710332-f2f8d702-d0f8-4ce5-b6c1-3b33119bfb5a.png">







