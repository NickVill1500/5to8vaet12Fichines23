-- Active: 1686961781332@@127.0.0.1@3306@5to_fichines
DELIMITER ;
USE 5to_Fichines;
SELECT 'Preparando para Inserts' AS 'Estado';
SET FOREIGN_KEY_CHECKS=0;
	TRUNCATE TABLE Usuario;
	TRUNCATE TABLE Tarjeta;
	TRUNCATE TABLE Recarga;
	TRUNCATE TABLE Fichin;
	TRUNCATE TABLE JuegaFichin;
SET FOREIGN_KEY_CHECKS=1;

SELECT 'Rellenando Fichines' AS 'Estado';

START TRANSACTION;
CALL altaFichin (0, 'Space Invaders', '1978', 150.0);
CALL altaFichin (1,'The Simpsons Arcade Game', '1991', 200.0);
CALL altaFichin (2, 'Metal Slug', '1996', 200.0);
CALL altaFichin (3, 'Metal Slug 2', '1998', 200.0);
CALL altaFichin (4, 'Metal Slug 3', '2000', 200.0);
CALL altaFichin (5, 'Street Fighter', '1987', 250.0);

CALL RegistrarUsuario (11561816, 'Gerente','Uno','gerentefichin@gmail.com','gerente1504');
CALL RegistrarUsuario (45147808, 'Cajero', 'Uno','cajerofichin@gmail.com', 'cajero1504');
CALL RegistrarUsuario (48552069,'Cliente','Uno','clientefichin@gmail.com', 'cliente1504');
COMMIT;