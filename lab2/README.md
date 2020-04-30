# Part 1
Написать 8 сценариев с использованием подхода *Behaviour Driven Development* for .NET фреймворка SpecFlow (ссылка на документацию https://specflow.org/). Каждый сценарий должен содержать минимум 3 степа. Данные сценарии (минимум 8) пишутся для одного веб сайта, на которые была выполнена первая домашняя работа(поиск багов).

Если вы находили баги для мобильного приложения, можете выбрать веб сайт из списка по данной ссылке: https://www.g2.com/categories/crm (тут представлен список кампаний со ссылками на их сайты).

# Part 2
Візьміть тести з попередньої домашки (спекфлоу сценарії)
напишіть під них автотести так, як ми робили на парі (юніт тест із створенням драйвера і т д)

бонус гра:
скиньте в листі код, який дозволить перевірити, що елемента на сторінці немає. забороняється використовувати try catch і ваш код не має кидати ексепшни

# How to reproduce a project?
Prerequisites:
* .NET Core SDK, follow the link to download -- https://dotnet.microsoft.com/download
* Visual Studio Code

1. To create a .NET console application run the following command:
    `dotnet new console`
2. To intsall Google Chrome web driver for Selenium run the following command in the CLI:
    `dotnet add package Selenium.WebDriver`

