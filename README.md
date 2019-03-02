# _Word Counter_

#### _A web application for a hair salon, Created 03/01/2019_

#### By _**Yulia Shidlovskaya**_

## Description

_An MVC web application for a hair salon that allows to manage stylists and their clients: add, edit, show and delete._

_The program uses the following specifications:_

* The program shows a list of all stylists.
* The program allows to select a stylist to see their details.
* The program shows a list of all clients that belong to that stylist.
* The program allows to edit stylist's details.
* The program allows to add new stylists to the system.
* The program allows to add new clients to a specific stylist.
* The program allows to edit client's details.
* The program allows to delete a client.
* The program allows to delete a selected stylist with all their clients.

## Setup/Installation Requirements

Requirements Software:

* Download .NET Core 1.1.4 SDK, .NET Core Runtime 1.1.2, .NET Core static files middleware 1.1.3 and install them.
* Download Mono and install it.

1. Clone this repository: $ git clone repo name
2. Change into the work directory: $ cd WordCounter.Solution
3. To edit the project, open the project in your preferred text editor.
4. To set up the server, use commands: $ dotnet restore $ dotnet build $ dotnet run
5. To open web application, enter http://localhost:5000/ in any browser
6. To run the tests, use these commands: $ cd WordCounter.Tests $ dotnet test

CREATE DATABASE yulia_shidlovskaya;
USE yulia_shidlovskaya;

CREATE TABLE stylists(id serial PRIMARY KEY, name VARCHAR(255), email VARCHAR(255), phone_number VARCHAR(15), schedule VARCHAR(255),haircut_styles VARCHAR(255));

CREATE TABLE clients(id serial PRIMARY KEY, stylist_id INT, name VARCHAR(255), email VARCHAR(255), phone_number VARCHAR(15));


## Known Bugs

_No known bugs_

## Support and contact details

_If you run into any issues or have questions, ideas or concerns. Please email me at sjullieb@gmail.com_

## Technologies Used

* _C#_
* _.NET Core_
* _Mono_
* _MSTest_

### License

*MIT*

Copyright (c) 2019 **_Yulia Shidlovskaya_**
