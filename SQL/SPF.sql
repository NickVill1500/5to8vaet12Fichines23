-- Realizar los SP para dar de alta todas las entidades menos la tabla Cliente.

DELIMITER $$
DROP PROCEDURE IF EXISTS altaTarjeta $$
CREATE PROCEDURE altaTarjeta (unTTarjeta SMALLINT, unTDNI SMALLINT)
BEGIN
    INSERT INTO Tarjeta (idTarjeta, DNI, saldo)
        VALUES (unTTarjeta, unTDNI, 0);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaRecarga $$
CREATE PROCEDURE altaRecarga (unRecarga INT, unRTarjeta SMALLINT, unRFYH DATETIME, unMonto DECIMAL(5,2))
BEGIN
    INSERT INTO Recarga (idRecarga, idTarjeta, fechayHora, montoRecargado)
        VALUES (unRecarga, unRTarjeta, unRFYH, unMonto);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaFichin $$
CREATE PROCEDURE altaFichin (unFFichin TINYINT, unFNombre VARCHAR(45), unLanzamiento YEAR, unPrecio DECIMAL(5,2))
BEGIN
    INSERT INTO Fichin (idFichin, nombre, lanzamiento, precio)
        VALUES (unFFichin, unFNombre, unLanzamiento, unPrecio);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaJuegaFichin $$
CREATE PROCEDURE altaJuegaFichin (unJTarjeta SMALLINT, unJFichin TINYINT, unJFYH DATETIME, unAcopio DECIMAL(5,2))
BEGIN
    INSERT INTO JuegaFichin (idTarjeta, idFichin, fechayHora)
        VALUES (unJTarjeta, unJFichin, unJFYH);
END $$

-- Se pide hacer el SP ‘registrarCliente’ que reciba los datos del cliente. Es importante guardar encriptada la contraseña del cliente usando SHA256.

DELIMITER $$
DROP PROCEDURE IF EXISTS registrarUsuario $$
CREATE PROCEDURE registrarUsuario (unUDNI SMALLINT, unUNombre VARCHAR(45), unUApellido VARCHAR(45), unMail VARCHAR(45), unPasw CHAR(64))
BEGIN
    INSERT INTO Usuario (DNI, nombre, apellido, mail, pasword)
        VALUES (unUDNI, unUNombre, unUApellido, unMail, SHA256(unPasw,256));
END $$

-- Se pide hacer el SP ‘RecaudacionPara’ que reciba por parámetro un identificador de fichin, se debe devolver la ganancia que tuvo entre esas 2 fechas (inclusive).

DELIMITER $$
DROP PROCEDURE IF EXISTS RecaudacionPara $$
CREATE PROCEDURE RecaudacionPara (unIdFichin TINYINT, fyhInicio DATETIME, fyhFinal DATETIME)
BEGIN
    SELECT SUM(acopio)
    FROM JuegaFichin
    WHERE idFichin = unIdFichin
    AND fechayHora BETWEEN fyhInicio AND fyhFinal;
END $$

-- Se pide hacer el SP ‘Gastos’ que reciba por parámetro una identificación de cliente. El SP tiene que devolver fecha y hora, nombre del juego y consumo ($) que el cliente haya jugado, ordenado por fecha y hora descendentemente.

DELIMITER $$
DROP PROCEDURE IF EXISTS Gastos $$
CREATE PROCEDURE Gastos (unCDNI SMALLINT)
BEGIN
    SELECT JuegaFichin.fechayHora, Fichin.nombre, Fichin.precio
    FROM Fichin
    JOIN JuegaFichin USING (idFichin)
    JOIN Tarjeta USING (idTarjeta)
    WHERE DNI = unCDNI
    ORDER BY fechayHora DESC;
END $$