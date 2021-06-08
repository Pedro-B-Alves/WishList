USE Senai_Wishlist;
GO

SELECT * FROM Usuarios;
GO
SELECT * FROM Desejos;
GO

SELECT IdDesejo,
	   Descricao,
	   FORMAT(DataCriacao, 'd', 'pt-bt') [Data de Criação],
	   Email	   
FROM Desejos D
INNER JOIN Usuarios U
ON U.IdUsuario = D.IdUsuario;
GO

SELECT IdDesejo,
	   Descricao,
	   FORMAT(DataCriacao, 'd', 'pt-bt') [Data de Criação]	   ,
	   Email
FROM Usuarios U
INNER JOIN Desejos D
ON U.IdUsuario = D.IdUsuario
WHERE U.IdUsuario = 1;
GO