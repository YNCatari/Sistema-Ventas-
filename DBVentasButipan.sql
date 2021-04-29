CREATE DATABASE DBVentas
go
USE [DBVentas]
GO

/*TABLA BOLETA*/
CREATE TABLE tbBoleta
(
	[Serie] [varchar](3) NOT NULL,
	[Numero] [varchar](6) NOT NULL,
	[Fecha] [varchar](10) NULL,
	[Total] [decimal](18, 2) NULL,
	[Estado] [varchar](5) NULL,
	[FRuc] [varchar](11) NULL,
	[FDniCliente] [varchar](8) NULL,
	[FCodigoEmpleado] [nvarchar](8) NULL
)
/*Agregando Llaves Primarias*/
alter table tbBoleta
alter column Serie varchar(3) not null
GO
alter table tbBoleta
alter column Numero varchar(6) not null
GO
alter table tbBoleta
add primary key (Serie, Numero)
GO

/*TABLA DETALLE*/
CREATE TABLE tbDetalle
(
	[IDDetalle] [int] IDENTITY(1,1) NOT NULL,
	[Serie] [varchar](3) NULL,
	[Numero] [varchar](6) NULL,
	[CantCompra] [int] NULL,
	[Importe] [decimal](18, 2) NULL,
	[FCodProducto] [nvarchar](6) NULL,
)
GO
/*TABLA CARGO*/
CREATE TABLE tbCargo
(
	[idCargo] [nvarchar](10) PRIMARY KEY NOT NULL,
	[Descripcion] [varchar](50) NOT NULL
)
GO

/*TABLA CLIENTE*/
CREATE TABLE tbCliente
(
	[Dni] [varchar](8) PRIMARY KEY NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Telefono] [varchar](18) NOT NULL,
	[Email] [varchar](max) NULL
)
GO

/*TABLA EMPLEADO*/
CREATE TABLE tbEmpleado
(
	[Codigo] [nvarchar](8) PRIMARY KEY NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Direccion] [varchar](150) NULL,
	[Email] [varchar](max) NULL,
	[Cargo] [nvarchar](10) NOT NULL,
	[Clave] [nvarchar](6) NOT NULL,
	[Estado] [nvarchar](5) NOT NULL
)
GO

/*TABLA PROVEEDOR*/
CREATE TABLE tbProveedor
(
	[Codigo] [nvarchar](8) PRIMARY KEY NOT NULL,
	[Ruc] [nvarchar](11) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Rubro] [varchar](50) NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Telefono] [varchar](18) NOT NULL,
	[Estado] [nvarchar](5) NOT NULL
)
GO

/*TABLA PRODUCTO*/
CREATE TABLE tbProducto
(
	[Codigo] [nvarchar](6) PRIMARY KEY NOT NULL,
	[Descripcion] [varchar](250) NOT NULL,
	[Cantidad] [nvarchar](3) NOT NULL,
	[PrecioUnitario] [numeric](6, 2) NOT NULL,
	[FCodProveedor] [nvarchar](8) NOT NULL
)
GO

/*TABLA INVENTARIO*/
CREATE TABLE tbInventario
(
	[Codigo] [nvarchar](6) PRIMARY KEY NOT NULL,
	[Descripcion] [varchar](250) NULL,
	[Cantidad] [nvarchar](3) NOT NULL,
	[PrecioUnitario] [decimal](6, 2) NOT NULL,
	[Condicion] [varchar](12) NOT NULL,
	[FCodProducto] [nvarchar](6) NOT NULL,
	[FCodProveedor] [nvarchar](8) NOT NULL
)
GO

CREATE TABLE [dbo].[tbEmpresa]
(
	[Ruc] [varchar](11) PRIMARY KEY NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Direccion] [varchar](max) NULL,
	[Telefono] [varchar](11) NULL
)
GO

/*TABLA PEDIDO*/
CREATE TABLE tbPedido
(
	[Codigo] [nvarchar](6) PRIMARY KEY NOT NULL,
	[Fecha] [varchar](10) NOT NULL,
	[Descripcion] [varchar](250) NOT NULL,
	[Total] [decimal](18, 2) NULL,
	[FDniCliente] [varchar](8) NOT NULL,
	[FCodEmpleado] [nvarchar](8) NOT NULL,
	[Estado] [varchar](12) NULL
)
GO








/*INSERTAR DATOS*/
INSERT [dbo].[tbCargo] ([idCargo], [Descripcion]) VALUES (N'1', N'Administador')
INSERT [dbo].[tbCargo] ([idCargo], [Descripcion]) VALUES (N'2', N'Cajero')
INSERT [dbo].[tbCargo] ([idCargo], [Descripcion]) VALUES (N'3', N'Almacen')

INSERT [dbo].[tbCliente] ([Dni], [Nombre], [Apellido], [Telefono], [Email]) VALUES (N'00000001', N'Ricardo Ernesto', N' Conde de las Casas',  N' 412054', 'ricardito@hotmail.com')
INSERT [dbo].[tbCliente] ([Dni], [Nombre], [Apellido], [Telefono], [Email]) VALUES (N'00000002', N'Francisco Ernesto', N'Pizarro Arias', N' 400054', N'piza@gmail.com')
INSERT [dbo].[tbCliente] ([Dni], [Nombre], [Apellido], [Telefono], [Email]) VALUES (N'00000003', N'Maria Rosa', N'Guadalupe Nina', N' 411100', N'maro@yahoo.com')

INSERT [dbo].[tbEmpleado] ([Codigo], [Nombre], [Apellido], [Direccion], [Email], [Cargo], [Clave], [Estado]) VALUES (N'10000001', N'Juan', N'Rodriguez Mamani', N'Calle Arica nro 1542', N'juan@hotmail.com', N'1', N'000001', N'TRUE')
INSERT [dbo].[tbEmpleado] ([Codigo], [Nombre], [Apellido], [Direccion], [Email], [Cargo], [Clave], [Estado]) VALUES (N'10000002', N'Yofer', N'Catari Cabrera', N'Av. Leguia 4511', N'yofer@gmail.com', N'2', N'000002', N'TRUE')
INSERT [dbo].[tbEmpleado] ([Codigo], [Nombre], [Apellido], [Direccion], [Email], [Cargo], [Clave], [Estado]) VALUES (N'10000003', N'Adnner', N'Esperilla Ruiz', N'Urba Tacna 542', N'adnner@yahoo.com', N'3', N'000003', N'FALSE')

INSERT [dbo].[tbProveedor] ([Codigo], [Ruc], [Descripcion], [Rubro], [Direccion], [Telefono], [Estado]) VALUES (N'100001', N'10000000001', N'Alicorp SAC', N'Harina', N'Av. Circunvalación nro 902', N'410101', N'TRUE')
INSERT [dbo].[tbProveedor] ([Codigo], [Ruc], [Descripcion], [Rubro], [Direccion], [Telefono], [Estado]) VALUES (N'100002', N'10000000002', N'Gloria SA', N'Leche', N'Av. Aviación nro 1002', N'419001', N'TRUE')
INSERT [dbo].[tbProveedor] ([Codigo], [Ruc], [Descripcion], [Rubro], [Direccion], [Telefono], [Estado]) VALUES (N'100003', N'10000000003', N'La Calera EIRL', N'Huevo', N'Av. Av. Industrial nro 842', N'488441', N'TRUE')
INSERT [dbo].[tbProveedor] ([Codigo], [Ruc], [Descripcion], [Rubro], [Direccion], [Telefono], [Estado]) VALUES (N'100004', N'11111111111', N'Panadería BUTIPAN', N'Panes', N'Gregorio Albarracín Mz 542', N'412300', N'TRUE')

INSERT [dbo].[tbProducto] ([Codigo], [Descripcion], [Cantidad], [PrecioUnitario], [FCodProveedor]) VALUES (N'000001', N'Pan de Trigo', N'45', CAST(1.50 AS Numeric(6, 2)), N'100001')
INSERT [dbo].[tbProducto] ([Codigo], [Descripcion], [Cantidad], [PrecioUnitario], [FCodProveedor]) VALUES (N'000002', N'Pan Yema', N'30', CAST(1.00 AS Numeric(6, 2)), N'100002')
INSERT [dbo].[tbProducto] ([Codigo], [Descripcion], [Cantidad], [PrecioUnitario], [FCodProveedor]) VALUES (N'000003', N'Pay de Manzana', N'45', CAST(5.50 AS Numeric(6, 2)), N'100003')
INSERT [dbo].[tbProducto] ([Codigo], [Descripcion], [Cantidad], [PrecioUnitario], [FCodProveedor]) VALUES (N'000004', N'Pan de Maiz', N'48', CAST(0.20 AS Numeric(6, 2)), N'100001')
INSERT [dbo].[tbProducto] ([Codigo], [Descripcion], [Cantidad], [PrecioUnitario], [FCodProveedor]) VALUES (N'000005', N'Pan de Chorizo', N'25', CAST(4.50 AS Numeric(6, 2)), N'100002')
INSERT [dbo].[tbProducto] ([Codigo], [Descripcion], [Cantidad], [PrecioUnitario], [FCodProveedor]) VALUES (N'000006', N'Pan Molde', N'50', CAST(10.50 AS Numeric(6, 2)), N'100003')
INSERT [dbo].[tbProducto] ([Codigo], [Descripcion], [Cantidad], [PrecioUnitario], [FCodProveedor]) VALUES (N'000007', N'Pan Frances', N'50', CAST(3.50 AS Numeric(6, 2)), N'100001')
INSERT [dbo].[tbProducto] ([Codigo], [Descripcion], [Cantidad], [PrecioUnitario], [FCodProveedor]) VALUES (N'000008', N'Pan Integral', N'50', CAST(3.50 AS Numeric(6, 2)), N'100002')
INSERT [dbo].[tbProducto] ([Codigo], [Descripcion], [Cantidad], [PrecioUnitario], [FCodProveedor]) VALUES (N'000009', N'Pan de Cebolla', N'45', CAST(1.20 AS Numeric(6, 2)), N'100003')
INSERT [dbo].[tbProducto] ([Codigo], [Descripcion], [Cantidad], [PrecioUnitario], [FCodProveedor]) VALUES (N'000010', N'Torta de Novia', N'1', CAST(100.00 AS Numeric(6, 2)), N'100001')

INSERT [dbo].[tbEmpresa] ([Ruc], [Nombre], [Direccion], [Telefono]) VALUES (N'11111111111', N'Panadería BUTIPAN', N'Gregorio Albarracín', N'412300')

INSERT [dbo].[tbBoleta] ([Serie], [Numero], [Fecha], [Total], [Estado], [FRuc], [FDniCliente], [FCodigoEmpleado]) VALUES (N'001', N'000001', CAST(N'2018-05-07T00:00:00.000' AS DateTime), CAST(50.50 AS Decimal(18, 2)), N'TRUE', N'11111111111', N'00000001', N'10000001')
INSERT [dbo].[tbBoleta] ([Serie], [Numero], [Fecha], [Total], [Estado], [FRuc], [FDniCliente], [FCodigoEmpleado]) VALUES (N'001', N'000002', CAST(N'2018-05-07T00:00:00.000' AS DateTime), CAST(31.00 AS Decimal(18, 2)), N'TRUE', N'11111111111', N'00000003', N'10000002')
INSERT [dbo].[tbBoleta] ([Serie], [Numero], [Fecha], [Total], [Estado], [FRuc], [FDniCliente], [FCodigoEmpleado]) VALUES (N'001', N'000003', CAST(N'2018-05-08T00:00:00.000' AS DateTime), CAST(15.50 AS Decimal(18, 2)), N'TRUE', N'11111111111', N'00000002', N'10000001')
INSERT [dbo].[tbBoleta] ([Serie], [Numero], [Fecha], [Total], [Estado], [FRuc], [FDniCliente], [FCodigoEmpleado]) VALUES (N'001', N'000004', CAST(N'2018-05-09T00:00:00.000' AS DateTime), CAST(80.20 AS Decimal(18, 2)), N'TRUE', N'11111111111', N'00000001', N'10000003')

INSERT [dbo].[tbdetalle] ([Serie], [Numero], [CantCompra], [Importe], [FCodProducto] ) VALUES (N'001', N'000001', 5, CAST(17.50 AS Decimal(18, 2)), N'000008')
INSERT [dbo].[tbdetalle] ([Serie], [Numero], [CantCompra], [Importe], [FCodProducto] ) VALUES (N'001', N'000001', 3, CAST(31.50 AS Decimal(18, 2)), N'000006')
INSERT [dbo].[tbdetalle] ([Serie], [Numero], [CantCompra], [Importe], [FCodProducto] ) VALUES (N'001', N'000001', 1, CAST(1.50 AS Decimal(18, 2)), N'000001')
INSERT [dbo].[tbdetalle] ([Serie], [Numero], [CantCompra], [Importe], [FCodProducto] ) VALUES (N'001', N'000002', 4, CAST(22.00 AS Decimal(18, 2)), N'000003')
INSERT [dbo].[tbdetalle] ([Serie], [Numero], [CantCompra], [Importe], [FCodProducto] ) VALUES (N'001', N'000002', 2, CAST(9.00 AS Decimal(18, 2)), N'000005')
INSERT [dbo].[tbdetalle] ([Serie], [Numero], [CantCompra], [Importe], [FCodProducto] ) VALUES (N'001', N'000003', 10, CAST(12.00 AS Decimal(18, 2)), N'000009')
INSERT [dbo].[tbdetalle] ([Serie], [Numero], [CantCompra], [Importe], [FCodProducto] ) VALUES (N'001', N'000003', 1, CAST(3.50 AS Decimal(18, 2)), N'000007')
INSERT [dbo].[tbdetalle] ([Serie], [Numero], [CantCompra], [Importe], [FCodProducto] ) VALUES (N'001', N'000004', 5, CAST(52.50 AS Decimal(18, 2)), N'000006')
INSERT [dbo].[tbdetalle] ([Serie], [Numero], [CantCompra], [Importe], [FCodProducto] ) VALUES (N'001', N'000004', 4, CAST(22.00 AS Decimal(18, 2)), N'000003')
INSERT [dbo].[tbdetalle] ([Serie], [Numero], [CantCompra], [Importe], [FCodProducto] ) VALUES (N'001', N'000004', 1, CAST(4.50 AS Decimal(18, 2)), N'000005')
INSERT [dbo].[tbdetalle] ([Serie], [Numero], [CantCompra], [Importe], [FCodProducto] ) VALUES (N'001', N'000004', 1, CAST(1.20 AS Decimal(18, 2)), N'000009')


INSERT [dbo].[tbInventario] ([Codigo], [Descripcion], [Cantidad], [PrecioUnitario], [Condicion], [FCodProducto], [FCodProveedor]) VALUES (N'200001', N'Pan Frances', N'10', CAST(3.50 AS Decimal(18, 2)), N'Bueno', N'000007', '100004')
INSERT [dbo].[tbInventario] ([Codigo], [Descripcion], [Cantidad], [PrecioUnitario], [Condicion], [FCodProducto], [FCodProveedor]) VALUES (N'200002', N'Pay de Manzana', N'10', CAST(5.50 AS Decimal(18, 2)), N'Bueno', N'000003', '100004')
INSERT [dbo].[tbInventario] ([Codigo], [Descripcion], [Cantidad], [PrecioUnitario], [Condicion], [FCodProducto], [FCodProveedor]) VALUES (N'200003', N'Pan Integral', N'10', CAST(3.50 AS Decimal(18, 2)), N'Bueno', N'000008', '100004')

INSERT [dbo].[tbPedido] ([Codigo], [Fecha], [Descripcion], [Total], [FDniCliente], [FCodEmpleado], [Estado]) VALUES (N'101', CAST(N'2018-05-25T00:00:00.000' AS DateTime), N'Torta de Novia', CAST(100.00 AS Decimal(18, 2)), N'00000001', N'10000001', N'Completado')
INSERT [dbo].[tbPedido] ([Codigo], [Fecha], [Descripcion], [Total], [FDniCliente], [FCodEmpleado], [Estado]) VALUES (N'102', CAST(N'2018-05-30T00:00:00.000' AS DateTime), N'Pan Frances', CAST(7.00 AS Decimal(18, 2)), N'00000002', N'10000001', N'Iniciado')
INSERT [dbo].[tbPedido] ([Codigo], [Fecha], [Descripcion], [Total], [FDniCliente], [FCodEmpleado], [Estado]) VALUES (N'103', CAST(N'2018-06-03T00:00:00.000' AS DateTime), N'Pan Integral', CAST(10.50 AS Decimal(18, 2)), N'00000003', N'10000001', N'Procesando')


GO

/*PROCEDIMIENTOS ALMACENADOS*/
/*Eliminar Cliente*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_D_EliminarCliente]
@DniCli varchar(8)
as 
begin 
Delete tbCliente
where 
Dni=@DniCli
end
GO

/*Agregar Boleta*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[USP_I_AgregarBoleta]
@SerieBo varchar(3),
@NumeroBo varchar(6),
@FechaBo varchar(10),
@TotalBo decimal(18,2),
@EstadoBo varchar(5),
@Fruc varchar(11),
@Fdnicliente varchar(8),
@Fcodigoempleado nvarchar(8)
as
begin
insert into tbBoleta(Serie,Numero,Fecha,Total,Estado,FRuc,FDniCliente,FCodigoEmpleado)
values (@SerieBo,@NumeroBo,@FechaBo,@TotalBo,@EstadoBo,@Fruc,@Fdnicliente,@Fcodigoempleado)
end
GO
/*Agregar Detalle*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_I_AgregarDetalle]
@Serie varchar(3),
@Numero varchar(6),
@CantCompra int,
@Importe decimal (18,2),
@FCodProducto nvarchar(6)
as
begin
insert into tbDetalle(Serie,Numero,CantCompra,Importe,FCodProducto)
values (@Serie,@Numero,@CantCompra,@Importe,@FCodProducto)
end
GO
/*Agregar Cargo*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[USP_I_AgregarCargo]
@IDCargo NVARCHAR (10), 
@DESCargo VARCHAR (50)
As 
Begin
insert into tbCargo(idCargo,Descripcion)
values (@IDCargo , @DESCargo)
End 
GO
/*Agregar Cliente*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_I_AgregarCliente]
@DniCli varchar(8),
@NombreCli varchar(40),
@ApellidoCli varchar(50),
@TelefonoCli varchar(18),
@EmailCli varchar(max)
as 
begin
insert into tbCliente (DNI,Nombre,Apellido,Telefono, Email)
values (@DniCli,@NombreCli,@ApellidoCli,@TelefonoCli, @EmailCli)
end
GO
/*Agregar Empleado*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_I_AgregarEmpleado]
@CodigoEmp nvarchar(8),
@NombreEmp varchar(50),
@ApellidoEmp varchar(50),
@DireccionEmp varchar(150),
@EmailEmp varchar(max),
@CargoEmp nvarchar(10),
@ClaveEmp nvarchar(6),
@EstadoEmp nvarchar(5)
as 
begin
insert into tbEmpleado(Codigo,Nombre,Apellido,Direccion,Email,Cargo,Clave,Estado)
values (@CodigoEmp,@NombreEmp,@ApellidoEmp,@DireccionEmp,@EmailEmp,@CargoEmp,@ClaveEmp,@EstadoEmp)
end
GO
/*Agregar Empresa*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_I_AgregarEmpresa]
@RucEmp varchar(11),
@NombreEmp varchar(100),
@DireccionEmp varchar(max),
@TelefonoEmp varchar(11)
as 
begin
insert into tbEmpresa(Ruc,Nombre,Direccion,Telefono)
values (@RucEmp,@NombreEmp,@DireccionEmp,@TelefonoEmp)
end
GO
/*Agregar Producto*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[USP_I_AgregarProducto]
@CodigoPro nvarchar(6),
@DescripcionPro varchar(250),
@CantidadPro nvarchar(3),
@PrecioUnitarioPro numeric(6,2),
@FCodProveedor nvarchar(8)
as
begin
insert into tbProducto(Codigo,Descripcion,Cantidad,PrecioUnitario, FCodProveedor)
values (@CodigoPro,@DescripcionPro,@CantidadPro,@PrecioUnitarioPro,@FCodProveedor)
end
GO
/*Agregar Proveedor*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_I_AgregarProveedor]
@CodigoPro nvarchar(8),
@RucPro nvarchar(11),
@DescripcionPro varchar(50),
@RubroPro varchar(50),
@DireccionPro varchar(50),
@TelefonoPro varchar(18),
@EstadoPro nvarchar(5)
as 
begin
insert into tbProveedor(Codigo, Ruc, Descripcion, Rubro, Direccion, Telefono, Estado)
values (@CodigoPro, @RucPro, @DescripcionPro, @RubroPro, @DireccionPro, @TelefonoPro, @EstadoPro)
end
GO
/*Agregar Inventario*/
CREATE procedure [dbo].[USP_I_AgregarInventario]
@CodigoIn nvarchar(6),
@DescripcionIn varchar(250),
@CantidadIn nvarchar(3),
@PrecioUnitario numeric(6,2),
@Condicion varchar(12),
@FCodProducto nvarchar(6),
@FCodProveedor nvarchar(8)
as
begin
insert into tbInventario(Codigo, Descripcion, Cantidad, PrecioUnitario, Condicion, FCodProducto, FCodProveedor)
values (@CodigoIn, @DescripcionIn, @CantidadIn, @PrecioUnitario, @Condicion, @FCodProducto, @FCodProveedor)
end 
GO
/*Agregar Pedido*/
CREATE procedure [dbo].[USP_I_AgregarPedido]
@CodigoPe nvarchar(6),
@FechaPe varchar(10),
@DescripcionPe varchar(250),
@TotalPe decimal(18,2),
@FDniCli varchar(8),
@FCodEmp nvarchar(8),
@Estado varchar(12)
as
begin
insert into tbPedido(Codigo, Fecha, Descripcion, Total, FDniCliente, FCodEmpleado, Estado)
values (@CodigoPe, @FechaPe, @DescripcionPe, @TotalPe, @FDniCli, @FCodEmp, @Estado)
end
GO



/*Buscar Boleta*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_S_BuscarBoleta]
@Serie varchar(3),
@Numero varchar(6)
as
begin
select * from tbBoleta
where 
Serie=@Serie and Numero=@Numero
end
GO
/*Buscar Detalle*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_S_BuscarDetalle] 
@Serie varchar(3),
@Numero varchar(6)
as
begin 
select * from tbDetalle
where
Serie=@Serie and Numero=@Numero
end
GO
/*Buscar Cargo*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_S_BuscarCargo]
@Idcargo nvarchar(10)
as
begin
select * from tbCargo
where 
idCargo=@Idcargo
end
GO
/*Buscar Cliente*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_S_BuscarCliente]
@DniCli varchar(8)
as
begin
select * from tbCliente
where 
Dni=@DniCli
end
/*Buscar Empleado*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_S_BuscarEmpleado]
@Codigo nvarchar(8)
as
begin
select * from tbEmpleado
where 
Codigo=@Codigo
end
GO
/*Buscar Empresa*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_S_BuscarEmpresa]
@Ruc varchar(11)
as
begin
select * from tbEmpresa
where 
Ruc=@Ruc
end
GO
/*Buscar Producto*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_S_BuscarProducto]
@Cod nvarchar(6)
as
begin
select * from tbProducto
where 
Codigo=@Cod
end
GO
/*Buscar Proveedor*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_S_BuscarProveedor]
@Cod nvarchar(8)
as
begin
select * from tbProveedor
where 
Codigo=@Cod
end
GO
/*Buscar Inventario*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_S_BuscarInventario]
@Cod nvarchar(6)
as
begin
select * from tbInventario
where 
Codigo=@Cod
end
GO
/*Buscar Pedido*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_S_BuscarPedido]
@CodigoPe nvarchar(6)
as
begin
select * from tbPedido
where 
Codigo=@CodigoPe
end
GO
/*Buscar Detalle*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_S_BuscarDetallePedido] 
@CodigoDet nvarchar(6)
as
begin 
select * from tbDetallePedido
where
Codigo=@CodigoDet
end
GO

/*Listar Boleta*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_S_ListarBoleta]
as 
begin
select * from tbBoleta
end 
GO
/*Listar Detalle*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_S_ListarDetalle]
as 
begin
select * from tbDetalle
end 
GO
/*Listar Cargo*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_S_ListarCargo]
as 
begin
select * from tbCargo
end 
GO
/*Listar Cliente*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_S_ListarCliente]
as 
begin
select * from tbCliente
end 
GO
/*Listar Empleado*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_S_ListarEmpleado]
as 
begin
select * from tbEmpleado
end
GO
/*Listar Empresa*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_S_ListarEmpresa]
as 
begin
select * from tbEmpresa
end 
GO
/*Listar Producto*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_S_ListarProducto]
as 
begin
select * from tbProducto
end 
GO
/*Listar Proveedor*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_S_ListarProveedor]
as 
begin
select * from tbProveedor
end 
GO
/*Listar Inventario*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_S_ListarInventario]
as 
begin
select * from tbInventario
end 
GO
/*Listar Pedido*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_S_ListarPedido]
as 
begin
select * from tbPedido
end 
GO


/*Validar Login*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_S_Login]
@CodigoEmp nvarchar (8),
@ClaveEmp nvarchar(6),
@EstadoEmp nvarchar(5)
as
begin
SELECT * FROM tbEmpleado
where 
Codigo=@CodigoEmp and Clave=@ClaveEmp and Estado=@EstadoEmp
end 
GO

/*Actualizar Boleta*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_U_ActualizarBoleta]
@SerieBo varchar(3),
@NumeroBo varchar(6),
@FechaBo varchar(10),
@TotalBo decimal(18,2),
@EstadoBo varchar(5),
@Fruc varchar(11),
@Fdnicliente varchar(8),
@Fcodigoempleado nvarchar(8)
as 
begin
UPDATE tbBoleta
set 
Numero=@NumeroBo,
Fecha=@FechaBo,
Total=@TotalBo,
Estado=@EstadoBo,
Fruc=@Fruc,
FdniCliente=@Fdnicliente,
FCodigoEmpleado=@Fcodigoempleado
where 
Serie=@SerieBo
end
GO
/*Actualizar Cargo*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_U_ActualizarCargo]
@idcargo nvarchar(10),
@Desc varchar(50)
as 
begin
UPDATE tbCargo
set 
Descripcion=@Desc

where 
idCargo=@idcargo
end
GO
/*Actualizar Cliente*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_U_ActualizarCliente]
@DniCli varchar(8),
@NombreCli varchar(40),
@ApellidoCli varchar(50),
@TelefonoCli varchar(18),
@EmailCli varchar(max)
as 
begin
UPDATE tbCliente
set 
Nombre=@NombreCli,
Apellido=@ApellidoCli,
Telefono=@TelefonoCli,
Email=@EmailCli
where 
DNI=@DniCli
end
GO
/*Actualizar Empleado*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_U_ActualizarEmpleado]
@CodigoEmp nvarchar(8),
@NombreEmp varchar(50),
@ApellidoEmp varchar(50),
@DireccionEmp varchar(150),
@EmailEmp varchar(max),
@CargoEmp nvarchar(10),
@ClaveEmp nvarchar(6),
@EstadoEmp nvarchar(5)
as 
begin
UPDATE tbEmpleado
set 
Nombre=@NombreEmp,
Apellido=@ApellidoEmp,
Direccion=@DireccionEmp,
Email=@EmailEmp,
Cargo=@CargoEmp,
Clave=@ClaveEmp,
Estado=@EstadoEmp
where 
Codigo=@CodigoEmp
end
GO
/*Actualizar Empresa*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_U_ActualizarEmpresa]
@RucEmp varchar(11),
@NombreEmp varchar(100),
@DireccionEmp varchar(max),
@TelefonoEmp varchar(11)
as 
begin
UPDATE tbEmpresa
set 
Nombre=@NombreEmp,
Direccion=@DireccionEmp,
Telefono=@TelefonoEmp
where 
Ruc=@RucEmp
end
GO
/*Actualizar Producto*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_U_ActualizarProducto]
@CodigoPro nvarchar(6),
@DescripcionPro varchar(250),
@CantidadPro nvarchar(3),
@PrecioUnitarioPro numeric(6,2),
@FCodProveedor nvarchar(8)

as 
begin
UPDATE tbProducto
set 
Descripcion=@DescripcionPro,
Cantidad=@CantidadPro,
PrecioUnitario=@PrecioUnitarioPro,
FCodProveedor=@FCodProveedor
where 
Codigo=@CodigoPro
end
GO
/*Actualizar Proveedor*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_U_ActualizarProveedor]
@CodigoPro nvarchar(8),
@RucPro nvarchar(11),
@DescripcionPro varchar(50),
@RubroPro varchar(50),
@DireccionPro varchar(50),
@TelefonoPro varchar(18),
@EstadoPro nvarchar(5)
as 
begin
UPDATE tbProveedor
set 
Ruc=@RucPro,
Descripcion=@DescripcionPro,
Rubro=@RubroPro,
Direccion=@DireccionPro,
Telefono=@TelefonoPro,
Estado=@EstadoPro
where 
Codigo=@CodigoPro
end
GO
/*Actualizar Inventario*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_U_ActualizarInventario]
@CodigoIn nvarchar(6),
@DescripcionIn varchar(250),
@CantidadIn nvarchar(3),
@PrecioUnitario numeric(6,2),
@Condicion varchar(12),
@FCodProducto nvarchar(6),
@FCodProveedor nvarchar(8)
as 
begin
UPDATE tbInventario
set 
Descripcion=@DescripcionIn,
Cantidad=@CantidadIn,
PrecioUnitario=@PrecioUnitario,
Condicion=@Condicion,
FCodProducto=@FCodProducto,
FCodProveedor=@FCodProveedor
where 
Codigo=@CodigoIn
end
GO
/*Actualizar Pedido*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_U_ActualizarPedido]
@CodigoPe nvarchar(6),
@FechaPe varchar(10),
@DescripcionPe varchar(250),
@TotalPe decimal(18,2),
@FDniCli varchar(8),
@FCodEmp nvarchar(8),
@Estado varchar(12)
as 
begin
UPDATE tbPedido
set 
Codigo=@CodigoPe,
Fecha=@FechaPe,
Descripcion=@DescripcionPe,
Total=@TotalPe,
FDniCliente=@FDniCli,
FCodEmpleado=@FCodEmp,
Estado=@Estado
where 
Codigo=@CodigoPe
end
GO


/*Anular Boleta*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[USP_U_AnularBoleta]
@Serie varchar(3),
@Numero varchar(6)
as 
begin
UPDATE tbBoleta
set 
Estado='FALSE'
where 
Serie=@Serie and Numero=@Numero
end

GO
/*Restar Productos*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[USP_U_RestaPro]
@Codigo nvarchar(6),
@Cantidad nvarchar(3)
as
begin
update tbProducto
set Cantidad=Cantidad - convert(int,@Cantidad)
where 
Codigo=@Codigo
end
GO
/*Sumar Productos*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[USP_U_SumPro]
@Codigo nvarchar(6),
@Cantidad nvarchar(3)
as
begin
update tbProducto
set Cantidad=Cantidad+@Cantidad
where 
Codigo=@Codigo
end
GO
