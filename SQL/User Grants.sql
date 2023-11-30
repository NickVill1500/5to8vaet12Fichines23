SELECT 'Creando Usuarios y Permisos' AS 'Estado';
# Creacion de Usuarios
DROP USER IF EXISTS 'Administrador'@'localhost';
DROP USER IF EXISTS 'Gerente'@'%';
DROP USER IF EXISTS 'Cajero'@'10.3.45.%';
DROP USER IF EXISTS 'Cliente'@'%';

CREATE USER IF NOT EXISTS 'Administrador'@'localhost' IDENTIFIED BY 'pasword';
CREATE USER IF NOT EXISTS 'Gerente'@'%' IDENTIFIED BY 'pasword';
CREATE USER IF NOT EXISTS 'Cajero'@'10.3.45.%' IDENTIFIED BY 'pasword';
CREATE USER IF NOT EXISTS 'Cliente'@'%' IDENTIFIED BY 'pasword';

GRANT ALL ON 5to_Fichines.* TO 'Administrador'@'localhost';

GRANT SELECT, UPDATE, DELETE, INSERT ON 5to_Fichines.* TO 'Gerente'@'%';

GRANT INSERT ON 5to_Fichines.Tarjeta TO 'Cajero'@'10.3.45.%';
GRANT INSERT ON 5to_Fichines.Recarga TO 'Cajero'@'10.3.45.%';

GRANT SELECT ON 5to_Fichines.Tarjeta TO 'Cliente'@'%';
GRANT SELECT ON 5to_Fichines.Usuario TO 'Cliente'@'%';