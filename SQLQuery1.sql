USE [master]
GO
/****** Object:  Database FinalCNPM ******/
CREATE DATABASE FinalCNPM
 
GO
USE FinalCNPM
GO
/****** Object:  Table [dbo].[HoaDon]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [int] NOT NULL,
	[NgayMua] [datetime] NULL,
	[TongTien] [decimal](18, 0) NULL,
	[MaKH] [nchar](10) NULL,
	[MaNV] [nchar](10) NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [nchar](10) NOT NULL,
	[TenKH] [nvarchar](500) NULL,
	[NgaySinh] [datetime] NULL,
	[DiaChi] [nvarchar](500) NULL,
	[SDT] [int] NULL,
	[Email] [nvarchar](500) NULL,
	[TaiKhoan] [nvarchar](500) NULL,
	[MatKhau] [nvarchar](500) NULL,
 CONSTRAINT [PK_Khach] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [nchar](10) NOT NULL,
	[TenNV] [nvarchar](500) NULL,
	[NgaySinh] [datetime] NULL,
	[DiaChi] [nvarchar](500) NULL,
	[SDT] [int] NULL,
	[Email] [nvarchar](500) NULL,
	[TaiKhoan] [nvarchar](500) NULL,
	[MatKhau] [nvarchar](500) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT [dbo].[HoaDon] ([MaHD], [NgayMua], [TongTien], [MaKH], [MaNV]) VALUES (1, CAST(N'2021-10-30T00:00:00.000' AS DateTime), CAST(10000000 AS Decimal(18, 0)), N'KH1       ', N'027    ')
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayMua], [TongTien], [MaKH], [MaNV]) VALUES (2, CAST(N'2021-09-09T00:00:00.000' AS DateTime), CAST(50000000 AS Decimal(18, 0)), N'KH1       ', N'027    ')
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayMua], [TongTien], [MaKH], [MaNV]) VALUES (3, CAST(N'2019-08-08T00:00:00.000' AS DateTime), CAST(1000000 AS Decimal(18, 0)), N'KH2       ', N'107    ')
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayMua], [TongTien], [MaKH], [MaNV]) VALUES (4, CAST(N'2021-10-28T00:00:00.000' AS DateTime), CAST(7000000 AS Decimal(18, 0)), N'KH2       ', N'027    ')
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayMua], [TongTien], [MaKH], [MaNV]) VALUES (5, CAST(N'2021-08-25T00:00:00.000' AS DateTime), CAST(600000 AS Decimal(18, 0)), N'KH3       ', N'107    ')
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayMua], [TongTien], [MaKH], [MaNV]) VALUES (6, CAST(N'2021-07-07T00:00:00.000' AS DateTime), CAST(1300000 AS Decimal(18, 0)), N'KH4       ', N'107    ')
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayMua], [TongTien], [MaKH], [MaNV]) VALUES (7, CAST(N'2021-02-13T00:00:00.000' AS DateTime), CAST(24000000 AS Decimal(18, 0)), N'KH1       ', N'107    ')
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [NgaySinh], [DiaChi], [SDT], [Email], [TaiKhoan], [MatKhau]) VALUES (N'KH1       ', N'Huỳnh Hữu Nhựt', CAST(N'2000-05-05T00:00:00.000' AS DateTime), N'Hồ Chí Minh', 907111111, N'Nhut@gmail.com', N'nhut', N'nhut')
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [NgaySinh], [DiaChi], [SDT], [Email], [TaiKhoan], [MatKhau]) VALUES (N'KH2       ', N'Nguyễn Trọng Nghĩa', CAST(N'2021-10-29T00:00:00.000' AS DateTime), N'Hà Nội', 123456879, N'Nghia@gmail.com', N'nghia', N'nghia')
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [NgaySinh], [DiaChi], [SDT], [Email], [TaiKhoan], [MatKhau]) VALUES (N'KH3       ', N'Trà Mi', CAST(N'2001-10-29T00:00:00.000' AS DateTime), N'Ninh Thuận', 123456789, N'MiMi@gmail.com', N'mimi', N'mimi')
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [NgaySinh], [DiaChi], [SDT], [Email], [TaiKhoan], [MatKhau]) VALUES (N'KH4       ', N'Quang Anh', CAST(N'2001-10-30T00:00:00.000' AS DateTime), N'Hồ Chí Minh', 70898765, N'QuangAnh@gmail.com', N'quanganh', N'quanganh')
GO
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [SDT], [Email], [TaiKhoan], [MatKhau]) VALUES (N'027    ', N'admin', CAST(N'2000-10-10T00:00:00.000' AS DateTime), N'Cao Lãnh', 908123456, N'admin@gmail.com', N'admin', N'admin')
GO
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [SDT], [Email], [TaiKhoan], [MatKhau]) VALUES (N'107    ', N'admin2', CAST(N'2001-05-05T00:00:00.000' AS DateTime), N'Hồ Chí Minh', 708987654, N'admin2@gmail.com', N'admin2', N'admin2')
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
USE [master]
GO
ALTER DATABASE [FinalCNPM] SET  READ_WRITE 
GO
