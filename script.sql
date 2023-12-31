USE [PRN211]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 8/5/2023 11:25:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[ReviewID] [int] NULL,
	[UserID] [int] NULL,
	[CommentText] [nvarchar](max) NULL,
	[CommentDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 8/5/2023 11:25:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Category] [nvarchar](50) NULL,
	[Brand] [nvarchar](50) NULL,
	[Price] [decimal](10, 2) NULL,
	[ReleaseDate] [date] NULL,
	[Image] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 8/5/2023 11:25:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[ReviewID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[UserID] [int] NULL,
	[Rating] [int] NULL,
	[ReviewText] [nvarchar](max) NULL,
	[ReviewDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/5/2023 11:25:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[LastLoginDate] [date] NULL,
	[isAdmin] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [ProductName], [Description], [Category], [Brand], [Price], [ReleaseDate], [Image]) VALUES (1, N'Laptop', N'Good', N'Tech', N'Asus', CAST(10000.00 AS Decimal(10, 2)), CAST(N'2023-03-03' AS Date), N'laptop.jpg')
INSERT [dbo].[Products] ([ProductID], [ProductName], [Description], [Category], [Brand], [Price], [ReleaseDate], [Image]) VALUES (2, N'Iphone', N'Good', N'Tech', N'Apple', CAST(340000.00 AS Decimal(10, 2)), CAST(N'2023-03-03' AS Date), N'iphone12.jpg')
INSERT [dbo].[Products] ([ProductID], [ProductName], [Description], [Category], [Brand], [Price], [ReleaseDate], [Image]) VALUES (3, N'ipad', N'Good', N'tech', N'Apple', CAST(10000.00 AS Decimal(10, 2)), CAST(N'2023-08-04' AS Date), N'ipad.jpg')
INSERT [dbo].[Products] ([ProductID], [ProductName], [Description], [Category], [Brand], [Price], [ReleaseDate], [Image]) VALUES (5, N'Nguyen Van ABC', N'Good', N'tech', N'Apple', CAST(10000.00 AS Decimal(10, 2)), CAST(N'2023-08-04' AS Date), N'laptop.jpg')
INSERT [dbo].[Products] ([ProductID], [ProductName], [Description], [Category], [Brand], [Price], [ReleaseDate], [Image]) VALUES (6, N'Nguyen Van ABC', N'Good', N'tech', N'Apple', CAST(10000.00 AS Decimal(10, 2)), CAST(N'2023-08-04' AS Date), N'speaker.jpg')
INSERT [dbo].[Products] ([ProductID], [ProductName], [Description], [Category], [Brand], [Price], [ReleaseDate], [Image]) VALUES (7, N'Nguyen Van ABC', N'Good', N'tech', N'Apple', CAST(10000.00 AS Decimal(10, 2)), CAST(N'2023-08-05' AS Date), N'Untitled Diagram.drawio (5).png')
INSERT [dbo].[Products] ([ProductID], [ProductName], [Description], [Category], [Brand], [Price], [ReleaseDate], [Image]) VALUES (8, N'Nhat Minh', N'Good 5', N'Beuty', N'ROG', CAST(10000.00 AS Decimal(10, 2)), CAST(N'2023-08-05' AS Date), N'eye.jpg')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Reviews] ON 

INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [UserID], [Rating], [ReviewText], [ReviewDate]) VALUES (1, 1, 1, 0, N'fdg 
 Posted at:8/1/2023 3:41:59 PM 
  
 Posted at:8/1/2023 3:42:04 PM 
  
 Posted at:8/1/2023 3:42:08 PM 
  
 Posted at:8/1/2023 3:42:21 PM 
 verry good', CAST(N'2023-08-01' AS Date))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [UserID], [Rating], [ReviewText], [ReviewDate]) VALUES (2, 1, 2, 4, N'nice', CAST(N'2023-08-01' AS Date))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [UserID], [Rating], [ReviewText], [ReviewDate]) VALUES (3, 2, 1, 4, N'nice 
 Posted at:8/1/2023 5:48:02 PM 
 nice
 
 Posted at:8/4/2023 1:11:11 AM 
  
 Posted at:8/4/2023 1:11:17 AM 
 ', CAST(N'2023-08-01' AS Date))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [UserID], [Rating], [ReviewText], [ReviewDate]) VALUES (5, 7, 1, 4, N'nice 
 Posted at:8/4/2023 11:48:40 AM 
 good', CAST(N'2023-08-04' AS Date))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [UserID], [Rating], [ReviewText], [ReviewDate]) VALUES (6, 2, 3, 0, N'hello 
 Posted at:8/4/2023 1:11:49 AM 
  
 Posted at:8/4/2023 1:11:53 AM 
  
 Posted at:8/4/2023 1:11:56 AM 
  
 Posted at:8/4/2023 1:13:14 AM 
 ', CAST(N'2023-08-04' AS Date))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [UserID], [Rating], [ReviewText], [ReviewDate]) VALUES (7, 5, 1, 5, N'good', CAST(N'2023-08-04' AS Date))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [UserID], [Rating], [ReviewText], [ReviewDate]) VALUES (8, 7, 3, 5, N'nice', CAST(N'2023-08-04' AS Date))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [UserID], [Rating], [ReviewText], [ReviewDate]) VALUES (9, 5, 3, 3, N'nice', CAST(N'2023-08-04' AS Date))
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Username], [Email], [Password], [LastLoginDate], [isAdmin]) VALUES (1, N'canh duong', N'canhduonghp02@gmail.com', N'123456', CAST(N'2023-08-01' AS Date), 1)
INSERT [dbo].[Users] ([UserID], [Username], [Email], [Password], [LastLoginDate], [isAdmin]) VALUES (2, N'd', N'adm@gmail.com', N'123456', CAST(N'2023-08-01' AS Date), 0)
INSERT [dbo].[Users] ([UserID], [Username], [Email], [Password], [LastLoginDate], [isAdmin]) VALUES (3, N'Mac', N'canhduonghp02@gmail.com', N'12345', CAST(N'2023-08-03' AS Date), 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD FOREIGN KEY([ReviewID])
REFERENCES [dbo].[Reviews] ([ReviewID])
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
