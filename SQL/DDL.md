```mermaid
erDiagram
    Usuario{

        SMALLINT DNI PK
        VARCHAR(45) nombre
        VARCHAR(45) apellido
        VARCHAR(45) mail
        CHAR(64) pasword
    }
    Tarjeta{

        SMALLINT idTarjeta PK
        SMALLINT DNI FK
        DECIMAL(5_2) saldo
    }
    Recarga{

        SMALLINT idTarjeta PK,FK
        DATETIME fechayHora PK
        DECIMAL(5_2) montoRecargado
    }
    Fichin{
       
        TINYINT idFichin PK
        VARCHAR(45) nombre
        YEAR lanzamiento
        DECIMAL(5_2) precio
    }
    JuegaFichin{

        SMALLINT idTarjeta PK,FK
        TINYINT idFichin PK,FK
        DATETIME fechayHora PK
        DECIMAL(5_2) acopio
    }
    Usuario }|--|| Tarjeta: ""
    Recarga }|--|| Tarjeta: ""
    JuegaFichin }|--|| Fichin : ""
    JuegaFichin }|--|| Tarjeta: ""
```