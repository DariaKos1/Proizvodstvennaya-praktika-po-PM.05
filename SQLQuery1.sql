-- Создание базы данных
CREATE DATABASE ElectroVypDB;
GO

-- Переключение на новую базу
USE ElectroVypDB;
GO

-- Таблица видов продукции
CREATE TABLE ProductTypes (
    TypeId INT PRIMARY KEY IDENTITY(1,1),
    TypeCode NVARCHAR(20) NOT NULL UNIQUE,
    TypeName NVARCHAR(100) NOT NULL,
    BaseRate DECIMAL(18,2) NOT NULL
);
GO

-- Таблица товаров
CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    TypeId INT NOT NULL,
    ProductName NVARCHAR(200) NOT NULL,
    PowerKw DECIMAL(10,2) NULL,
    CurrentAmps INT NULL,
    VoltageV INT NULL,
    ComplexityFactor DECIMAL(5,2) DEFAULT 1.0,
    BasePrice DECIMAL(18,2) NULL,
    FOREIGN KEY (TypeId) REFERENCES ProductTypes(TypeId)
);
GO

-- Таблица расчетов
CREATE TABLE Calculations (
    CalcId INT PRIMARY KEY IDENTITY(1,1),
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    TotalPrice DECIMAL(18,2) NOT NULL,
    CalcDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);
GO

-- Добавляем виды продукции
INSERT INTO ProductTypes (TypeCode, TypeName, BaseRate) VALUES
('SPP', 'Силовые полупроводниковые приборы', 4500),
('PC', 'Преобразователи частоты', 35000),
('PE', 'Преобразовательное оборудование', 75000),
('ACC', 'Комплектующие', 1200);
GO

-- Добавляем товары
INSERT INTO Products (TypeId, ProductName, PowerKw, CurrentAmps, VoltageV, ComplexityFactor, BasePrice) VALUES
(1, 'Диод D143-800', NULL, 800, 400, 1.0, 5200),
(1, 'Тиристор T253-1000', NULL, 1000, 400, 1.2, 6800),
(1, 'Силовой модуль МТОТО-200', NULL, 200, 600, 1.5, 12500),
(2, 'Преобразователь "Омега-3" 7.5 кВт', 7.5, NULL, NULL, 1.2, NULL),
(2, 'Преобразователь "Омега-3" 22 кВт', 22, NULL, NULL, 1.4, NULL),
(2, 'Преобразователь "Омега-3" 45 кВт', 45, NULL, NULL, 1.6, NULL),
(3, 'Выпрямитель В-ТПЕ-1М', 110, NULL, 380, 1.6, NULL),
(3, 'Инвертор И-ТПЕ-50', 50, NULL, 380, 1.4, NULL),
(4, 'Система охлаждения О-200', NULL, NULL, NULL, 1.0, 8900),
(4, 'Блок управления БУ-ПЧ', NULL, NULL, NULL, 1.1, 4500);
GO

-- Проверяем данные
SELECT * FROM ProductTypes;
SELECT * FROM Products;
GO