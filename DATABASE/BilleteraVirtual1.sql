USE [master]
GO
/****** Object:  Database [Billetera]    Script Date: 12/11/2022 19:37:31 ******/
CREATE DATABASE [Billetera]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Billetera', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Billetera.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Billetera_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Billetera_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Billetera] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Billetera].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Billetera] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Billetera] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Billetera] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Billetera] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Billetera] SET ARITHABORT OFF 
GO
ALTER DATABASE [Billetera] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Billetera] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Billetera] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Billetera] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Billetera] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Billetera] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Billetera] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Billetera] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Billetera] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Billetera] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Billetera] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Billetera] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Billetera] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Billetera] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Billetera] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Billetera] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Billetera] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Billetera] SET RECOVERY FULL 
GO
ALTER DATABASE [Billetera] SET  MULTI_USER 
GO
ALTER DATABASE [Billetera] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Billetera] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Billetera] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Billetera] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Billetera] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Billetera', N'ON'
GO
USE [Billetera]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 12/11/2022 19:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Cuil] [varchar](50) NOT NULL,
	[Fecha_Nacimiento] [date] NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Contrasenia] [varchar](250) NOT NULL,
	[Fecha_Alta] [datetime] NULL,
	[Fecha_Baja] [datetime] NULL,
	[Id_Localidad] [int] NULL,
 CONSTRAINT [Clientes_Id_Cliente_PK] PRIMARY KEY CLUSTERED 
(
	[Id_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 12/11/2022 19:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[Id_Cuenta] [int] IDENTITY(1,1) NOT NULL,
	[Cvu] [int] NOT NULL,
	[Saldo] [int] NOT NULL,
	[Esta_Habilitada] [bit] NOT NULL,
	[Fecha_Alta] [datetime] NULL,
	[Fecha_Baja] [datetime] NULL,
	[Id_Cliente] [int] NULL,
	[Id_Moneda] [int] NULL,
 CONSTRAINT [Cuentas_Id_Cuenta_PK] PRIMARY KEY CLUSTERED 
(
	[Id_Cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 12/11/2022 19:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Localidades](
	[Id_Localidad] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Fecha_Alta] [datetime] NULL,
	[Fecha_Baja] [datetime] NULL,
	[Id_Provincia] [int] NULL,
 CONSTRAINT [Localidades_Id_Localidad_PK] PRIMARY KEY CLUSTERED 
(
	[Id_Localidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Monedas]    Script Date: 12/11/2022 19:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Monedas](
	[Id_Moneda] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Fecha_Alta] [datetime] NULL,
	[Fecha_Baja] [datetime] NULL,
 CONSTRAINT [Monedas_Id_Moneda_PK] PRIMARY KEY CLUSTERED 
(
	[Id_Moneda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Operaciones_deposito_o_extraccion]    Script Date: 12/11/2022 19:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operaciones_deposito_o_extraccion](
	[Id_Operacion] [int] IDENTITY(1,1) NOT NULL,
	[Es_Deposito] [bit] NOT NULL,
	[Fecha] [datetime] NULL,
	[Monto] [int] NOT NULL,
	[Fecha_Baja] [datetime] NULL,
	[Id_Cuenta] [int] NULL,
 CONSTRAINT [Operaciones_Id_Operacion_PK] PRIMARY KEY CLUSTERED 
(
	[Id_Operacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 12/11/2022 19:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Provincias](
	[Id_Provincia] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Fecha_Alta] [datetime] NULL,
	[Fecha_Baja] [datetime] NULL,
 CONSTRAINT [Provincias_Id_Provincia_PK] PRIMARY KEY CLUSTERED 
(
	[Id_Provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([Id_Cliente], [Nombre], [Apellido], [Cuil], [Fecha_Nacimiento], [Usuario], [Contrasenia], [Fecha_Alta], [Fecha_Baja], [Id_Localidad]) VALUES (1, N'Juan', N'Perez', N'20-34567847-4', CAST(N'1991-03-03' AS Date), N'juan@gmail.com', N'agB1AGEAbgAxADIAMwA0AA==', CAST(N'2022-11-10 17:23:00.380' AS DateTime), NULL, 1)
INSERT [dbo].[Clientes] ([Id_Cliente], [Nombre], [Apellido], [Cuil], [Fecha_Nacimiento], [Usuario], [Contrasenia], [Fecha_Alta], [Fecha_Baja], [Id_Localidad]) VALUES (2, N'Maria', N'Gonzalez', N'27-49562841-2', CAST(N'1998-09-05' AS Date), N'maria@gmail.com', N'bQBhAHIAaQBhADEAMgAzAA==', CAST(N'2022-11-10 17:23:00.380' AS DateTime), NULL, 2)
INSERT [dbo].[Clientes] ([Id_Cliente], [Nombre], [Apellido], [Cuil], [Fecha_Nacimiento], [Usuario], [Contrasenia], [Fecha_Alta], [Fecha_Baja], [Id_Localidad]) VALUES (3, N'Pablo', N'Rodriguez', N'20-35567843-4', CAST(N'1993-05-09' AS Date), N'pablo@gmail.com', N'cABhAGIAbABvADEAMgAzAA==', CAST(N'2022-11-10 17:23:00.387' AS DateTime), NULL, 3)
INSERT [dbo].[Clientes] ([Id_Cliente], [Nombre], [Apellido], [Cuil], [Fecha_Nacimiento], [Usuario], [Contrasenia], [Fecha_Alta], [Fecha_Baja], [Id_Localidad]) VALUES (4, N'Ana', N'Gutierrez', N'27-48562848-2', CAST(N'1997-11-18' AS Date), N'ana@gmail.com', N'YQBuAGEAMQAyADMANAA1AA==', CAST(N'2022-11-10 17:23:00.390' AS DateTime), NULL, 4)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
SET IDENTITY_INSERT [dbo].[Cuentas] ON 

INSERT [dbo].[Cuentas] ([Id_Cuenta], [Cvu], [Saldo], [Esta_Habilitada], [Fecha_Alta], [Fecha_Baja], [Id_Cliente], [Id_Moneda]) VALUES (1, 94346174, 55000, 1, CAST(N'2022-11-10 17:25:07.123' AS DateTime), NULL, 1, 1)
INSERT [dbo].[Cuentas] ([Id_Cuenta], [Cvu], [Saldo], [Esta_Habilitada], [Fecha_Alta], [Fecha_Baja], [Id_Cliente], [Id_Moneda]) VALUES (2, 95241361, 60000, 1, CAST(N'2022-11-10 17:25:07.123' AS DateTime), NULL, 2, 2)
INSERT [dbo].[Cuentas] ([Id_Cuenta], [Cvu], [Saldo], [Esta_Habilitada], [Fecha_Alta], [Fecha_Baja], [Id_Cliente], [Id_Moneda]) VALUES (3, 87547242, 75000, 1, CAST(N'2022-11-10 17:25:07.123' AS DateTime), NULL, 3, 1)
INSERT [dbo].[Cuentas] ([Id_Cuenta], [Cvu], [Saldo], [Esta_Habilitada], [Fecha_Alta], [Fecha_Baja], [Id_Cliente], [Id_Moneda]) VALUES (4, 83646523, 80000, 1, CAST(N'2022-11-10 17:25:07.127' AS DateTime), NULL, 4, 2)
INSERT [dbo].[Cuentas] ([Id_Cuenta], [Cvu], [Saldo], [Esta_Habilitada], [Fecha_Alta], [Fecha_Baja], [Id_Cliente], [Id_Moneda]) VALUES (5, 83619475, 90000, 1, CAST(N'2022-11-10 17:25:07.127' AS DateTime), NULL, 4, 1)
SET IDENTITY_INSERT [dbo].[Cuentas] OFF
SET IDENTITY_INSERT [dbo].[Localidades] ON 

INSERT [dbo].[Localidades] ([Id_Localidad], [Nombre], [Fecha_Alta], [Fecha_Baja], [Id_Provincia]) VALUES (1, N'Alta Gracia', CAST(N'2022-11-10 17:21:05.267' AS DateTime), NULL, 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [Nombre], [Fecha_Alta], [Fecha_Baja], [Id_Provincia]) VALUES (2, N'Capilla del Monte', CAST(N'2022-11-10 17:21:05.270' AS DateTime), NULL, 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [Nombre], [Fecha_Alta], [Fecha_Baja], [Id_Provincia]) VALUES (3, N'Colonia Caroya', CAST(N'2022-11-10 17:21:05.270' AS DateTime), NULL, 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [Nombre], [Fecha_Alta], [Fecha_Baja], [Id_Provincia]) VALUES (4, N'Cosquin', CAST(N'2022-11-10 17:21:05.270' AS DateTime), NULL, 1)
INSERT [dbo].[Localidades] ([Id_Localidad], [Nombre], [Fecha_Alta], [Fecha_Baja], [Id_Provincia]) VALUES (5, N'Chamical', CAST(N'2022-11-10 17:21:05.270' AS DateTime), NULL, 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [Nombre], [Fecha_Alta], [Fecha_Baja], [Id_Provincia]) VALUES (6, N'Sanagasta', CAST(N'2022-11-10 17:21:05.270' AS DateTime), NULL, 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [Nombre], [Fecha_Alta], [Fecha_Baja], [Id_Provincia]) VALUES (7, N'Anillaco', CAST(N'2022-11-10 17:21:05.270' AS DateTime), NULL, 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [Nombre], [Fecha_Alta], [Fecha_Baja], [Id_Provincia]) VALUES (8, N'Villa Union', CAST(N'2022-11-10 17:21:05.273' AS DateTime), NULL, 2)
INSERT [dbo].[Localidades] ([Id_Localidad], [Nombre], [Fecha_Alta], [Fecha_Baja], [Id_Provincia]) VALUES (9, N'Tinogasta', CAST(N'2022-11-10 17:21:05.273' AS DateTime), NULL, 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [Nombre], [Fecha_Alta], [Fecha_Baja], [Id_Provincia]) VALUES (10, N'Recreo', CAST(N'2022-11-10 17:21:05.273' AS DateTime), NULL, 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [Nombre], [Fecha_Alta], [Fecha_Baja], [Id_Provincia]) VALUES (11, N'Fiambala', CAST(N'2022-11-10 17:21:05.273' AS DateTime), NULL, 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [Nombre], [Fecha_Alta], [Fecha_Baja], [Id_Provincia]) VALUES (12, N'Saujil', CAST(N'2022-11-10 17:21:05.273' AS DateTime), NULL, 3)
INSERT [dbo].[Localidades] ([Id_Localidad], [Nombre], [Fecha_Alta], [Fecha_Baja], [Id_Provincia]) VALUES (13, N'Valle Fertil', CAST(N'2022-11-10 17:21:05.273' AS DateTime), NULL, 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [Nombre], [Fecha_Alta], [Fecha_Baja], [Id_Provincia]) VALUES (14, N'Barreal', CAST(N'2022-11-10 17:21:05.273' AS DateTime), NULL, 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [Nombre], [Fecha_Alta], [Fecha_Baja], [Id_Provincia]) VALUES (15, N'Caucete', CAST(N'2022-11-10 17:21:05.277' AS DateTime), NULL, 4)
INSERT [dbo].[Localidades] ([Id_Localidad], [Nombre], [Fecha_Alta], [Fecha_Baja], [Id_Provincia]) VALUES (16, N'Jachal', CAST(N'2022-11-10 17:21:05.277' AS DateTime), NULL, 4)
SET IDENTITY_INSERT [dbo].[Localidades] OFF
SET IDENTITY_INSERT [dbo].[Monedas] ON 

INSERT [dbo].[Monedas] ([Id_Moneda], [Nombre], [Fecha_Alta], [Fecha_Baja]) VALUES (1, N'Peso', CAST(N'2022-11-10 17:24:39.400' AS DateTime), NULL)
INSERT [dbo].[Monedas] ([Id_Moneda], [Nombre], [Fecha_Alta], [Fecha_Baja]) VALUES (2, N'Bitcoin', CAST(N'2022-11-10 17:24:39.400' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Monedas] OFF
SET IDENTITY_INSERT [dbo].[Operaciones_deposito_o_extraccion] ON 

INSERT [dbo].[Operaciones_deposito_o_extraccion] ([Id_Operacion], [Es_Deposito], [Fecha], [Monto], [Fecha_Baja], [Id_Cuenta]) VALUES (1, 1, CAST(N'2022-11-10 17:25:36.670' AS DateTime), 2000, NULL, 2)
INSERT [dbo].[Operaciones_deposito_o_extraccion] ([Id_Operacion], [Es_Deposito], [Fecha], [Monto], [Fecha_Baja], [Id_Cuenta]) VALUES (2, 0, CAST(N'2022-11-10 17:25:36.673' AS DateTime), 3000, NULL, 4)
INSERT [dbo].[Operaciones_deposito_o_extraccion] ([Id_Operacion], [Es_Deposito], [Fecha], [Monto], [Fecha_Baja], [Id_Cuenta]) VALUES (3, 1, CAST(N'2022-11-10 17:25:36.673' AS DateTime), 3500, NULL, 1)
INSERT [dbo].[Operaciones_deposito_o_extraccion] ([Id_Operacion], [Es_Deposito], [Fecha], [Monto], [Fecha_Baja], [Id_Cuenta]) VALUES (4, 0, CAST(N'2022-11-10 17:25:36.673' AS DateTime), 4000, NULL, 3)
INSERT [dbo].[Operaciones_deposito_o_extraccion] ([Id_Operacion], [Es_Deposito], [Fecha], [Monto], [Fecha_Baja], [Id_Cuenta]) VALUES (5, 0, CAST(N'2022-11-10 17:25:36.673' AS DateTime), 2500, NULL, 3)
SET IDENTITY_INSERT [dbo].[Operaciones_deposito_o_extraccion] OFF
SET IDENTITY_INSERT [dbo].[Provincias] ON 

INSERT [dbo].[Provincias] ([Id_Provincia], [Nombre], [Fecha_Alta], [Fecha_Baja]) VALUES (1, N'Cordoba', CAST(N'2022-11-10 17:17:03.503' AS DateTime), NULL)
INSERT [dbo].[Provincias] ([Id_Provincia], [Nombre], [Fecha_Alta], [Fecha_Baja]) VALUES (2, N'La Rioja', CAST(N'2022-11-10 17:17:03.507' AS DateTime), NULL)
INSERT [dbo].[Provincias] ([Id_Provincia], [Nombre], [Fecha_Alta], [Fecha_Baja]) VALUES (3, N'Catamarca', CAST(N'2022-11-10 17:17:03.507' AS DateTime), NULL)
INSERT [dbo].[Provincias] ([Id_Provincia], [Nombre], [Fecha_Alta], [Fecha_Baja]) VALUES (4, N'San Juan', CAST(N'2022-11-10 17:17:03.507' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Provincias] OFF
/****** Object:  Index [Cuentas_Cvu_UK]    Script Date: 12/11/2022 19:37:31 ******/
ALTER TABLE [dbo].[Cuentas] ADD  CONSTRAINT [Cuentas_Cvu_UK] UNIQUE NONCLUSTERED 
(
	[Cvu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clientes] ADD  DEFAULT (getdate()) FOR [Fecha_Alta]
GO
ALTER TABLE [dbo].[Cuentas] ADD  DEFAULT (getdate()) FOR [Fecha_Alta]
GO
ALTER TABLE [dbo].[Localidades] ADD  DEFAULT (getdate()) FOR [Fecha_Alta]
GO
ALTER TABLE [dbo].[Monedas] ADD  DEFAULT (getdate()) FOR [Fecha_Alta]
GO
ALTER TABLE [dbo].[Operaciones_deposito_o_extraccion] ADD  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[Provincias] ADD  DEFAULT (getdate()) FOR [Fecha_Alta]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [Clientes_Id_Localidad_FK] FOREIGN KEY([Id_Localidad])
REFERENCES [dbo].[Localidades] ([Id_Localidad])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [Clientes_Id_Localidad_FK]
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [Cuentas_Id_Cliente_FK] FOREIGN KEY([Id_Cliente])
REFERENCES [dbo].[Clientes] ([Id_Cliente])
GO
ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [Cuentas_Id_Cliente_FK]
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [Cuentas_Id_Moneda_FK] FOREIGN KEY([Id_Moneda])
REFERENCES [dbo].[Monedas] ([Id_Moneda])
GO
ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [Cuentas_Id_Moneda_FK]
GO
ALTER TABLE [dbo].[Localidades]  WITH CHECK ADD  CONSTRAINT [Localidades_Id_Provincia_FK] FOREIGN KEY([Id_Provincia])
REFERENCES [dbo].[Provincias] ([Id_Provincia])
GO
ALTER TABLE [dbo].[Localidades] CHECK CONSTRAINT [Localidades_Id_Provincia_FK]
GO
ALTER TABLE [dbo].[Operaciones_deposito_o_extraccion]  WITH CHECK ADD  CONSTRAINT [Operaciones_Id_Cuenta_FK] FOREIGN KEY([Id_Cuenta])
REFERENCES [dbo].[Cuentas] ([Id_Cuenta])
GO
ALTER TABLE [dbo].[Operaciones_deposito_o_extraccion] CHECK CONSTRAINT [Operaciones_Id_Cuenta_FK]
GO
USE [master]
GO
ALTER DATABASE [Billetera] SET  READ_WRITE 
GO
