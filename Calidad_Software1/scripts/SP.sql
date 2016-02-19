CREATE PROCEDURE [dbo].[Sp_Validar_Usuario]
@nombre_usuario nvarchar(50),
@Password nvarchar(50)
AS
	 SELECT COUNT(*) FROM USUARIO WHERE NOMBRE= @nombre_usuario AND CONTRASENA = @Password;
RETURN 0