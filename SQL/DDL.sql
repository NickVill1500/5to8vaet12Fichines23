-- Active: 1686961781332@@127.0.0.1@3306
DROP DATABASE IF EXISTS 5to_Fichines;

CREATE DATABASE 5to_Fichines;

USE 5to_Fichines;
CREATE TABLE
    Usuario(
        DNI INT UNSIGNED NOT NULL,
        nombre VARCHAR(45) NOT NULL,
        apellido VARCHAR(45) NOT NULL,
        mail VARCHAR(45) NOT NULL,
        pasword CHAR(64) NOT NULL,
        PRIMARY KEY (DNI)
    );
CREATE TABLE
    Tarjeta(
        idTarjeta SMALLINT UNSIGNED NOT NULL,
        DNI INT UNSIGNED NOT NULL,
        saldo DECIMAL (5,2) NOT NULL,
        PRIMARY KEY (idTarjeta),
        CONSTRAINT fk_Tarjeta_Usuario FOREIGN KEY(DNI) REFERENCES Usuario(DNI)
    );
CREATE TABLE
    Recarga(
        idTarjeta SMALLINT UNSIGNED NOT NULL,
        fechayHora DATETIME NOT NULL,
        montoRecargado DECIMAL (5,2) NOT NULL,
        CONSTRAINT pk_Recarga PRIMARY KEY (idTarjeta, fechayHora),
        CONSTRAINT fk_Recarga_Tarjeta FOREIGN KEY(idTarjeta) REFERENCES Tarjeta(idTarjeta)
    );
CREATE TABLE
    Fichin(
        idFichin TINYINT UNSIGNED NOT NULL,
        nombre VARCHAR(45) NOT NULL,
        lanzamiento YEAR NOT NULL,
        precio DECIMAL (5,2) NOT NULL,
        PRIMARY KEY (idFichin)
    );    
CREATE TABLE
    JuegaFichin(
        idTarjeta SMALLINT UNSIGNED NOT NULL,
        idFichin TINYINT UNSIGNED NOT NULL,
        fechayHora DATETIME NOT NULL,
        acopio DECIMAL (5,2) NOT NULL,
        CONSTRAINT pk_JuegaFichin PRIMARY KEY (idTarjeta, idFichin, fechayHora),
        CONSTRAINT fk_JuegaFichin_Fichin FOREIGN KEY(idFichin) REFERENCES Fichin(idFichin),
        CONSTRAINT fk_JuegaFichin_Tarjeta FOREIGN KEY(idTarjeta) REFERENCES Tarjeta(idTarjeta)
        );