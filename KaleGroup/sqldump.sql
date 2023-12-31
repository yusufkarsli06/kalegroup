USE [master]
GO
/****** Object:  Database [kalegroup]    Script Date: 1/1/2024 7:43:19 PM ******/
CREATE DATABASE [kalegroup]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'kalegroup', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\kalegroup.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'kalegroup_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\kalegroup_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [kalegroup] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [kalegroup].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [kalegroup] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [kalegroup] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [kalegroup] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [kalegroup] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [kalegroup] SET ARITHABORT OFF 
GO
ALTER DATABASE [kalegroup] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [kalegroup] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [kalegroup] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [kalegroup] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [kalegroup] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [kalegroup] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [kalegroup] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [kalegroup] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [kalegroup] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [kalegroup] SET  DISABLE_BROKER 
GO
ALTER DATABASE [kalegroup] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [kalegroup] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [kalegroup] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [kalegroup] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [kalegroup] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [kalegroup] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [kalegroup] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [kalegroup] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [kalegroup] SET  MULTI_USER 
GO
ALTER DATABASE [kalegroup] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [kalegroup] SET DB_CHAINING OFF 
GO
ALTER DATABASE [kalegroup] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [kalegroup] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [kalegroup] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [kalegroup] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [kalegroup] SET QUERY_STORE = OFF
GO
USE [kalegroup]
GO
/****** Object:  Table [dbo].[Menus]    Script Date: 1/1/2024 7:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[EnName] [nvarchar](250) NULL,
	[EnDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 1/1/2024 7:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SettingsKey] [nvarchar](50) NULL,
	[SettingsValue] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slider]    Script Date: 1/1/2024 7:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slider](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FilePath] [nvarchar](max) NULL,
	[isActive] [bit] NULL,
	[MenuId] [int] NULL,
	[OrderNumber] [int] NULL,
	[PageUrl] [nvarchar](max) NULL,
	[EnPageUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_Slider] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubMenus]    Script Date: 1/1/2024 7:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubMenus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Description] [nvarchar](max) NULL,
	[MenuId] [int] NULL,
	[IsActive] [bit] NULL,
	[EnName] [nvarchar](250) NULL,
	[EnDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_SubMenu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UploadFiles]    Script Date: 1/1/2024 7:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UploadFiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](500) NULL,
	[FileUrl] [nvarchar](max) NULL,
	[FilePath] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogs]    Script Date: 1/1/2024 7:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_UserLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/1/2024 7:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](250) NULL,
	[Password] [nvarchar](max) NULL,
	[Email] [nvarchar](250) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WebPages]    Script Date: 1/1/2024 7:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WebPages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[MenuId] [int] NULL,
	[PageTopSubject] [nvarchar](max) NULL,
	[PageTopDescription] [nvarchar](max) NULL,
	[PageTopBackground] [nvarchar](50) NULL,
	[PageTopImages] [nvarchar](max) NULL,
	[PageDescription] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[PageUrl] [nvarchar](max) NULL,
	[Keyword] [nvarchar](max) NULL,
	[EnName] [nvarchar](50) NULL,
	[EnPageTopSubject] [nvarchar](max) NULL,
	[EnPageTopDescription] [nvarchar](max) NULL,
	[EnPageTopBackground] [nvarchar](50) NULL,
	[EnPageDescription] [nvarchar](max) NULL,
	[EnPageUrl] [nvarchar](max) NULL,
	[IsNews] [bit] NULL,
	[IsSubMenu] [bit] NULL,
	[IsMenu] [bit] NULL,
	[IsTopBody] [bit] NULL,
	[IsButtomBody] [bit] NULL,
	[CreatedAt] [datetime] NULL,
	[EnKeyword] [nvarchar](max) NULL,
	[IsSlider] [bit] NULL,
 CONSTRAINT [PK_Pages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Menus] ON 

INSERT [dbo].[Menus] ([Id], [Name], [Description], [IsActive], [EnName], [EnDescription]) VALUES (1, N'Kurumsal', N'Kurumsal', 1, N'Kurumsal', N'Kurumsal')
INSERT [dbo].[Menus] ([Id], [Name], [Description], [IsActive], [EnName], [EnDescription]) VALUES (2, N'Faaliyet Alanları', N'Faaliyet Alanları', 0, N'Faaliyet Alanları', N'Faaliyet Alanları')
INSERT [dbo].[Menus] ([Id], [Name], [Description], [IsActive], [EnName], [EnDescription]) VALUES (9, N'Toplumsal Yatırımlar', N'Toplumsal Yatırımlar', 0, N'Toplumsal Yatırımlar', N'Toplumsal Yatırımlar')
INSERT [dbo].[Menus] ([Id], [Name], [Description], [IsActive], [EnName], [EnDescription]) VALUES (10, N'İnsan Kaynakları', N'İnsan Kaynakları', 1, N'İnsan Kaynakları', N'İnsan Kaynakları')
INSERT [dbo].[Menus] ([Id], [Name], [Description], [IsActive], [EnName], [EnDescription]) VALUES (11, N'Medya', N'Medya', 1, N'Medya', N'Medya')
INSERT [dbo].[Menus] ([Id], [Name], [Description], [IsActive], [EnName], [EnDescription]) VALUES (12, N'İletişim', N'İletişim', 1, N'İletişim', N'İletişim')
SET IDENTITY_INSERT [dbo].[Menus] OFF
GO
SET IDENTITY_INSERT [dbo].[Settings] ON 

INSERT [dbo].[Settings] ([Id], [SettingsKey], [SettingsValue], [IsActive]) VALUES (1, N'google_analitic', N'script', NULL)
INSERT [dbo].[Settings] ([Id], [SettingsKey], [SettingsValue], [IsActive]) VALUES (2, N'facebook', N'www.facebook.com', NULL)
INSERT [dbo].[Settings] ([Id], [SettingsKey], [SettingsValue], [IsActive]) VALUES (3, N'youtube', N'www.youtube.com', NULL)
SET IDENTITY_INSERT [dbo].[Settings] OFF
GO
SET IDENTITY_INSERT [dbo].[Slider] ON 

INSERT [dbo].[Slider] ([Id], [FilePath], [isActive], [MenuId], [OrderNumber], [PageUrl], [EnPageUrl]) VALUES (1, N'c3a11288dc034cd5b5525f7215696a90.jpg', 1, 1, 1, N'12', N'12')
INSERT [dbo].[Slider] ([Id], [FilePath], [isActive], [MenuId], [OrderNumber], [PageUrl], [EnPageUrl]) VALUES (2, N'7b8e6a96e4534a71992a3082ca4cff26.jpg', 0, 1, 2, N'12', N'12')
SET IDENTITY_INSERT [dbo].[Slider] OFF
GO
SET IDENTITY_INSERT [dbo].[SubMenus] ON 

INSERT [dbo].[SubMenus] ([Id], [Name], [Description], [MenuId], [IsActive], [EnName], [EnDescription]) VALUES (1, N'Hakkımızda', N'ewqe', 1, 1, N'Hakkımızda', N'Hakkımızda')
INSERT [dbo].[SubMenus] ([Id], [Name], [Description], [MenuId], [IsActive], [EnName], [EnDescription]) VALUES (2, N'Sektörler', N'ewe', 2, 1, N'Sektörler', N'Sektörler')
SET IDENTITY_INSERT [dbo].[SubMenus] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [IsActive]) VALUES (4, N'1', N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', N'1', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[WebPages] ON 

INSERT [dbo].[WebPages] ([Id], [Name], [MenuId], [PageTopSubject], [PageTopDescription], [PageTopBackground], [PageTopImages], [PageDescription], [IsActive], [PageUrl], [Keyword], [EnName], [EnPageTopSubject], [EnPageTopDescription], [EnPageTopBackground], [EnPageDescription], [EnPageUrl], [IsNews], [IsSubMenu], [IsMenu], [IsTopBody], [IsButtomBody], [CreatedAt], [EnKeyword], [IsSlider]) VALUES (1, N'Hakkımızda', 1, N'1', N'1', N'1', N'1', N'1', 1, N'hakkimizda', N'1', N'1', N'1', N'1', N'1', N'1', N'1', 0, 1, 0, 0, 0, CAST(N'2023-12-23T11:49:57.637' AS DateTime), NULL, 0)
INSERT [dbo].[WebPages] ([Id], [Name], [MenuId], [PageTopSubject], [PageTopDescription], [PageTopBackground], [PageTopImages], [PageDescription], [IsActive], [PageUrl], [Keyword], [EnName], [EnPageTopSubject], [EnPageTopDescription], [EnPageTopBackground], [EnPageDescription], [EnPageUrl], [IsNews], [IsSubMenu], [IsMenu], [IsTopBody], [IsButtomBody], [CreatedAt], [EnKeyword], [IsSlider]) VALUES (2, N'Sektörler', 2, N'1', N'1', N'1', N'1', N'1', 1, N'sektorler', N'1', N'1', N'1', N'1', N'1', N'1', N'1', 0, 1, 0, 0, 0, CAST(N'2023-12-23T11:49:57.637' AS DateTime), NULL, 0)
INSERT [dbo].[WebPages] ([Id], [Name], [MenuId], [PageTopSubject], [PageTopDescription], [PageTopBackground], [PageTopImages], [PageDescription], [IsActive], [PageUrl], [Keyword], [EnName], [EnPageTopSubject], [EnPageTopDescription], [EnPageTopBackground], [EnPageDescription], [EnPageUrl], [IsNews], [IsSubMenu], [IsMenu], [IsTopBody], [IsButtomBody], [CreatedAt], [EnKeyword], [IsSlider]) VALUES (3, N'Uygulamalar', 10, N'İnsan Kaynakları Uygulamaları', N'İK uygulamalarımızla insanı merkezimize koyuyoruz.', N'#FBD9D6', N'e832719f5f3340dbb852c491f4131451.jpg', N'             <p>İnsan Kaynakları Uygulamaları ile yeni yeteneklerin Kale Grubu’na katılması, çalışanların yetkinliklerine göre doğru pozisyonlarda çalışması, çalışanların öğrenme ve gelişim süreçlerinin desteklenmesi ve doğru performans takibi ile şirketlerin hedeflerine ulaşmasına katkı sağlanması hedefleniyor.<br></p>
<h4 style="font-family: Poppins; color: rgb(0, 0, 0);"><span style="font-size: 1.5rem;">İşe Alım</span></h4><p>İşe alım süreci uygulamaları, gelişime ve yeniliklere açık, işin niteliği ve yetkinlikleriyle eşleşen, iş ahlakına sahip, kurum kültürüne, değerlerine ve hedeflerine uygun bireyleri Kale Grubu’na kazandırmayı hedefliyor.&nbsp;</p><p>Pozisyonun gerekliliklerine göre adayların değerlendirilmesinde genel yetenek testi, yabancı dil seviye belirleme testi, kişilik envanteri, değerlendirme merkezi uygulaması ve yetkinlik bazlı mülakatlar olmak üzere belirli süreçler uygulanıyor. Tüm değerlendirmelerin sonucunda pozisyon için en uygun adaya iş teklifi yapılıyor.</p><p>Mevcut iş ilanlarımıza <a href="https://www.kariyer.net/firma-profil/kale-grubu-31033-184245" target="_blank">kariyer.net</a> ve <a href="https://www.linkedin.com/company/kalegrubu/jobs" target="_blank">LinkedIn</a> üzerinden ulaşabilirsiniz.&nbsp;<br></p><h4 style="font-family: Poppins; color: rgb(0, 0, 0);">Yetenek Yönetimi</h4><p>Kale Grubu yetenek yönetimi yaklaşımı, her çalışanının bir yetenek olduğu gerçeğiyle oluşturuldu. Bu doğrultuda, işlere uygun yetenek, yeterlilik, bilgi ve beceriye sahip kişilerin gruba alınması, grupta tutulması ve yeteneklerinin etkin bir şekilde geliştirilmesi hedefleniyor.</p><p>Bununla birlikte, çalışanların gelişim planları doğrultusunda performanslarının artırılması, çalışan beklentileri ile şirket beklentilerinin dengelenmesi de yetenek yönetimi sürecinin bir parçası olarak değerlendiriliyor.</p><h4 style="font-family: Poppins; color: rgb(0, 0, 0);">Öğrenme ve Gelişim</h4><p>Öğrenme ve gelişim süreci ile tüm çalışanlarına yönelik mesleki, teknik ve kişisel gelişim alanlarında eğitim ve gelişim çözümleri sunuluyor. Böylece, sürekli öğrenen, öğrendiğini uygulayan ve paylaşan “öğrenen organizasyon” olma kültürünün geliştirilmesi; aynı zamanda, çalışanların iş tatmininin ve motivasyonunun artırılması da hedefleniyor.</p><h4 style="font-family: Poppins; color: rgb(0, 0, 0);">Performans Yönetim Süreci</h4><p>Kale Grubu Performans Yönetim Sisteminde çok boyutlu ve hedef bazlı değerlendirme esas alınarak Dengeli Karne metodu kullanılıyor. Sistem, tüm şirketin gelişime ve büyümeye odaklı aynı yönü takip etmesini sağlamanın yanı sıra şirketin uzun vadeli başarısı için gerekli olan stratejik hedefleri de içeriyor.<br></p><p>Şirket hedef kartlarının belirlenmesini takiben başlayan bireysel performans sistemi finansal, müşteri, iş süreçleri ile öğrenme ve gelişim kategorileri olmak üzere dört temel alanda takip ediliyor.</p><h4 style="font-family: Poppins; color: rgb(0, 0, 0);">İş Değerleme ve Ücret Yönetimi</h4><p>Kale Grubu şirketlerinde, şirket stratejileri doğrultusunda işlerin organizasyona kattığı göreceli değeri ölçmek amacıyla tüm çalışanların görevlerini kapsayan İş Değerlendirme Sistemi uygulanıyor. Bu sistemde işler, Kale Grubu için oluşturulan “İş Aileleri” kapsamında ve belirli kademelerde gruplandırılıyor.<br></p><p>Ücret yönetim sistemine temel oluşturan iş kademeleri, yapılan iş değerlendirmeleri sonucunda belirlenirken; iş değerlendirme sürecinde unvan ve kişiden bağımsız, işin içeriğine dayalı ve işin kurum hedeflerine ulaşılmasındaki etki ve katkısını ölçen ve sorumluluk seviyelerine göre sıralanmasını sağlayan uluslararası bir sistem olan HAY İş Değerleme Sistemi kullanılıyor.</p><p>İş değerleme çalışmalarının ardından, piyasa araştırmaları ile yurt içi ücret piyasaları yakından takip ediliyor ve analizler sonucunda şirketlerin mevcut ücret yapıları, piyasadaki konumları ve finansal güçlerine göre rekabetçi ve adil ücret politikaları belirlenerek uygulanıyor.</p><h4 style="font-family: Poppins; color: rgb(0, 0, 0);">Kariyer Yönetimi</h4><p>Kale Grubu bünyesinde, terfi, atama, kademe artışı ve rotasyon süreçlerinin bütünsel ve objektif bir insan kaynakları yaklaşımıyla yürütülmesi amacıyla performans ve yetkinlik değerlendirme sonuçları kullanılıyor.<br></p><p>Eğitim ve Gelişim, Performans Yönetimi, Yetkinlik Yönetimi gibi uygulamalarla kişilerin teknik ve kişisel gelişimleri ile kariyer hedefleri destekleniyor. Yönetim Kariyer Yolu, çalışanın daha üst pozisyona geçmek için gerekli koşulları sağlamanın yanında, yönetim ve liderlik becerilerini de gerektiren bir kariyer yoluyken; Teknik Kariyer Yolu, derinlemesine uzmanlık gerektiren bir konu üzerinde (Arge, mühendislik vb.) danışılan görevinin üstlenildiği rolleri içeren kariyer yolu olarak değerlendiriliyor. Kale Grubu çalışanları, yetkinlik değerlendirme sonuçlarına göre Yönetim Kariyer Yolu veya Teknik Kariyer Yolu’na yönlendirilerek kariyer hedefleri belirleniyor.</p>', 1, N'insan_kaynaklari_uygulamalari', N'1', N'1', N'Human Resources Policies', N'Putting people at the heart of our policies.

', N'1', N'        <p>Our human resources policies aim to attract new talents to Kale Group, place the right people in the right jobs, support their learning and development, and contribute to achieving our corporate goals through sound performance monitoring.</p>
<h4 style="">Recruitment</h4><p>Kale Group’s recruitment processes aim to attract individuals who are open to development and novelty, have the qualities and competencies that meet the job requirements, demonstrate ethical values, and are aligned with the organisation’s culture, values and goals.</p><p>Our recruitment process includes a series of general aptitude tests, foreign language tests, personality inventory, assessment centre practices and competency based interviews to evaluate candidates against relevant job criteria. The most suitable candidate receives a job offer after all the assessments are completed.</p><h4 style="">Talent Management</h4><p>Kale Group’s talent management approach builds on the fact that each and every employee is a talent. Our talent management process aims to recruit and retain individuals who have the right talents, competencies, knowledge and skills for the job and develop their talents efficiently.</p><p>Our talent management process also focuses on increasing employee performance in line with individual development plans and balancing employee expectations with the organisation’s expectations.</p><h4 style="">Learning and Development</h4><p>Kale Group offers all employees vocational, technical and personal training and development solutions as part of its learning and development policy. In doing so, Kale Group aims to nurture a ‘learning organisation’ culture in which the organisation continuously learns and applies, while also increasing employee satisfaction and motivation.</p><h4 style="">Performance Management</h4><p>Kale Group uses the balanced scorecard method built around a multi-dimensional and target-based assessment. The system enables the whole organisation to be aligned in the same growth and development direction, while also defining the strategic goals needed for the organisation’s success in the long run.</p><p>After identifying the scorecards for each company, individual performance is monitored in four key categories: financial, customer, business processes, and learning and development.</p><h4 style="">Job Evaluation and Compensation Management</h4><p>Kale Group companies use a job evaluation system that applies to all jobs across the organisation to measure the relevant value that each job adds to the company’s strategies. The jobs are grouped under Job Families created for Kale Group and graded according to specific levels.</p><p>Job assessments are conducted to determine the job grades that form the basis of the compensation management system. Kale Group uses the international HAY Job Evaluation System that measures jobs by their impact and contribution to the organisation’s targets, irrespective of titles and individuals, and grades them according their level of responsibility required.</p><p>After the job evaluation process is completed, Kale Group uses current market research to keep close track of domestic compensation markets and conducts a series of analyses to identify competitive and fair remuneration policies in line with each company’s current compensation structure, market position and financial strength..</p><h4 style="">Career Management</h4><p>To apply an integrated and objective human resources approach, Kale Group uses performance and competency assessments to make decisions for appointments, assignments, upgrades and rotations.&nbsp;</p><p>Kale Group supports the technical and personal development and career goals of its employees through practices such as training and development, performance management and talent management. The Executive Career Path identifies the conditions that employees need to meet to move to a higher position. Employees need to possess management and leadership skills to follow this path. The Technical Career Path pursues a path consisting of roles that require in-depth knowledge in a specific field (e.g. R&amp;D, engineering). Kale Group employees are guided to pursue the Executive Career Path or Technical Career Path based on their competency assessment results and their career goals are identified accordingly.</p>
                    ', N'human_resources_application', 0, 1, 0, 0, 0, CAST(N'2023-12-23T11:49:57.637' AS DateTime), NULL, 0)
INSERT [dbo].[WebPages] ([Id], [Name], [MenuId], [PageTopSubject], [PageTopDescription], [PageTopBackground], [PageTopImages], [PageDescription], [IsActive], [PageUrl], [Keyword], [EnName], [EnPageTopSubject], [EnPageTopDescription], [EnPageTopBackground], [EnPageDescription], [EnPageUrl], [IsNews], [IsSubMenu], [IsMenu], [IsTopBody], [IsButtomBody], [CreatedAt], [EnKeyword], [IsSlider]) VALUES (4, N'İnsan Kaynakları', 10, N'İnsan Kaynakları Uygulamaları', N'İnsan odaklı yönetim anlayışımız doğrultusunda tüm çalışanlarımızla birlikte geleceğe doğru ilerliyoruz.', N'#FBD9D6', N'009e81aff77e427796d773750405b7b4.jpg', N'', 1, N'insan_kaynaklari', N'1', N'Human Resources', N'Human Resources', N'Putting people at the heart of our policies.

', N'1', N'aadad', N'human_resources', 0, 0, 1, 0, 0, CAST(N'2023-12-23T11:49:57.637' AS DateTime), NULL, 0)
INSERT [dbo].[WebPages] ([Id], [Name], [MenuId], [PageTopSubject], [PageTopDescription], [PageTopBackground], [PageTopImages], [PageDescription], [IsActive], [PageUrl], [Keyword], [EnName], [EnPageTopSubject], [EnPageTopDescription], [EnPageTopBackground], [EnPageDescription], [EnPageUrl], [IsNews], [IsSubMenu], [IsMenu], [IsTopBody], [IsButtomBody], [CreatedAt], [EnKeyword], [IsSlider]) VALUES (5, N'Toplumsal Yatırımlar', 9, N'1', N'1', N'1', N'1', N'1', 1, N'toplumsal_yatirimlar', N'1', N'1', N'1', N'1', N'1', N'1', N'1', 0, 0, 1, 0, 0, CAST(N'2023-12-23T11:49:57.637' AS DateTime), NULL, 0)
INSERT [dbo].[WebPages] ([Id], [Name], [MenuId], [PageTopSubject], [PageTopDescription], [PageTopBackground], [PageTopImages], [PageDescription], [IsActive], [PageUrl], [Keyword], [EnName], [EnPageTopSubject], [EnPageTopDescription], [EnPageTopBackground], [EnPageDescription], [EnPageUrl], [IsNews], [IsSubMenu], [IsMenu], [IsTopBody], [IsButtomBody], [CreatedAt], [EnKeyword], [IsSlider]) VALUES (6, N'Kurucumuz', 1, N'Dr. (h.c.) İbrahim Bodur
', N'Anadolu’da sanayileşmenin ilk adımlarını atan Kale Grubu’nun Kurucusu Dr. (h.c.) İbrahim Bodur’un hayatının kilometre taşları...

', N'#eceafa', N'd5e14eab8e044580a4ae4fb46e10e042.jpg', N'1', 1, N'insan_kaynaklari', N'1', N'Human Resources', N'Human Resources', N'Putting people at the heart of our policies.', N'1', N'1', N'1', 0, 1, 0, 0, 0, CAST(N'2023-12-23T11:49:57.637' AS DateTime), NULL, 0)
INSERT [dbo].[WebPages] ([Id], [Name], [MenuId], [PageTopSubject], [PageTopDescription], [PageTopBackground], [PageTopImages], [PageDescription], [IsActive], [PageUrl], [Keyword], [EnName], [EnPageTopSubject], [EnPageTopDescription], [EnPageTopBackground], [EnPageDescription], [EnPageUrl], [IsNews], [IsSubMenu], [IsMenu], [IsTopBody], [IsButtomBody], [CreatedAt], [EnKeyword], [IsSlider]) VALUES (11, N'Yönetim', 1, N'Yönetim', N'1', N'1', N'4b120d3236164c91b03640808d5bdb79.jpg', N'1', 1, N'yonetim', N'1', N'1', N'1', N'1', N'1', N'1', N'1', 0, 1, 0, 0, 1, CAST(N'2023-12-23T11:49:57.637' AS DateTime), NULL, 0)
INSERT [dbo].[WebPages] ([Id], [Name], [MenuId], [PageTopSubject], [PageTopDescription], [PageTopBackground], [PageTopImages], [PageDescription], [IsActive], [PageUrl], [Keyword], [EnName], [EnPageTopSubject], [EnPageTopDescription], [EnPageTopBackground], [EnPageDescription], [EnPageUrl], [IsNews], [IsSubMenu], [IsMenu], [IsTopBody], [IsButtomBody], [CreatedAt], [EnKeyword], [IsSlider]) VALUES (12, N'Kilometre Taşları', 1, N'66 Yıllık Sanayi Yolculuğu
', N'Kurulduğumuz günden bu yana her alanda öncü olduk. Her zaman ilkleri gerçekleştirirken, milyonlarca hayata dokunduk. 1957 yılında başladığımız yolculuğumuzu...', N'1', N'4201fd97bf7b41a6b67fe0d5bce4e10a.jpg', N'66 Yıllık Sanayi Yolculuğu
', 1, N'kilometre_taslari', N'1', N'1', N'1', N'1', N'1', N'1', N'1', 0, 1, 0, 1, 0, CAST(N'2023-12-23T11:49:57.637' AS DateTime), NULL, 0)
INSERT [dbo].[WebPages] ([Id], [Name], [MenuId], [PageTopSubject], [PageTopDescription], [PageTopBackground], [PageTopImages], [PageDescription], [IsActive], [PageUrl], [Keyword], [EnName], [EnPageTopSubject], [EnPageTopDescription], [EnPageTopBackground], [EnPageDescription], [EnPageUrl], [IsNews], [IsSubMenu], [IsMenu], [IsTopBody], [IsButtomBody], [CreatedAt], [EnKeyword], [IsSlider]) VALUES (13, N'Kilometre Taşları', 1, N'66 Yıllık Sanayi Yolculuğu', N'Kurulduğumuz günden bu yana her alanda öncü olduk. Her zaman ilkleri gerçekleştirirken, milyonlarca hayata dokunduk. 1957 yılında başladığımız yolculuğumuzu...', N'1', N'4201fd97bf7b41a6b67fe0d5bce4e10a.jpg', N'66 Yıllık Sanayi Yolculuğu
', 1, N'kilometre_taslari', N'1', N'1', N'1', N'1', N'1', N'1', N'1', 0, 1, 0, 1, 0, CAST(N'2023-12-23T12:08:12.850' AS DateTime), NULL, 0)
INSERT [dbo].[WebPages] ([Id], [Name], [MenuId], [PageTopSubject], [PageTopDescription], [PageTopBackground], [PageTopImages], [PageDescription], [IsActive], [PageUrl], [Keyword], [EnName], [EnPageTopSubject], [EnPageTopDescription], [EnPageTopBackground], [EnPageDescription], [EnPageUrl], [IsNews], [IsSubMenu], [IsMenu], [IsTopBody], [IsButtomBody], [CreatedAt], [EnKeyword], [IsSlider]) VALUES (16, N'haber 2', 11, N'Dr. (h.c.) İbrahim Bodur', N'Anadolu’da sanayileşmenin ilk adımlarını atan Kale Grubu’nun Kurucusu Dr. (h.c.) İbrahim Bodur’un hayatının kilometre taşları...

', N'#eceafa', N'd5e14eab8e044580a4ae4fb46e10e042.jpg', N'1', 1, N'haber2', N'1', N'1', N'1', N'1', N'1', N'1', N'1', 1, 0, 0, 0, 0, CAST(N'2023-12-23T12:22:54.300' AS DateTime), NULL, 0)
INSERT [dbo].[WebPages] ([Id], [Name], [MenuId], [PageTopSubject], [PageTopDescription], [PageTopBackground], [PageTopImages], [PageDescription], [IsActive], [PageUrl], [Keyword], [EnName], [EnPageTopSubject], [EnPageTopDescription], [EnPageTopBackground], [EnPageDescription], [EnPageUrl], [IsNews], [IsSubMenu], [IsMenu], [IsTopBody], [IsButtomBody], [CreatedAt], [EnKeyword], [IsSlider]) VALUES (19, N'haber 3', 11, N'Dr. (h.c.) İbrahim Bodur', N'Anadolu’da sanayileşmenin ilk adımlarını atan Kale Grubu’nun Kurucusu Dr. (h.c.) İbrahim Bodur’un hayatının kilometre taşları...', N'#eceafa', N'd5e14eab8e044580a4ae4fb46e10e042.jpg', N'1', 1, N'haber3', N'1', N'1', N'1', N'1', N'1', N'1', N'1', 1, 0, 0, 0, 0, CAST(N'2023-12-23T12:24:01.080' AS DateTime), NULL, 0)
INSERT [dbo].[WebPages] ([Id], [Name], [MenuId], [PageTopSubject], [PageTopDescription], [PageTopBackground], [PageTopImages], [PageDescription], [IsActive], [PageUrl], [Keyword], [EnName], [EnPageTopSubject], [EnPageTopDescription], [EnPageTopBackground], [EnPageDescription], [EnPageUrl], [IsNews], [IsSubMenu], [IsMenu], [IsTopBody], [IsButtomBody], [CreatedAt], [EnKeyword], [IsSlider]) VALUES (21, N'haber 4', 11, N'Dr. (h.c.) İbrahim Bodur', N'Anadolu’da sanayileşmenin ilk adımlarını atan Kale Grubu’nun Kurucusu Dr. (h.c.) İbrahim Bodur’un hayatının kilometre taşları...', N'#eceafa', N'd5e14eab8e044580a4ae4fb46e10e042.jpg', N'1', 1, N'haber4', N'1', N'1', N'1', N'1', N'1', N'1', N'1', 1, 0, 0, 0, 0, CAST(N'2023-12-23T12:24:01.080' AS DateTime), NULL, 0)
INSERT [dbo].[WebPages] ([Id], [Name], [MenuId], [PageTopSubject], [PageTopDescription], [PageTopBackground], [PageTopImages], [PageDescription], [IsActive], [PageUrl], [Keyword], [EnName], [EnPageTopSubject], [EnPageTopDescription], [EnPageTopBackground], [EnPageDescription], [EnPageUrl], [IsNews], [IsSubMenu], [IsMenu], [IsTopBody], [IsButtomBody], [CreatedAt], [EnKeyword], [IsSlider]) VALUES (22, N'haber 1', 11, N'Dr. (h.c.) İbrahim Bodur', N'Anadolu’da sanayileşmenin ilk adımlarını atan Kale Grubu’nun Kurucusu Dr. (h.c.) İbrahim Bodur’un hayatının kilometre taşları...', N'#eceafa', N'd5e14eab8e044580a4ae4fb46e10e042.jpg', N'1', 1, N'haber1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', 1, 0, 0, 0, 0, CAST(N'2023-12-23T12:24:01.080' AS DateTime), NULL, 0)
INSERT [dbo].[WebPages] ([Id], [Name], [MenuId], [PageTopSubject], [PageTopDescription], [PageTopBackground], [PageTopImages], [PageDescription], [IsActive], [PageUrl], [Keyword], [EnName], [EnPageTopSubject], [EnPageTopDescription], [EnPageTopBackground], [EnPageDescription], [EnPageUrl], [IsNews], [IsSubMenu], [IsMenu], [IsTopBody], [IsButtomBody], [CreatedAt], [EnKeyword], [IsSlider]) VALUES (23, N'Haberler', 11, N'Haberler', N'Tüm Haberler', N'#eceafa', N'009e81aff77e427796d773750405b7b4.jpg', N'', 1, N'haberler', N'1', N'News', N'News', N'News', N'1', N'1', N'news', 1, 1, 0, 0, 0, CAST(N'2023-12-23T14:45:44.730' AS DateTime), NULL, 0)
SET IDENTITY_INSERT [dbo].[WebPages] OFF
GO
ALTER TABLE [dbo].[WebPages] ADD  CONSTRAINT [DF_WebPages_IsTopBody]  DEFAULT ((0)) FOR [IsTopBody]
GO
ALTER TABLE [dbo].[WebPages] ADD  CONSTRAINT [DF_WebPages_IsButtomBody]  DEFAULT ((0)) FOR [IsButtomBody]
GO
ALTER TABLE [dbo].[WebPages] ADD  CONSTRAINT [DF_WebPages_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[WebPages] ADD  CONSTRAINT [DF_WebPages_IsSlider]  DEFAULT ((0)) FOR [IsSlider]
GO
USE [master]
GO
ALTER DATABASE [kalegroup] SET  READ_WRITE 
GO
