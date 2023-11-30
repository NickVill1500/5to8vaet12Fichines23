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
CALL altaFichin (0, 'Space Invaders', '1978/04/01', 150.0);
CALL altaFichin (1,'The Simpsons Arcade Game', '1991/03/04', 200.0);
CALL altaFichin (2, 'Metal Slug', '1996/04/19', 200.0);
CALL altaFichin (3, 'Metal Slug 2', '1998/02/23', 200.0);
CALL altaFichin (4, 'Metal Slug 3', '2000/03/23', 200.0);
CALL altaFichin (5, 'Street Fighter', '1987/08/12', 250.0);
COMMIT;