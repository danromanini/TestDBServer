create database TestDBServer

USE [TestDBServer]
GO
/****** Object:  Table [dbo].[tbl_Lancamentos]    Script Date: 09/07/2019 21:23:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Lancamentos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Lancamento] [varchar](100) NULL,
	[TipoLancamento] [varchar](20) NULL,
	[Conta] [int] NULL,
	[Valor] [decimal](24, 2) NULL,
 CONSTRAINT [PK_tbl_Lancamentos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
