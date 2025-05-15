# Dummy (Пустышка)

## Назначение

Предоставляет шаблонный код для старта нового приложения на базе .NET/C# и React/Next.js.

## Frontend

За оразец взят https://nextjs.org/learn

## Backend. Микросервисы:

1. Gateway - Шлюз

Направляет запросы и команды от клиентов другим микросервисам

2. Writer - Писатель

Изменяет (добавляет, обновляет, удаляет) и читает сущности

3. Reader - Читатель

Читает сущности

## Взаимодействие микросервисов

1. Для изменения данных клиент отправляет запрос в микросервис Gateway, а тот отправляет команду в микросервис Writer

2. Для чтения данных клиент отправляет запрос в микросервис Gateway, а тот отправляет запрос в микросервис Reader

3. После изменения данных микросервис Writer отправляет событие изменения данных в очередь

4. Микросервис Reader извлекает из очереди сообщение о событии изменения данных и обрабатывает его

## Сертификат

https://learn.microsoft.com/en-us/aspnet/core/security/docker-compose-https?view=aspnetcore-9.0

1. Создать .pfx-файл самоподписанного сертификата для HTTPS:

```
dotnet dev-certs https -ep .\https\cert.pfx -p Qwer!678
```

2. Установить openssl, если он ещё не установлен:

```
winget install openssl
```

3. Создать .crt-файл открытого ключа из .pfx-файла сертификата:

```
openssl pkcs12 -in .\https\cert.pfx -clcerts -nokeys -out .\https\cert.crt
```

4. Создать .rsa-файл закрытого ключа из .pfx-файла сертификата:

```
openssl pkcs12 -in .\https\cert.pfx -nocerts -nodes -out .\https\cert.rsa
```

5. Сделать самоподписанные сертификаты доверенными на локальной машине:

```
dotnet dev-certs https --trust
```

## Миграции

### MS SQL Server

1. Добавить миграцию с именем InitialCreate:

```
cd .\src\Backend\src\MicroserviceWriter\src\Infrastructure\EntityFrameworkForMSSQLServer

dotnet ef migrations add InitialCreate --startup-project ../../Apps/WebApp --output-dir ./App/Db/Migrations
```

2. Применить все миграции:

```
cd .\src\Backend\src\MicroserviceWriter\src\Infrastructure\EntityFrameworkForMSSQLServer

dotnet ef database update --startup-project ../../Apps/WebApp
```

### PostgreSQL

1. Добавить миграцию с именем InitialCreate:

```
cd .\src\Backend\src\MicroserviceWriter\src\Infrastructure\EntityFrameworkForPostgreSQL

dotnet ef migrations add InitialCreate --startup-project ../../Apps/WebApp --output-dir ./App/Db/Migrations
```

2. Применить все миграции:

```
cd .\src\Backend\src\MicroserviceWriter\src\Infrastructure\EntityFrameworkForPostgreSQL

dotnet ef database update --startup-project ../../Apps/WebApp
```
