CREATE TABLE [dbo].[ARCHIVO] (
	[id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[fecha] [varchar] (50) COLLATE Modern_Spanish_CI_AS NULL ,
	[autor] [varchar] (50) COLLATE Modern_Spanish_CI_AS NULL ,
	[titulo] [varchar] (100) COLLATE Modern_Spanish_CI_AS NULL ,
	[criterio] [varchar] (100) COLLATE Modern_Spanish_CI_AS NULL ,
	[ruta] [varchar] (500) COLLATE Modern_Spanish_CI_AS NULL ,
	[fuente_id] [numeric](10, 0) NULL ,
	[dat_var_id] [numeric](10, 0) NULL ,
	[recurso_id] [numeric](10, 0) NULL ,
	[form_aprov_id] [numeric](10, 0) NULL ,
	[var_tecn_id] [numeric](10, 0) NULL ,
	[proceso_id] [numeric](10, 0) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DATOS_VARIABLE] (
	[id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[fecha] [varchar] (50) COLLATE Modern_Spanish_CI_AS NOT NULL ,
	[responsable] [varchar] (50) COLLATE Modern_Spanish_CI_AS NOT NULL ,
	[valor] [varchar] (50) COLLATE Modern_Spanish_CI_AS NULL ,
	[criterio] [varchar] (100) COLLATE Modern_Spanish_CI_AS NULL ,
	[descripcion] [varchar] (7000) COLLATE Modern_Spanish_CI_AS NULL ,
	[fuente] [varchar] (100) COLLATE Modern_Spanish_CI_AS NULL ,
	[var_tecn_id] [numeric](10, 0) NULL ,
	[recurso_id] [numeric](10, 0) NULL ,
	[form_aprov_id] [numeric](10, 0) NULL ,
	[var_carac_id] [numeric](10, 0) NULL ,
	[fuente_id] [numeric](10, 0) NULL ,
	[proceso_id] [numeric](10, 0) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[FORMA_APROVECHAMIENTO] (
	[id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[nombre] [varchar] (100) COLLATE Modern_Spanish_CI_AS NULL ,
	[descripcion] [varchar] (7000) COLLATE Modern_Spanish_CI_AS NOT NULL ,
	[proceso_id] [numeric](10, 0) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[FORMA_VARIANTE] (
	[id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[nombre] [varchar] (100) COLLATE Modern_Spanish_CI_AS NOT NULL ,
	[form_aprov_id] [numeric](10, 0) NULL ,
	[var_tecn_id] [numeric](10, 0) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[FUENTE] (
	[id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[nombre] [varchar] (100) COLLATE Modern_Spanish_CI_AS NOT NULL ,
	[descripcion] [varchar] (7000) COLLATE Modern_Spanish_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[GRUPO] (
	[id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[nombre] [varchar] (100) COLLATE Modern_Spanish_CI_AS NOT NULL ,
	[descripcion] [varchar] (7000) COLLATE Modern_Spanish_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PROCESO] (
	[id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[nombre] [varchar] (100) COLLATE Modern_Spanish_CI_AS NOT NULL ,
	[descripcion] [varchar] (7000) COLLATE Modern_Spanish_CI_AS NULL ,
	[fuente_id] [numeric](10, 0) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RECURSO] (
	[id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[nombre] [varchar] (100) COLLATE Modern_Spanish_CI_AS NOT NULL ,
	[descripcion] [varchar] (7000) COLLATE Modern_Spanish_CI_AS NULL ,
	[var_tecn_id] [numeric](10, 0) NULL ,
	[form_aprov_id] [numeric](10, 0) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[VARIABLE_CARACTERISTICA] (
	[id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[nombre] [varchar] (100) COLLATE Modern_Spanish_CI_AS NOT NULL ,
	[unidad] [varchar] (50) COLLATE Modern_Spanish_CI_AS NULL ,
	[grupo_id] [numeric](10, 0) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[VARIANTE_TECNOLOGICA] (
	[id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[nombre] [varchar] (100) COLLATE Modern_Spanish_CI_AS NOT NULL ,
	[descripcion] [varchar] (7000) COLLATE Modern_Spanish_CI_AS NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ARCHIVO] WITH NOCHECK ADD 
	CONSTRAINT [PK_ARCHIVO] PRIMARY KEY  CLUSTERED 
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

ALTER TABLE [dbo].[FORMA_APROVECHAMIENTO] WITH NOCHECK ADD 
	CONSTRAINT [PK_FORMA_APROVECHAMIENTO] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[FORMA_VARIANTE] WITH NOCHECK ADD 
	CONSTRAINT [PK_FORMA_VARIANTE] PRIMARY KEY  CLUSTERED 
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

ALTER TABLE [dbo].[PROCESO] WITH NOCHECK ADD 
	CONSTRAINT [PK_PROCESO] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[RECURSO] WITH NOCHECK ADD 
	CONSTRAINT [PK_RECURSO] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[VARIABLE_CARACTERISTICA] WITH NOCHECK ADD 
	CONSTRAINT [PK_VARIABLE_CARACTERISTICA] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[VARIANTE_TECNOLOGICA] WITH NOCHECK ADD 
	CONSTRAINT [PK_VARIANTE_TECNOLOGICA] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ARCHIVO] ADD 
	CONSTRAINT [FK_ARCHIVO_DATOS_VARIABLE] FOREIGN KEY 
	(
		[dat_var_id]
	) REFERENCES [dbo].[DATOS_VARIABLE] (
		[id]
	),
	CONSTRAINT [FK_ARCHIVO_FORMA_APROVECHAMIENTO] FOREIGN KEY 
	(
		[form_aprov_id]
	) REFERENCES [dbo].[FORMA_APROVECHAMIENTO] (
		[id]
	),
	CONSTRAINT [FK_ARCHIVO_FUENTE] FOREIGN KEY 
	(
		[fuente_id]
	) REFERENCES [dbo].[FUENTE] (
		[id]
	),
	CONSTRAINT [FK_ARCHIVO_PROCESO] FOREIGN KEY 
	(
		[proceso_id]
	) REFERENCES [dbo].[PROCESO] (
		[id]
	),
	CONSTRAINT [FK_ARCHIVO_RECURSO] FOREIGN KEY 
	(
		[recurso_id]
	) REFERENCES [dbo].[RECURSO] (
		[id]
	),
	CONSTRAINT [FK_ARCHIVO_VARIANTE_TECNOLOGICA] FOREIGN KEY 
	(
		[var_tecn_id]
	) REFERENCES [dbo].[VARIANTE_TECNOLOGICA] (
		[id]
	)
GO

ALTER TABLE [dbo].[DATOS_VARIABLE] ADD 
	CONSTRAINT [FK_DATOS_VARIABLE_FORMA_APROVECHAMIENTO] FOREIGN KEY 
	(
		[form_aprov_id]
	) REFERENCES [dbo].[FORMA_APROVECHAMIENTO] (
		[id]
	),
	CONSTRAINT [FK_DATOS_VARIABLE_FUENTE] FOREIGN KEY 
	(
		[fuente_id]
	) REFERENCES [dbo].[FUENTE] (
		[id]
	),
	CONSTRAINT [FK_DATOS_VARIABLE_PROCESO] FOREIGN KEY 
	(
		[proceso_id]
	) REFERENCES [dbo].[PROCESO] (
		[id]
	),
	CONSTRAINT [FK_DATOS_VARIABLE_RECURSO] FOREIGN KEY 
	(
		[recurso_id]
	) REFERENCES [dbo].[RECURSO] (
		[id]
	),
	CONSTRAINT [FK_DATOS_VARIABLE_VARIABLE_CARACTERISTICA] FOREIGN KEY 
	(
		[var_carac_id]
	) REFERENCES [dbo].[VARIABLE_CARACTERISTICA] (
		[id]
	),
	CONSTRAINT [FK_DATOS_VARIABLE_VARIANTE_TECNOLOGICA] FOREIGN KEY 
	(
		[var_tecn_id]
	) REFERENCES [dbo].[VARIANTE_TECNOLOGICA] (
		[id]
	)
GO

ALTER TABLE [dbo].[FORMA_APROVECHAMIENTO] ADD 
	CONSTRAINT [FK_FORMA_APROVECHAMIENTO_PROCESO] FOREIGN KEY 
	(
		[proceso_id]
	) REFERENCES [dbo].[PROCESO] (
		[id]
	)
GO

ALTER TABLE [dbo].[FORMA_VARIANTE] ADD 
	CONSTRAINT [FK_FORMA_VARIANTE_FORMA_APROVECHAMIENTO] FOREIGN KEY 
	(
		[form_aprov_id]
	) REFERENCES [dbo].[FORMA_APROVECHAMIENTO] (
		[id]
	),
	CONSTRAINT [FK_FORMA_VARIANTE_VARIANTE_TECNOLOGICA] FOREIGN KEY 
	(
		[var_tecn_id]
	) REFERENCES [dbo].[VARIANTE_TECNOLOGICA] (
		[id]
	)
GO

ALTER TABLE [dbo].[PROCESO] ADD 
	CONSTRAINT [FK_PROCESO_FUENTE] FOREIGN KEY 
	(
		[fuente_id]
	) REFERENCES [dbo].[FUENTE] (
		[id]
	)
GO

ALTER TABLE [dbo].[RECURSO] ADD 
	CONSTRAINT [FK_RECURSO_FORMA_APROVECHAMIENTO] FOREIGN KEY 
	(
		[form_aprov_id]
	) REFERENCES [dbo].[FORMA_APROVECHAMIENTO] (
		[id]
	),
	CONSTRAINT [FK_RECURSO_VARIANTE_TECNOLOGICA] FOREIGN KEY 
	(
		[var_tecn_id]
	) REFERENCES [dbo].[VARIANTE_TECNOLOGICA] (
		[id]
	)
GO

ALTER TABLE [dbo].[VARIABLE_CARACTERISTICA] ADD 
	CONSTRAINT [FK_VARIABLE_CARACTERISTICA_GRUPO] FOREIGN KEY 
	(
		[grupo_id]
	) REFERENCES [dbo].[GRUPO] (
		[id]
	)
GO

