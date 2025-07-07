GO
USE Actividad4LengProg3

GO
INSERT INTO ListadoEstudiantes (
    Nombre, Matricula, Carrera, CorreoInstitucional, Telefono,
    FechaNacimiento, Genero, Turno, TipoIngreso, Becado, PorcentajeBeca
)
VALUES 
('Laura Méndez', 'sd-2023-04866', 'Ingeniería Industrial', 'sd-2023-04866@ufhec.edu.do', '8095551234', '2002-03-14', 'F', 'Matutino', 'Nuevo', 1, 75.00),
('Carlos Jiménez', 'sd-2023-04867', 'Derecho', 'sd-2023-04867@ufhec.edu.do', '8095552233', '2001-06-22', 'M', 'Vespertino', 'Reingreso', 0, 0.00),
('María Rodríguez', 'sd-2023-04868', 'Psicología', 'sd-2023-04868@ufhec.edu.do', '8095553344', '2003-01-08', 'F', 'Matutino', 'Nuevo', 1, 100.00),
('Juan Pérez', 'sd-2023-04869', 'Administración de Empresas', 'sd-2023-04869@ufhec.edu.do', '8095554455', '2000-12-01', 'M', 'Nocturno', 'Transferencia', 0, 0.00),
('Ana Castillo', 'sd-2023-04870', 'Contabilidad', 'sd-2023-04870@ufhec.edu.do', '8095555566', '2002-07-19', 'F', 'Matutino', 'Nuevo', 1, 50.00);

GO
INSERT INTO Materia (Codigo, Nombre, Creditos, Carrera)
VALUES 
('MAT101', 'Matemáticas I', 4, 'Ingeniería Industrial'),
('DER201', 'Derecho Civil I', 3, 'Derecho'),
('PSI110', 'Introducción a la Psicología', 3, 'Psicología'),
('ADM300', 'Gestión Empresarial', 4, 'Administración de Empresas'),
('CON210', 'Contabilidad Básica', 3, 'Contabilidad');

GO
INSERT INTO Calificacion (MatriculaEstudiante, CodigoMateria, Nota, Periodo)
VALUES 
('sd-2023-04866', 'MAT101', 89.50, '2024-1'),
('sd-2023-04867', 'DER201', 74.00, '2024-1'),
('sd-2023-04868', 'PSI110', 95.25, '2024-1'),
('sd-2023-04869', 'ADM300', 82.00, '2024-1'),
('sd-2023-04870', 'CON210', 91.75, '2024-1'),
('sd-2023-04866', 'ADM300', 88.00, '2024-2'),
('sd-2023-04868', 'MAT101', 97.00, '2024-2'),
('sd-2023-04870', 'MAT101', 85.50, '2024-2');