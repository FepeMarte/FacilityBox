USE master;
ALTER DATABASE [Facility] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE [Facility] ;

CREATE DATABASE Facility

GO

Use [Facility]

GO


IF OBJECT_ID('Items') IS NOT NULL
    DROP TABLE Items
GO
			
CREATE TABLE Items
(
	ItemID int identity not null primary key,
	Name varchar(150),
	Description varchar(255),
	Value money,
	CategoryID int,
	Inactive bit
)

GO

IF OBJECT_ID('Platforms') IS NOT NULL
    DROP TABLE Platforms

GO

CREATE TABLE Platforms
(
	PlatformID int identity not null primary key,
	Name varchar(150),
	Rate money,
	Inactive bit
)

GO

IF OBJECT_ID('PaymentMethods') IS NOT NULL
    DROP TABLE PaymentMethods

GO

CREATE TABLE PaymentMethods
(
	PaymentID int identity not null primary key,
	Name varchar(150),
	Rate money,
	Inactive bit
)

GO

IF OBJECT_ID('Orders') IS NOT NULL
    DROP TABLE Orders

GO

CREATE TABLE Orders
(
	OrderID int not null identity primary key,
	NameClient varchar(150),
	PaymentID int,
	PlatFormID int,
	TotalValue money,
	StatusID int
)

GO

CREATE TABLE Status
(
	StatusID int not null identity primary key,
	Name varchar(30)
)

GO



IF OBJECT_ID('OrderItems') IS NOT NULL
    DROP TABLE OrderItems

GO

CREATE TABLE OrderItems
(
	OrderItemId int not null identity primary key,
	OrderId int,
	Quantity int,
	Name varchar(150)
)

GO

IF OBJECT_ID('Categories') IS NOT NULL
    DROP TABLE Categories

GO

CREATE TABLE Categories
(
	CategoryID int not null identity primary key,
	Name varchar(150),
	Inactive bit
)

GO

IF OBJECT_ID('Configuration') IS NOT NULL
    DROP TABLE Configuration
GO

CREATE TABLE Configuration
(
    ConfigID int not null identity primary key,
	PrimaryColor varchar(20),
	SecondaryColor varchar(20)
)

GO

INSERT INTO Configuration
(
	PrimaryColor,
	SecondaryColor
)VALUES
(
	'#ff6100',
	'#ffcfb2'
)

GO

INSERT INTO Status(Name) VALUES ('Pendente')

GO
INSERT INTO Status(Name) VALUES ('Pago')

GO
INSERT INTO Status(Name) VALUES ('Cancelado')


---------------------------------------------------------------------------------------------
---------------------------PROCEDURES-------------------------------------------------------
---------------------------------------------------------------------------------------------

Use [Facility]

GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Facility_Config_GetConfigByID' 
AND ROUTINE_SCHEMA = 'dbo' AND ROUTINE_TYPE = 'PROCEDURE')
EXEC('CREATE PROCEDURE [dbo].[Facility_Config_GetConfigByID] AS BEGIN SET NOCOUNT ON; END')

GO

ALTER PROCEDURE Facility_Config_GetConfigByID 
@ConfigID as int
AS
BEGIN
	SELECT 
	ConfigID,
	PrimaryColor,
	SecondaryColor
	FROM Configuration
	WHERE ConfigID = @ConfigID
END
GO

----------------------------------------------------------------------

Use [Facility]

GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Facility_Category_GetMaxID' 
AND ROUTINE_SCHEMA = 'dbo' AND ROUTINE_TYPE = 'PROCEDURE')
EXEC('CREATE PROCEDURE [dbo].[Facility_Category_GetMaxID] AS BEGIN SET NOCOUNT ON; END')

GO
ALTER PROCEDURE Facility_Category_GetMaxID

AS
BEGIN
 SELECT MAX(CategoryID) FROM Categories

END
GO

-------------------------------------------------------------------------------

Use [Facility]

GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Facility_Config_UpdateConfig' 
AND ROUTINE_SCHEMA = 'dbo' AND ROUTINE_TYPE = 'PROCEDURE')
EXEC('CREATE PROCEDURE [dbo].[Facility_Config_UpdateConfig] AS BEGIN SET NOCOUNT ON; END')

GO

ALTER PROCEDURE Facility_Config_UpdateConfig 
@PrimaryColor varchar(150),
@SecondaryColor varchar(150)
AS
BEGIN
	UPDATE Configuration
	SET PrimaryColor = @PrimaryColor,
	SecondaryColor = @SecondaryColor
	WHERE ConfigID = 1
END
GO

-------------------------------------------------------------------------------------

Use [Facility]

GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Facility_Category_Create' 
AND ROUTINE_SCHEMA = 'dbo' AND ROUTINE_TYPE = 'PROCEDURE')
EXEC('CREATE PROCEDURE [dbo].[Facility_Category_Create] AS BEGIN SET NOCOUNT ON; END')

GO

ALTER PROCEDURE Facility_Category_Create
@Name varchar(150),
@Inactive Bit
AS
BEGIN
	INSERT INTO Categories
	(
		Name,
		Inactive
	)VALUES
	(
		@Name,
		@Inactive
	)

	SELECT SCOPE_IDENTITY();

END
GO

-----------------------------------------------------------------------------------------

Use [Facility]

GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Facility_Category_GetAllCategories' 
AND ROUTINE_SCHEMA = 'dbo' AND ROUTINE_TYPE = 'PROCEDURE')
EXEC('CREATE PROCEDURE [dbo].[Facility_Category_GetAllCategories] AS BEGIN SET NOCOUNT ON; END')

GO

ALTER PROCEDURE Facility_Category_GetAllCategories
AS
BEGIN
	SELECT 
	CategoryID,
	Name,
	Inactive
	FROM Categories
	Order By Name

END
GO

------------------------------------------------------------------------------------