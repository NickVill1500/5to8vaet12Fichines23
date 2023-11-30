using System.Data;
using Dapper;
using MySqlConnector;

namespace Fichines.core.Dapper;
public class DapAdoFic : IAdoFichin
{
    private readonly IDbConnection _conexion;
    public DapAdoFic(IDbConnection conexion) => this._conexion = conexion;
    public DapAdoFic(string cadena) => _conexion = new MySqlConnection(cadena);

    #region Usuario

    private static readonly string _queryCientePas
        = @"SELECT  *
            FROM    Usuario
            WHERE   Dni = @unCDNI
            AND     pasword = SHA2(@unPasw, 256)
            LIMIT   1";
    private static readonly string _queryAltaCajero
        = @"INSERT INTO Cajero VALUES (@dni, @nombre, @apellido, @pass)";

    public void AltaFichin(Fichin fichin)
    {
        throw new NotImplementedException();
    }

    #endregion

}
