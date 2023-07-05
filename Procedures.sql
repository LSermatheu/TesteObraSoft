USE TESTE_OBRASOFT
GO

CREATE PROCEDURE ProcedureIncluir 
(
	@nome VARCHAR(MAX)
	,@endereco VARCHAR(MAX)
	,@telFixo VARCHAR(11)
	,@telCelular VARCHAR(11)
	,@email VARCHAR(MAX)
	,@sexo VARCHAR(10)
	,@estadoCivil VARCHAR(15)
	,@salario DECIMAL(7,2)
)
AS
BEGIN
	INSERT INTO Pessoa           
    VALUES (
		@nome
        ,@endereco
        ,@telFixo
        ,@telCelular
        ,@email
        ,@sexo
        ,@estadoCivil
        ,@salario
	)
END	
GO

CREATE PROCEDURE ProcedureAlterar
(
	@id INT
	,@nome VARCHAR(MAX)
	,@endereco VARCHAR(MAX)
	,@telFixo VARCHAR(11)
	,@telCelular VARCHAR(11)
	,@email VARCHAR(MAX)
	,@sexo VARCHAR(10)
	,@estadoCivil VARCHAR(15)
	,@salario DECIMAL(7,2)
)
AS
BEGIN
	UPDATE Pessoa           
    SET Nome = @nome
        ,Endereco = @endereco
        ,TelefoneFixo = @telFixo
        ,TelefoneCelular = @telCelular
        ,Email = @email
        ,Sexo = @sexo
        ,EstadoCivil = @estadoCivil
        ,Salario = @salario
	WHERE Id = @id
END	
GO

CREATE PROCEDURE ProcedureConsultar
(
	@id INT
)
AS
BEGIN
	SELECT * FROM Pessoa
	WHERE Id = @id
END
GO

CREATE PROCEDURE ProcedureListar
AS
BEGIN
	SELECT * FROM Pessoa
END
GO

CREATE PROCEDURE ProcedureExcluir
(
	@id INT
)
AS
BEGIN
	DELETE FROM Pessoa
	WHERE Id = @id
END
GO