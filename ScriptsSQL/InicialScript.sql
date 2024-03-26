USE [master]
GO

CREATE DATABASE [BrasilApiClima]
GO

USE [BrasilApiClima]
GO


IF OBJECT_ID(N'dbo.Clima', N'U') IS NULL
CREATE TABLE dbo.Clima (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Data] DATETIME NOT NULL,
    [Condicao] [varchar](255) NOT NULL,
    [Min] INT NOT NULL,
    [Max] INT NOT NULL,
    [IndiceUv] FLOAT NOT NULL,
    [CondicaoDesc] [varchar](255) ,
    [CreatedOn] DATETIME NOT NULL,
)ON [PRIMARY]
GO


IF OBJECT_ID(N'dbo.CidadeClima', N'U') IS NULL
CREATE TABLE dbo.CidadeClima (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [IdClima] INT NOT NULL,
    [Cidade] [varchar](255) NOT NULL,
    [Estado] [varchar](255) NOT NULL,
    [AtualizadoEm] DATETIME NOT NULL,
    [RotaRequest] [nvarchar](500) NOT NULL,
    [CreatedOn] DATETIME NOT NULL,
    CONSTRAINT FK_Clima_ID FOREIGN KEY (IdClima) REFERENCES [Clima]([Id])
)ON [PRIMARY]
GO


IF OBJECT_ID(N'dbo.AeroportoClima', N'U') IS NULL
CREATE TABLE dbo.AeroportoClima (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [CodigoAeroporto] [varchar](255) NOT NULL,
    [AtualizadoEm] DATETIME NOT NULL,
    [PressaoAtmosferica] INT NOT NULL,
    [Visibilidade] [varchar](255) NOT NULL,
    [Vento] INT NOT NULL,
    [DirecaoVento] INT NOT NULL,
    [Umidade] INT NOT NULL,
    [Condicao] [varchar](255) ,
    [CondicaoDesc] [varchar](255),
    [Temp] FLOAT NOT NULL,
    [RotaRequest][nvarchar](500) NOT NULL,
    [CreatedOn] DATETIME NOT NULL,
)ON [PRIMARY]
GO


USE [BrasilApiClima]
GO

INSERT INTO [dbo].[AeroportoClima]
           ([CodigoAeroporto]
           ,[AtualizadoEm]
           ,[PressaoAtmosferica]
           ,[Visibilidade]
           ,[Vento]
           ,[DirecaoVento]
           ,[Umidade]
           ,[Condicao]
           ,[CondicaoDesc]
           ,[Temp]
           ,[RotaRequest]
           ,[CreatedOn])
     VALUES
           (
		   'SBAR'
           ,'2024-03-25T12:00:00.400Z'
           ,1010
           ,'>10000'
           ,22
           ,80
           ,75
           ,'ps'
           ,'Predomínio de Sol'
           ,31
           ,'https://brasilapi.com.br/api/cptec/v1/clima/aeroporto/SBAR'
           ,GETDATE()
		   )
GO

