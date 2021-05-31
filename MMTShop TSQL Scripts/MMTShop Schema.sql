USE [MMTShop]
GO
CREATE TABLE Category(
			Id int IDENTITY(1,1),
			[Name] nvarchar(50)
			)

USE [MMTShop]
GO
CREATE TABLE Product(
			Id int IDENTITY(1,1),
			SKU nvarchar(50) null,
			[Name] nvarchar(250) null,
			[Description] nvarchar(MAX) null,
			Price money null,
			CategoryId int null,
			IsFeatured bit null
			)


USE [MMTShop]
GO
INSERT INTO Category ([Name])
values('Home'), ('Garden'), ('Electronics'), ('Fitness'), ('Toys')



USE [MMTShop]
GO
INSERT INTO Product(SKU, [Name], [Description], Price, CategoryId, IsFeatured)
VALUES('1001', 'Sofa', 'Sofa for you to sit on', 200, 1, 1),
	  ('1002','Arm Chair','Arm chair for you to sit on',150, 1, 1),
	  ('2001', 'Garden Swing', 'A swing for your garden', 200, 2, 1),
	  ('3001', 'TV', '4K 50" TV', 300, 3, 1),
	  ('4001', 'Dumbbells', 'A set of dumbbells', 50, 4, 0),
	  ('5001', 'Toy', 'The most popular toy around that always sells out', 60, 5, 0)


