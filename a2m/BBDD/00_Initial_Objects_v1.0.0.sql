USE [master]
GO
/****** Object:  Database [a2m]    Script Date: 04/08/2015 21:25:31 ******/
CREATE DATABASE [a2m]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'a2m', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\a2m.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'a2m_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\a2m_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [a2m] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [a2m].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [a2m] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [a2m] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [a2m] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [a2m] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [a2m] SET ARITHABORT OFF 
GO
ALTER DATABASE [a2m] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [a2m] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [a2m] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [a2m] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [a2m] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [a2m] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [a2m] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [a2m] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [a2m] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [a2m] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [a2m] SET  DISABLE_BROKER 
GO
ALTER DATABASE [a2m] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [a2m] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [a2m] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [a2m] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [a2m] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [a2m] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [a2m] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [a2m] SET RECOVERY FULL 
GO
ALTER DATABASE [a2m] SET  MULTI_USER 
GO
ALTER DATABASE [a2m] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [a2m] SET DB_CHAINING OFF 
GO
ALTER DATABASE [a2m] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [a2m] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'a2m', N'ON'
GO
USE [a2m]
GO
/****** Object:  Schema [Business]    Script Date: 04/08/2015 21:25:32 ******/
CREATE SCHEMA [Business]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Pk_Admin] [int] IDENTITY(1,1) NOT NULL,
	[User_Name] [nchar](20) NOT NULL,
	[Password] [nchar](20) NOT NULL,
	[Fk_Municipality] [int] NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Pk_Admin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Business]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Business](
	[Pk_Business] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[Phone] [nchar](12) NULL,
	[Alternate_Phone] [nchar](12) NULL,
	[Fk_Schedule] [int] NOT NULL,
	[Address] [nchar](200) NULL,
	[Fk_Municipality] [int] NOT NULL,
	[Email] [nchar](50) NULL,
	[Webpage] [nchar](50) NULL,
	[Min_Price_For_Shipping] [money] NULL,
	[Allow_Shipping] [bit] NOT NULL,
	[Allow_PickUp] [bit] NOT NULL,
	[Shipping_Cost_If_Not_Min_Price] [money] NOT NULL,
	[Allow_Shipping_Not_Enougth_Amount] [bit] NOT NULL,
	[Fk_Business_Status] [int] NOT NULL,
	[Max_Order_Price_Allowed] [money] NULL,
	[Creation_Date] [datetime] NOT NULL,
	[Password] [char](40) NOT NULL,
	[Is_A2M] [bit] NOT NULL,
	[Has_Pdf] [bit] NOT NULL,
	[Pdf_Last_Update] [datetime] NULL,
	[Lat] [float] NULL,
	[Lon] [float] NULL,
	[Description] [nchar](200) NULL,
 CONSTRAINT [PK_Business] PRIMARY KEY CLUSTERED 
(
	[Pk_Business] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Business_Images]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Business_Images](
	[Fk_Business] [int] NOT NULL,
	[Image_Name] [nchar](255) NOT NULL,
	[Pk_Image] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Business_Images_1] PRIMARY KEY CLUSTERED 
(
	[Pk_Image] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Business_Status]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Business_Status](
	[Pk_Business_Status] [int] NOT NULL,
	[Name] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Business_Status] PRIMARY KEY CLUSTERED 
(
	[Pk_Business_Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Pk_Product_Category] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[Fk_Business] [int] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Pk_Product_Category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Pk_Customer] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NULL,
	[Surname] [nchar](50) NULL,
	[Second_Surname] [nchar](50) NULL,
	[Phone] [nchar](10) NULL,
	[Alternate_Phone] [nchar](10) NULL,
	[Email] [nchar](50) NULL,
	[Password] [nchar](50) NULL,
	[Fk_Customer_Status] [int] NOT NULL,
	[Creation_Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Pk_Customer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer_Address]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_Address](
	[Fk_Address] [int] IDENTITY(1,1) NOT NULL,
	[Fk_Customer] [int] NOT NULL,
	[Name] [nchar](30) NOT NULL,
	[Is_Default] [bit] NOT NULL,
	[Address] [nchar](50) NOT NULL,
	[Number] [nchar](10) NOT NULL,
	[Floor] [nchar](10) NULL,
	[Stairs] [nchar](10) NULL,
	[Letter] [nchar](10) NULL,
	[Aditional_Data] [nchar](200) NULL,
 CONSTRAINT [PK_Customer_Address] PRIMARY KEY CLUSTERED 
(
	[Fk_Address] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer_Status]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_Status](
	[Pk_Status] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Customer_Status] PRIMARY KEY CLUSTERED 
(
	[Pk_Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DatabaseVersion]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatabaseVersion](
	[Version] [text] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Municipality]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Municipality](
	[Pk_Municipality] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[Postal_Code] [nchar](5) NOT NULL,
	[Fk_Municipality_Status] [int] NOT NULL,
 CONSTRAINT [PK_Municipality] PRIMARY KEY CLUSTERED 
(
	[Pk_Municipality] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Municipality_Status]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Municipality_Status](
	[Pk_Municipality_Status] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Municipality_Status] PRIMARY KEY CLUSTERED 
(
	[Pk_Municipality_Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order_Details]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Details](
	[Pk_Order_Detail] [int] IDENTITY(1,1) NOT NULL,
	[Fk_Order_Product] [int] NOT NULL,
	[Fk_Order_Extender] [int] NULL,
	[Fk_Order] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Order_Details] PRIMARY KEY CLUSTERED 
(
	[Pk_Order_Detail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order_Movements]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Movements](
	[Pk_Order_Movement] [int] NOT NULL,
	[Fk_Order] [int] NOT NULL,
	[Datetime] [datetime] NOT NULL,
	[Fk_Order_Status] [int] NOT NULL,
 CONSTRAINT [PK_Order_Movements] PRIMARY KEY CLUSTERED 
(
	[Pk_Order_Movement] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order_Status]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Status](
	[Pk_Order_Status] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Order_Status] PRIMARY KEY CLUSTERED 
(
	[Pk_Order_Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Pk_Order] [int] IDENTITY(1,1) NOT NULL,
	[Fk_Customer] [int] NOT NULL,
	[Fk_Bussiness] [int] NOT NULL,
	[Fk_Order_Status] [int] NOT NULL,
	[Total_Amount] [int] NOT NULL,
	[Discount] [int] NULL,
	[Need_Money_Change] [int] NULL,
	[What_Change] [int] NULL,
	[Vat] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Pk_Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product_Extender]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Extender](
	[Pk_Product_Extender] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](30) NOT NULL,
	[Fk_Product_Extender_Group] [int] NOT NULL,
	[Total_Price] [money] NULL,
	[Add_Price] [money] NULL,
	[Is_Default] [bit] NULL,
 CONSTRAINT [PK_Product_Extender] PRIMARY KEY CLUSTERED 
(
	[Pk_Product_Extender] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product_Extender_Group]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Extender_Group](
	[Pk_Product_Extender_Group] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](30) NOT NULL,
	[Fk_Product] [int] NOT NULL,
 CONSTRAINT [PK_Product_Extender_Group] PRIMARY KEY CLUSTERED 
(
	[Pk_Product_Extender_Group] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Pk_Product] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[Unit_Price] [money] NULL,
	[Fk_Category] [int] NOT NULL,
	[Description] [nchar](500) NOT NULL,
	[Icon] [nchar](255) NULL,
	[Custom_Image] [nchar](255) NULL,
	[Unit_Price_Second_Item] [money] NULL,
	[Unit_Price_Third_Item] [money] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Pk_Product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products_Product_Extender_Group]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products_Product_Extender_Group](
	[Fk_Product] [int] NOT NULL,
	[Fk_Product_Extender_Group] [int] NOT NULL,
	[Pk_Products_Product_Extender_Group] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Products_Product_Extender_Group] PRIMARY KEY CLUSTERED 
(
	[Pk_Products_Product_Extender_Group] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products_Special_Food_Categories]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products_Special_Food_Categories](
	[Fk_Product] [int] NOT NULL,
	[Fk_Special_Food_Categories] [int] NOT NULL,
	[Pk_Products_Special_Food_Categories] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Products_Special_Food_Categories] PRIMARY KEY CLUSTERED 
(
	[Pk_Products_Special_Food_Categories] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Schedule](
	[Pk_Schedule] [int] IDENTITY(1,1) NOT NULL,
	[Day_Week] [char](7) NOT NULL,
	[Time_Mask] [char](48) NOT NULL,
	[Fk_Business] [int] NOT NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[Pk_Schedule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Special_Food_Categories]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Special_Food_Categories](
	[Pk_Special_Food] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Special_Food_Categories] PRIMARY KEY CLUSTERED 
(
	[Pk_Special_Food] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Special_Offers]    Script Date: 04/08/2015 21:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Special_Offers](
	[Pk_Special_Offer] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](30) NULL,
	[Description] [nchar](400) NULL,
	[Image] [nchar](50) NULL,
	[Start_Date] [datetime] NOT NULL,
	[End_Date] [datetime] NULL,
	[Min_Total_Amount] [money] NULL,
	[Discount] [int] NULL,
	[Fixed_Price] [money] NULL,
	[Promotional_Code] [nchar](20) NULL,
	[Fk_Business] [int] NULL,
	[Fk_Product] [int] NULL,
	[Fk_Product_Extender] [int] NULL,
 CONSTRAINT [PK_Special_Offers] PRIMARY KEY CLUSTERED 
(
	[Pk_Special_Offer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Business] ADD  CONSTRAINT [DF_Business_Shipping_Cost_If_Not_Min_Price]  DEFAULT ((0)) FOR [Shipping_Cost_If_Not_Min_Price]
GO
ALTER TABLE [dbo].[Business] ADD  CONSTRAINT [DF_Business_Is_A2M]  DEFAULT ((0)) FOR [Is_A2M]
GO
ALTER TABLE [dbo].[Business] ADD  CONSTRAINT [DF_Business_Has_Pdf]  DEFAULT ((0)) FOR [Has_Pdf]
GO
ALTER TABLE [dbo].[Admin]  WITH CHECK ADD  CONSTRAINT [FK_Admin_Municipality] FOREIGN KEY([Fk_Municipality])
REFERENCES [dbo].[Municipality] ([Pk_Municipality])
GO
ALTER TABLE [dbo].[Admin] CHECK CONSTRAINT [FK_Admin_Municipality]
GO
ALTER TABLE [dbo].[Business]  WITH CHECK ADD  CONSTRAINT [FK_Business_Business_Status] FOREIGN KEY([Fk_Municipality])
REFERENCES [dbo].[Business_Status] ([Pk_Business_Status])
GO
ALTER TABLE [dbo].[Business] CHECK CONSTRAINT [FK_Business_Business_Status]
GO
ALTER TABLE [dbo].[Business]  WITH CHECK ADD  CONSTRAINT [FK_Business_Municipality] FOREIGN KEY([Fk_Municipality])
REFERENCES [dbo].[Municipality] ([Pk_Municipality])
GO
ALTER TABLE [dbo].[Business] CHECK CONSTRAINT [FK_Business_Municipality]
GO
ALTER TABLE [dbo].[Business]  WITH CHECK ADD  CONSTRAINT [FK_Business_Schedule] FOREIGN KEY([Fk_Schedule])
REFERENCES [dbo].[Schedule] ([Pk_Schedule])
GO
ALTER TABLE [dbo].[Business] CHECK CONSTRAINT [FK_Business_Schedule]
GO
ALTER TABLE [dbo].[Business_Images]  WITH CHECK ADD  CONSTRAINT [FK_Business_Images_Business] FOREIGN KEY([Fk_Business])
REFERENCES [dbo].[Business] ([Pk_Business])
GO
ALTER TABLE [dbo].[Business_Images] CHECK CONSTRAINT [FK_Business_Images_Business]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Business] FOREIGN KEY([Fk_Business])
REFERENCES [dbo].[Business] ([Pk_Business])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Business]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Customer_Status] FOREIGN KEY([Fk_Customer_Status])
REFERENCES [dbo].[Customer_Status] ([Pk_Status])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Customer_Status]
GO
ALTER TABLE [dbo].[Customer_Address]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Address_Customer] FOREIGN KEY([Fk_Customer])
REFERENCES [dbo].[Customer] ([Pk_Customer])
GO
ALTER TABLE [dbo].[Customer_Address] CHECK CONSTRAINT [FK_Customer_Address_Customer]
GO
ALTER TABLE [dbo].[Municipality]  WITH CHECK ADD  CONSTRAINT [FK_Municipality_Municipality_Status] FOREIGN KEY([Fk_Municipality_Status])
REFERENCES [dbo].[Municipality_Status] ([Pk_Municipality_Status])
GO
ALTER TABLE [dbo].[Municipality] CHECK CONSTRAINT [FK_Municipality_Municipality_Status]
GO
ALTER TABLE [dbo].[Order_Details]  WITH CHECK ADD  CONSTRAINT [FK_Order_Details_Orders] FOREIGN KEY([Fk_Order])
REFERENCES [dbo].[Orders] ([Pk_Order])
GO
ALTER TABLE [dbo].[Order_Details] CHECK CONSTRAINT [FK_Order_Details_Orders]
GO
ALTER TABLE [dbo].[Order_Details]  WITH CHECK ADD  CONSTRAINT [FK_Order_Details_Product_Extender] FOREIGN KEY([Fk_Order_Extender])
REFERENCES [dbo].[Product_Extender] ([Pk_Product_Extender])
GO
ALTER TABLE [dbo].[Order_Details] CHECK CONSTRAINT [FK_Order_Details_Product_Extender]
GO
ALTER TABLE [dbo].[Order_Details]  WITH CHECK ADD  CONSTRAINT [FK_Order_Details_Products] FOREIGN KEY([Fk_Order_Product])
REFERENCES [dbo].[Products] ([Pk_Product])
GO
ALTER TABLE [dbo].[Order_Details] CHECK CONSTRAINT [FK_Order_Details_Products]
GO
ALTER TABLE [dbo].[Order_Movements]  WITH CHECK ADD  CONSTRAINT [FK_Order_Movements_Order_Status] FOREIGN KEY([Fk_Order_Status])
REFERENCES [dbo].[Order_Status] ([Pk_Order_Status])
GO
ALTER TABLE [dbo].[Order_Movements] CHECK CONSTRAINT [FK_Order_Movements_Order_Status]
GO
ALTER TABLE [dbo].[Order_Movements]  WITH CHECK ADD  CONSTRAINT [FK_Order_Movements_Orders] FOREIGN KEY([Fk_Order])
REFERENCES [dbo].[Orders] ([Pk_Order])
GO
ALTER TABLE [dbo].[Order_Movements] CHECK CONSTRAINT [FK_Order_Movements_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Business] FOREIGN KEY([Fk_Bussiness])
REFERENCES [dbo].[Business] ([Pk_Business])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Business]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customer] FOREIGN KEY([Fk_Customer])
REFERENCES [dbo].[Customer] ([Pk_Customer])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customer]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Order_Status] FOREIGN KEY([Fk_Order_Status])
REFERENCES [dbo].[Order_Status] ([Pk_Order_Status])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Order_Status]
GO
ALTER TABLE [dbo].[Product_Extender]  WITH CHECK ADD  CONSTRAINT [FK_Product_Extender_Product_Extender_Group] FOREIGN KEY([Fk_Product_Extender_Group])
REFERENCES [dbo].[Product_Extender_Group] ([Pk_Product_Extender_Group])
GO
ALTER TABLE [dbo].[Product_Extender] CHECK CONSTRAINT [FK_Product_Extender_Product_Extender_Group]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([Fk_Category])
REFERENCES [dbo].[Categories] ([Pk_Product_Category])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[Products_Product_Extender_Group]  WITH CHECK ADD  CONSTRAINT [FK_Products_Product_Extender_Group_Product_Extender_Group] FOREIGN KEY([Fk_Product_Extender_Group])
REFERENCES [dbo].[Product_Extender_Group] ([Pk_Product_Extender_Group])
GO
ALTER TABLE [dbo].[Products_Product_Extender_Group] CHECK CONSTRAINT [FK_Products_Product_Extender_Group_Product_Extender_Group]
GO
ALTER TABLE [dbo].[Products_Product_Extender_Group]  WITH CHECK ADD  CONSTRAINT [FK_Products_Product_Extender_Group_Products] FOREIGN KEY([Fk_Product])
REFERENCES [dbo].[Products] ([Pk_Product])
GO
ALTER TABLE [dbo].[Products_Product_Extender_Group] CHECK CONSTRAINT [FK_Products_Product_Extender_Group_Products]
GO
ALTER TABLE [dbo].[Products_Special_Food_Categories]  WITH CHECK ADD  CONSTRAINT [FK_Products_Special_Food_Categories_Products] FOREIGN KEY([Fk_Product])
REFERENCES [dbo].[Products] ([Pk_Product])
GO
ALTER TABLE [dbo].[Products_Special_Food_Categories] CHECK CONSTRAINT [FK_Products_Special_Food_Categories_Products]
GO
ALTER TABLE [dbo].[Products_Special_Food_Categories]  WITH CHECK ADD  CONSTRAINT [FK_Products_Special_Food_Categories_Special_Food_Categories] FOREIGN KEY([Fk_Special_Food_Categories])
REFERENCES [dbo].[Special_Food_Categories] ([Pk_Special_Food])
GO
ALTER TABLE [dbo].[Products_Special_Food_Categories] CHECK CONSTRAINT [FK_Products_Special_Food_Categories_Special_Food_Categories]
GO
ALTER TABLE [dbo].[Special_Offers]  WITH CHECK ADD  CONSTRAINT [FK_Special_Offers_Business] FOREIGN KEY([Fk_Business])
REFERENCES [dbo].[Business] ([Pk_Business])
GO
ALTER TABLE [dbo].[Special_Offers] CHECK CONSTRAINT [FK_Special_Offers_Business]
GO
ALTER TABLE [dbo].[Special_Offers]  WITH CHECK ADD  CONSTRAINT [FK_Special_Offers_Product_Extender] FOREIGN KEY([Fk_Product_Extender])
REFERENCES [dbo].[Product_Extender] ([Pk_Product_Extender])
GO
ALTER TABLE [dbo].[Special_Offers] CHECK CONSTRAINT [FK_Special_Offers_Product_Extender]
GO
ALTER TABLE [dbo].[Special_Offers]  WITH CHECK ADD  CONSTRAINT [FK_Special_Offers_Products] FOREIGN KEY([Fk_Product])
REFERENCES [dbo].[Products] ([Pk_Product])
GO
ALTER TABLE [dbo].[Special_Offers] CHECK CONSTRAINT [FK_Special_Offers_Products]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Clave principal de los negocios' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Business', @level2type=N'COLUMN',@level2name=N'Pk_Business'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del comercio' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Business', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Teléfono del negocio' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Business', @level2type=N'COLUMN',@level2name=N'Phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mínimo precio si no se llega al pedído mínimo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Business', @level2type=N'COLUMN',@level2name=N'Shipping_Cost_If_Not_Min_Price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Si se permite enviar, pagando una cantidad extra si no se llega al mínimo del pedido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Business', @level2type=N'COLUMN',@level2name=N'Allow_Shipping_Not_Enougth_Amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Si es una categoría personalizada de cada comercio, o las generales de a2m' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categories', @level2type=N'COLUMN',@level2name=N'Fk_Business'
GO
USE [master]
GO
ALTER DATABASE [a2m] SET  READ_WRITE 
GO
