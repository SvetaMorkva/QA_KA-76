# Lab 3
## Part 1
Create test scenarios which will cover the next functionality inside Dropbox API:
* Create folder
* Add new file to the existing folder
* Get file
* Get list of files in the folder
* Delete folder (delete file) – what will happen if you delete folder with a file inside

* Try to get folder (file) after delete

## Part 2
Emphasize OOP principles used in the project:
* Polymorhphism
* Inheritance
* Encapsulation
* Abstraction 

## Bonus task
Implement authorization using OAuth 2.0 using https://www.dropbox.com/oauth2/authorize endpoint.

# Project setup
## Install dependencies:
* Fluent assertions:
    dotnet add package FluentAssertions --version 5.10.3
* Specflow:
    dotnet add package SpecFlow --version 3.1.97
* Newtonsoft.Json:
    dotnet add package Newtonsoft.Json --version 12.0.3
* XUnit:
    dotnet add package xunit --version 2.4.1