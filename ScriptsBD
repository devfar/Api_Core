
/*********************** EXAMEN **************************/
--CREACION BASE DE DATOS

CREATE DATABASE EmployeeExamen;

--CREACION DE TABLA EMPLOYEE

CREATE TABLE dbo.Employee
(
    EmployeeId INT IDENTITY PRIMARY KEY,
    EmployeeName VARCHAR(500) NULL,
    EmployeeSalary DECIMAL(10, 2) NULL,
    EmployeeAge INT NULL,
    ProfileImage VARCHAR(500) NULL
);

--- INSERCIÓN DE PRIMEROS REGISTROS DE PRUEBA

INSERT INTO dbo.Employee
(
    EmployeeName,
    EmployeeSalary,
    EmployeeAge,
    ProfileImage
)
VALUES
(   'Juan Alban', -- EmployeeName - varchar(500)
    3200,         -- EmployeeSalary - decimal(10, 2)
    26,           -- EmployeeAge - int
    ''            -- ProfileImage - varchar(500)
    ),
(   'Marco Martinez', -- EmployeeName - varchar(500)
    5000,             -- EmployeeSalary - decimal(10, 2)
    37,               -- EmployeeAge - int
    ''                -- ProfileImage - varchar(500)
),
(   'Luis Herrera', -- EmployeeName - varchar(500)
    4520,           -- EmployeeSalary - decimal(10, 2)
    40,             -- EmployeeAge - int
    ''              -- ProfileImage - varchar(500)
);


SELECT EmployeeId,
       EmployeeName,
       EmployeeSalary,
       EmployeeAge,
       ProfileImage
FROM dbo.Employee;

----CREACION DE STORE PROCEDURE PARA LA TABLA EMPLOYEE

-- SP DE CONSULTA

GO
CREATE PROCEDURE dbo.sp_employee_cons
    @X_EmployeeId AS INT,
    @X_EmployeeName AS VARCHAR(500),
    @X_EmployeeSalary AS DECIMAL,
    @X_EmployeeAge AS INT,
    @X_ProfileImage AS VARCHAR(500),
    @X_ID_OPE AS INT
AS
BEGIN

    -- TRAE LISTADO COMPLETO DE EMPLEADOS
    IF @X_ID_OPE = 1
    BEGIN
        SELECT EmployeeId,
               EmployeeName,
               EmployeeSalary,
               EmployeeAge,
               ProfileImage
        FROM dbo.Employee
    END;
END;
GO

-- SP DE MANTENIMIENTO
GO
CREATE PROCEDURE dbo.sp_employee_mant
    @X_EmployeeId AS INT,
    @X_EmployeeName AS VARCHAR(500),
    @X_EmployeeSalary AS DECIMAL,
    @X_EmployeeAge AS INT,
    @X_ProfileImage AS VARCHAR(500),
    @X_ID_OPE AS INT
AS
BEGIN

    DECLARE @L_CORRELATIVO INT = 0,
            @L_MENSAJE VARCHAR(500) = '',
            @L_ERROR INT = 0;

    -- INSERTAR REGISTRO EN LA TABLA
    IF @X_ID_OPE = 1
    BEGIN
        BEGIN TRAN;
        BEGIN TRY
            INSERT INTO dbo.Employee
            (
                EmployeeName,
                EmployeeSalary,
                EmployeeAge,
                ProfileImage
            )
            VALUES
            (@X_EmployeeName, @X_EmployeeSalary, @X_EmployeeAge, @X_ProfileImage);

            COMMIT TRAN;
            SET @L_CORRELATIVO = SCOPE_IDENTITY();

        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRAN;
            SET @L_ERROR = 1;
            SET @L_MENSAJE = ERROR_MESSAGE();
        END CATCH;
    END;

    -- ACTUALIZAR REGISTRO DE LA TABLA 
    ELSE IF @X_ID_OPE = 2
    BEGIN
        BEGIN TRAN;
        BEGIN TRY
            UPDATE dbo.Employee
            SET EmployeeName = @X_EmployeeName,
                EmployeeSalary = @X_EmployeeSalary,
                EmployeeAge = @X_EmployeeAge,
                ProfileImage = @X_ProfileImage
            WHERE EmployeeId = @X_EmployeeId;
            COMMIT TRAN;
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRAN;
            SET @L_ERROR = 1;
            SET @L_MENSAJE = ERROR_MESSAGE();
        END CATCH;
    END;

    --ELIMINAR REGISTRO DE LA TABLA
    ELSE IF @X_ID_OPE = 3
    BEGIN
        BEGIN TRAN;
        BEGIN TRY
            DELETE FROM dbo.Employee
            WHERE EmployeeId = @X_EmployeeId;
            COMMIT TRAN;
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRAN;
            SET @L_ERROR = 1;
            SET @L_MENSAJE = ERROR_MESSAGE();
        END CATCH;
    END;

    SELECT @L_ERROR ID_ERROR,
           @L_MENSAJE MENSAJE,
           @L_CORRELATIVO VALOR;
END;

GO
