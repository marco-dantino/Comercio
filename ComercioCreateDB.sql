USE master
GO

DROP DATABASE COMERCIO_DB;
GO

CREATE DATABASE COMERCIO_DB;
GO


USE COMERCIO_DB;
GO


CREATE TABLE ROLES (
  id INT PRIMARY KEY IDENTITY(1,1),
  nombre VARCHAR(50) NOT NULL
);

CREATE TABLE USUARIOS (
  id INT PRIMARY KEY IDENTITY(1,1),
  nombre VARCHAR(50) NOT NULL,
  apellido VARCHAR(50) NOT NULL,
  email VARCHAR(50) NOT NULL UNIQUE,
  password VARCHAR(50) NOT NULL,
  id_rol INT,
  FOREIGN KEY (id_rol) REFERENCES ROLES(id)
);

CREATE TABLE CLIENTES (
  id INT PRIMARY KEY IDENTITY(1,1),
  dni INT NOT NULL,
  nombre VARCHAR(50) NOT NULL,
  direccion VARCHAR(50),
  telefono VARCHAR(50),
  email VARCHAR(50),
  activo BIT DEFAULT 1
);

CREATE TABLE PROVEEDORES (
  id INT PRIMARY KEY IDENTITY(1,1),
  cuit VARCHAR(20) NOT NULL,
  nombre VARCHAR(50) NOT NULL,
  direccion VARCHAR(50),
  telefono VARCHAR(50),
  email VARCHAR(50),
  activo BIT DEFAULT 1
);

CREATE TABLE MARCAS (
  id INT PRIMARY KEY IDENTITY(1,1),
  nombre VARCHAR(50) NOT NULL
);

CREATE TABLE CATEGORIAS (
  id INT PRIMARY KEY IDENTITY(1,1),
  nombre VARCHAR(50) NOT NULL
);

CREATE TABLE PRODUCTOS (
  id INT PRIMARY KEY IDENTITY(1,1),
  nombre VARCHAR(50) NOT NULL,
  stock_actual INT NOT NULL,
  precio_compra INT NOT NULL,
  porcentaje_ganancia FLOAT NOT NULL,
  id_marca INT,
  id_categoria INT,
  imagen_url VARCHAR(200),
  activo BIT DEFAULT 1,

  FOREIGN KEY (id_marca) REFERENCES MARCAS(id),
  FOREIGN KEY (id_categoria) REFERENCES CATEGORIAS(id)
);

CREATE TABLE PROVEEDOR_PRODUCTO (
    id INT PRIMARY KEY IDENTITY(1,1),
    id_proveedor INT NOT NULL,
    id_producto INT NOT NULL,
    activo BIT DEFAULT 1,
    FOREIGN KEY (id_proveedor) REFERENCES PROVEEDORES(id),
    FOREIGN KEY (id_producto) REFERENCES PRODUCTOS(id)
);


CREATE TABLE COMPRAS (
  id INT PRIMARY KEY IDENTITY(1,1),
  fecha DATETIME NOT NULL,
  total FLOAT NOT NULL,
  id_proveedor INT,

  FOREIGN KEY (id_proveedor) REFERENCES PROVEEDORES(id)
);

CREATE TABLE DETALLE_COMPRAS (
  id INT PRIMARY KEY IDENTITY(1,1),
  cantidad INT NOT NULL,
  precio_unitario FLOAT NOT NULL,
  id_compra INT,
  id_producto INT,

  FOREIGN KEY (id_compra) REFERENCES COMPRAS(id),
  FOREIGN KEY (id_producto) REFERENCES PRODUCTOS(id)
);

CREATE TABLE VENTAS (
  id INT PRIMARY KEY IDENTITY(1,1),
  fecha DATETIME NOT NULL,
  total FLOAT NOT NULL,
  numero_factura VARCHAR(50) NOT NULL UNIQUE,
  id_cliente INT,
  id_usuario INT,

  FOREIGN KEY (id_cliente) REFERENCES CLIENTES(id),
  FOREIGN KEY (id_usuario) REFERENCES USUARIOS(id)
);

CREATE TABLE DETALLE_VENTAS (
  id INT PRIMARY KEY IDENTITY(1,1),
  cantidad INT NOT NULL,
  precio_unitario FLOAT NOT NULL,
  id_venta INT,
  id_producto INT,

  FOREIGN KEY (id_venta) REFERENCES VENTAS(id),
  FOREIGN KEY (id_producto) REFERENCES PRODUCTOS(id)
);


INSERT INTO ROLES (nombre) VALUES
('admin'),
('vendedor');


INSERT INTO USUARIOS (nombre, apellido, email, password, id_rol) VALUES
('Marco', 'Dantino', 'marco.dantino@colidevs.com', 'holacomova123', 1),
('Roberto', 'Passini', 'passiniroberto@hotmail.com', 'soyUsuario', 2),
('Francisco', 'Sanchez', 'fransanchez@gmail.com', 'soyFran', 2);


INSERT INTO CLIENTES (dni, nombre, direccion, telefono, email) VALUES
(33445566, 'cl1', 'Boulevard San Martín 850', '1140386592', 'cl1@gmail.com'),
(99887766, 'cl2', 'Calle Las Rosas 221', '1133211592', 'cl2@gmail.com'),
(44556677, 'cl3', 'Avenida Belgrano 1045', '1133216592', 'cl3@gmail.com');


INSERT INTO PROVEEDORES (cuit, nombre, direccion, telefono, email) VALUES
('12-34567891-11', 'prov1', 'Calle Comercio 120', '1133211592', 'prov1@gmail.com'),
('30-25262722-22', 'prov2', 'Avenida Industrial 450', '1122222222', 'prov2@gmail.com'),
('21-77738884-33', 'prov3', 'Boulevard Central 980', '1133333333', 'prov3@gmail.com');

INSERT INTO MARCAS (nombre) VALUES
('Marca A'),
('Marca B'),
('Marca C');


INSERT INTO CATEGORIAS (nombre) VALUES
('Electrónica'),
('Hogar'),
('Ropa');

INSERT INTO PRODUCTOS (nombre, stock_actual, precio_compra, porcentaje_ganancia, id_marca, id_categoria, imagen_url) VALUES
('Producto 1', 100, 500, 20.0, 1, 1, 'https://res.cloudinary.com/dnpxdmyhl/image/upload/v1750361574/bc_PineappleIce_trgsnn.webp'),
('Producto 2', 50, 300, 15.5, 2, 2, 'https://res.cloudinary.com/dnpxdmyhl/image/upload/v1750361574/bc_PineappleIce_trgsnn.webp'),
('Producto 3', 200, 150, 30.0, 3, 3, 'https://res.cloudinary.com/dnpxdmyhl/image/upload/v1750361574/bc_PineappleIce_trgsnn.webp');

INSERT INTO COMPRAS (fecha, total, id_proveedor) VALUES
('2024-10-10T12:30:00', 1000.0, 1),
('2024-10-11T14:00:00', 2000.0, 2),
('2024-10-12T15:45:00', 1500.0, 3);

INSERT INTO DETALLE_COMPRAS (cantidad, precio_unitario, id_compra, id_producto) VALUES
(10, 100.0, 1, 1),
(20, 50.0, 2, 2),
(15, 75.0, 3, 3);

INSERT INTO VENTAS (fecha, total, numero_factura, id_cliente, id_usuario) VALUES
('2024-10-13T10:00:00', 500.0, '00001', 1, 1),
('2024-10-14T11:30:00', 750.0, '00002', 2, 2),
('2024-10-15T09:45:00', 1000.0, '00003', 3, 3);

INSERT INTO DETALLE_VENTAS (cantidad, precio_unitario, id_venta, id_producto) VALUES
(5, 100.0, 1, 1),
(10, 75.0, 2, 2),
(8, 125.0, 3, 3);

INSERT INTO PROVEEDOR_PRODUCTO (id_proveedor, id_producto) VALUES
(1, 1),
(2, 2),
(3, 3);
