if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_INTER_FA_R_FORMA_APROVECHAMIENTO]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[INTER_FA_R] DROP CONSTRAINT FK_INTER_FA_R_FORMA_APROVECHAMIENTO
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_VARIANTE_TECNOLOGICA_FORMA_APROVECHAMIENTO]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[VARIANTE_TECNOLOGICA] DROP CONSTRAINT FK_VARIANTE_TECNOLOGICA_FORMA_APROVECHAMIENTO
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PROCESO_FUENTE]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PROCESO] DROP CONSTRAINT FK_PROCESO_FUENTE
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_FORMA_APROVECHAMIENTO_PROCESO]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[FORMA_APROVECHAMIENTO] DROP CONSTRAINT FK_FORMA_APROVECHAMIENTO_PROCESO
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_INTER_FA_R_RECURSO]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[INTER_FA_R] DROP CONSTRAINT FK_INTER_FA_R_RECURSO
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_INTER_VT_R_RECURSO]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[INTER_VT_R] DROP CONSTRAINT FK_INTER_VT_R_RECURSO
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ARCHIVO_VARIANTE_TECNOLOGICA]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ARCHIVO] DROP CONSTRAINT FK_ARCHIVO_VARIANTE_TECNOLOGICA
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_DATOS_VARIABLE_VARIANTE_TECNOLOGICA]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[DATOS_VARIABLE] DROP CONSTRAINT FK_DATOS_VARIABLE_VARIANTE_TECNOLOGICA
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_INTER_VT_R_VARIANTE_TECNOLOGICA]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[INTER_VT_R] DROP CONSTRAINT FK_INTER_VT_R_VARIANTE_TECNOLOGICA
GO

/****** Objeto:  desencadenador dbo.faborrar  fecha de la secuencia de comandos: 26/01/2006 17:49:26 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[faborrar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [dbo].[faborrar]
GO

/****** Objeto:  desencadenador dbo.fuenteborrar  fecha de la secuencia de comandos: 26/01/2006 17:49:26 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fuenteborrar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [dbo].[fuenteborrar]
GO

/****** Objeto:  desencadenador dbo.grupoborrar  fecha de la secuencia de comandos: 26/01/2006 17:49:26 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[grupoborrar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [dbo].[grupoborrar]
GO

/****** Objeto:  desencadenador dbo.procesoborrar  fecha de la secuencia de comandos: 26/01/2006 17:49:26 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[procesoborrar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [dbo].[procesoborrar]
GO

/****** Objeto:  desencadenador dbo.rborrar  fecha de la secuencia de comandos: 26/01/2006 17:49:26 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[rborrar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [dbo].[rborrar]
GO

/****** Objeto: tabla [dbo].[ARCHIVO]    fecha de la secuencia de comandos: 26/01/2006 17:49:26 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ARCHIVO]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ARCHIVO]
GO

/****** Objeto: tabla [dbo].[DATOS_VARIABLE]    fecha de la secuencia de comandos: 26/01/2006 17:49:26 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DATOS_VARIABLE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DATOS_VARIABLE]
GO

/****** Objeto: tabla [dbo].[DIRECTORIO]    fecha de la secuencia de comandos: 26/01/2006 17:49:26 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DIRECTORIO]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DIRECTORIO]
GO

/****** Objeto: tabla [dbo].[FORMA_APROVECHAMIENTO]    fecha de la secuencia de comandos: 26/01/2006 17:49:26 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FORMA_APROVECHAMIENTO]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[FORMA_APROVECHAMIENTO]
GO

/****** Objeto: tabla [dbo].[FUENTE]    fecha de la secuencia de comandos: 26/01/2006 17:49:26 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FUENTE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[FUENTE]
GO

/****** Objeto: tabla [dbo].[GRUPO]    fecha de la secuencia de comandos: 26/01/2006 17:49:26 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GRUPO]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[GRUPO]
GO

/****** Objeto: tabla [dbo].[INTER_FA_R]    fecha de la secuencia de comandos: 26/01/2006 17:49:26 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INTER_FA_R]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[INTER_FA_R]
GO

/****** Objeto: tabla [dbo].[INTER_VT_R]    fecha de la secuencia de comandos: 26/01/2006 17:49:26 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INTER_VT_R]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[INTER_VT_R]
GO

/****** Objeto: tabla [dbo].[PROCESO]    fecha de la secuencia de comandos: 26/01/2006 17:49:26 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PROCESO]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PROCESO]
GO

/****** Objeto: tabla [dbo].[RECURSO]    fecha de la secuencia de comandos: 26/01/2006 17:49:26 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RECURSO]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[RECURSO]
GO

/****** Objeto: tabla [dbo].[USUARIO]    fecha de la secuencia de comandos: 26/01/2006 17:49:26 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[USUARIO]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[USUARIO]
GO

/****** Objeto: tabla [dbo].[VARIABLE_CARACTERISTICA]    fecha de la secuencia de comandos: 26/01/2006 17:49:26 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VARIABLE_CARACTERISTICA]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[VARIABLE_CARACTERISTICA]
GO

/****** Objeto: tabla [dbo].[VARIANTE_TECNOLOGICA]    fecha de la secuencia de comandos: 26/01/2006 17:49:26 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VARIANTE_TECNOLOGICA]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[VARIANTE_TECNOLOGICA]
GO

/****** Objeto: tabla [dbo].[ARCHIVO]    fecha de la secuencia de comandos: 26/01/2006 17:49:29 ******/
CREATE TABLE [dbo].[ARCHIVO] (
	[id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[fecha] [datetime] NULL ,
	[autor] [varchar] (255) COLLATE Modern_Spanish_CI_AS NULL ,
	[titulo] [varchar] (255) COLLATE Modern_Spanish_CI_AS NULL ,
	[descripcion] [varchar] (4000) COLLATE Modern_Spanish_CI_AS NULL ,
	[ruta] [varchar] (255) COLLATE Modern_Spanish_CI_AS NULL ,
	[fuente_id] [numeric](10, 0) NULL ,
	[recurso_id] [numeric](10, 0) NULL ,
	[form_aprov_id] [numeric](10, 0) NULL ,
	[var_tecn_id] [numeric](10, 0) NULL ,
	[proceso_id] [numeric](10, 0) NULL 
) ON [PRIMARY]
GO

/****** Objeto: tabla [dbo].[DATOS_VARIABLE]    fecha de la secuencia de comandos: 26/01/2006 17:49:29 ******/
CREATE TABLE [dbo].[DATOS_VARIABLE] (
	[id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[fecha] [datetime] NULL ,
	[responsable] [varchar] (255) COLLATE Modern_Spanish_CI_AS NULL ,
	[valor] [varchar] (255) COLLATE Modern_Spanish_CI_AS NULL ,
	[criterio] [varchar] (255) COLLATE Modern_Spanish_CI_AS NULL ,
	[descripcion] [varchar] (7000) COLLATE Modern_Spanish_CI_AS NULL ,
	[fuente] [varchar] (1000) COLLATE Modern_Spanish_CI_AS NULL ,
	[var_tecn_id] [numeric](10, 0) NULL ,
	[recurso_id] [numeric](10, 0) NULL ,
	[form_aprov_id] [numeric](10, 0) NULL ,
	[fuente_id] [numeric](10, 0) NULL ,
	[proceso_id] [numeric](10, 0) NULL ,
	[var_car_id] [numeric](10, 0) NULL 
) ON [PRIMARY]
GO

/****** Objeto: tabla [dbo].[DIRECTORIO]    fecha de la secuencia de comandos: 26/01/2006 17:49:29 ******/
CREATE TABLE [dbo].[DIRECTORIO] (
	[id] [int] NOT NULL ,
	[ruta] [varchar] (1000) COLLATE Modern_Spanish_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Objeto: tabla [dbo].[FORMA_APROVECHAMIENTO]    fecha de la secuencia de comandos: 26/01/2006 17:49:30 ******/
CREATE TABLE [dbo].[FORMA_APROVECHAMIENTO] (
	[id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[nombre] [varchar] (100) COLLATE Modern_Spanish_CI_AS NULL ,
	[descripcion] [varchar] (7000) COLLATE Modern_Spanish_CI_AS NOT NULL ,
	[proceso_id] [numeric](10, 0) NULL 
) ON [PRIMARY]
GO

/****** Objeto: tabla [dbo].[FUENTE]    fecha de la secuencia de comandos: 26/01/2006 17:49:30 ******/
CREATE TABLE [dbo].[FUENTE] (
	[id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[nombre] [varchar] (100) COLLATE Modern_Spanish_CI_AS NOT NULL ,
	[descripcion] [varchar] (7000) COLLATE Modern_Spanish_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Objeto: tabla [dbo].[GRUPO]    fecha de la secuencia de comandos: 26/01/2006 17:49:30 ******/
CREATE TABLE [dbo].[GRUPO] (
	[id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[nombre] [varchar] (100) COLLATE Modern_Spanish_CI_AS NOT NULL ,
	[descripcion] [varchar] (7000) COLLATE Modern_Spanish_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Objeto: tabla [dbo].[INTER_FA_R]    fecha de la secuencia de comandos: 26/01/2006 17:49:30 ******/
CREATE TABLE [dbo].[INTER_FA_R] (
	[id_fa] [numeric](10, 0) NOT NULL ,
	[id_recurso] [numeric](10, 0) NOT NULL 
) ON [PRIMARY]
GO

/****** Objeto: tabla [dbo].[INTER_VT_R]    fecha de la secuencia de comandos: 26/01/2006 17:49:30 ******/
CREATE TABLE [dbo].[INTER_VT_R] (
	[id_vt] [numeric](10, 0) NOT NULL ,
	[id_recurso] [numeric](10, 0) NOT NULL 
) ON [PRIMARY]
GO

/****** Objeto: tabla [dbo].[PROCESO]    fecha de la secuencia de comandos: 26/01/2006 17:49:30 ******/
CREATE TABLE [dbo].[PROCESO] (
	[id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[nombre] [varchar] (100) COLLATE Modern_Spanish_CI_AS NOT NULL ,
	[descripcion] [varchar] (7000) COLLATE Modern_Spanish_CI_AS NULL ,
	[fuente_id] [numeric](10, 0) NULL 
) ON [PRIMARY]
GO

/****** Objeto: tabla [dbo].[RECURSO]    fecha de la secuencia de comandos: 26/01/2006 17:49:30 ******/
CREATE TABLE [dbo].[RECURSO] (
	[id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[nombre] [varchar] (255) COLLATE Modern_Spanish_CI_AS NOT NULL ,
	[descripcion] [varchar] (7000) COLLATE Modern_Spanish_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Objeto: tabla [dbo].[USUARIO]    fecha de la secuencia de comandos: 26/01/2006 17:49:30 ******/
CREATE TABLE [dbo].[USUARIO] (
	[id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[login] [varchar] (50) COLLATE Modern_Spanish_CS_AS NOT NULL ,
	[perfil] [varchar] (1) COLLATE Modern_Spanish_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Objeto: tabla [dbo].[VARIABLE_CARACTERISTICA]    fecha de la secuencia de comandos: 26/01/2006 17:49:30 ******/
CREATE TABLE [dbo].[VARIABLE_CARACTERISTICA] (
	[id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[nombre] [varchar] (255) COLLATE Modern_Spanish_CI_AS NOT NULL ,
	[unidad] [varchar] (255) COLLATE Modern_Spanish_CI_AS NULL ,
	[grupo_id] [numeric](10, 0) NOT NULL 
) ON [PRIMARY]
GO

/****** Objeto: tabla [dbo].[VARIANTE_TECNOLOGICA]    fecha de la secuencia de comandos: 26/01/2006 17:49:30 ******/
CREATE TABLE [dbo].[VARIANTE_TECNOLOGICA] (
	[id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[nombre] [nvarchar] (255) COLLATE Modern_Spanish_CI_AS NOT NULL ,
	[descripcion] [varchar] (7000) COLLATE Modern_Spanish_CI_AS NULL ,
	[form_aprov_id] [numeric](10, 0) NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ARCHIVO] WITH NOCHECK ADD 
	CONSTRAINT [PK_rrrrr] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[DATOS_VARIABLE] WITH NOCHECK ADD 
	CONSTRAINT [PK_DATOS_VARIABLE] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[DIRECTORIO] WITH NOCHECK ADD 
	CONSTRAINT [PK_DIRECTORIO] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[FORMA_APROVECHAMIENTO] WITH NOCHECK ADD 
	CONSTRAINT [PK_FORMA_APROVECHAMIENTO] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[FUENTE] WITH NOCHECK ADD 
	CONSTRAINT [PK_FUENTE] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[GRUPO] WITH NOCHECK ADD 
	CONSTRAINT [PK_GRUPO] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[INTER_FA_R] WITH NOCHECK ADD 
	CONSTRAINT [PK_inter1] PRIMARY KEY  CLUSTERED 
	(
		[id_fa],
		[id_recurso]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[INTER_VT_R] WITH NOCHECK ADD 
	CONSTRAINT [PK_intervt] PRIMARY KEY  CLUSTERED 
	(
		[id_vt],
		[id_recurso]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[PROCESO] WITH NOCHECK ADD 
	CONSTRAINT [PK_PROCESO] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[RECURSO] WITH NOCHECK ADD 
	CONSTRAINT [PK_rr] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[USUARIO] WITH NOCHECK ADD 
	CONSTRAINT [PK_USUARIO] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[VARIABLE_CARACTERISTICA] WITH NOCHECK ADD 
	CONSTRAINT [PK_vc] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[VARIANTE_TECNOLOGICA] WITH NOCHECK ADD 
	CONSTRAINT [PK_tabla1] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ARCHIVO] ADD 
	CONSTRAINT [FK_ARCHIVO_VARIANTE_TECNOLOGICA] FOREIGN KEY 
	(
		[var_tecn_id]
	) REFERENCES [dbo].[VARIANTE_TECNOLOGICA] (
		[id]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[DATOS_VARIABLE] ADD 
	CONSTRAINT [FK_DATOS_VARIABLE_VARIANTE_TECNOLOGICA] FOREIGN KEY 
	(
		[var_tecn_id]
	) REFERENCES [dbo].[VARIANTE_TECNOLOGICA] (
		[id]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[FORMA_APROVECHAMIENTO] ADD 
	CONSTRAINT [FK_FORMA_APROVECHAMIENTO_PROCESO] FOREIGN KEY 
	(
		[proceso_id]
	) REFERENCES [dbo].[PROCESO] (
		[id]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[INTER_FA_R] ADD 
	CONSTRAINT [FK_INTER_FA_R_FORMA_APROVECHAMIENTO] FOREIGN KEY 
	(
		[id_fa]
	) REFERENCES [dbo].[FORMA_APROVECHAMIENTO] (
		[id]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_INTER_FA_R_RECURSO] FOREIGN KEY 
	(
		[id_recurso]
	) REFERENCES [dbo].[RECURSO] (
		[id]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[INTER_VT_R] ADD 
	CONSTRAINT [FK_INTER_VT_R_RECURSO] FOREIGN KEY 
	(
		[id_vt]
	) REFERENCES [dbo].[RECURSO] (
		[id]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_INTER_VT_R_VARIANTE_TECNOLOGICA] FOREIGN KEY 
	(
		[id_vt]
	) REFERENCES [dbo].[VARIANTE_TECNOLOGICA] (
		[id]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[PROCESO] ADD 
	CONSTRAINT [FK_PROCESO_FUENTE] FOREIGN KEY 
	(
		[fuente_id]
	) REFERENCES [dbo].[FUENTE] (
		[id]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[VARIANTE_TECNOLOGICA] ADD 
	CONSTRAINT [FK_VARIANTE_TECNOLOGICA_FORMA_APROVECHAMIENTO] FOREIGN KEY 
	(
		[form_aprov_id]
	) REFERENCES [dbo].[FORMA_APROVECHAMIENTO] (
		[id]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** Objeto:  desencadenador dbo.faborrar  fecha de la secuencia de comandos: 26/01/2006 17:49:31 ******/

/****** Objeto:  desencadenador dbo.faborrar  fecha de la secuencia de comandos: 26/01/2006 17:13:26 ******/
CREATE TRIGGER faborrar ON dbo.FORMA_APROVECHAMIENTO
FOR DELETE 
AS 
DECLARE @FAID NUMERIC(9)
SELECT @FAID = (SELECT id FROM Deleted)
delete ARCHIVO where ARCHIVO.form_aprov_id = @FAID
delete DATOS_VARIABLE where DATOS_VARIABLE.form_aprov_id = @FAID

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** Objeto:  desencadenador dbo.fuenteborrar  fecha de la secuencia de comandos: 26/01/2006 17:49:31 ******/

/****** Objeto:  desencadenador dbo.fuenteborrar  fecha de la secuencia de comandos: 26/01/2006 17:13:26 ******/
CREATE TRIGGER fuenteborrar ON dbo.FUENTE
FOR DELETE 
AS 
DECLARE @FID NUMERIC(9)
SELECT @FID = (SELECT id FROM Deleted)
delete ARCHIVO where ARCHIVO.fuente_id = @FID
delete DATOS_VARIABLE where DATOS_VARIABLE.fuente_id = @FID

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** Objeto:  desencadenador dbo.grupoborrar  fecha de la secuencia de comandos: 26/01/2006 17:49:31 ******/

/****** Objeto:  desencadenador dbo.grupoborrar  fecha de la secuencia de comandos: 26/01/2006 17:13:27 ******/
CREATE TRIGGER grupoborrar ON dbo.GRUPO
FOR DELETE 
AS 
DECLARE @GID NUMERIC(9)
SELECT @GID = (SELECT id FROM Deleted)
delete VARIABLE_CARACTERISTICA 
where VARIABLE_CARACTERISTICA.grupo_id = @GID


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** Objeto:  desencadenador dbo.procesoborrar  fecha de la secuencia de comandos: 26/01/2006 17:49:31 ******/

/****** Objeto:  desencadenador dbo.procesoborrar  fecha de la secuencia de comandos: 26/01/2006 17:13:27 ******/
CREATE TRIGGER procesoborrar ON PROCESO
FOR DELETE 
AS 
DECLARE @PID NUMERIC(9)
SELECT @PID = (SELECT id FROM Deleted)
delete ARCHIVO where ARCHIVO.proceso_id = @PID
delete DATOS_VARIABLE where DATOS_VARIABLE.proceso_id = @PID

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** Objeto:  desencadenador dbo.rborrar  fecha de la secuencia de comandos: 26/01/2006 17:49:31 ******/

/****** Objeto:  desencadenador dbo.rborrar  fecha de la secuencia de comandos: 26/01/2006 17:13:27 ******/
CREATE TRIGGER rborrar ON dbo.RECURSO
FOR DELETE 
AS 
DECLARE @RID NUMERIC(9)
SELECT @RID = (SELECT id FROM Deleted)
delete ARCHIVO where ARCHIVO.recurso_id = @RID
delete DATOS_VARIABLE where DATOS_VARIABLE.recurso_id = @RID

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

insert into directorio values (1, 'c:')
insert into usuario values ('administrador', 'a')