USE BdiExamen
GO

CREATE PROCEDURE spAgregar
    @Nombre VARCHAR(255),
    @Descripcion VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Insertar el registro en la tabla
        INSERT INTO tblexamen (Nombre, Descripcion)
        VALUES (@Nombre, @Descripcion);

        SELECT 0 AS CodigoRetorno, 'Registro insertado satisfactoriamente' AS Descripcion;

    END TRY
    BEGIN CATCH
        -- Devolver error
        DECLARE @ErrorNumero INT, @ErrorDescripcion NVARCHAR(4000);
        SELECT @ErrorNumero = ERROR_NUMBER(), @ErrorDescripcion = ERROR_MESSAGE();
        SELECT @ErrorNumero AS CodigoRetorno, @ErrorDescripcion AS Descripcion;
    END CATCH
END

--Ejemplo de ejecucion
--EXEC spAgregar 'Test3','Test3';
--SELECT * FROM tblExamen;