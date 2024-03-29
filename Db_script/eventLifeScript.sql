USE [master]
GO
/****** Object:  Database [event_life]    Script Date: 10/02/2014 21:16:37 ******/
CREATE DATABASE [event_life] ON  PRIMARY 
( NAME = N'event_life', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\event_life.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'event_life_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\event_life_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [event_life] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [event_life].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [event_life] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [event_life] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [event_life] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [event_life] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [event_life] SET ARITHABORT OFF 
GO
ALTER DATABASE [event_life] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [event_life] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [event_life] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [event_life] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [event_life] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [event_life] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [event_life] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [event_life] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [event_life] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [event_life] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [event_life] SET  DISABLE_BROKER 
GO
ALTER DATABASE [event_life] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [event_life] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [event_life] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [event_life] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [event_life] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [event_life] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [event_life] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [event_life] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [event_life] SET  MULTI_USER 
GO
ALTER DATABASE [event_life] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [event_life] SET DB_CHAINING OFF 
GO
USE [event_life]
GO
/****** Object:  Table [dbo].[Anagrafica]    Script Date: 10/02/2014 21:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Anagrafica](
	[ID_anagrafica] [int] IDENTITY(1,1) NOT NULL,
	[data_nascita] [date] NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[cognome] [nvarchar](50) NOT NULL,
	[sesso] [nvarchar](1) NULL,
	[codice_fiscale] [nvarchar](50) NULL,
	[p_iva] [nvarchar](50) NULL,
	[indirizzo] [nvarchar](100) NULL,
	[cap] [nvarchar](10) NULL,
	[citta] [nvarchar](50) NULL,
	[provincia] [nvarchar](2) NULL,
	[carta_identita] [nvarchar](50) NULL,
	[utente_id] [int] NOT NULL,
	[tel] [nvarchar](50) NULL,
	[cell] [nvarchar](50) NULL,
	[fax] [nvarchar](50) NULL,
 CONSTRAINT [PK_Anagrafica] PRIMARY KEY CLUSTERED 
(
	[ID_anagrafica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 10/02/2014 21:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[ID_categoria] [int] IDENTITY(1,1) NOT NULL,
	[Titolo] [nvarchar](150) NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[ID_categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Eventi]    Script Date: 10/02/2014 21:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Eventi](
	[Id_evento] [int] IDENTITY(1,1) NOT NULL,
	[Titolo] [varchar](50) NOT NULL,
	[desc_breve] [varchar](50) NULL,
	[desc_lunga] [text] NULL,
	[gallery_id] [int] NULL,
	[data_inizio] [datetime] NOT NULL,
	[data_fine] [datetime] NOT NULL,
	[profilo_id] [int] NOT NULL,
	[categoria_id] [int] NOT NULL,
 CONSTRAINT [PK_Eventi] PRIMARY KEY CLUSTERED 
(
	[Id_evento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Foto]    Script Date: 10/02/2014 21:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Foto](
	[ID_foto] [int] IDENTITY(1,1) NOT NULL,
	[path] [nvarchar](100) NOT NULL,
	[ordine] [int] NULL,
	[gallery_id] [int] NOT NULL,
 CONSTRAINT [PK_Foto] PRIMARY KEY CLUSTERED 
(
	[ID_foto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gallery]    Script Date: 10/02/2014 21:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gallery](
	[ID_gallery] [int] IDENTITY(1,1) NOT NULL,
	[nome] [int] NULL,
 CONSTRAINT [PK_Gallery] PRIMARY KEY CLUSTERED 
(
	[ID_gallery] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gallery_tipo]    Script Date: 10/02/2014 21:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gallery_tipo](
	[ID_gallery_tipo] [int] NOT NULL,
	[tipi_gallery_id] [int] NOT NULL,
	[profilo_id] [int] NOT NULL,
 CONSTRAINT [PK_Gallery_tipo] PRIMARY KEY CLUSTERED 
(
	[ID_gallery_tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Livello_Utenti]    Script Date: 10/02/2014 21:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livello_Utenti](
	[ID_livello] [int] IDENTITY(1,1) NOT NULL,
	[livello] [int] NOT NULL,
	[descrizione] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Livello_Utenti] PRIMARY KEY CLUSTERED 
(
	[ID_livello] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Profilo]    Script Date: 10/02/2014 21:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profilo](
	[ID_profilo] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[logo] [nvarchar](100) NOT NULL,
	[indirizzo] [nvarchar](100) NOT NULL,
	[cap] [nvarchar](10) NOT NULL,
	[citta] [nvarchar](50) NOT NULL,
	[latitudine] [decimal](18, 10) NOT NULL,
	[longitudine] [decimal](18, 10) NOT NULL,
	[desc_breve] [nvarchar](50) NULL,
	[desc_long] [text] NULL,
	[utente_id] [int] NOT NULL,
	[gallery_id] [int] NULL,
	[categoria_id] [int] NOT NULL,
 CONSTRAINT [PK_Profilo] PRIMARY KEY CLUSTERED 
(
	[ID_profilo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Telefono]    Script Date: 10/02/2014 21:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telefono](
	[ID_telefono] [int] IDENTITY(1,1) NOT NULL,
	[tel] [nvarchar](50) NOT NULL,
	[profilo_id] [int] NOT NULL,
 CONSTRAINT [PK_Telefono] PRIMARY KEY CLUSTERED 
(
	[ID_telefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Utenti]    Script Date: 10/02/2014 21:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utenti](
	[ID_utente] [int] IDENTITY(1,1) NOT NULL,
	[usename] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[livello_id] [int] NOT NULL,
 CONSTRAINT [PK_Utenti] PRIMARY KEY CLUSTERED 
(
	[ID_utente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_Livello_Utenti]    Script Date: 10/02/2014 21:16:37 ******/
CREATE NONCLUSTERED INDEX [IX_Livello_Utenti] ON [dbo].[Livello_Utenti]
(
	[ID_livello] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Anagrafica]  WITH CHECK ADD  CONSTRAINT [FK_Anagrafica_Utenti] FOREIGN KEY([utente_id])
REFERENCES [dbo].[Utenti] ([ID_utente])
GO
ALTER TABLE [dbo].[Anagrafica] CHECK CONSTRAINT [FK_Anagrafica_Utenti]
GO
ALTER TABLE [dbo].[Eventi]  WITH CHECK ADD  CONSTRAINT [FK_Eventi_Categoria] FOREIGN KEY([categoria_id])
REFERENCES [dbo].[Categoria] ([ID_categoria])
GO
ALTER TABLE [dbo].[Eventi] CHECK CONSTRAINT [FK_Eventi_Categoria]
GO
ALTER TABLE [dbo].[Eventi]  WITH CHECK ADD  CONSTRAINT [FK_Eventi_Gallery] FOREIGN KEY([gallery_id])
REFERENCES [dbo].[Gallery] ([ID_gallery])
GO
ALTER TABLE [dbo].[Eventi] CHECK CONSTRAINT [FK_Eventi_Gallery]
GO
ALTER TABLE [dbo].[Eventi]  WITH CHECK ADD  CONSTRAINT [FK_Eventi_Profilo] FOREIGN KEY([profilo_id])
REFERENCES [dbo].[Profilo] ([ID_profilo])
GO
ALTER TABLE [dbo].[Eventi] CHECK CONSTRAINT [FK_Eventi_Profilo]
GO
ALTER TABLE [dbo].[Foto]  WITH CHECK ADD  CONSTRAINT [FK_Foto_Gallery] FOREIGN KEY([gallery_id])
REFERENCES [dbo].[Gallery] ([ID_gallery])
GO
ALTER TABLE [dbo].[Foto] CHECK CONSTRAINT [FK_Foto_Gallery]
GO
ALTER TABLE [dbo].[Gallery]  WITH CHECK ADD  CONSTRAINT [FK_Gallery_Profilo] FOREIGN KEY([nome])
REFERENCES [dbo].[Profilo] ([ID_profilo])
GO
ALTER TABLE [dbo].[Gallery] CHECK CONSTRAINT [FK_Gallery_Profilo]
GO
ALTER TABLE [dbo].[Profilo]  WITH CHECK ADD  CONSTRAINT [FK_Profilo_Categoria] FOREIGN KEY([categoria_id])
REFERENCES [dbo].[Categoria] ([ID_categoria])
GO
ALTER TABLE [dbo].[Profilo] CHECK CONSTRAINT [FK_Profilo_Categoria]
GO
ALTER TABLE [dbo].[Profilo]  WITH CHECK ADD  CONSTRAINT [FK_Profilo_Gallery] FOREIGN KEY([gallery_id])
REFERENCES [dbo].[Gallery] ([ID_gallery])
GO
ALTER TABLE [dbo].[Profilo] CHECK CONSTRAINT [FK_Profilo_Gallery]
GO
ALTER TABLE [dbo].[Profilo]  WITH CHECK ADD  CONSTRAINT [FK_Profilo_Utenti] FOREIGN KEY([utente_id])
REFERENCES [dbo].[Utenti] ([ID_utente])
GO
ALTER TABLE [dbo].[Profilo] CHECK CONSTRAINT [FK_Profilo_Utenti]
GO
ALTER TABLE [dbo].[Telefono]  WITH CHECK ADD  CONSTRAINT [FK_Telefono_Profilo] FOREIGN KEY([profilo_id])
REFERENCES [dbo].[Profilo] ([ID_profilo])
GO
ALTER TABLE [dbo].[Telefono] CHECK CONSTRAINT [FK_Telefono_Profilo]
GO
ALTER TABLE [dbo].[Utenti]  WITH CHECK ADD  CONSTRAINT [FK_Utenti_Livello_Utenti] FOREIGN KEY([livello_id])
REFERENCES [dbo].[Livello_Utenti] ([ID_livello])
GO
ALTER TABLE [dbo].[Utenti] CHECK CONSTRAINT [FK_Utenti_Livello_Utenti]
GO
USE [master]
GO
ALTER DATABASE [event_life] SET  READ_WRITE 
GO
