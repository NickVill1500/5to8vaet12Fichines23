using System.Data;
using Dapper;
using Fichines.core.Tablas;
using MySqlConnector;

namespace Fichines.core.Dapper;
public class DapAdoFic : IAdoFichin
{
    private readonly IDbConnection _conexion;
    public DapAdoFic(IDbConnection conexion) => this._conexion = conexion;
    public DapAdoFic(string cadena) => _conexion = new MySqlConnection(cadena);

    #region Usuario

    private static readonly string _queryUsuarioPas
        = @"SELECT  *
            FROM    Usuario
            WHERE   Dni = @unCDNI
            AND     pasword = SHA2(@unPasw, 256)
            LIMIT   1";
    private static readonly string _queryRegistrarUsuario
        = @"INSERT INTO Usuario VALUES (@dni, @nombre, @apellido, @mail, @pasword)";


    public void RegistrarUsuario(Tablas.Usuario usuario)
    =>_conexion.Execute(_
                _queryRegistrarUsuario,
                new
                {
                    dni = usuario.Dni,
                    nombre = usuario.Nombre,
                    apellido = usuario.Apellido,
                    mail = usuario.Mail,
                    pasword = pasword
                }
            );
    

    public Tablas.Usuario? UsuarioPorDni()
    {
        throw new NotImplementedException();
    }
}