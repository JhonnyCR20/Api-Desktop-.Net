
CREATE database PuntoVenta
USE PuntoVenta

drop table Bitacora;
drop table DetFactura;
drop table Cliente;
drop table Factura;
drop table Producto;
drop table CuentasPorCobrar;
drop table Usuario;


-- Tabla Usuarios
IF EXISTS(SELECT NAME FROM dbo.sysobjects WHERE NAME ='Usuario')
DROP TABLE [Usuario]
go
CREATE TABLE Usuario (
    login VARCHAR(100) NOT NULL PRIMARY KEY,
    password VARCHAR(100) NOT NULL,
	FechaRegistro datetime not null default getdate(),
	Estado char not null default 'A');

-- Tabla Bitacora
CREATE TABLE Bitacora(
    Tabla VARCHAR(100),
    Usuario VARCHAR(100),
    Maquina VARCHAR(100) NOT NULL,
    Fecha DATE NOT NULL,
    TipoMov VARCHAR(100) NOT NULL,
    Registro VARCHAR(100) NOT NULL
);

-- Tabla Productos
CREATE TABLE Producto(
    CodigoInterno varchar(100) NOT NULL PRIMARY KEY,
    CodigoBarra INT NOT NULL,
    Descripcion VARCHAR(100) NOT NULL,
    PrecioVenta INT NOT NULL,
    Descuento FLOAT NOT NULL,
    Impuesto FLOAT NOT NULL,
    UnidadMedida VARCHAR(100) NOT NULL,
    PrecioCompra FLOAT NOT NULL,
    Usuario VARCHAR(100),
    Existencia INT NOT NULL
);

-- Tabla CuentasPorCobrar
CREATE TABLE CuentasPorCobrar (
    numFactura int NOT NULL,
    codCliente Varchar(100) NOT NULL,
    FechaFactura DATE NOT NULL,
    FechaRegistro DATE NOT NULL,
    MontoFactura FLOAT NOT NULL,
    usuario VARCHAR(100),
    estado CHAR,
    PRIMARY KEY (numFactura, codCliente)
);

-- Tabla Det_Facturas
CREATE TABLE DetFactura (
    numFactura INT NOT NULL,
    codInterno varchar(100) NOT NULL,
    cantidad INT NOT NULL,
    PrecioUnitario FLOAT NOT NULL,
    Subtotal FLOAT NOT NULL,
    PorImp FLOAT NOT NULL,
    porDescuento FLOAT NOT NULL,
    PRIMARY KEY (numFactura, codInterno)
);

-- Tabla Clientes
CREATE TABLE Cliente (
    CedulaLegal VARCHAR(100) NOT NULL,
    tipoCedula VARCHAR(100),
    NombreCompleto VARCHAR(100),
    Email VARCHAR(100) NOT NULL,
    FechaRegistro DATE,
    estado CHAR NOT NULL,
    Usuario VARCHAR(100) NOT NULL,
    PRIMARY KEY (CedulaLegal)
);

CREATE TABLE Factura (
    numero INT NOT NULL,
    Fecha DATE NOT NULL,
    codCliente varchar(100) NOT NULL,
    Subtotal FLOAT NOT NULL,
    MontoDescuento FLOAT NOT NULL,
    MontoImpuesto FLOAT NOT NULL,
    Total FLOAT NOT NULL,
    estado CHAR NOT NULL,
    Usuario VARCHAR(100) NOT NULL,
    TipoPago VARCHAR(100) NOT NULL,
    PRIMARY KEY (numero)
);

commit;
-- Establecer relaciones--------------------------------------------------------------

-- Relación Bitacora
ALTER TABLE Bitacora
ADD CONSTRAINT FK_Bitacora_Usuario
FOREIGN KEY (Usuario) REFERENCES Usuario(login);

-- Relación Producto
ALTER TABLE Producto
ADD CONSTRAINT FK_Productos_Usuarios
FOREIGN KEY (Usuario) REFERENCES Usuario(login);

-- Relación CuentasPorCobrar
ALTER TABLE CuentasPorCobrar
ADD CONSTRAINT FK_CuentasPorCobrar_Cliente
FOREIGN KEY (codCliente) REFERENCES Cliente (CedulaLegal);

ALTER TABLE CuentasPorCobrar
ADD CONSTRAINT FK_CuentasPorCobrar_Usuario
FOREIGN KEY (Usuario) REFERENCES Usuario(login);

ALTER TABLE CuentasPorCobrar
ADD CONSTRAINT FK_CuentasPorCobrar_Factura
FOREIGN KEY (numFactura) REFERENCES Factura (numero);


-- Relación Det_Facturas
ALTER TABLE DetFactura
ADD CONSTRAINT FK_Det_Facturas_Productos
FOREIGN KEY (CodInterno) REFERENCES Producto(CodigoInterno);

ALTER TABLE DetFactura
ADD CONSTRAINT FK_Det_Facturas_Facturas
FOREIGN KEY (numFactura) REFERENCES Factura (numero);

-- Relación Facturas
ALTER TABLE Factura
ADD CONSTRAINT FK_Facturas_Usuario
FOREIGN KEY (usuario) REFERENCES Usuario (login);

ALTER TABLE Factura
ADD CONSTRAINT FK_Facturas_Clientes
FOREIGN KEY (codCliente) REFERENCES Cliente (CedulaLegal);

--Relacion Clientes
ALTER TABLE Cliente
ADD CONSTRAINT FK_Clientes_Usuario
FOREIGN KEY (usuario) REFERENCES Usuario (login);


select * from Usuario
go