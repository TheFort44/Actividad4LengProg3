GO
CREATE DATABASE Actividad4LengProg3

GO
USE Actividad4LengProg3

GO
CREATE TABLE ListadoEstudiantes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Matricula VARCHAR(20) UNIQUE NOT NULL,
    Carrera NVARCHAR(100) NOT NULL,
    CorreoInstitucional VARCHAR(100) NOT NULL,
    Telefono VARCHAR(15),
    FechaNacimiento DATE NOT NULL,
    Genero CHAR(1) CHECK (Genero IN ('M', 'F')),
    Turno VARCHAR(20) CHECK (Turno IN ('Matutino', 'Vespertino', 'Nocturno')),
    TipoIngreso VARCHAR(50) CHECK (TipoIngreso IN ('Nuevo', 'Reingreso', 'Transferencia')),
    Becado BIT NOT NULL,
    PorcentajeBeca DECIMAL(5,2) CHECK (PorcentajeBeca >= 0 AND PorcentajeBeca <= 100)
);


GO
CREATE TABLE Materia (
    Codigo VARCHAR(20) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Creditos INT CHECK (Creditos > 0),
    Carrera NVARCHAR(100) NOT NULL
);

GO
CREATE TABLE Calificacion (
    MatriculaEstudiante VARCHAR(20),
    CodigoMateria VARCHAR(20),
    Nota DECIMAL(4,2) CHECK (Nota >= 0 AND Nota <= 100),
    Periodo VARCHAR(20) NOT NULL,
    PRIMARY KEY (MatriculaEstudiante, CodigoMateria, Periodo),
    FOREIGN KEY (MatriculaEstudiante) REFERENCES ListadoEstudiantes(Matricula),
    FOREIGN KEY (CodigoMateria) REFERENCES Materia(Codigo)
);