# LIBRERIAS INSTALADAS
1. npm install sweetalert2

# COMANDOS NPM EJECUTADOS
1. ng g c components/inicio --skipTests=true <!-- CREA EL COMPONENTE inicio -->
2. ng g c components/editar --skipTests=true <!-- CREA EL COMPONENTE editar -->
3. ng g s servicio/crudServicio <!-- CREAR EL ARCHIVO SERVICIO -->
4. ng serve -o <!-- COMPILAR LA APLICACION Y VISUALIZA EN EL NAVEGADOR -->
5. DESPUES DE CLONAR EL REPOSITORIO EJECUTAR EL SIGIENTE COMANDO: npm install

# SCRIPT DE BASE DE DATOS A GENERAR
USE [AngularChat]
GO
/****** Object:  Table [dbo].[Value]    Script Date: 27/03/2021 3:47:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Value](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value1] [varchar](50) NULL,
	[Value2] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[DeleteValue]    Script Date: 27/03/2021 3:47:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteValue]
@Id int
as
begin
	delete from [Value] where Id = @Id
end

GO
/****** Object:  StoredProcedure [dbo].[GetAllValues]    Script Date: 27/03/2021 3:47:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllValues]
as
begin
	select * from Value
end
GO
/****** Object:  StoredProcedure [dbo].[GetValueId]    Script Date: 27/03/2021 3:47:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetValueId]
@Id int
as
begin
	select * from [value] where Id = @Id
end

GO
/****** Object:  StoredProcedure [dbo].[InsertValue]    Script Date: 27/03/2021 3:47:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertValue]
@Value1 varchar(50),
@Value2 varchar(50),
@Return int output
as
begin
	insert into [Value](value1, value2)
	values(@Value1, @Value2)

	set @Return = SCOPE_IDENTITY()

end
GO
/****** Object:  StoredProcedure [dbo].[UpdateValue]    Script Date: 27/03/2021 3:47:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateValue]
@Id int,
@Value1 varchar(50),
@Value2 varchar(50)
AS
BEGIN
	update Value set Value1 = @Value1,
		Value2 = @Value2
	where Id = @Id
END
GO
