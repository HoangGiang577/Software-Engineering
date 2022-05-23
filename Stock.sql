Create database Stock
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](20) NULL,
	[Password] [nvarchar](20) NULL,
	[Role] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)

CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)

CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](MAX) NOT NULL,
	[Image] [image],
	[Quantity] int NOT NULL,
	[Price] money NOT NULL,
	[Description] [nvarchar](MAX) NOT NULL,
	[Status] bit NOT NULL,
	[DOI] date NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)

CREATE TABLE [dbo].[Export](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Product] [int] NOT NULL,
	[Quantity] int NOT NULL,
	[DOE] date NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)

insert into Export(ID_Product, Quantity, DOE) values (3, 10, '2022-05-25')

CREATE TABLE [dbo].[StatusProduct](
	[ID] [int] NOT NULL,
	[Status] [nvarchar](MAX) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
select * from Product
insert into Product(Name, Quantity, Price, Description, Status, DOI) values('TV',10,10000000,'Very good', 1, '2022-11-5')
insert into Product(Name, Quantity, Price, Description, Status, DOI) values('Air conditioning',20,20000000,'Incredible', 1, '2022-11-5')
insert into Product(Name, Quantity, Price, Description, Status, DOI) values('Watch',30,15000000,'Nice', 0, '2022-11-5')


Select ex.id, p.Name, p.Image, p.Price , ex.ID_Product, ex.Quantity, ex.DOE 
from Export ex join Product p on ex.ID_Product = p.ID where datepart(month, doe) = MONTH(GETDATE())


Select ex.ID_Product, p.Name, p.Image, p.Price , ex.ID_Product, sum(ex.Quantity) as TotalQuantity 
from Export ex join Product p on ex.ID_Product = p.ID where datepart(month,doe) = MONTH(GETDATE()) 
group by ex.ID_Product, p.Name, p.Price;


SELECT MONTH(GETDATE());


SELECT *  from Export group by DOE;
