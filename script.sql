create table Cliente_Cuentas
(id  int  identity(1,1),
cbu numeric (20),
saldo float(10),
tipoCuenta int,
id_cliente int
constraint id primary key(id),
constraint tipoC foreign key(tipoCuenta)
	references tipoCuenta  (id_tipo_cuenta),
constraint cliente foreign key(id_cliente)
	references clientes(id_cliente)

)

insert into Cliente_Cuentas(cbu,saldo,tipoCuenta,id_cliente) values (1111111111,120,1,2)
insert into Cliente_Cuentas(cbu,saldo,tipoCuenta,id_cliente) values (22222222222,320,2,5)
insert into Cliente_Cuentas(cbu,saldo,tipoCuenta,id_cliente) values (33333333333,400,3,8)
insert into Cliente_Cuentas(cbu,saldo,tipoCuenta,id_cliente) values (44444444444,500,4,9)

select * from clientes