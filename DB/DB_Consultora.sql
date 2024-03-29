USE [DB_Consultora]
GO
/****** Object:  Table [dbo].[Proyecto]    Script Date: 9/25/2019 4:44:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proyecto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](300) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteProyecto]    Script Date: 9/25/2019 4:44:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteProyecto]   
@Id INT
AS
BEGIN
 DELETE FROM Proyecto WHERE Id = @Id 
END


GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllProyects]    Script Date: 9/25/2019 4:44:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllProyects]   
AS
BEGIN
  SELECT *
  FROM DB_Consultora.dbo.Proyecto
end
GO
/****** Object:  StoredProcedure [dbo].[SP_GetProyectById]    Script Date: 9/25/2019 4:44:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetProyectById]   
@Id as int
AS
BEGIN
  SELECT *
  FROM DB_Consultora.dbo.Proyecto AS A
  WHERE A.Id = @Id
END


GO
/****** Object:  StoredProcedure [dbo].[SP_InsertProyecto]    Script Date: 9/25/2019 4:44:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_InsertProyecto]   
@Titulo varchar(300),
@Descripcion varchar(MAX)
AS
BEGIN
 INSERT INTO Proyecto([Titulo],[Descripcion])VALUES(@Titulo,@Descripcion)
END


GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateProyecto]    Script Date: 9/25/2019 4:44:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateProyecto]   
@Id INT,
@Titulo VARCHAR(300),
@Descripcion VARCHAR(max)
AS
BEGIN
 UPDATE A
 SET A.Titulo = @Titulo , A.Descripcion = @Descripcion 
 FROM Proyecto AS A
 WHERE Id = @Id 
END


GO
