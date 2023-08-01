Create database Store_LowCost

create table Users(
UserID int  not null IDENTITY(1,1) Primary key,
UserName varchar(50) not null,
Passwo varchar(50) not null,
Email varchar(100) not null unique,
Addres varchar(100) not null
)

create table Products(
ProductID int not null IDENTITY(1,1) primary key,
ProductName varchar(50) not null,
Descript varchar(150) not null,
Precio decimal not null,
Stock int not null,
Categoria varchar(100) not null,
Imagen varchar(5000) not null,
)

create table Carrito(
CarritoID int identity(1,1) not null primary key,
UserID int,
CarritoStatus varchar(30),
foreign key(UserID) REFERENCES Users(UserID)

)
create table CarritoDetails(
 IDDetalleCarrito INT PRIMARY KEY,
 IDCarrito INT FOREIGN KEY REFERENCES Carrito(CarritoID),
 IDProducto INT FOREIGN KEY REFERENCES Products(ProductID),
 CantidadProducto INT,
 PrecioUnitario DECIMAL(10, 2),
 Subtotal DECIMAL(10, 2)
)
CREATE TABLE Pedidos (
    IDPedido INT PRIMARY KEY,
    IDUsuario INT FOREIGN KEY REFERENCES Users(UserID),
    FechaHoraPedido DATETIME,
    EstadoPedido VARCHAR(50),
    DireccionEnvio VARCHAR(100),
    TotalPedido DECIMAL(10, 2)
);

CREATE TABLE DetallesPedido (
    IDDetallePedido INT PRIMARY KEY,
    IDPedido INT FOREIGN KEY REFERENCES Pedidos(IDPedido),
    IDProducto INT FOREIGN KEY REFERENCES Products(ProductID),
    CantidadProducto INT,
    PrecioUnitario DECIMAL(10, 2),
    Subtotal DECIMAL(10, 2)
);
