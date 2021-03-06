USE [master]
GO
/****** Object:  Database [School]    Script Date: 19.6.2015 г. 11:49:43 ч. ******/
CREATE DATABASE [School]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'School', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\School.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'School_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\School_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [School] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [School].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [School] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [School] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [School] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [School] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [School] SET ARITHABORT OFF 
GO
ALTER DATABASE [School] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [School] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [School] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [School] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [School] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [School] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [School] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [School] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [School] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [School] SET  DISABLE_BROKER 
GO
ALTER DATABASE [School] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [School] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [School] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [School] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [School] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [School] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [School] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [School] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [School] SET  MULTI_USER 
GO
ALTER DATABASE [School] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [School] SET DB_CHAINING OFF 
GO
ALTER DATABASE [School] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [School] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [School] SET DELAYED_DURABILITY = DISABLED 
GO
USE [School]
GO
/****** Object:  User [radko]    Script Date: 19.6.2015 г. 11:49:43 ч. ******/
CREATE USER [radko] FOR LOGIN [radko] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [radko]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 19.6.2015 г. 11:49:43 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Classes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[MaxStudents] [int] NOT NULL,
 CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Students]    Script Date: 19.6.2015 г. 11:49:44 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Students](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[PhoneNumber] [int] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentsClasses]    Script Date: 19.6.2015 г. 11:49:44 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentsClasses](
	[StudentID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
 CONSTRAINT [PK_StudentsClasses] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC,
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Classes] ON 

INSERT [dbo].[Classes] ([ID], [Name], [MaxStudents]) VALUES (1, N'C#', 200)
INSERT [dbo].[Classes] ([ID], [Name], [MaxStudents]) VALUES (2, N'PHP', 200)
INSERT [dbo].[Classes] ([ID], [Name], [MaxStudents]) VALUES (3, N'JS', 250)
INSERT [dbo].[Classes] ([ID], [Name], [MaxStudents]) VALUES (4, N'Java', 220)
INSERT [dbo].[Classes] ([ID], [Name], [MaxStudents]) VALUES (5, N'OOP', 220)
INSERT [dbo].[Classes] ([ID], [Name], [MaxStudents]) VALUES (6, N'DB', 250)
SET IDENTITY_INSERT [dbo].[Classes] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([ID], [Name], [Age], [PhoneNumber]) VALUES (1, N'Radko', 33, 55433455)
INSERT [dbo].[Students] ([ID], [Name], [Age], [PhoneNumber]) VALUES (2, N'Peshko', 13, NULL)
INSERT [dbo].[Students] ([ID], [Name], [Age], [PhoneNumber]) VALUES (3, N'Stanka', 23, 88888888)
INSERT [dbo].[Students] ([ID], [Name], [Age], [PhoneNumber]) VALUES (5, N'Penka', 24, 666666666)
INSERT [dbo].[Students] ([ID], [Name], [Age], [PhoneNumber]) VALUES (6, N'Goshko', 34, 555555)
INSERT [dbo].[Students] ([ID], [Name], [Age], [PhoneNumber]) VALUES (7, N'Ginka', 20, 4444444)
INSERT [dbo].[Students] ([ID], [Name], [Age], [PhoneNumber]) VALUES (8, N'Gruio', 20, NULL)
SET IDENTITY_INSERT [dbo].[Students] OFF
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (1, 1)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (1, 2)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (1, 3)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (1, 6)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (2, 2)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (2, 3)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (2, 6)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (3, 2)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (5, 2)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (5, 3)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (5, 4)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (5, 6)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (6, 2)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (6, 3)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (6, 4)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (6, 5)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (7, 1)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (7, 3)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (7, 4)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (7, 6)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (8, 3)
INSERT [dbo].[StudentsClasses] ([StudentID], [ClassID]) VALUES (8, 4)
ALTER TABLE [dbo].[StudentsClasses]  WITH CHECK ADD  CONSTRAINT [FK_StudentsClasses_Classes] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Classes] ([ID])
GO
ALTER TABLE [dbo].[StudentsClasses] CHECK CONSTRAINT [FK_StudentsClasses_Classes]
GO
ALTER TABLE [dbo].[StudentsClasses]  WITH CHECK ADD  CONSTRAINT [FK_StudentsClasses_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([ID])
GO
ALTER TABLE [dbo].[StudentsClasses] CHECK CONSTRAINT [FK_StudentsClasses_Students]
GO
USE [master]
GO
ALTER DATABASE [School] SET  READ_WRITE 
GO
