USE [master]
GO
/****** Object:  Database [friedl]    Script Date: 10/03/2024 22:06:52 ******/
CREATE DATABASE [friedl]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'friedl', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS2019\MSSQL\DATA\friedl.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'friedl_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS2019\MSSQL\DATA\friedl_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [friedl] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [friedl].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [friedl] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [friedl] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [friedl] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [friedl] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [friedl] SET ARITHABORT OFF 
GO
ALTER DATABASE [friedl] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [friedl] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [friedl] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [friedl] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [friedl] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [friedl] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [friedl] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [friedl] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [friedl] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [friedl] SET  ENABLE_BROKER 
GO
ALTER DATABASE [friedl] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [friedl] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [friedl] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [friedl] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [friedl] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [friedl] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [friedl] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [friedl] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [friedl] SET  MULTI_USER 
GO
ALTER DATABASE [friedl] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [friedl] SET DB_CHAINING OFF 
GO
ALTER DATABASE [friedl] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [friedl] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [friedl] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [friedl] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [friedl] SET QUERY_STORE = OFF
GO
USE [friedl]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 10/03/2024 22:06:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](40) NOT NULL,
	[surname] [varchar](40) NOT NULL,
	[gender] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 10/03/2024 22:06:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](40) NOT NULL,
	[surname] [varchar](40) NOT NULL,
	[employee_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payment_method]    Script Date: 10/03/2024 22:06:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment_method](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pc_order]    Script Date: 10/03/2024 22:06:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pc_order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NOT NULL,
	[employee_id] [int] NOT NULL,
	[pc_type_id] [int] NOT NULL,
	[payment_method_id] [int] NOT NULL,
	[price] [decimal](18, 0) NOT NULL,
	[order_date] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pc_type]    Script Date: 10/03/2024 22:06:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pc_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[customer] ON 
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (1, N'Lorry', N'Jury', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (2, N'Toddie', N'Nertney', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (3, N'Hilde', N'Baldack', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (4, N'Tremain', N'Penkethman', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (5, N'Antonietta', N'Askin', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (6, N'Efren', N'Gurden', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (7, N'Farra', N'Abele', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (8, N'Yolanda', N'Corbin', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (9, N'Rowland', N'Norris', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (10, N'Skipp', N'Gerault', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (11, N'Hilario', N'Hummerston', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (12, N'Reece', N'Lithgow', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (13, N'Olivette', N'Girodon', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (14, N'Wylma', N'Casaletto', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (15, N'Carmita', N'Beelby', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (16, N'Leora', N'Alwen', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (17, N'Lary', N'Hovee', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (18, N'Pincus', N'Dunbobbin', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (19, N'Amble', N'Gent', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (20, N'Bernhard', N'Roskelley', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (21, N'Bendix', N'Lownds', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (22, N'Curt', N'Candelin', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (23, N'Damien', N'Constantine', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (24, N'Natalina', N'Patton', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (25, N'Shaun', N'Brandom', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (26, N'Eadmund', N'Scamadin', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (27, N'Ricca', N'Atty', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (28, N'Selinda', N'Weippert', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (29, N'Gilbert', N'De Domenici', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (30, N'Nert', N'Titcumb', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (31, N'Delmore', N'Thon', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (32, N'Benjy', N'Jozsika', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (33, N'Tremaine', N'Clampe', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (34, N'Ardeen', N'De Hailes', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (35, N'Gabrila', N'Physick', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (36, N'Kacey', N'Crick', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (37, N'Sara', N'Worster', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (38, N'Carly', N'Ledgerton', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (39, N'Gabriela', N'Sparkes', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (40, N'Frederic', N'Borg-Bartolo', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (41, N'Glyn', N'Norridge', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (42, N'Teresita', N'Savine', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (43, N'Kyla', N'Bodle', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (44, N'Shermy', N'Radclyffe', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (45, N'Kara', N'Kike', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (46, N'Stevena', N'Corona', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (47, N'Yancy', N'Hyman', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (48, N'Madelina', N'Comberbeach', 1)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (49, N'Dallas', N'Merredy', 0)
GO
INSERT [dbo].[customer] ([id], [name], [surname], [gender]) VALUES (50, N'Emogene', N'Summerlie', 0)
GO
SET IDENTITY_INSERT [dbo].[customer] OFF
GO
SET IDENTITY_INSERT [dbo].[employee] ON 
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (1, N'Fawn', N'Badgers', 451)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (2, N'Raina', N'Pavia', 214)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (3, N'Fina', N'Philott', 858)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (4, N'Avie', N'Weatherup', 846)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (5, N'Lev', N'Dmitr', 142)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (6, N'Redd', N'Faveryear', 865)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (7, N'Sharlene', N'Laxston', 989)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (8, N'Scotti', N'Cricket', 985)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (9, N'Desdemona', N'Toop', 356)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (10, N'Beatrisa', N'Wollrauch', 482)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (11, N'Leesa', N'Skillington', 188)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (12, N'Kiersten', N'Ruffy', 993)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (13, N'Monah', N'Eseler', 891)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (14, N'Darryl', N'Fancutt', 369)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (15, N'Dorena', N'Carles', 947)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (16, N'Wadsworth', N'Petrovykh', 642)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (17, N'Giffy', N'Hugland', 5)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (18, N'Edin', N'Frankham', 929)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (19, N'Ulysses', N'Gleave', 952)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (20, N'Ruben', N'Jedrzejczyk', 223)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (21, N'Esmaria', N'Freda', 394)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (22, N'Benedicta', N'Binfield', 816)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (23, N'Shepherd', N'Veryard', 365)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (24, N'Gertrud', N'Drayson', 636)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (25, N'Evelyn', N'Prydden', 360)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (26, N'Errol', N'Faragher', 118)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (27, N'Amos', N'Caizley', 149)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (28, N'Annaliese', N'Mandy', 195)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (29, N'Hortensia', N'Faircley', 98)
GO
INSERT [dbo].[employee] ([id], [name], [surname], [employee_id]) VALUES (30, N'Ulla', N'Stollenberg', 211)
GO
SET IDENTITY_INSERT [dbo].[employee] OFF
GO
SET IDENTITY_INSERT [dbo].[payment_method] ON 
GO
INSERT [dbo].[payment_method] ([id], [name]) VALUES (1, N'Cash')
GO
INSERT [dbo].[payment_method] ([id], [name]) VALUES (2, N'Credit Card')
GO
INSERT [dbo].[payment_method] ([id], [name]) VALUES (3, N'Debit Card')
GO
INSERT [dbo].[payment_method] ([id], [name]) VALUES (4, N'PayPal')
GO
INSERT [dbo].[payment_method] ([id], [name]) VALUES (5, N'Google Pay')
GO
SET IDENTITY_INSERT [dbo].[payment_method] OFF
GO
SET IDENTITY_INSERT [dbo].[pc_order] ON 
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (1, 28, 20, 2, 4, CAST(3 AS Decimal(18, 0)), CAST(N'2024-02-29' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (2, 24, 10, 3, 5, CAST(3 AS Decimal(18, 0)), CAST(N'2022-11-13' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (3, 3, 25, 3, 1, CAST(4 AS Decimal(18, 0)), CAST(N'2023-11-05' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (4, 12, 16, 3, 4, CAST(3 AS Decimal(18, 0)), CAST(N'2023-05-09' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (5, 27, 6, 4, 2, CAST(2 AS Decimal(18, 0)), CAST(N'2023-03-26' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (6, 29, 18, 5, 2, CAST(3 AS Decimal(18, 0)), CAST(N'2024-03-06' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (7, 23, 17, 3, 4, CAST(5 AS Decimal(18, 0)), CAST(N'2024-02-16' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (8, 29, 14, 2, 5, CAST(5 AS Decimal(18, 0)), CAST(N'2024-02-01' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (9, 15, 24, 4, 4, CAST(3 AS Decimal(18, 0)), CAST(N'2023-09-27' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (10, 33, 10, 4, 3, CAST(2 AS Decimal(18, 0)), CAST(N'2022-09-26' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (11, 22, 25, 3, 3, CAST(4 AS Decimal(18, 0)), CAST(N'2022-08-13' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (12, 50, 21, 3, 3, CAST(1 AS Decimal(18, 0)), CAST(N'2023-05-21' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (13, 27, 6, 4, 3, CAST(1 AS Decimal(18, 0)), CAST(N'2022-07-17' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (14, 49, 17, 3, 4, CAST(3 AS Decimal(18, 0)), CAST(N'2023-01-26' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (15, 23, 29, 2, 1, CAST(4 AS Decimal(18, 0)), CAST(N'2024-01-24' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (16, 12, 9, 5, 5, CAST(3 AS Decimal(18, 0)), CAST(N'2023-04-27' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (17, 16, 14, 4, 3, CAST(2 AS Decimal(18, 0)), CAST(N'2022-08-29' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (18, 22, 12, 2, 2, CAST(3 AS Decimal(18, 0)), CAST(N'2022-10-03' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (19, 30, 20, 4, 1, CAST(3 AS Decimal(18, 0)), CAST(N'2023-11-21' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (20, 45, 24, 3, 4, CAST(2 AS Decimal(18, 0)), CAST(N'2023-07-08' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (21, 45, 25, 1, 5, CAST(4 AS Decimal(18, 0)), CAST(N'2022-11-13' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (22, 37, 1, 1, 3, CAST(3 AS Decimal(18, 0)), CAST(N'2022-10-28' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (23, 25, 16, 2, 5, CAST(1 AS Decimal(18, 0)), CAST(N'2022-08-11' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (24, 20, 29, 1, 1, CAST(3 AS Decimal(18, 0)), CAST(N'2023-05-17' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (25, 45, 26, 4, 3, CAST(5 AS Decimal(18, 0)), CAST(N'2023-03-02' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (26, 47, 23, 4, 3, CAST(1 AS Decimal(18, 0)), CAST(N'2022-10-30' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (27, 13, 9, 4, 5, CAST(3 AS Decimal(18, 0)), CAST(N'2022-10-31' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (28, 36, 12, 2, 2, CAST(3 AS Decimal(18, 0)), CAST(N'2023-05-20' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (29, 35, 8, 3, 3, CAST(2 AS Decimal(18, 0)), CAST(N'2023-06-07' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (30, 13, 20, 2, 4, CAST(5 AS Decimal(18, 0)), CAST(N'2023-10-28' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (31, 49, 6, 2, 3, CAST(3 AS Decimal(18, 0)), CAST(N'2023-01-28' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (32, 36, 3, 4, 1, CAST(3 AS Decimal(18, 0)), CAST(N'2023-09-06' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (33, 22, 29, 4, 2, CAST(4 AS Decimal(18, 0)), CAST(N'2024-02-11' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (34, 39, 14, 1, 2, CAST(3 AS Decimal(18, 0)), CAST(N'2023-04-07' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (35, 12, 15, 1, 4, CAST(1 AS Decimal(18, 0)), CAST(N'2023-06-28' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (36, 26, 3, 1, 3, CAST(3 AS Decimal(18, 0)), CAST(N'2024-02-13' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (37, 25, 7, 3, 4, CAST(2 AS Decimal(18, 0)), CAST(N'2023-10-07' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (38, 31, 12, 2, 2, CAST(2 AS Decimal(18, 0)), CAST(N'2022-12-06' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (39, 42, 11, 5, 1, CAST(3 AS Decimal(18, 0)), CAST(N'2024-01-11' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (40, 1, 16, 3, 4, CAST(4 AS Decimal(18, 0)), CAST(N'2023-03-08' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (41, 44, 7, 1, 1, CAST(4 AS Decimal(18, 0)), CAST(N'2023-10-25' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (42, 38, 28, 4, 1, CAST(4 AS Decimal(18, 0)), CAST(N'2023-03-13' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (43, 34, 14, 4, 4, CAST(4 AS Decimal(18, 0)), CAST(N'2023-07-11' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (44, 41, 27, 1, 2, CAST(2 AS Decimal(18, 0)), CAST(N'2023-02-15' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (45, 23, 11, 5, 3, CAST(4 AS Decimal(18, 0)), CAST(N'2023-01-21' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (46, 11, 11, 4, 5, CAST(4 AS Decimal(18, 0)), CAST(N'2023-01-21' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (47, 12, 7, 4, 5, CAST(4 AS Decimal(18, 0)), CAST(N'2023-10-13' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (48, 18, 1, 4, 4, CAST(4 AS Decimal(18, 0)), CAST(N'2022-12-27' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (49, 41, 25, 4, 3, CAST(5 AS Decimal(18, 0)), CAST(N'2022-08-05' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (50, 4, 3, 2, 4, CAST(4 AS Decimal(18, 0)), CAST(N'2022-08-27' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (51, 20, 13, 2, 1, CAST(3 AS Decimal(18, 0)), CAST(N'2023-02-21' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (52, 47, 22, 3, 3, CAST(1 AS Decimal(18, 0)), CAST(N'2023-08-29' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (53, 30, 29, 4, 1, CAST(2 AS Decimal(18, 0)), CAST(N'2022-10-06' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (54, 36, 17, 4, 2, CAST(3 AS Decimal(18, 0)), CAST(N'2022-07-19' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (55, 30, 23, 5, 2, CAST(5 AS Decimal(18, 0)), CAST(N'2023-03-28' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (56, 36, 28, 5, 1, CAST(2 AS Decimal(18, 0)), CAST(N'2023-06-30' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (57, 13, 19, 1, 2, CAST(2 AS Decimal(18, 0)), CAST(N'2023-02-24' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (58, 10, 8, 4, 4, CAST(2 AS Decimal(18, 0)), CAST(N'2023-10-03' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (59, 32, 28, 2, 1, CAST(2 AS Decimal(18, 0)), CAST(N'2024-01-14' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (60, 40, 24, 4, 4, CAST(1 AS Decimal(18, 0)), CAST(N'2022-08-31' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (61, 34, 26, 1, 4, CAST(1 AS Decimal(18, 0)), CAST(N'2022-10-02' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (62, 10, 17, 3, 4, CAST(4 AS Decimal(18, 0)), CAST(N'2022-12-06' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (63, 41, 16, 4, 2, CAST(2 AS Decimal(18, 0)), CAST(N'2023-02-21' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (64, 14, 10, 2, 5, CAST(3 AS Decimal(18, 0)), CAST(N'2023-12-05' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (65, 5, 9, 2, 4, CAST(3 AS Decimal(18, 0)), CAST(N'2022-08-01' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (66, 16, 2, 5, 5, CAST(3 AS Decimal(18, 0)), CAST(N'2023-07-08' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (67, 34, 19, 1, 2, CAST(1 AS Decimal(18, 0)), CAST(N'2022-08-24' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (68, 31, 19, 1, 5, CAST(2 AS Decimal(18, 0)), CAST(N'2024-03-02' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (69, 1, 1, 4, 5, CAST(2 AS Decimal(18, 0)), CAST(N'2022-09-07' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (70, 47, 25, 4, 3, CAST(3 AS Decimal(18, 0)), CAST(N'2022-10-22' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (71, 5, 6, 4, 1, CAST(2 AS Decimal(18, 0)), CAST(N'2023-04-30' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (72, 28, 9, 2, 1, CAST(5 AS Decimal(18, 0)), CAST(N'2024-01-09' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (73, 36, 3, 2, 4, CAST(5 AS Decimal(18, 0)), CAST(N'2023-01-26' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (74, 19, 3, 3, 5, CAST(3 AS Decimal(18, 0)), CAST(N'2022-08-10' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (75, 35, 16, 3, 2, CAST(1 AS Decimal(18, 0)), CAST(N'2023-06-22' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (76, 27, 14, 3, 4, CAST(4 AS Decimal(18, 0)), CAST(N'2023-03-25' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (77, 20, 27, 5, 2, CAST(3 AS Decimal(18, 0)), CAST(N'2024-01-29' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (78, 46, 30, 1, 2, CAST(1 AS Decimal(18, 0)), CAST(N'2023-09-17' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (79, 40, 24, 4, 4, CAST(5 AS Decimal(18, 0)), CAST(N'2022-11-19' AS Date))
GO
INSERT [dbo].[pc_order] ([id], [customer_id], [employee_id], [pc_type_id], [payment_method_id], [price], [order_date]) VALUES (80, 47, 24, 2, 1, CAST(4 AS Decimal(18, 0)), CAST(N'2023-03-17' AS Date))
GO
SET IDENTITY_INSERT [dbo].[pc_order] OFF
GO
SET IDENTITY_INSERT [dbo].[pc_type] ON 
GO
INSERT [dbo].[pc_type] ([id], [name]) VALUES (1, N'Laptop')
GO
INSERT [dbo].[pc_type] ([id], [name]) VALUES (2, N'Desktop')
GO
INSERT [dbo].[pc_type] ([id], [name]) VALUES (3, N'Gaming')
GO
INSERT [dbo].[pc_type] ([id], [name]) VALUES (4, N'Server')
GO
INSERT [dbo].[pc_type] ([id], [name]) VALUES (5, N'Mini')
GO
SET IDENTITY_INSERT [dbo].[pc_type] OFF
GO
ALTER TABLE [dbo].[pc_order]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[customer] ([id])
GO
ALTER TABLE [dbo].[pc_order]  WITH CHECK ADD FOREIGN KEY([employee_id])
REFERENCES [dbo].[employee] ([id])
GO
ALTER TABLE [dbo].[pc_order]  WITH CHECK ADD FOREIGN KEY([payment_method_id])
REFERENCES [dbo].[payment_method] ([id])
GO
ALTER TABLE [dbo].[pc_order]  WITH CHECK ADD FOREIGN KEY([pc_type_id])
REFERENCES [dbo].[pc_type] ([id])
GO
USE [master]
GO
ALTER DATABASE [friedl] SET  READ_WRITE 
GO
