USE [MVC_DEMO]
GO

/****** Object:  StoredProcedure [dbo].[GetEmployeeDetails]    Script Date: 1/19/2022 00:16:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[GetEmployeeDetails]
as 
begin
	select * from dbo.Employee
end
GO

