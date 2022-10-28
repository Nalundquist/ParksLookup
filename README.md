# Parks Lookup

### Created by Noah Lundquist in October of 2022

## Links

* [Repository](https://github.com/nalundquist/ParksLookup)

## Description

An API for looking up National/State Parks.  Has full CRUD functionality on routes of the Parks Controller.  Has some existing parks inside but most of them are from the realm of the imagination, much to my chagrin.  Uses bearer token authorization for the majority of routes.

## Features

* Be authorized with a bearer token
* once authorized view a list of Parks
* Filter parks by State/National
* Add, Delete, or Edit individual park entries.


## Technologies Used

* Built in VS Code (v.1.70.1) using the following languages:
	* C#

* ASP.Net Core
* MySQL Database
* MySQL Workbench
* Entity Framework

Tested in Postman

## Installation

* Download [Git Bash](https://git-scm.com/downloads)
* Input the following into Git Bash to clone this repository onto your computer:

		>git clone https://github.com/nalundquist/ParksLookup


* Enter the cloned project folder "/ParksLookup/ParksLookup" and type:

		>dotnet restore

followed by

		>dotnet build

*After this, create an appsettings.json file in the root /ParksLookup folder (sub in your own set username and password for the bracketed bits)

```		
		{
			"Logging": {
				"LogLevel": {
					"Default": "Warning",
					"System": "Information",
					"Microsoft": "Information"
				}
			},
			"AllowedHosts": "*",
			"JWT": {
				"Key": "kshioahfhdoihfidohishf",
				"Issuer": "a",
				"Audience": "a"
			},
			"ConnectionStrings": {
				"DefaultConnection": "Server=localhost;Port=3306;database=parkslookup;uid=root;pwd=epicodus;"
			}
		}
```
note that the Key, Issuer, and Audience fields can have any value in quotes *BUT* the value in Key must be over 16 characters (or 128 bits).

* next, type into console in the root directory:

		>dotnet ef database update

* Finally, navigate to the / directory in git bash (if you navigated away) and type  

		>dotnet run

Next, download, configure, and run [Postman](https://www.postman.com/downloads/).  Once inside you can use:

### Routes

#### Auth

Do this before anything else.  Make a new POST request to the address `http://localhost:5000/api/parks/auth`.  In the "Body" tab of the request, paste the following:

```
{
    "name": "user1",
    "password": "pass123"
}
```
and press the blue button on the right of your screen to Send it.  The body of the response you receive should look something like this:

```
{
    "tokensId": 0,
    "token": "{BEARER-TOKEN-HERE}",
    "refreshToken": null
}
```
Hold on the the value represented by {BEARER-TOKEN-HERE}.  

In all of our API calls after this one your will need to authorize using this token.  In the "Auth" or "Authorize" tab under any call specify a "Type" of "Bearer Token" and then paste your bearer token from the Auth Route into the "Token" field to the right.  This is necessary for each API call other than Auth.

## Known Bugs

## License

Licensed under [GNU GPL 3.0](https://www.gnu.org/licenses/gpl-3.0.en.html)