create database Bancario
use bancario

CREATE TABLE [dbo].[clientes](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[dni] [varchar](8) NULL,
	[fecha_alta] [datetime]  NULL,
 CONSTRAINT [pk_clientes] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[tipoCuenta](
	[id_tipo_cuenta] [int] IDENTITY(1,1) NOT NULL,
	[nombre_tipo_cuenta] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tipo_cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[CuentaCliente](
	[id_cliente] [int] NOT NULL,
	[id_tipo_cuenta] [int] NOT NULL,
	[cbu] [numeric] NULL,
	[saldo] [float] NULL,
	
 CONSTRAINT [pk_CuentaCliente] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC,
	[id_tipo_cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT [dbo].[tipoCuenta] ([nombre_tipo_cuenta]) VALUES ('Cuenta sueldo')
INSERT [dbo].[tipoCuenta] ([nombre_tipo_cuenta]) VALUES ('Cuenta Corriente')
INSERT [dbo].[tipoCuenta] ([nombre_tipo_cuenta]) VALUES ('Caja de ahorro en Pesos')
INSERT [dbo].[tipoCuenta] ([nombre_tipo_cuenta]) VALUES ('Caja de ahorro en Dolar')
SET IDENTITY_INSERT [dbo].[tipo_cuenta] OFF
GO

INSERT [dbo].[CuentaCliente] ([id_cliente], [id_tipo_cuenta], [cbu], [saldo]) VALUES (1, 1, 6789012345, 1500)
INSERT [dbo].[CuentaCliente] ([id_cliente], [id_tipo_cuenta], [cbu], [saldo]) VALUES (1, 2, 6789012343, 1300)
INSERT [dbo].[CuentaCliente] ([id_cliente], [id_tipo_cuenta], [cbu], [saldo]) VALUES (1, 4, 6789012322,6500)

INSERT [dbo].[CuentaCliente] ([id_cliente], [id_tipo_cuenta], [cbu], [saldo]) VALUES (2, 1, 6789666666, 1500)
INSERT [dbo].[CuentaCliente] ([id_cliente], [id_tipo_cuenta], [cbu], [saldo]) VALUES (3, 2, 6789555555, 1300)
INSERT [dbo].[CuentaCliente] ([id_cliente], [id_tipo_cuenta], [cbu], [saldo]) VALUES (4, 4, 6789999999,6500)
GO

INSERT [dbo].[clientes] ([nombre], [apellido], [dni], [fecha_alta]) VALUES ('Pablo', 'Picaso', '12456789', '12/10/2021')
INSERT [dbo].[clientes] ([nombre], [apellido], [dni], [fecha_alta]) VALUES ('Mirta', 'Gomez', '33356789', '10/10/2021')
SET IDENTITY_INSERT [dbo].[clientes] OFF
GO


create PROCEDURE dbo.SP_EDITAR_CLIENTE
@nombre varchar(50),
@apellido varchar(255)=null,
@dni varchar(100)=null,
@fecha_alta datetime=null
AS
BEGIN
UPDATE clientes
SET nombre=@nombre,apellido=@apellido,dni=@dni,fecha_alta=@fecha_alta
WHERE dni = @dni 
END
GO

CREATE PROCEDURE SP_BORRAR_CLIENTE
@dni varchar(100)=null
AS
BEGIN
DELETE FROM clientes WHERE dni = @dni 
END
GO

create procedure SP_CONSULTAR_CLIENTES
AS
BEGIN
	SELECT id_cliente,nombre,apellido,dni,convert(varchar,fecha_alta,3) as Fecha
	FROM clientes
	
END
GO


create PROCEDURE SP_CONSULTAR_CLIENTE_POR_ID
	@id_cliente int
AS
BEGIN
	SELECT *
	FROM clientes 
	WHERE id_cliente = @id_cliente
END
GO

CREATE PROCEDURE SP_CONSULTAR_CLIENTE_POR_DNI
	@dni varchar(10)
AS
BEGIN
	SELECT *
	FROM clientes 
	WHERE dni = @dni
END
GO

CREATE procedure SP_INSERTAR_CLIENTE
(@nombre varchar(100),
@apellido varchar(100),
@dni varchar(50),
@fecha_alta datetime)
as
begin
	insert into clientes (nombre,apellido,dni,fecha_alta)
	values(@nombre,@apellido,@dni, @fecha_alta)
END
GO

create PROCEDURE SP_CONSULTAR_Cliente_Cuenta 
@dni varchar (8)
as
begin
	select cu.id_cliente as ID, cu.cbu as CBU, cu.saldo as Saldo, cu.id_tipo_cuenta as Tipo_Cuenta 

	from clientes c join CuentaCliente cu  on c.id_cliente = cu.id_cliente
	where c.dni = @dni
end 
GO

create procedure SP_INSERTAR_CUENTA_CLIENTE
@id_cliente int,
@tipoCuenta int,
@cbu int,
@saldo float(10)

as
begin		
	insert into CuentaCliente
	values(@id_cliente,@tipoCuenta,@cbu,@saldo)
END
GO

create procedure [dbo].[SP_CONSULTAR_CUENTAS]
AS
BEGIN
	SELECT *
	FROM tipoCuenta
	
END
GO

alter procedure [dbo].[SP_CONSULTAR_CUENTAS_POR_NOMBRE]
	@nombre_tipo_cuenta varchar(30)
AS
BEGIN
	SELECT *
	FROM tipoCuenta
	WHERE nombre_tipo_cuenta = @nombre_tipo_cuenta
END

GO



CREATE PROCEDURE [dbo].[SP_REGISTRAR_BAJA_CUENTA] 
	@nombre varchar(30)
AS
BEGIN
	DELETE FROM tipoCuenta WHERE nombre_tipo_cuenta = @nombre
	
END


create view ClienteCuenta
as
select c.nombre, c.apellido,cu.cbu ,ti.nombre_tipo_cuenta
from clientes c join CuentaCliente cu on c.id_cliente = cu.id_cliente 
join tipoCuenta ti on cu.id_tipo_cuenta = ti.id_tipo_cuenta


select * from clientes