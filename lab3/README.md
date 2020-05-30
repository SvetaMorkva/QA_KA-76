# Lab 3
## Part 1
1. Refer to this API: https://www.dropbox.com/developers/documentation/http/overview
2. Cover the next endpoints with tests (C# or JS) and execute in CI:
    * GetFileMetaData
    * Delete file
3. Create a postman collection with the requests

## Part 2
Emphasize OOP principles used in the project:
* Polymorhphism
* Inheritance
* Encapsulation
* Abstraction 

# Project setup
## 1. Create console application:
Execute the following command in the .NET CLI:
    `dotnet new console`

## 2. Setup test environment: 
* Create and then move to a *test* folder.
* Execute `dotnet new xunit`

## 2. Install dependencies:
* Fluent assertions:
    `dotnet add package FluentAssertions --version 5.10.3`
* Specflow:
    `dotnet add package SpecFlow --version 3.1.97`
    `dotnet add package SpecFlow.xUnit --version 3.1.97`
    `dotnet add package SpecFlow.Tools.MsBuild.Generation --version 3.1.97`
* Newtonsoft.Json:
    `dotnet add package Newtonsoft.Json --version 12.0.3`
* Dropbox .NET API:
    `dotnet add package Dropbox.Api --version 4.10.0`

## Notices
If you are using .NET core SDK 3.1. and higher the following problem may occur with using Specflow:
>FileNotFoundException: Could not load file or assembly
>'TechTalk.SpecFlow, Version=3.1.0.0, Culture=neutral,
>PublicKeyToken=xxxxxx'. The system cannot find the file specified.
>File name: 'TechTalk.SpecFlow, Version=3.1.0.0, Culture=neutral,
>PublicKeyToken=0778194805d6db41'

As described in [THIS](https://github.com/SpecFlowOSS/SpecFlow/issues/1939) discussion the solution is to setup the following environment variable:
    `MSBUILDSINGLELOADCONTEXT=1`