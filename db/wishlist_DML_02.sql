USE Senai_Wishlist;
GO

INSERT INTO Usuarios (Email, Senha)
VALUES ('vini@vini.com', '123'),
	   ('pedrob@pedrob.com', '123'),
	   ('claudiomir@claudiomir.com', '123'),
	   ('pedrof@pedrof.com', '123');
GO

INSERT INTO Desejos (Descricao, DataCriacao, IdUsuario)
VALUES ('Me formar', GETDATE() , 2),
	   ('Ser vacinado', GETDATE(), 1),
	   ('Pegar challenger no lol', GETDATE(), 3);
GO