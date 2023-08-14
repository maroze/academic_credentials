![image](https://github.com/maroze/academic_credentials/assets/91451262/7d3b3d1b-2451-4c98-b9bd-67cb74c1bb61)

# Разработка веб-сервиса для бронирования парковочных мест. Реализация серверной части
Проект создается на платформе ASP.NET, на языке программирования C#, с использованием реляционной системы управления базами данных «PostgreSQL». 
#
## Цель работы
![image](https://github.com/maroze/academic_credentials/assets/91451262/2f4b5bcf-f0d2-447b-8473-9b7dfa5e82a7)
Целью работы является проектирование и разработка серверной части программного продукта для бронирования парковочных мест, позволяющего пользователю спланировать поездку, сократить время на поиск парковочного места и зарезервировать его в удобное для себя время.
#
### Поставленные задачи
![image](https://github.com/maroze/academic_credentials/assets/91451262/2f4b5bcf-f0d2-447b-8473-9b7dfa5e82a7)
* Исследовать предметную область и сравнить с другими похожими продуктами;
* Сформировать архитектуру серверной части приложения;
* Спроектировать базу данных;
* Разработать серверную часть веб-платформы;
#
### ER-Диаграмма

![image](https://github.com/maroze/academic_credentials/assets/91451262/2f4b5bcf-f0d2-447b-8473-9b7dfa5e82a7)

![image](https://github.com/maroze/academic_credentials/assets/91451262/90f8ccc8-ea8d-42d1-896b-2bb21dbc4d70)
#
### Входные данные
![image](https://github.com/maroze/academic_credentials/assets/91451262/2f4b5bcf-f0d2-447b-8473-9b7dfa5e82a7)
* Логин, пароль при регистрации и авторизации, также данные профиля;
* Данные о парковке и парковочных местах;
* Данные для бронирования.

### Выходные данные
![image](https://github.com/maroze/academic_credentials/assets/91451262/2f4b5bcf-f0d2-447b-8473-9b7dfa5e82a7)
* Информация о парковках и парковочные места, их адреса и состояния;
* Профиль пользователя и его брони;
* Информация о сервисе и контакты.
#
![image](https://github.com/maroze/academic_credentials/assets/91451262/ceac3ce5-6dcc-4838-b3c7-c40cdc417af0)
## Конечные точки REST API

![image](https://github.com/maroze/academic_credentials/assets/91451262/e784cf01-e505-417d-b30d-8ebe8413e70a)

| URL | Метод | Описание |
| --- | --- | --- |
| api/accounts | Ресурс пользователей |   |
| accounts	| get	| Возвращает информацию о конкретном пользователе | 
| /profiles	| put	| изменяет личные данные пользователя |  
| /login	| post	| авторизует зарегистрированного пользователя | 
| /forgot-password	| post	| отправляет токен для восстановления пароля | 
| /register	| post	| регистрирует нового пользователя | 
| /logout	| head	| выход пользователя из аккаунта | 
| /reset-password	| patch	| создает новый пароль пользователя | 
| /change-password	| patch	| изменяет пароль пользователя | 
| /users	| delete	| удаляет пользователя | 

![image](https://github.com/maroze/academic_credentials/assets/91451262/3005a991-af64-4021-ab46-4a7f4dedc966)

![image](https://github.com/maroze/academic_credentials/assets/91451262/e784cf01-e505-417d-b30d-8ebe8413e70a)

| URL | Метод | Описание |
| --- | --- | --- |
| api/parkings | Ресурс парковок и мест |   |
| /lots/{id}/park	| get	| возвращает список всех парковочных мест парковки | 
| /lots/{id}	| get	| возвращает парковочное место с данным ID | 
| /lots	| post	| создает новое парковочное место | 
| /lots	| put	| изменяет данные парковочного места | 
| /lots/{id}	| delete	| удаляет парковочное место с конкретным ID | 
| /parks	| post	| создает новую парковку | 
| /parks/{id}	| get	| возвращает парковку с конкретным ID | 
| /parks	| put	| изменяет данные парковки с конкретным ID | 
| /parks/{id}	| delete	| удаляет парковку с конкретным ID | 
| /parks/all	| get	| возвращает список всех парковок | 
 
![image](https://github.com/maroze/academic_credentials/assets/91451262/bc6da9bb-7f83-4fc8-8c40-a41bc5e2fe83)

![image](https://github.com/maroze/academic_credentials/assets/91451262/e784cf01-e505-417d-b30d-8ebe8413e70a)

| URL | Метод | Описание |
| --- | --- | --- |
| api/booking | Ресурс броней |   |
| booking	| get | возвращает список всех броней пользователя|  
| booking	| post |	создает новую бронь| 
| booking/{id}	| delete	| удаляет бронь с конкретным ID| 

![image](https://github.com/maroze/academic_credentials/assets/91451262/9d377c45-c18d-493d-93b7-3f2df89d7e95)





