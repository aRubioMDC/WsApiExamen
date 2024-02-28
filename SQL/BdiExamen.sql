CREATE DATABASE BdiExamen
USE BdiExamen
GO

CREATE TABLE tblExamen(
    idExamen INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(255),
    Descripcion VARCHAR(255)
);

SELECT * FROM tblExamen;

