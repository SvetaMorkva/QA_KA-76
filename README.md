General repository for students from IASA KPI group KA-76 and our mentors from EPAM to study QA.

Состоит из 2ух задачек, необходимо написать минимум по 2 юнит теста к каждой задачке, всё решение должно быть залито в Гит в репозиторий, созданный под каждую группу, каждому будет необходимо создать билд джобу на СI и заранить там свои тесты с своей бранчи
В качестве решения - мы ожидаем ссылку на решение в Гите, ссылки на успешные раны на СI.
Бранчи необходимо называть по такому патерну - firstName.LasteName_lab
Дедлайн - 22.04 23:59.

Непосредственно задачи на C# Задача №1. Посчитайте сколько остается в остатке от деления на 4 вашего порядкового номера в списке (к примеру :  - если номер 11 - остаток 3 ,  - если 1 - то 1,  - если 4 - то 0  - и т д) Это и будет ваш вариант.  Порядковые номера проставлены в файле с оценками 
Вариант №0 - напишите свою имплементацию односвязного списка, метод Add и GetCurrent, GetNext
Вариант №1 - напишите свою имплементацию двусвязного списка, метод Add, GetCurrent, GetNext, GetPrevious
Вариант №2 - напишите свою имлементацию очереди (FIFO), проперти Count и методов Enqueue, Dequeue, Clear and Peek Вариант №3 - напишите свою имлементацию стека (FILO), проперти Count и методов  Push, Pop, Peek 

Задача №2. Write С# CompareVersions() method, which takes as parameters 2 strings. These strings are product versions. Product version consists of unlimited versions and subversions. Pattern for version is numbers and dot delimiters. If first version is greater than second method returns 1, if equals 0, if less -1.
Examples:
str1 = “1.2.3” str2 = “4.5.6” return -1
str1 = “1” str2 = “1.0” return 0
str1 = “1.1.0” str2 = “1.0.1” return 1