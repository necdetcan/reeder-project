USE [master]
GO
/****** Object:  Database [Rapor]    Script Date: 24.08.2020 12:27:22 ******/
CREATE DATABASE [Rapor]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Rapor', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Rapor.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Rapor_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Rapor_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Rapor] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Rapor].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Rapor] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Rapor] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Rapor] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Rapor] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Rapor] SET ARITHABORT OFF 
GO
ALTER DATABASE [Rapor] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Rapor] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Rapor] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Rapor] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Rapor] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Rapor] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Rapor] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Rapor] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Rapor] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Rapor] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Rapor] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Rapor] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Rapor] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Rapor] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Rapor] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Rapor] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Rapor] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Rapor] SET RECOVERY FULL 
GO
ALTER DATABASE [Rapor] SET  MULTI_USER 
GO
ALTER DATABASE [Rapor] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Rapor] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Rapor] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Rapor] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Rapor] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Rapor', N'ON'
GO
ALTER DATABASE [Rapor] SET QUERY_STORE = OFF
GO
USE [Rapor]
GO
/****** Object:  Table [dbo].[Depo]    Script Date: 24.08.2020 12:27:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Depo](
	[servisNo] [varchar](50) NULL,
	[seriNo] [varchar](50) NULL,
	[tarih] [varchar](50) NULL,
	[model] [varchar](100) NULL,
	[modelKodu] [varchar](50) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [Depo_pkey] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepoParca]    Script Date: 24.08.2020 12:27:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepoParca](
	[depoID] [varchar](100) NULL,
	[parcaAd] [varchar](100) NULL,
	[parcaKod] [varchar](2044) NULL,
	[parcaDurum] [varchar](800) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [DepoParca_pkey] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 24.08.2020 12:27:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici](
	[sifre] [varchar](50) NULL,
	[dogumTarihi] [date] NULL,
	[ad] [varchar](50) NULL,
	[soyad] [varchar](50) NULL,
	[yetki] [varchar](50) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[kullaniciAdi] [nchar](50) NULL,
 CONSTRAINT [Kullanici_pkey] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KullaniciRapor]    Script Date: 24.08.2020 12:27:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KullaniciRapor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[kullaniciID] [int] NOT NULL,
	[RaporID] [int] NOT NULL,
 CONSTRAINT [KullaniciRapor_pkey] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[musteriHizmetleri]    Script Date: 24.08.2020 12:27:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[musteriHizmetleri](
	[tarih] [date] NULL,
	[temsilci] [varchar](100) NULL,
	[musteriAd] [varchar](100) NULL,
	[musteriSoyad] [varchar](100) NULL,
	[musteriTelefon] [varchar](100) NULL,
	[musteriEmail] [varchar](100) NULL,
	[musteriSikayeti] [varchar](500) NULL,
	[musteriyeCevap] [varchar](500) NULL,
	[musteriyeUlasildi] [varchar](100) NULL,
	[cihazModel] [varchar](100) NULL,
	[cihazSeriNo] [varchar](50) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [MusteriHizmetleri_pkey] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Raporlar]    Script Date: 24.08.2020 12:27:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Raporlar](
	[raporAdi] [varchar](150) NULL,
	[raporTarih] [date] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[kategori] [varchar](100) NULL,
 CONSTRAINT [Raporlar_pkey] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servis]    Script Date: 24.08.2020 12:27:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servis](
	[servisNumarasi] [varchar](100) NOT NULL,
	[seriNumarasi] [varchar](100) NULL,
	[model] [varchar](200) NULL,
	[modelKodu] [varchar](200) NULL,
	[musteriNo] [varchar](100) NULL,
	[musteriAd] [varchar](50) NULL,
	[musteriSoyad] [varchar](50) NULL,
	[musteriAdres] [varchar](500) NULL,
	[musteriIl] [varchar](50) NULL,
	[musteriIlce] [varchar](50) NULL,
	[serviseGelisTarih] [date] NULL,
	[kargoTarihi] [date] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [Servis_pkey] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Kullanici] ON 

INSERT [dbo].[Kullanici] ([sifre], [dogumTarihi], [ad], [soyad], [yetki], [ID], [kullaniciAdi]) VALUES (N'12345', CAST(N'2000-01-01' AS Date), N'ali', N'veli', N'uye', 1, N'uye                                               ')
INSERT [dbo].[Kullanici] ([sifre], [dogumTarihi], [ad], [soyad], [yetki], [ID], [kullaniciAdi]) VALUES (N'12345', CAST(N'2321-01-01' AS Date), N'asd', N'asd', N'yonetici', 3, N'admin                                             ')
SET IDENTITY_INSERT [dbo].[Kullanici] OFF
GO
SET IDENTITY_INSERT [dbo].[KullaniciRapor] ON 

INSERT [dbo].[KullaniciRapor] ([ID], [kullaniciID], [RaporID]) VALUES (42, 3, 9)
INSERT [dbo].[KullaniciRapor] ([ID], [kullaniciID], [RaporID]) VALUES (43, 3, 10)
SET IDENTITY_INSERT [dbo].[KullaniciRapor] OFF
GO
SET IDENTITY_INSERT [dbo].[musteriHizmetleri] ON 

INSERT [dbo].[musteriHizmetleri] ([tarih], [temsilci], [musteriAd], [musteriSoyad], [musteriTelefon], [musteriEmail], [musteriSikayeti], [musteriyeCevap], [musteriyeUlasildi], [cihazModel], [cihazSeriNo], [ID]) VALUES (CAST(N'2020-02-01' AS Date), N'temsilci a', N'ahmet', N'demir', N'55555555', N'dsadsadsa@gmail.com', N'bozuk', N'olumsuz', N'evet', N'reeder p13', N'11111111111', 1)
INSERT [dbo].[musteriHizmetleri] ([tarih], [temsilci], [musteriAd], [musteriSoyad], [musteriTelefon], [musteriEmail], [musteriSikayeti], [musteriyeCevap], [musteriyeUlasildi], [cihazModel], [cihazSeriNo], [ID]) VALUES (CAST(N'2020-02-01' AS Date), N'temsilci a', N'burak', N'ahmet', N'123123123', N'dsadsadsa@gmail.com', N'bozuk', N'olumsuz', N'evet', N'p12', N'123123123', 2)
INSERT [dbo].[musteriHizmetleri] ([tarih], [temsilci], [musteriAd], [musteriSoyad], [musteriTelefon], [musteriEmail], [musteriSikayeti], [musteriyeCevap], [musteriyeUlasildi], [cihazModel], [cihazSeriNo], [ID]) VALUES (CAST(N'2020-02-01' AS Date), N'temsilci b', N'ayşe', N'yusuf', N'111111111', N'dsadsadsa@gmail.com', N'bozuk', N'olumsuz', N'evet', N'p12', N'123123123', 3)
SET IDENTITY_INSERT [dbo].[musteriHizmetleri] OFF
GO
SET IDENTITY_INSERT [dbo].[Raporlar] ON 

INSERT [dbo].[Raporlar] ([raporAdi], [raporTarih], [ID], [kategori]) VALUES (N'musteriHizmetleri', CAST(N'2000-01-01' AS Date), 9, N'musteriHizmetleri')
INSERT [dbo].[Raporlar] ([raporAdi], [raporTarih], [ID], [kategori]) VALUES (N'servis', CAST(N'2020-01-01' AS Date), 10, N'servis')
SET IDENTITY_INSERT [dbo].[Raporlar] OFF
GO
SET IDENTITY_INSERT [dbo].[Servis] ON 

INSERT [dbo].[Servis] ([servisNumarasi], [seriNumarasi], [model], [modelKodu], [musteriNo], [musteriAd], [musteriSoyad], [musteriAdres], [musteriIl], [musteriIlce], [serviseGelisTarih], [kargoTarihi], [ID]) VALUES (N'1', N'123', N'Reeder P13', N'1', N'5070000000', N'ali', N'demir', N'------- ---- ---', N'Samsun', N'Atakum', CAST(N'2011-01-01' AS Date), CAST(N'2012-01-01' AS Date), 8)
SET IDENTITY_INSERT [dbo].[Servis] OFF
GO
ALTER TABLE [dbo].[KullaniciRapor]  WITH CHECK ADD  CONSTRAINT [fk_Kullanici] FOREIGN KEY([kullaniciID])
REFERENCES [dbo].[Kullanici] ([ID])
GO
ALTER TABLE [dbo].[KullaniciRapor] CHECK CONSTRAINT [fk_Kullanici]
GO
ALTER TABLE [dbo].[KullaniciRapor]  WITH CHECK ADD  CONSTRAINT [fk_Raporlar] FOREIGN KEY([RaporID])
REFERENCES [dbo].[Raporlar] ([ID])
GO
ALTER TABLE [dbo].[KullaniciRapor] CHECK CONSTRAINT [fk_Raporlar]
GO
/****** Object:  StoredProcedure [dbo].[spRaporSirala]    Script Date: 24.08.2020 12:27:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE PROCEDURE [dbo].[spRaporSirala]

	@ID int


AS
BEGIN
SELECT k.ID [KullaniciID],
      k.kullaniciAdi,
	  r.raporAdi,
	  r.ID[RaporID],
	  r.raporTarih

  FROM [Rapor].[dbo].[KullaniciRapor]as kr left join Raporlar as r on kr.RaporID = r.ID left join Kullanici as k on k.ID = kr.kullaniciID
  WHERE k.ID = @ID
END;
GO
/****** Object:  StoredProcedure [dbo].[test]    Script Date: 24.08.2020 12:27:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[test](@table_name varchar(max))
 AS
 BEGIN
 declare @tablename varchar(max)=@table_name;
	declare @statement varchar(max);
 set @statement = 'Select * from ' + @tablename;
 execute (@statement);
 END
GO
USE [master]
GO
ALTER DATABASE [Rapor] SET  READ_WRITE 
GO
