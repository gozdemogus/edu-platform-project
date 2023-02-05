<a name="readme-top"></a>
<h2 align="center">
Up School .NET Development Graduation Project
</h3>
<h3 align="center">
This repo includes my project I developed as Up School graduation project.
<br/>
<br/>
<img height="100" width="100" src="https://i.pinimg.com/originals/e7/b9/f7/e7b9f765e3e589e4d445ec3f7069106a.gif" />
</h3>

# About

https://user-images.githubusercontent.com/107196935/216828760-08215020-a1cb-42ac-a9b8-657e63c86751.mov

An education aimed web app similar to [Udemy](https://www.udemy.com/), where users can access educational content in various categories, add courses to the cart and purchase, view the profiles of content producers and filter courses accordingly.

In addition, adding courses with the admin panel, assigning courses to content producers, adding categories, creating campaigns, displaying notifications, displaying data via instant dashboard, creating a to-do list and performing CRUD operations on this list, creating user documents in Excel and also as PDF, consume APIs and with the help of APIs doing translations or searching the internet.

Also, creating a role, assigning a role to users, viewing the communication messages received on the site and replying to them by e-mail, getting informed automatically when a new contact message received.


# Intro

The project topic selection is left to the individuals, however, the desired and completed features in the project content are as follows:
- AspNet Core 3.1 / 5.0 / 6.0 / 7.0
- N Tier Architecture
- Entity Layer
- Data Access Layer
- Business Layer
- Presentation Layer
- [Identity](#identity)
- [DI Container](#di-container)
- [Reporting](#reporting) 
- [Dynamic Schedule (To-Do List)](#dynamic-schedule-to-do-list)
- [SignalR - Instant Dashboard](#signalr---instant-dashboard)
- [CQRS - Unit Of Work](#cqrs---unit-of-work)
- [Dynamic API Consume](#dynamic-api-consume)
- [SQL Trigger](#sql-trigger)
- [JSON Web Token](#json-web-token)
- [DTO Layer](#dto-layer)
- [API Layer](#api-layer)
- [Fluent Validation](#fluent-validation)

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

## Division

### The Showcase

Which is offered to the end user, where operations such as course listing, enrollment and purchasing are carried out.

https://user-images.githubusercontent.com/107196935/216832870-471b64eb-52ba-4223-99a5-f824cac12b17.mov

### Admin Panel

With dynamic dashboard where operations such as adding courses, managing, assigning roles, user document operations are done.

I used **SignalR** in order to get instant data on charts and analysis at widgets and used **jQuery** and **Ajax** for updating To-Do's. Also, an **API** is consumed in order to get instant Bitcoin rate. The data exchange interval especially kept this short in order to show the instant change.

https://user-images.githubusercontent.com/107196935/216830514-1e5b39d5-46d6-40de-9b80-ce95c0155152.mov

## Project Layers

In project I used N Tier architecture and also all of the required layers are provided.
<p align="center">
<img width="276" alt="image" src="https://user-images.githubusercontent.com/107196935/213684327-08cc7b52-a297-482b-8f10-c57d6c5f8ee2.png">
</p>

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Identity

Project contains Identity framework. User can:

- Register
- Sign In
- Sign Out
- E-Mail Confirm
- Forgot Password operations
- Reset Password via user page
- Access role based pages

<img width="1403" alt="image" src="https://user-images.githubusercontent.com/107196935/213691302-f4a84e0e-1444-44b6-b4ec-7cd795542264.png">
<img width="1403" alt="image" src="https://user-images.githubusercontent.com/107196935/213694744-2347a625-3e52-47d5-93f1-d33cb994d703.png">
<img width="1403" alt="image" src="https://user-images.githubusercontent.com/107196935/216823341-bb3a94b7-06c5-49ba-9220-fd18929128bf.png">All forms input fields are able to validate the inputs.
<img width="1403" alt="image" src="https://user-images.githubusercontent.com/107196935/213695477-0f535ebb-84fe-44dd-86b6-6be5c3bb90e4.png">

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## DI Container

<img width="1403" alt="image" src="https://user-images.githubusercontent.com/107196935/213712711-b7765cf5-1a20-4821-8ff4-3ff37a0d1b62.png">

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Reporting

At Admin Panel, admin can list the users and get the user list data as Excel and download their individual info as PDF. **iTextSharp** and. **ClosedXml** are used.
<img width="900" alt="image" src="https://user-images.githubusercontent.com/107196935/213713685-97a4cd68-c27a-4a35-ac92-b32360e0b0b9.png">
<img width="900" alt="image" src="https://user-images.githubusercontent.com/107196935/213714611-5cf7368b-54f5-4b84-9049-bc6243e8f9b2.png">
<img width="900" alt="image" src="https://user-images.githubusercontent.com/107196935/213715439-bea4c7fc-cc7d-4c24-b7de-2a783d770699.png">

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Dynamic Schedule (To-Do List)

In this part, I benefited heavily from **jQuery** and **Ajax** technologies. The user can update the status, view the details of the list items and delete the list item by performing the requests without refreshing the page.
<img width="1273" alt="image" src="https://user-images.githubusercontent.com/107196935/213717207-a4000d8a-9247-42e2-aaa6-d258d40a3bcf.png">

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## SignalR - Instant Dashboard

With SignalR, I transferred various analysis and statistical data to the dashboard instantly and pulled the instant Bitcoin data through an API and displayed it on the screen.
<img width="1441" alt="image" src="https://user-images.githubusercontent.com/107196935/213720459-ed4d77e3-41c1-400c-8be6-b890f9861dab.png">

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## CQRS - Unit Of Work

I did all the operations in the Course entity with CQRS. 

<img width="1552" alt="Ekran Resmi 2023-02-05 20 16 05" src="https://user-images.githubusercontent.com/107196935/216835287-eccf22f6-e1cf-4075-9c64-0ed1627ad930.png">
<p align="center">
<img width="284" alt="image" src="https://user-images.githubusercontent.com/107196935/213721863-b6f477e2-d572-47c1-ada0-38a1ba5d7de8.png">
</p>

I carried out the approval processes in the payment system with **Unit of Work**. I assigned a SuperAdmin user as default and when user wants to buy the course credits passing into the SuperAdmin's balance.

<p align="center">
<img width="779" alt="image" src="https://user-images.githubusercontent.com/107196935/216837259-45ad9c5d-3916-4326-ab4e-fb4748e82498.png">
</p>

<img width="1346" alt="image" src="https://user-images.githubusercontent.com/107196935/213722212-3666197a-16bd-4a8d-83bb-b963693d6f0b.png">

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Dynamic API Consume

With the translator API that I have integrated, translation can be made in the desired target language and search results can be accessed via the search engine API.
<img width="1288" alt="image" src="https://user-images.githubusercontent.com/107196935/213723182-c2d92eaa-49d3-48c6-8636-4202fdff0a89.png">
<img width="1288" alt="image" src="https://user-images.githubusercontent.com/107196935/213723599-5ab1ef7b-4ff8-4705-9827-50fd4a0ace0d.png">

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## SQL Trigger

I created a trigger that allows records to be posted to the Notifications table when a record is sent to the Contacts table, and inserts parameters from the contacts table there.

``` sql
CREATE TRIGGER NotificationTrigger ON Contacts
AFTER INSERT
AS BEGIN TRY
  SET NOCOUNT ON;
  INSERT INTO Notifications (Message, DateTime, MessageWriter)
  SELECT 'A new contact message received', GETDATE(), ISNULL(inserted.UserName, 'Unknown User')
  FROM inserted;
END TRY
BEGIN CATCH
      ROLLBACK TRANSACTION;
      THROW;
END CATCH
```

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## JSON Web Token

I included JSON Web Token in API-Campaign layer and used it in campaigns access service. I set token duration as 5 minutes and after accessing the token, I saved it over the cookies for future requests.
<img width="1325" alt="image" src="https://user-images.githubusercontent.com/107196935/213728479-2630487b-07ab-4a81-96a4-f5aa0d673cec.png">

```csharp
   Response.Cookies.Append("access_token", (string)token, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true, // set to true if you're using https
                        Expires = DateTime.Now.AddMinutes(5)
                   });
                   
  ```
  
<img width="1047" alt="image" src="https://user-images.githubusercontent.com/107196935/213756238-31f6418a-cac7-43c7-9b93-8e2d22bdbf08.png">
<img width="1047" alt="image" src="https://user-images.githubusercontent.com/107196935/213728098-b79c08f0-358b-43ba-a897-9dbded308fc1.png">

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## API Layer

I developed Campaign entities in API layer and provided all the CRUD operations via API requests.
<img width="900" alt="image" src="https://user-images.githubusercontent.com/107196935/213732724-264e43e0-ae6d-4018-8141-846ea56b5f0e.png">

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## DTO Layer

<img width="900" alt="image" src="https://user-images.githubusercontent.com/107196935/213733044-0100da55-6bfc-4b1b-aa76-901aea48f7c9.png">

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Fluent Validation

Fluent Validation is used in input fields.
<img width="1403" alt="image" src="https://user-images.githubusercontent.com/107196935/213712284-0b4062ed-5b36-4af8-8fec-5e9ae74e2266.png">

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Courses

Courses are listed dynamically and be filtered by instructor.
<img width="1403" alt="image" src="https://user-images.githubusercontent.com/107196935/216821845-1eabfc5f-2cd0-468e-93aa-1d908f360182.png">
<img width="1403" alt="image" src="https://user-images.githubusercontent.com/107196935/213710332-f2f8d702-d0f8-4ce5-b6c1-3b33119bfb5a.png">

<p align="right">(<a href="#readme-top">back to top</a>)</p>


## Cart

Users can add the courses they want to buy to the cart, see the total amount in the cart and buy them. In addition, the undesired courses can be removed from the cart, the updated new amount is reflected in the cart.

<img width="1403" alt="image" src="https://user-images.githubusercontent.com/107196935/216821538-f91a0df9-ef06-4af3-b8f5-8aaae6586f97.png">


## Error Pages
404 - Not Found
<img width="1403" alt="image" src="https://user-images.githubusercontent.com/107196935/213753275-31414b4c-302a-4e0b-9e61-94f064c2e8ab.png">
403 - Unauthorized
<img width="1403" alt="image" src="https://user-images.githubusercontent.com/107196935/213754364-3e5b1c76-162c-4f85-babf-92a0f064da56.png">

<p align="right">(<a href="#readme-top">back to top</a>)</p>



