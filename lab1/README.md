# Lab1. Problem Statement
Состоит из 2ух задачек, необходимо написать минимум по 2 юнит теста к каждой задачке, всё решение должно быть залито в Гит в репозиторий, созданный под каждую группу, каждому будет необходимо создать билд джобу на СI и заранить там свои тесты с своей бранчи
В качестве решения - мы ожидаем ссылку на решение в Гите, ссылки на успешные раны на СI.
Бранчи необходимо называть по такому патерну - firstName.LasteName_lab
Дедлайн - 22.04 23:59.

# Непосредственно задачи на C#
* Вариант №1 - напишите свою имплементацию двусвязного списка, метод Add, GetCurrent, GetNext, GetPrevious

* Задача №2. Write С# CompareVersions() method, which takes as parameters 2 strings. These strings are product versions. Product version consists of unlimited versions and subversions. Pattern for version is numbers and dot delimiters. If first version is greater than second method returns 1, if equals 0, if less -1.
Examples:
str1 = “1.2.3” str2 = “4.5.6” return -1
str1 = “1” str2 = “1.0” return 0
str1 = “1.1.0” str2 = “1.0.1” return 1

The project is built using .NET Core on the Linux machine, Ubuntu 18.04. Follow the link to see the documentation for .NET Core: https://docs.microsoft.com/en-us/dotnet/core/

# Steps to reproduce the project:
1. Create console application using .NET Core CLI:
    `dotnet new console`

    `dotnet new` creates an up-to-date `Hello.csproj` project file with the dependencies necessary to build a console app. It also creates a `Program.cs`, a basic file containing the entry point for the application.

2. Create a *test* folder and execute `dotnet new xunit`. This produces two files: test.csproj and UnitTest1.cs.

3. The test project cannot currently test the types in DoublyLinkedList and VersionComparator, and requires a project reference to the lab1 project. To add a project reference, run the following command in the CLI:
    `dotnet add reference /lab1/lab1.csproj`

4. To run tests use `dotnet test` command.