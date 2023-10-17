CREATE TABLE Sucursales(
	Id INT PRIMARY KEY IDENTITY,
	Nombre VARCHAR(255)
);

INSERT INTO Sucursales(Nombre) VALUES('Sucursal Norte'),('Sucursal Sur'),('Sucursal Occidente'),('Sucursal Oriente');

CREATE TABLE Elementos(
	Id INT PRIMARY KEY IDENTITY,
	Nombre VARCHAR(255)
);

INSERT INTO Elementos(Nombre) VALUES('Gafas'),('Casco'),('Botas'),('Camisa'),('Pantalon'),('Tapa Oidos'),('Guantes');

CREATE TABLE Tecnicos(
	Id INT PRIMARY KEY IDENTITY,
	Nombre VARCHAR(255),
	Codigo VARCHAR(40),
	SueldoBase DECIMAL(12,2),
	SucursalId INT FOREIGN KEY REFERENCES Sucursales(Id),
	FechaCreacion DATETIME DEFAULT GETDATE(),
	FechaModificacion DATETIME NULL
);

INSERT INTO Tecnicos(Nombre,Codigo,SueldoBase,SucursalId) 
VALUES
	(
		'Juan',
		'5412',
		500000.00,
		1
	);

CREATE TABLE ElementosTecnico(
	Id INT PRIMARY KEY IDENTITY,
	TecnicoId INT FOREIGN KEY REFERENCES Tecnicos(Id),
	ElementoId INT FOREIGN KEY REFERENCES Elementos(Id),
	FechaCreacion DATETIME DEFAULT GETDATE(),
	FechaModificacion DATETIME NULL
);

INSERT INTO ElementosTecnico(TecnicoId,ElementoId) 
VALUES 
	(
		1,
		1
	);