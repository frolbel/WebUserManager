# WebUserManager
Реализация простейшего **CRUD** интерфейса на **ASP.NET Core MVC**
_ _ _

## Описание
Простейшее приложение на **ASP.NET Core MVC** + **EF Core** с использованием **Code First** подхода. В приложении реализован простейший **CRUD** интерфейс для работы с данными пользователей, то есть приложение обеспечивает выполнения базовых операций по чтению, добавлению, изменению и удалению данных пользователей.

## Подготовка к первому запуску приложения
Добавьте в параметры конфигурации приложения (файл **appsettings.json**) строку подключения к базе данных:
```
"ConnectionStrings": {
    "DefaultConnection": "Server=WIN-0JV6NF5VJF9; Database=UserDb; Integrated Security=False; User ID=sa; Password=***"
  },
```

Создайте свою базу данных в консоли **VS Package Manager**:

```
Update-Database
```
или в **.NET Core CLI**
```
dotnet ef database update

```
##  Вопросы? Комментарии?
Если у вас возникнут проблемы, не стесняйтесь, напишите о них здесь, Issue на Github.
