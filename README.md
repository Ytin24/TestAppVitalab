строка подключения изменяется в TestAppVitalab.Api/appsettings.json
лучше инициализировать базу данных при помощи миграции (dotnet ef database update)

-- Вставка тестовых данных в таблицу Products
INSERT INTO Products (Name, Price) VALUES
('Product 1', 10.00),
('Product 2', 20.00),
('Product 3', 30.00);
GO

-- Вставка тестовых данных в таблицу Users
INSERT INTO Users (UserName, UserLogin, UserPassword) VALUES
('User 1', 'user1', 'user1'),
('User 2', 'user2', 'user1');
GO
