USE [MVC_DEMO]
GO

/****** Object:  StoredProcedure [dbo].[DeleteEmployee]    Script Date: 1/19/2022 00:16:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[DeleteEmployee] (@ID int)
as 
begin 
	delete from dbo.Employee where id = @ID
end
GO

