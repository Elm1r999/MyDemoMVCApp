USE [MVC_DEMO]
GO

/****** Object:  StoredProcedure [dbo].[UpdateEmployeeDetails]    Script Date: 1/19/2022 00:16:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[UpdateEmployeeDetails](
@id int,
@first_name nvarchar(50),
@last_name nvarchar(50),
@email nvarchar(50),
@department nvarchar(50),
@job_position nvarchar(50)
)
as
begin
	update dbo.Employee
	set first_name = @first_name, last_name = @last_name, email = @email, department = @department, job_position = @job_position
	where id = @id
end
GO

