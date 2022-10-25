﻿# Описание
Приложение предоставляет оконный интерфейс для ввода интервала IP-адресов, 
выполнения поиска камер в локальной сети и отображения результатов поиска в оконном интерфейсе.
Примечание: не применялось на реальном примере

# Описание работы программы
1.	В программе заданется интервал IP-адресов.
2.	Проверяются на доступность (Ping) IP-адреса из заданного интервала.
3.  Недоступные IP-адреса отображаются в окне вывода программы
4.	Для доступных IP-адресов отправляется проверочный HTTP-запросов и анализируется ответ на них. 
Строка запроса выглядит следующим образом: 
http://<ip>[:<port>]/cgi-bin/admin/privacy.cgi
5.	Приложение отображает сообщение (MessageBox) с результатом выполнения проверочного запроса, 
Если проверка завершилась успешно, то выводиться «проверка выполнена успешно»,
если во время проверки произошли какие то ошибки, то выводиться «проверка не выполнена».

# Инструкция по применению


# Описание классов программы
Классы разделенны по задачам. Каждый класс отвечает за свою задачу
Идея в том что бы у каждого была своя ответственность
Классы IPEnumeration, PingChecking, HTTPChecking. Помещены в отдельную папку, так как предполагается что эти классы могут быть использованны в других проектах 
 
IPEnumeration-Описанны методы перебора IP по заданному диапазону.
PingChecking-Описанны методы для Пинга определенных IP адресов
HTTPChecking-Отправка запроса на определенные IP адреса

Checker-промежуточный класс, предназначенный для отделения методов логики, от описания окна

CheckingResult-класс который описывает нужные возвращаемые данные после выполнения запроса
