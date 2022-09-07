CREATE  TABLE   FUNCIONARIO(
        IDFUNCIONARIO        UNIQUEIDENTIFIER  NOT NULL,
        NOME                 NVARCHAR(150)     NOT NULL,
        CPF                  NVARCHAR(11)      NOT NULL,
        MATRICULA            NVARCHAR(10)      NOT NULL,
        DATAADMISSAO         DATE              NOT NULL,
        DATACADASTRO         DATETIME          NOT NULL,
        DATAULTIMAALTERACAO  DATETIME          NOT NULL,
        PRIMARY KEY(IDFUNCIONARIO))
        GO

CREATE PROCEDURE SP_INSERT_FUNCIONARIO
            @NOME           NVARCHAR(150),
            @CPF            NVARCHAR(11),
            @MATRICULA      NVARCHAR(10),
            @DATAADMISSAO   DATE
AS
BEGIN
     BEGIN TRANSACTION
         INSERT INTO FUNCIONARIO(
                      IDFUNCIONARIO,
                      NOME,
                      CPF,
                      MATRICULA,
                      DATAADMISSAO,
                      DATACADASTRO,
                      DATAULTIMAALTERACAO) 
              VALUES(
                      NEWID(),
                      @NOME,
                      @CPF,
                      @MATRICULA,
                      @DATAADMISSAO,
                      GETDATE(),
                      GETDATE())
                COMMIT
END
GO


  
