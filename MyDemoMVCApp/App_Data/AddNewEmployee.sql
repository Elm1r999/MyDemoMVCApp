USE [MVC_DEMO]
GO

/****** Object:  StoredProcedure [dbo].[AddNewEmployee]    Script Date: 1/19/2022 00:16:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[AddNewEmployee] 
(
	@first_name nvarchar(50),
	@last_name nvarchar(50),
	@email nvarchar(100),
	@department nvarchar(50),
	@job_position nvarchar(50)
)
as
begin
	insert into dbo.Employee(first_name,last_name,email,department,job_position) values (@first_name,@last_name,@email,@department,@job_position)
end
GO

