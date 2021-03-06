USE [master]
GO
/****** Object:  Database [TP4]    Script Date: 20/6/2022 02:36:07 ******/
CREATE DATABASE [TP4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TP4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\TP4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TP4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\TP4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TP4] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TP4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TP4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TP4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TP4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TP4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TP4] SET ARITHABORT OFF 
GO
ALTER DATABASE [TP4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TP4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TP4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TP4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TP4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TP4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TP4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TP4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TP4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TP4] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TP4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TP4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TP4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TP4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TP4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TP4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TP4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TP4] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TP4] SET  MULTI_USER 
GO
ALTER DATABASE [TP4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TP4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TP4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TP4] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TP4] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TP4] SET QUERY_STORE = OFF
GO
USE [TP4]
GO
/****** Object:  Table [dbo].[catalogos]    Script Date: 20/6/2022 02:36:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[catalogos](
	[id] [int] NULL,
	[nombre] [varchar](50) NULL,
	[cantidad] [int] NULL,
	[precio] [decimal](10, 1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clientela]    Script Date: 20/6/2022 02:36:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientela](
	[dni] [int] NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[catalogos] ([id], [nombre], [cantidad], [precio]) VALUES (1, N'primero', 2, CAST(23.0 AS Decimal(10, 1)))
INSERT [dbo].[catalogos] ([id], [nombre], [cantidad], [precio]) VALUES (2, N'Segundo', 34, CAST(2.0 AS Decimal(10, 1)))
INSERT [dbo].[catalogos] ([id], [nombre], [cantidad], [precio]) VALUES (3, N'Tercero', 4, CAST(56.0 AS Decimal(10, 1)))
INSERT [dbo].[catalogos] ([id], [nombre], [cantidad], [precio]) VALUES (6, N'sexto', 56, CAST(767.0 AS Decimal(10, 1)))
INSERT [dbo].[catalogos] ([id], [nombre], [cantidad], [precio]) VALUES (7, N'septimo', 34, CAST(565.0 AS Decimal(10, 1)))
INSERT [dbo].[catalogos] ([id], [nombre], [cantidad], [precio]) VALUES (8, N'octavo', 9, CAST(68.0 AS Decimal(10, 1)))
INSERT [dbo].[catalogos] ([id], [nombre], [cantidad], [precio]) VALUES (10, N'décimo', 56, CAST(79.0 AS Decimal(10, 1)))
INSERT [dbo].[catalogos] ([id], [nombre], [cantidad], [precio]) VALUES (11, N'onceavo', 45, CAST(88.0 AS Decimal(10, 1)))
INSERT [dbo].[catalogos] ([id], [nombre], [cantidad], [precio]) VALUES (12, N'doceavo', 565, CAST(9.0 AS Decimal(10, 1)))
INSERT [dbo].[catalogos] ([id], [nombre], [cantidad], [precio]) VALUES (13, N'treceavo', 5, CAST(909.0 AS Decimal(10, 1)))
INSERT [dbo].[catalogos] ([id], [nombre], [cantidad], [precio]) VALUES (14, N'catorceavo', 6, CAST(679.0 AS Decimal(10, 1)))
INSERT [dbo].[catalogos] ([id], [nombre], [cantidad], [precio]) VALUES (15, N'quinveavo', 5656, CAST(95.0 AS Decimal(10, 1)))
GO
INSERT [dbo].[clientela] ([dni], [nombre], [apellido]) VALUES (1, N'Cindy', N'Mello')
INSERT [dbo].[clientela] ([dni], [nombre], [apellido]) VALUES (2, N'Laura', N'Novoa')
INSERT [dbo].[clientela] ([dni], [nombre], [apellido]) VALUES (3, N'Claudia', N'Lapacó')
INSERT [dbo].[clientela] ([dni], [nombre], [apellido]) VALUES (4, N'Laura', N'Branigan')
INSERT [dbo].[clientela] ([dni], [nombre], [apellido]) VALUES (6, N'Melisa', N'Manchester')
INSERT [dbo].[clientela] ([dni], [nombre], [apellido]) VALUES (6, N'March', N'Simpson')
INSERT [dbo].[clientela] ([dni], [nombre], [apellido]) VALUES (8, N'Julianne', N'Moore')
INSERT [dbo].[clientela] ([dni], [nombre], [apellido]) VALUES (10, N'Lisa', N'Simpson')
INSERT [dbo].[clientela] ([dni], [nombre], [apellido]) VALUES (12, N'Arrugada', N'Simpson')
INSERT [dbo].[clientela] ([dni], [nombre], [apellido]) VALUES (13, N'Lilly', N'Collins')
INSERT [dbo].[clientela] ([dni], [nombre], [apellido]) VALUES (15, N'Percival', N'Lowell')
INSERT [dbo].[clientela] ([dni], [nombre], [apellido]) VALUES (18, N'Mel', N'Ferrer')
INSERT [dbo].[clientela] ([dni], [nombre], [apellido]) VALUES (18, N'Hans', N'Müller')
GO
USE [master]
GO
ALTER DATABASE [TP4] SET  READ_WRITE 
GO
