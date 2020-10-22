USE [master]
GO
/****** Object:  Database [PW3_TP_20202C]    Script Date: 22/10/2020 11:28:30 ******/
CREATE DATABASE [PW3_TP_20202CGALLO]
 GO
USE [PW3_TP_20202CGALLO]
GO
/****** Object:  Table [dbo].[Consorcio]    Script Date: 22/10/2020 11:28:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consorcio](
	[IdConsorcio] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[IdProvincia] [int] NOT NULL,
	[Ciudad] [nvarchar](200) NOT NULL,
	[Calle] [nvarchar](200) NOT NULL,
	[Altura] [int] NOT NULL,
	[DiaVencimientoExpensas] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[IdUsuarioCreador] [int] NULL,
 CONSTRAINT [PK_Consorcio] PRIMARY KEY CLUSTERED 
(
	[IdConsorcio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gasto]    Script Date: 22/10/2020 11:28:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gasto](
	[IdGasto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[IdConsorcio] [int] NOT NULL,
	[IdTipoGasto] [int] NOT NULL,
	[FechaGasto] [datetime] NOT NULL,
	[AnioExpensa] [int] NOT NULL,
	[MesExpensa] [int] NOT NULL,
	[ArchivoComprobante] [nvarchar](500) NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[IdUsuarioCreador] [int] NOT NULL,
 CONSTRAINT [PK_Gasto] PRIMARY KEY CLUSTERED 
(
	[IdGasto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 22/10/2020 11:28:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[IdProvincia] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Provincia] PRIMARY KEY CLUSTERED 
(
	[IdProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoGasto]    Script Date: 22/10/2020 11:28:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoGasto](
	[IdTipoGasto] [int] NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_TipoGasto] PRIMARY KEY CLUSTERED 
(
	[IdTipoGasto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unidad]    Script Date: 22/10/2020 11:28:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unidad](
	[IdUnidad] [int] IDENTITY(1,1) NOT NULL,
	[IdConsorcio] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[NombrePropietario] [nvarchar](200) NULL,
	[ApellidoPropietario] [nvarchar](200) NULL,
	[EmailPropietario] [nvarchar](500) NULL,
	[Superficie] [int] NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[IdUsuarioCreador] [int] NOT NULL,
 CONSTRAINT [PK_Unidad] PRIMARY KEY CLUSTERED 
(
	[IdUnidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 22/10/2020 11:28:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](80) NOT NULL,
	[Email] [nvarchar](300) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FechaRegistracion] [datetime] NOT NULL,
	[FechaUltLogin] [datetime] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Consorcio] ON 
GO
INSERT [dbo].[Consorcio] ([IdConsorcio], [Nombre], [IdProvincia], [Ciudad], [Calle], [Altura], [DiaVencimientoExpensas], [FechaCreacion], [IdUsuarioCreador]) VALUES (1, N'Edificio Godoy Cruz', 2, N'CABA', N'Godoy Cruz', 2369, 6, CAST(N'2020-09-29T22:50:00.837' AS DateTime), NULL)
GO
INSERT [dbo].[Consorcio] ([IdConsorcio], [Nombre], [IdProvincia], [Ciudad], [Calle], [Altura], [DiaVencimientoExpensas], [FechaCreacion], [IdUsuarioCreador]) VALUES (2, N'Edificio Arieta', 1, N'San Justo', N'Arieta', 2748, 12, CAST(N'2020-09-29T22:50:48.663' AS DateTime), NULL)
GO
INSERT [dbo].[Consorcio] ([IdConsorcio], [Nombre], [IdProvincia], [Ciudad], [Calle], [Altura], [DiaVencimientoExpensas], [FechaCreacion], [IdUsuarioCreador]) VALUES (3, N'Edificio Alberdi', 2, N'CABA', N'Alberdi', 2387, 1, CAST(N'2020-09-29T22:51:37.607' AS DateTime), NULL)
GO
INSERT [dbo].[Consorcio] ([IdConsorcio], [Nombre], [IdProvincia], [Ciudad], [Calle], [Altura], [DiaVencimientoExpensas], [FechaCreacion], [IdUsuarioCreador]) VALUES (4, N'Torres Florencia', 1, N'Ramos Mejia', N'Dr. Gabriel Ardoino', 364, 5, CAST(N'2020-09-29T22:51:56.580' AS DateTime), NULL)
GO
INSERT [dbo].[Consorcio] ([IdConsorcio], [Nombre], [IdProvincia], [Ciudad], [Calle], [Altura], [DiaVencimientoExpensas], [FechaCreacion], [IdUsuarioCreador]) VALUES (5, N'Vilanova', 1, N'Ramos Mejia', N'Tacuari', 620, 21, CAST(N'2020-09-29T22:53:31.700' AS DateTime), NULL)
GO
INSERT [dbo].[Consorcio] ([IdConsorcio], [Nombre], [IdProvincia], [Ciudad], [Calle], [Altura], [DiaVencimientoExpensas], [FechaCreacion], [IdUsuarioCreador]) VALUES (6, N'Altos de Gandara', 1, N'Haedo', N'Juez de la Gandara', 851, 2, CAST(N'2020-09-29T22:58:32.020' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Consorcio] OFF
GO
SET IDENTITY_INSERT [dbo].[Gasto] ON 
GO
INSERT [dbo].[Gasto] ([IdGasto], [Nombre], [Descripcion], [IdConsorcio], [IdTipoGasto], [FechaGasto], [AnioExpensa], [MesExpensa], [ArchivoComprobante], [Monto], [FechaCreacion], [IdUsuarioCreador]) VALUES (1, N'Fumigacion de Unidades', N'Se fumigaron todas las unidades excepto la unidad 10 y 12', 1, 5, CAST(N'2020-08-12T00:00:00.000' AS DateTime), 2020, 8, N'/Gastos/fumigacion-20200812.pdf', CAST(25000.00 AS Decimal(18, 2)), CAST(N'2020-08-13T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Gasto] ([IdGasto], [Nombre], [Descripcion], [IdConsorcio], [IdTipoGasto], [FechaGasto], [AnioExpensa], [MesExpensa], [ArchivoComprobante], [Monto], [FechaCreacion], [IdUsuarioCreador]) VALUES (2, N'Restauracion SUM', NULL, 1, 5, CAST(N'2020-08-22T00:00:00.000' AS DateTime), 2020, 8, N'/Gastos/Sum08.pdf', CAST(125000.00 AS Decimal(18, 2)), CAST(N'2020-08-23T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Gasto] ([IdGasto], [Nombre], [Descripcion], [IdConsorcio], [IdTipoGasto], [FechaGasto], [AnioExpensa], [MesExpensa], [ArchivoComprobante], [Monto], [FechaCreacion], [IdUsuarioCreador]) VALUES (3, N'Compra productos de limpieza', N'Detalle:
1. Balde de 12 litros
2. Pala Cepillo VP2
3. Escoba topacio con cabo
4. Secador de piso con cabo art 1125
5. Cepillo Multiuso Mathilde
6. Secador Multiuso
7. Escobillon Diamante V2 Diamante', 1, 7, CAST(N'2020-09-02T00:00:00.000' AS DateTime), 2020, 9, N'/Gastos/Limpieza-2020-09-02.pdf', CAST(40000.00 AS Decimal(18, 2)), CAST(N'2020-09-02T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Gasto] ([IdGasto], [Nombre], [Descripcion], [IdConsorcio], [IdTipoGasto], [FechaGasto], [AnioExpensa], [MesExpensa], [ArchivoComprobante], [Monto], [FechaCreacion], [IdUsuarioCreador]) VALUES (4, N'Reparacion humeadad unidad 1A', N'Habia manchas en el techo, se impermiabilizo y se volvio a pintar', 1, 6, CAST(N'2020-09-12T00:00:00.000' AS DateTime), 2020, 9, N'/Gastos/Reparacion-2020-09-12.pdf', CAST(30000.00 AS Decimal(18, 2)), CAST(N'2020-09-12T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Gasto] ([IdGasto], [Nombre], [Descripcion], [IdConsorcio], [IdTipoGasto], [FechaGasto], [AnioExpensa], [MesExpensa], [ArchivoComprobante], [Monto], [FechaCreacion], [IdUsuarioCreador]) VALUES (5, N'Fumigacion de Unidades', N'Se fumigaron todas las unidades', 1, 5, CAST(N'2020-09-20T00:00:00.000' AS DateTime), 2020, 9, N'/Gastos/fumigacion-2020-09-20.pdf', CAST(25000.00 AS Decimal(18, 2)), CAST(N'2020-09-28T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Gasto] ([IdGasto], [Nombre], [Descripcion], [IdConsorcio], [IdTipoGasto], [FechaGasto], [AnioExpensa], [MesExpensa], [ArchivoComprobante], [Monto], [FechaCreacion], [IdUsuarioCreador]) VALUES (6, N'Sueldos Agosto', N'Se abonaron los sueldos de los 3 encargados', 1, 1, CAST(N'2020-08-30T00:00:00.000' AS DateTime), 2020, 8, N'/Gastos/liquidacion-sueldos-2020-08.pdf', CAST(150000.00 AS Decimal(18, 2)), CAST(N'2020-09-01T00:00:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Gasto] OFF
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (1, N'Buenos Aires')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (2, N'CABA')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (3, N'Catamarca')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (4, N'Chaco')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (5, N'Chubut')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (6, N'Córdoba')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (7, N'Corrientes')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (8, N'Entre Ríos')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (9, N'Formosa')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (10, N'Jujuy')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (11, N'La Pampa')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (12, N'La Rioja')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (13, N'Mendoza')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (14, N'Misiones')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (15, N'Neuquén')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (16, N'Río Negro')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (17, N'Salta')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (18, N'San Juan')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (19, N'San Luis')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (20, N'Santa Cruz')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (21, N'Santa Fe')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (22, N'Santiago del Estero')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (23, N'Tierra del Fuego')
GO
INSERT [dbo].[Provincia] ([IdProvincia], [Nombre]) VALUES (24, N'Tucumán')
GO
INSERT [dbo].[TipoGasto] ([IdTipoGasto], [Nombre]) VALUES (1, N'Sueldos')
GO
INSERT [dbo].[TipoGasto] ([IdTipoGasto], [Nombre]) VALUES (2, N'Servicios')
GO
INSERT [dbo].[TipoGasto] ([IdTipoGasto], [Nombre]) VALUES (3, N'Cargas Sociales')
GO
INSERT [dbo].[TipoGasto] ([IdTipoGasto], [Nombre]) VALUES (4, N'Seguros')
GO
INSERT [dbo].[TipoGasto] ([IdTipoGasto], [Nombre]) VALUES (5, N'Mantenimiento Gral')
GO
INSERT [dbo].[TipoGasto] ([IdTipoGasto], [Nombre]) VALUES (6, N'Reparacion Unidad')
GO
INSERT [dbo].[TipoGasto] ([IdTipoGasto], [Nombre]) VALUES (7, N'Compras Limpieza')
GO
INSERT [dbo].[TipoGasto] ([IdTipoGasto], [Nombre]) VALUES (8, N'Extraordinario')
GO
SET IDENTITY_INSERT [dbo].[Unidad] ON 
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (1, 1, N'1A', N'Pepe', N'Argento', N'pepeargento@test.com', NULL, CAST(N'2020-09-29T23:36:43.727' AS DateTime), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (2, 1, N'1B', N'Dardo', N'Fuseneco', N'dardo@test.com', NULL, CAST(N'2020-09-29T23:37:11.970' AS DateTime), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (4, 1, N'1C', N'Fatiga', N'Argento', N'fatiga@test.com', NULL, CAST(N'2020-09-29T23:37:40.170' AS DateTime), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (5, 1, N'2A', N'Edna', N'Krabappel', N'edna@test.com', NULL, CAST(N'2020-09-29T23:38:10.270' AS DateTime), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (7, 1, N'2B', N'Ned', N'Flanders', N'neddy@test.com', NULL, CAST(N'2020-09-29T23:40:15.133' AS DateTime), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (8, 1, N'2C', N'Moe', N'Szyslak', N'moe@test.com', NULL, CAST(N'2020-09-29T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (9, 1, N'3A', N'Franco', N'Milazzo', N'franco@test.com', NULL, CAST(N'2020-09-29T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (10, 1, N'3B', N'Emilio', N'Ravenna', N'ravenna@test.com', NULL, CAST(N'2020-09-29T23:42:25.980' AS DateTime), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (11, 1, N'3C', N'Gabriel', N'Medina', N'gmedina@test.com', NULL, CAST(N'2020-09-29T23:42:50.507' AS DateTime), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (12, 1, N'4A', N'Jack', N'Shepard', N'jackperdido@test.com', NULL, CAST(N'2020-09-29T23:43:41.887' AS DateTime), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (13, 1, N'4B', N'Desmond', N'Hume', N'desmond@test.com', NULL, CAST(N'2020-09-29T23:44:27.130' AS DateTime), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (14, 1, N'4C', N'Kate', N'Austen', N'kate@test.com', NULL, CAST(N'2020-09-29T23:45:21.017' AS DateTime), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (15, 2, N'1A', N'Michael', N'Scofield', N'michael@test.com', NULL, CAST(N'2020-09-29T23:46:12.093' AS DateTime), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (16, 2, N'1B', N'T', N'Bag', N'tbag@test.com', NULL, CAST(N'2020-09-29T23:46:25.593' AS DateTime), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (17, 2, N'1C', N'Sara', N'Tancredi', N'sara@test.com', NULL, CAST(N'2020-09-29T23:47:03.817' AS DateTime), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (19, 3, N'Unidad 1', N'Tokio', NULL, N'tokio@test.com', NULL, CAST(N'2020-09-29T23:47:53.770' AS DateTime), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (20, 3, N'Unidad 2', N'Berlin', NULL, N'berlin@test.com', NULL, CAST(N'2020-09-29T23:48:07.327' AS DateTime), 1)
GO
INSERT [dbo].[Unidad] ([IdUnidad], [IdConsorcio], [Nombre], [NombrePropietario], [ApellidoPropietario], [EmailPropietario], [Superficie], [FechaCreacion], [IdUsuarioCreador]) VALUES (21, 3, N'Unidad 3', N'Denver', NULL, N'denver@test.com', NULL, CAST(N'2020-09-29T23:48:26.127' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Unidad] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([IdUsuario], [Nombre], [Email], [Password], [FechaRegistracion], [FechaUltLogin]) VALUES (1, N'Pablo                                                                           ', N'pnsanchez@unlam.edu.ar', N'Test1234!', CAST(N'2020-09-29T22:45:36.567' AS DateTime), CAST(N'2020-09-29T22:05:36.567' AS DateTime))
GO
INSERT [dbo].[Usuario] ([IdUsuario], [Nombre], [Email], [Password], [FechaRegistracion], [FechaUltLogin]) VALUES (2, N'Matias                                                                          ', N'mpaz@unlam.edu.ar', N'Test1234!', CAST(N'2020-09-29T22:45:36.567' AS DateTime), CAST(N'2020-09-29T22:55:36.567' AS DateTime))
GO
INSERT [dbo].[Usuario] ([IdUsuario], [Nombre], [Email], [Password], [FechaRegistracion], [FechaUltLogin]) VALUES (3, N'Mariano                                                                         ', N'mjuiz@unlam.edu.ar', N'Test1234!', CAST(N'2020-09-29T22:45:36.567' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Consorcio] ADD  CONSTRAINT [DF_Consorcio_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Gasto] ADD  CONSTRAINT [DF_Gasto_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Unidad] ADD  CONSTRAINT [DF_Unidad_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_FechaRegistracion]  DEFAULT (getdate()) FOR [FechaRegistracion]
GO
ALTER TABLE [dbo].[Consorcio]  WITH CHECK ADD  CONSTRAINT [FK_Consorcio_Consorcio] FOREIGN KEY([IdProvincia])
REFERENCES [dbo].[Provincia] ([IdProvincia])
GO
ALTER TABLE [dbo].[Consorcio] CHECK CONSTRAINT [FK_Consorcio_Consorcio]
GO
ALTER TABLE [dbo].[Consorcio]  WITH CHECK ADD  CONSTRAINT [FK_Consorcio_Usuario] FOREIGN KEY([IdUsuarioCreador])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Consorcio] CHECK CONSTRAINT [FK_Consorcio_Usuario]
GO
ALTER TABLE [dbo].[Gasto]  WITH CHECK ADD  CONSTRAINT [FK_Gasto_Consorcio] FOREIGN KEY([IdConsorcio])
REFERENCES [dbo].[Consorcio] ([IdConsorcio])
GO
ALTER TABLE [dbo].[Gasto] CHECK CONSTRAINT [FK_Gasto_Consorcio]
GO
ALTER TABLE [dbo].[Gasto]  WITH CHECK ADD  CONSTRAINT [FK_Gasto_TipoGasto] FOREIGN KEY([IdTipoGasto])
REFERENCES [dbo].[TipoGasto] ([IdTipoGasto])
GO
ALTER TABLE [dbo].[Gasto] CHECK CONSTRAINT [FK_Gasto_TipoGasto]
GO
ALTER TABLE [dbo].[Gasto]  WITH CHECK ADD  CONSTRAINT [FK_Gasto_Usuario] FOREIGN KEY([IdUsuarioCreador])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Gasto] CHECK CONSTRAINT [FK_Gasto_Usuario]
GO
ALTER TABLE [dbo].[Unidad]  WITH CHECK ADD  CONSTRAINT [FK_Unidad_Consorcio] FOREIGN KEY([IdConsorcio])
REFERENCES [dbo].[Consorcio] ([IdConsorcio])
GO
ALTER TABLE [dbo].[Unidad] CHECK CONSTRAINT [FK_Unidad_Consorcio]
GO
ALTER TABLE [dbo].[Unidad]  WITH CHECK ADD  CONSTRAINT [FK_Unidad_Usuario] FOREIGN KEY([IdUsuarioCreador])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Unidad] CHECK CONSTRAINT [FK_Unidad_Usuario]
GO
USE [master]
GO
ALTER DATABASE [PW3_TP_20202C] SET  READ_WRITE 
GO
