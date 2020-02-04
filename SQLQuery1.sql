USE [aspnet-MVC_Login_B-20200128090916]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[SP_Retrieve_Role]

SELECT	@return_value as 'Return Value'

GO
