﻿USE [master]
GO
/****** Object:  Database [Desiderata]    Script Date: 21/02/2018 16:58:37 ******/
CREATE DATABASE [Desiderata]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Desiderata', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQL2008\MSSQL\DATA\Desiderata.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Desiderata_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQL2008\MSSQL\DATA\Desiderata_log.ldf' , SIZE = 4096KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Desiderata] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Desiderata].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Desiderata] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Desiderata] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Desiderata] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Desiderata] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Desiderata] SET ARITHABORT OFF 
GO
ALTER DATABASE [Desiderata] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Desiderata] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Desiderata] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Desiderata] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Desiderata] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Desiderata] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Desiderata] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Desiderata] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Desiderata] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Desiderata] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Desiderata] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Desiderata] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Desiderata] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Desiderata] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Desiderata] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Desiderata] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Desiderata] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Desiderata] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Desiderata] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Desiderata] SET  MULTI_USER 
GO
ALTER DATABASE [Desiderata] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Desiderata] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Desiderata] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Desiderata] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Desiderata]
GO
/****** Object:  Table [dbo].[Collection]    Script Date: 21/02/2018 16:58:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Collection](
	[CollectionID] [int] IDENTITY(1,1) NOT NULL,
	[Path] [varchar](256) NOT NULL,
	[DefaultSchemaID] [int] NOT NULL,
 CONSTRAINT [PK_Collection] PRIMARY KEY CLUSTERED 
(
	[CollectionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Desideratum]    Script Date: 21/02/2018 16:58:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Desideratum](
	[DesideratumID] [int] IDENTITY(1,1) NOT NULL,
	[MediaType] [varchar](50) NOT NULL,
	[Content] [ntext] NOT NULL,
	[Path] [varchar](265) NOT NULL,
	[CollectionID] [int] NOT NULL,
	[SchemaID] [int] NOT NULL,
 CONSTRAINT [PK_Desideratum] PRIMARY KEY CLUSTERED 
(
	[DesideratumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Schema]    Script Date: 21/02/2018 16:58:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Schema](
	[SchemaID] [int] IDENTITY(1,1) NOT NULL,
	[Content] [ntext] NOT NULL,
	[InferenceMode] [tinyint] NOT NULL,
	[Path] [varchar](256) NOT NULL,
 CONSTRAINT [PK_Schema] PRIMARY KEY CLUSTERED 
(
	[SchemaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [Desiderata] SET  READ_WRITE 
GO
