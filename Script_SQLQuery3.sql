CREATE TABLE Cliente (
    Identificacion INT PRIMARY KEY, -- NO autoincremental
    Nombres VARCHAR(100),
    Apellidos VARCHAR(100),
    Direccion VARCHAR(150),
    Telefono VARCHAR(20)
);

CREATE TABLE Mesero (
    IdMesero INT IDENTITY(1,1) PRIMARY KEY,
    Nombres VARCHAR(100),
    Apellidos VARCHAR(100),
    Edad INT,
    Antiguedad INT
);

CREATE TABLE Mesa (
    NroMesa INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50),
    Reservada BIT,
    Puestos INT
);

CREATE TABLE Supervisor (
    IdSupervisor INT IDENTITY(1,1) PRIMARY KEY,
    Nombres VARCHAR(100),
    Apellidos VARCHAR(100),
    Edad INT,
    Antiguedad INT
);

CREATE TABLE Factura (
    NroFactura INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT,
    NroMesa INT,
    IdMesero INT,
    Fecha DATE,
    FOREIGN KEY (IdCliente) REFERENCES Cliente(Identificacion),
    FOREIGN KEY (NroMesa) REFERENCES Mesa(NroMesa),
    FOREIGN KEY (IdMesero) REFERENCES Mesero(IdMesero)
);

CREATE TABLE DetallexFactura (
    IdDetallexFactura INT IDENTITY(1,1) PRIMARY KEY,
    NroFactura INT,
    IdSupervisor INT,
    Plato VARCHAR(100),
    Valor DECIMAL(10,2),
    FOREIGN KEY (NroFactura) REFERENCES Factura(NroFactura),
    FOREIGN KEY (IdSupervisor) REFERENCES Supervisor(IdSupervisor)
);
