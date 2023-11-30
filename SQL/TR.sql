-- Active: 1691412339871@@127.0.0.1@3306
-- Realizar un trigger para que al dar de alta una fila en recarga, impacte automáticamente en el saldo del cliente.
CREATE TRIGGER TriggaRecarga AFTER INSERT ON Recarga
FOR EACH ROW
BEGIN
    CALL altaRecarga (NEW.idRecarga, NEW.idTarjeta, NEW.fechayHora, NEW.montoRecargado);
END

-- Realizar un trigger para que al momento de hacer un gasto en el saldo del cliente, se verifique que tenga el saldo necesario para ese gasto; en caso contrario se debe mostrar la leyenda ‘Saldo insuficiente’ y no permitir la operación.
CREATE TRIGGER TriggaNoSaldo BEFORE INSERT ON JuegaFichin
FOR EACH ROW
BEGIN
    IF (EXISTS (SELECT *
        FROM Tarjeta
        INNER JOIN JuegaFichin ON Tarjeta.idTarjeta = JuegaFichin.idTarjeta
        INNER JOIN Fichin ON JuegaFichin.idFichin = Fichin.idFichin
        WHERE saldo < precio)) THEN
        SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'Saldo insuficiente';
    END IF;
END