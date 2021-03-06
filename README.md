# _Hair Salon_

#### _A web application for a hair salon, Created 03/01/2019_

#### By _**Yulia Shidlovskaya**_

## Description

_An MVC web application for a hair salon that allows to manage stylists and their clients: add, edit, show and delete._

_The program uses the following specifications:_

* The program shows a list of all stylists.
* The program allows to select a stylist, see their details, and see a list of all clients that belong to that stylist.
* The program shows a list of all clients that belong to that stylist.
* The program allows to edit stylist's details.
* The program allows to add new stylists to the system.
* The program allows to add new clients to a specific stylist. A client can't be added if no stylists have been added.
* The program allows to edit client's details.
* The program allows to delete a client.
* The program allows to delete all clients.
* The program allows to delete a selected stylist with all their clients.
* The program allows to delete all stylists.
* The program allows to view a selected client.
* The program allows to view all clients.
* The program allows to add a specialty.
* The program allows to view all specialties.
* The program allows to add an existing specialty to an existing stylist.
* The program allows to add an existing stylist to an existing specialty.
* The program allows to view all stylists with a selected specialty.
* The program allows to view all specialties for a selected stylist on his detail page.

## Setup/Installation Requirements

Requirements Software:

Download and install:
* .NET Core 1.1.4 SDK, .NET Core Runtime 1.1.2, .NET Core static files middleware 1.1.3
* Mono
* MAMP

Clone this repository: $ git clone repo name
Change into the work directory: $ cd HairSalon.Solution

Export database into phpMyAdmin:

* Start MAMP and click Open WebStart page in the MAMP window.
* In the website you're taken to, select phpMyAdmin from the Tools dropdown.
* Select the Import tab.
* Note that it's important to make sure you're not importing to a database that already exists, so make sure that a database with the same name as the one you're importing isn't already present.
* Select your yulia_shidlovskaya.sql file, and click Go.
* Do the same for yulia_shidlovskaya_file.sql to restore test database.

* Open and edit the project in your preferred text editor.
* Run commands: $ dotnet restore $ dotnet build $ dotnet run
* To open web application, enter http://localhost:5000/ in any browser
* To run the tests, use these commands: $ cd HairSalon.Tests $ dotnet test


To recreate database In MySQL:

> CREATE DATABASE yulia_shidlovskaya;
> USE to_do;
> CREATE TABLE clients (id serial PRIMARY KEY, stylist_id int,  name varchar(255), email varchar(255), phone_number varchar(15));
> CREATE TABLE specialties(id serial PRIMARY KEY, description varchar(255));
> CREATE TABLE stylists (id serial PRIMARY KEY, name varchar(255), email varchar(255), phone_number varchar(15), schedule varchar(255), haircut_styles varchar(255));
> CREATE TABLE stylists_specialties (id serial PRIMARY KEY, stylist_id int, specialty_id int);


## Known Bugs

_No known bugs_

## Support and contact details

_If you run into any issues or have questions, ideas or concerns. Please email me at sjullieb@gmail.com_

## Technologies Used

* _C#_
* _.NET Core_
* _Mono_
* _MSTest_
* _MAMP_
* _MySQL_

### License

*MIT*

Copyright (c) 2019 **_Yulia Shidlovskaya_**
