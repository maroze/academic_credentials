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
| --- | ---  --- |
| api/accounts | Ресурс пользователей |
| --- | --- | --- |
| accounts	| get	| Возвращает информацию о конкретном пользователе | 
| /profiles	| put	| изменяет личные данные пользователя |  
| /login	| post	| авторизует зарегистрированного пользователя | 
| /forgot-password	| post	| отправляет токен для восстановления пароля | 
| /register	| post	| регистрирует нового пользователя | 
| /logout	| head	| выход пользователя из аккаунта | 
| /reset-password	| patch	| создает новый пароль пользователя | 
| /change-password	| patch	| изменяет пароль пользователя | 
| /users	| delete	| удаляет пользователя | 


![image](https://github.com/maroze/academic_credentials/assets/91451262/02781174-ef93-4d39-a4b2-91b9e5623974)

![image](https://github.com/maroze/academic_credentials/assets/91451262/e784cf01-e505-417d-b30d-8ebe8413e70a)

![image](https://github.com/maroze/academic_credentials/assets/91451262/1f0cd9a8-79dd-4d2e-bf02-404ed81b7947)

![image](https://github.com/maroze/academic_credentials/assets/91451262/e784cf01-e505-417d-b30d-8ebe8413e70a)

![image](https://github.com/maroze/academic_credentials/assets/91451262/f18b50d7-21e9-48ae-8011-86ced3bc15bb)




