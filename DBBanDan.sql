CREATE DATABASE [DBBanDan]
GO
USE [DBBanDan]
GO
/****** Object:  Table [dbo].[CATEGORY]    Script Date: 23/01/2021 8:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORY](
	[IdCategory] [int] IDENTITY(1,1) NOT NULL,
	[NameCategory] [nvarchar](500) NOT NULL,
	[Slug] [varchar](500) NOT NULL,
	[MetaKey] [nvarchar](155) NOT NULL,
	[MetaDesc] [nvarchar](155) NOT NULL,
	[Created_By] [int] NULL,
	[Created_At] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CONTACT]    Script Date: 23/01/2021 8:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONTACT](
	[IdContact] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Detail] [ntext] NOT NULL,
	[FullName] [nvarchar](255) NOT NULL,
	[Phone] [varchar](12) NOT NULL,
	[Email] [nvarchar](64) NOT NULL,
	[DateContact] [datetime] NULL,
	[Status] [int] NULL,
	[IdUser] [int] NULL,
 CONSTRAINT [PK__CONTACT__2AC556F6E2F31DEF] PRIMARY KEY CLUSTERED 
(
	[IdContact] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ORDER]    Script Date: 23/01/2021 8:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORDER](
	[IdOrder] [int] IDENTITY(1,1) NOT NULL,
	[Note] [nvarchar](255) NULL,
	[DateOrder] [datetime] NOT NULL,
	[Status] [int] NULL,
	[IdUser] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ORDER_DETAIL]    Script Date: 23/01/2021 8:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORDER_DETAIL](
	[IdProduct] [int] NOT NULL,
	[IdOrder] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[PriceBuy] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProduct] ASC,
	[IdOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[POST]    Script Date: 23/01/2021 8:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[POST](
	[IdPost] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
	[IdTopic] [int] NOT NULL,
	[Slug] [nvarchar](500) NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Img] [nvarchar](255) NULL,
	[Sumary] [nvarchar](255) NULL,
	[PostType] [nvarchar](100) NULL,
	[Detail] [ntext] NOT NULL,
	[DateCreate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPost] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCT]    Script Date: 23/01/2021 8:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCT](
	[IdProduct] [int] IDENTITY(1,1) NOT NULL,
	[IdCategory] [int] NOT NULL,
	[Img] [nvarchar](255) NULL,
	[NameProduct] [nvarchar](255) NOT NULL,
	[Slug] [varchar](255) NOT NULL,
	[Detail] [nvarchar](500) NULL,
	[PriceBuy] [float] NOT NULL,
	[MetaKey] [nvarchar](255) NOT NULL,
	[MetaDesc] [nvarchar](255) NOT NULL,
	[Created_By] [int] NULL,
	[Created_At] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROLE]    Script Date: 23/01/2021 8:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROLE](
	[IdRole] [int] IDENTITY(1,1) NOT NULL,
	[NameRole] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SLIDER]    Script Date: 23/01/2021 8:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SLIDER](
	[IdSlider] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Link] [nvarchar](255) NOT NULL,
	[Img] [nvarchar](255) NOT NULL,
	[DateCreate] [datetime] NULL,
	[IdUser] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSlider] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TOPIC]    Script Date: 23/01/2021 8:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TOPIC](
	[IdTopic] [int] IDENTITY(1,1) NOT NULL,
	[NameTopic] [nvarchar](255) NOT NULL,
	[Slug] [varchar](255) NOT NULL,
	[IdUser] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTopic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER]    Script Date: 23/01/2021 8:04:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[IdRole] [int] NOT NULL,
	[FullName] [nvarchar](255) NOT NULL,
	[UserName] [varchar](255) NOT NULL,
	[Password] [varchar](40) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Phone] [varchar](15) NOT NULL,
	[Address] [nvarchar](255) NOT NULL,
	[Created_By] [int] NULL,
	[Created_At] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CATEGORY] ON 

INSERT [dbo].[CATEGORY] ([IdCategory], [NameCategory], [Slug], [MetaKey], [MetaDesc], [Created_By], [Created_At]) VALUES (9, N'Guitar Acoustic', N'guitar-acoustic', N'1', N'1', 1, NULL)
INSERT [dbo].[CATEGORY] ([IdCategory], [NameCategory], [Slug], [MetaKey], [MetaDesc], [Created_By], [Created_At]) VALUES (11, N'Guitar Classic', N'guitar-classic', N'1', N'1', 1, NULL)
INSERT [dbo].[CATEGORY] ([IdCategory], [NameCategory], [Slug], [MetaKey], [MetaDesc], [Created_By], [Created_At]) VALUES (13, N'organ', N'organ', N'123', N'123', NULL, NULL)
INSERT [dbo].[CATEGORY] ([IdCategory], [NameCategory], [Slug], [MetaKey], [MetaDesc], [Created_By], [Created_At]) VALUES (14, N'Guitar điện', N'guitar-din', N'1', N'1', NULL, NULL)
INSERT [dbo].[CATEGORY] ([IdCategory], [NameCategory], [Slug], [MetaKey], [MetaDesc], [Created_By], [Created_At]) VALUES (15, N'trống', N'trng', N'1', N'1', NULL, NULL)
SET IDENTITY_INSERT [dbo].[CATEGORY] OFF
GO
SET IDENTITY_INSERT [dbo].[CONTACT] ON 

INSERT [dbo].[CONTACT] ([IdContact], [Title], [Detail], [FullName], [Phone], [Email], [DateContact], [Status], [IdUser]) VALUES (1, N'di choi', N'afafafda', N'nguyen quang a', N'12314354524', N'quangtruong.tdr017@gmail.com', CAST(N'2021-01-21T16:37:09.583' AS DateTime), 1, NULL)
INSERT [dbo].[CONTACT] ([IdContact], [Title], [Detail], [FullName], [Phone], [Email], [DateContact], [Status], [IdUser]) VALUES (2, N'di choi', N'ffdsfsdfs', N'Nguyễn Quang Trường', N'0778955931', N'quangtruong.tdr012@gmail.com', CAST(N'2021-01-21T17:17:03.380' AS DateTime), 1, 12)
INSERT [dbo].[CONTACT] ([IdContact], [Title], [Detail], [FullName], [Phone], [Email], [DateContact], [Status], [IdUser]) VALUES (3, N'di choi tet', N'adfaf', N'nguyen quang a', N'0778955931', N'quangtruong.tdr000@gmail.com', CAST(N'2021-01-21T17:23:55.713' AS DateTime), 1, NULL)
INSERT [dbo].[CONTACT] ([IdContact], [Title], [Detail], [FullName], [Phone], [Email], [DateContact], [Status], [IdUser]) VALUES (5, N'di choi', N'dafdafad', N'nguyen quang a', N'0778955931', N'quangtruong.tdr000@gmail.com', CAST(N'2021-01-21T17:32:45.847' AS DateTime), 1, NULL)
INSERT [dbo].[CONTACT] ([IdContact], [Title], [Detail], [FullName], [Phone], [Email], [DateContact], [Status], [IdUser]) VALUES (6, N'di choi tet', N'dfdafadfad', N'nguyen quang a888', N'0778955931', N'quangtruong.tdr000@gmail.com', CAST(N'2021-01-21T17:33:53.657' AS DateTime), 1, NULL)
INSERT [dbo].[CONTACT] ([IdContact], [Title], [Detail], [FullName], [Phone], [Email], [DateContact], [Status], [IdUser]) VALUES (7, N'di choi tet 2', N'dafafadfda', N'Nguyễn Quang Trường', N'0778955931', N'quangtruong.tdr012@gmail.com', CAST(N'2021-01-21T17:34:42.890' AS DateTime), 1, 12)
INSERT [dbo].[CONTACT] ([IdContact], [Title], [Detail], [FullName], [Phone], [Email], [DateContact], [Status], [IdUser]) VALUES (8, N'adaf', N'adfadfa', N'adf', N'11111', N'quangtruong.tdr012@gmail.com', CAST(N'2021-01-21T17:35:09.470' AS DateTime), 1, NULL)
INSERT [dbo].[CONTACT] ([IdContact], [Title], [Detail], [FullName], [Phone], [Email], [DateContact], [Status], [IdUser]) VALUES (9, N'adaf', N'adfadfa', N'adf', N'11111', N'quangtruong.tdr012@gmail.com', CAST(N'2021-01-21T17:35:14.170' AS DateTime), 1, NULL)
INSERT [dbo].[CONTACT] ([IdContact], [Title], [Detail], [FullName], [Phone], [Email], [DateContact], [Status], [IdUser]) VALUES (10, N'di choi', N'dafadf', N'nguyen quang a', N'0778955931', N'quangtruong.tdr000@gmail.com', CAST(N'2021-01-21T17:35:43.167' AS DateTime), 1, NULL)
INSERT [dbo].[CONTACT] ([IdContact], [Title], [Detail], [FullName], [Phone], [Email], [DateContact], [Status], [IdUser]) VALUES (11, N'di choi', N'dafdafda', N'Nguyễn Quang Trường', N'0778955931', N'quangtruong.tdr012@gmail.com', CAST(N'2021-01-21T17:35:58.533' AS DateTime), 1, 12)
INSERT [dbo].[CONTACT] ([IdContact], [Title], [Detail], [FullName], [Phone], [Email], [DateContact], [Status], [IdUser]) VALUES (12, N'về nhà', N'về nhà ăn tết', N'Nguyễn Quang Trường', N'0778955931', N'quangtruong.tdr012@gmail.com', CAST(N'2021-01-22T10:28:03.473' AS DateTime), NULL, 12)
INSERT [dbo].[CONTACT] ([IdContact], [Title], [Detail], [FullName], [Phone], [Email], [DateContact], [Status], [IdUser]) VALUES (13, N'di choi tet', N'adfafadfa', N'nguyen quang a11', N'123456788', N'quangtruong.tdr017@gmail.com', CAST(N'2021-01-23T19:49:17.307' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[CONTACT] OFF
GO
SET IDENTITY_INSERT [dbo].[ORDER] ON 

INSERT [dbo].[ORDER] ([IdOrder], [Note], [DateOrder], [Status], [IdUser]) VALUES (9, NULL, CAST(N'2021-01-21T22:40:38.663' AS DateTime), 2, 12)
INSERT [dbo].[ORDER] ([IdOrder], [Note], [DateOrder], [Status], [IdUser]) VALUES (10, NULL, CAST(N'2021-01-21T22:48:39.803' AS DateTime), 2, 12)
INSERT [dbo].[ORDER] ([IdOrder], [Note], [DateOrder], [Status], [IdUser]) VALUES (11, NULL, CAST(N'2021-01-22T09:44:48.520' AS DateTime), NULL, 12)
INSERT [dbo].[ORDER] ([IdOrder], [Note], [DateOrder], [Status], [IdUser]) VALUES (12, NULL, CAST(N'2021-01-22T10:23:49.403' AS DateTime), NULL, 15)
INSERT [dbo].[ORDER] ([IdOrder], [Note], [DateOrder], [Status], [IdUser]) VALUES (13, NULL, CAST(N'2021-01-22T10:34:28.260' AS DateTime), NULL, 12)
INSERT [dbo].[ORDER] ([IdOrder], [Note], [DateOrder], [Status], [IdUser]) VALUES (14, NULL, CAST(N'2021-01-22T16:26:54.297' AS DateTime), NULL, 12)
INSERT [dbo].[ORDER] ([IdOrder], [Note], [DateOrder], [Status], [IdUser]) VALUES (15, NULL, CAST(N'2021-01-23T12:33:54.557' AS DateTime), NULL, 12)
INSERT [dbo].[ORDER] ([IdOrder], [Note], [DateOrder], [Status], [IdUser]) VALUES (16, NULL, CAST(N'2021-01-23T17:12:51.213' AS DateTime), NULL, 12)
INSERT [dbo].[ORDER] ([IdOrder], [Note], [DateOrder], [Status], [IdUser]) VALUES (17, NULL, CAST(N'2021-01-23T19:49:44.000' AS DateTime), NULL, 12)
SET IDENTITY_INSERT [dbo].[ORDER] OFF
GO
INSERT [dbo].[ORDER_DETAIL] ([IdProduct], [IdOrder], [Quantity], [PriceBuy]) VALUES (8, 9, 2, 7000000)
INSERT [dbo].[ORDER_DETAIL] ([IdProduct], [IdOrder], [Quantity], [PriceBuy]) VALUES (8, 10, 1, 3500000)
INSERT [dbo].[ORDER_DETAIL] ([IdProduct], [IdOrder], [Quantity], [PriceBuy]) VALUES (8, 11, 3, 10500000)
INSERT [dbo].[ORDER_DETAIL] ([IdProduct], [IdOrder], [Quantity], [PriceBuy]) VALUES (8, 12, 3, 10500000)
INSERT [dbo].[ORDER_DETAIL] ([IdProduct], [IdOrder], [Quantity], [PriceBuy]) VALUES (8, 13, 1, 3500000)
INSERT [dbo].[ORDER_DETAIL] ([IdProduct], [IdOrder], [Quantity], [PriceBuy]) VALUES (8, 14, 1, 3500000)
INSERT [dbo].[ORDER_DETAIL] ([IdProduct], [IdOrder], [Quantity], [PriceBuy]) VALUES (8, 15, 5, 17500000)
INSERT [dbo].[ORDER_DETAIL] ([IdProduct], [IdOrder], [Quantity], [PriceBuy]) VALUES (8, 16, 1, 3500000)
INSERT [dbo].[ORDER_DETAIL] ([IdProduct], [IdOrder], [Quantity], [PriceBuy]) VALUES (9, 9, 2, 8000000)
INSERT [dbo].[ORDER_DETAIL] ([IdProduct], [IdOrder], [Quantity], [PriceBuy]) VALUES (9, 10, 1, 4000000)
INSERT [dbo].[ORDER_DETAIL] ([IdProduct], [IdOrder], [Quantity], [PriceBuy]) VALUES (9, 11, 3, 12000000)
INSERT [dbo].[ORDER_DETAIL] ([IdProduct], [IdOrder], [Quantity], [PriceBuy]) VALUES (9, 17, 4, 16000000)
INSERT [dbo].[ORDER_DETAIL] ([IdProduct], [IdOrder], [Quantity], [PriceBuy]) VALUES (12, 17, 3, 3000000)
GO
SET IDENTITY_INSERT [dbo].[POST] ON 

INSERT [dbo].[POST] ([IdPost], [IdUser], [IdTopic], [Slug], [Title], [Img], [Sumary], [PostType], [Detail], [DateCreate]) VALUES (1, 12, 1, N'post-1', N'title 1', NULL, N'đây là summary', NULL, N'sngfsjngsfjgnskfjgksjfgkjfsgjsnjkgsfjgfh', NULL)
SET IDENTITY_INSERT [dbo].[POST] OFF
GO
SET IDENTITY_INSERT [dbo].[PRODUCT] ON 

INSERT [dbo].[PRODUCT] ([IdProduct], [IdCategory], [Img], [NameProduct], [Slug], [Detail], [PriceBuy], [MetaKey], [MetaDesc], [Created_By], [Created_At]) VALUES (8, 9, N'guitar_1.jpg', N'Guitar 1', N'guitar-1', N'Đàn Guitar Acoustic Yamaha F310 là model rẻ nhất dành cho người mới học theo phong cách dây sắt, đệm hát.', 3500000, N'1', N'1', 1, NULL)
INSERT [dbo].[PRODUCT] ([IdProduct], [IdCategory], [Img], [NameProduct], [Slug], [Detail], [PriceBuy], [MetaKey], [MetaDesc], [Created_By], [Created_At]) VALUES (9, 11, N'guitar_2.jpg', N'Guitar 2', N'guitar-2', NULL, 4000000, N'1', N'1', 1, NULL)
INSERT [dbo].[PRODUCT] ([IdProduct], [IdCategory], [Img], [NameProduct], [Slug], [Detail], [PriceBuy], [MetaKey], [MetaDesc], [Created_By], [Created_At]) VALUES (10, 9, NULL, N'Guitar 3', N'guitar-3', NULL, 6000000, N'1', N'1', 1, NULL)
INSERT [dbo].[PRODUCT] ([IdProduct], [IdCategory], [Img], [NameProduct], [Slug], [Detail], [PriceBuy], [MetaKey], [MetaDesc], [Created_By], [Created_At]) VALUES (11, 9, N'guitar-2.jpg', N'Ghita 3', N'ghita-3', N'12312312', 12312312, N'312312', N'312312', 1, CAST(N'2021-01-23T17:47:55.597' AS DateTime))
INSERT [dbo].[PRODUCT] ([IdProduct], [IdCategory], [Img], [NameProduct], [Slug], [Detail], [PriceBuy], [MetaKey], [MetaDesc], [Created_By], [Created_At]) VALUES (12, 15, N'j0427700000100000500x5001_1499846894.jpg', N'trông 1', N'trong-1', N'trống xịn', 1000000, N'1', N'1', 18, CAST(N'2021-01-23T19:44:09.273' AS DateTime))
SET IDENTITY_INSERT [dbo].[PRODUCT] OFF
GO
SET IDENTITY_INSERT [dbo].[ROLE] ON 

INSERT [dbo].[ROLE] ([IdRole], [NameRole]) VALUES (5, N'User')
INSERT [dbo].[ROLE] ([IdRole], [NameRole]) VALUES (6, N'Admin')
SET IDENTITY_INSERT [dbo].[ROLE] OFF
GO
SET IDENTITY_INSERT [dbo].[SLIDER] ON 

INSERT [dbo].[SLIDER] ([IdSlider], [Name], [Link], [Img], [DateCreate], [IdUser]) VALUES (6, N'Ghita', N'#', N'guitar-2.jpg', CAST(N'2021-01-23T17:45:52.347' AS DateTime), 18)
SET IDENTITY_INSERT [dbo].[SLIDER] OFF
GO
SET IDENTITY_INSERT [dbo].[TOPIC] ON 

INSERT [dbo].[TOPIC] ([IdTopic], [NameTopic], [Slug], [IdUser]) VALUES (1, N'Tin khuyến mãi', N'tin-khuyen-mai', 12)
INSERT [dbo].[TOPIC] ([IdTopic], [NameTopic], [Slug], [IdUser]) VALUES (2, N'Tin chia sẽ', N'tin-chia-se', 12)
SET IDENTITY_INSERT [dbo].[TOPIC] OFF
GO
SET IDENTITY_INSERT [dbo].[USER] ON 

INSERT [dbo].[USER] ([IdUser], [IdRole], [FullName], [UserName], [Password], [Email], [Phone], [Address], [Created_By], [Created_At]) VALUES (12, 5, N'Nguyễn Quang Trường', N'quangtruong', N'123', N'quangtruong.tdr012@gmail.com', N'0778955931', N'117a Nguyễn Duy Trinh,P.Bình Trưng Tây,Quận 2,TP.HCM', NULL, NULL)
INSERT [dbo].[USER] ([IdUser], [IdRole], [FullName], [UserName], [Password], [Email], [Phone], [Address], [Created_By], [Created_At]) VALUES (13, 5, N'Nguyễn Quang  Trường 2', N'quangtruong2', N'123', N'quangtruong.tdr017@gmail.com', N'0778933931', N'117a Nguyễn Duy Trinh,P.Bình Trưng Tây,Quận 2,TP.HCM', NULL, NULL)
INSERT [dbo].[USER] ([IdUser], [IdRole], [FullName], [UserName], [Password], [Email], [Phone], [Address], [Created_By], [Created_At]) VALUES (14, 5, N'Nguyễn Quang  Trường 3', N'quangtruong3', N'123', N'quangtruong.tdr011@gmail.com', N'0778933932', N'117a Nguyễn Duy Trinh,P.Bình Trưng Tây,Quận 2,TP.HCM', NULL, NULL)
INSERT [dbo].[USER] ([IdUser], [IdRole], [FullName], [UserName], [Password], [Email], [Phone], [Address], [Created_By], [Created_At]) VALUES (15, 5, N'HieuThuHai', N'HieuZzo', N'123123', N'hieu@gmail.com', N'0123456789', N'duoi cau Binh Loi', NULL, NULL)
INSERT [dbo].[USER] ([IdUser], [IdRole], [FullName], [UserName], [Password], [Email], [Phone], [Address], [Created_By], [Created_At]) VALUES (16, 5, N'nguyen quang trường', N'quangtruong11', N'123', N'quangtruong.tdr011@gmail.com', N'0778955931', N'117a Nguyễn Duy Trinh,P.Bình Trưng Tây,Quận 2,TP.HCM', NULL, NULL)
INSERT [dbo].[USER] ([IdUser], [IdRole], [FullName], [UserName], [Password], [Email], [Phone], [Address], [Created_By], [Created_At]) VALUES (17, 5, N'nguyen quang ab', N'quangtruongab', N'ab123', N'quangtruong.tdr015@gmail.com', N'0778955931', N'duoi cau Binh Loi', NULL, NULL)
INSERT [dbo].[USER] ([IdUser], [IdRole], [FullName], [UserName], [Password], [Email], [Phone], [Address], [Created_By], [Created_At]) VALUES (18, 6, N'Vu Le', N'vule', N'123', N'vule@gmail.com', N'123456', N'123', 1, CAST(N'2021-01-23T17:45:06.763' AS DateTime))
SET IDENTITY_INSERT [dbo].[USER] OFF
GO
ALTER TABLE [dbo].[CATEGORY] ADD  DEFAULT ((1)) FOR [Created_By]
GO
ALTER TABLE [dbo].[CONTACT] ADD  CONSTRAINT [DF__CONTACT__Status__46E78A0C]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[ORDER] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[PRODUCT] ADD  DEFAULT ((1)) FOR [Created_By]
GO
ALTER TABLE [dbo].[USER] ADD  DEFAULT ((1)) FOR [Created_By]
GO
ALTER TABLE [dbo].[CONTACT]  WITH CHECK ADD  CONSTRAINT [FK__CONTACT__IdUser__5070F446] FOREIGN KEY([IdUser])
REFERENCES [dbo].[USER] ([IdUser])
GO
ALTER TABLE [dbo].[CONTACT] CHECK CONSTRAINT [FK__CONTACT__IdUser__5070F446]
GO
ALTER TABLE [dbo].[ORDER]  WITH CHECK ADD FOREIGN KEY([IdUser])
REFERENCES [dbo].[USER] ([IdUser])
GO
ALTER TABLE [dbo].[ORDER_DETAIL]  WITH CHECK ADD FOREIGN KEY([IdOrder])
REFERENCES [dbo].[ORDER] ([IdOrder])
GO
ALTER TABLE [dbo].[ORDER_DETAIL]  WITH CHECK ADD FOREIGN KEY([IdProduct])
REFERENCES [dbo].[PRODUCT] ([IdProduct])
GO
ALTER TABLE [dbo].[POST]  WITH CHECK ADD FOREIGN KEY([IdTopic])
REFERENCES [dbo].[TOPIC] ([IdTopic])
GO
ALTER TABLE [dbo].[POST]  WITH CHECK ADD FOREIGN KEY([IdUser])
REFERENCES [dbo].[USER] ([IdUser])
GO
ALTER TABLE [dbo].[PRODUCT]  WITH CHECK ADD FOREIGN KEY([IdCategory])
REFERENCES [dbo].[CATEGORY] ([IdCategory])
GO
ALTER TABLE [dbo].[SLIDER]  WITH CHECK ADD FOREIGN KEY([IdUser])
REFERENCES [dbo].[USER] ([IdUser])
GO
ALTER TABLE [dbo].[TOPIC]  WITH CHECK ADD FOREIGN KEY([IdUser])
REFERENCES [dbo].[USER] ([IdUser])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([IdRole])
REFERENCES [dbo].[ROLE] ([IdRole])
GO
USE [master]
GO
ALTER DATABASE [DBBanDan] SET  READ_WRITE 
GO
