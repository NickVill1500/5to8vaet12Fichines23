using System.Data;
using Dapper;
using Fichines.core.Tablas;
using MySqlConnector;

namespace Fichines.core.Dapper;
public class AdoDapper : IAdo
{
    private readonly IDbConnection _conexion;
    public AdoDapper(IDbConnection conexion) => this._conexion = conexion;
    public AdoDapper(string cadena) => _conexion = new MySqlConnection(cadena);

    public void altaFichin(Fichin fichin)
    {
        throw new NotImplementedException();
    }

    public void altaJuegaFichin(JuegaFichin juegaFichin)
    {
        throw new NotImplementedException();
    }

    public void altaRecarga(Recarga recarga)
    {
        throw new NotImplementedException();
    }

    public void altaTarjeta(Tarjeta tarjeta)
    {
        throw new NotImplementedException();
    }

    public List<Tarjeta> ObtenerFichines()
    {
        throw new NotImplementedException();
    }

    public List<Tarjeta> ObtenerJueFichines()
    {
        throw new NotImplementedException();
    }

    public List<Tarjeta> ObtenerRecargas()
    {
        throw new NotImplementedException();
    }

    public List<Tarjeta> ObtenerTarjetas()
    {
        throw new NotImplementedException();
    }

    public List<Usuario> ObtenerUsuarios()
    {
        throw new NotImplementedException();
    }
    #region Usuario
    public void RegistrarUsuario(Tablas.Usuario usuario, ParameterDirection parameterDirection)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@unUDNI",usuario.Dni);
        parametros.Add("@unUNombre", usuario.Nombre);
        parametros.Add("@unUApellido", usuario.Apellido);
        parametros.Add("@unMail",usuario.Mail);
        parametros.Add("@unPasw",usuario.Pasword);
    }

    public void RegistrarUsuario(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public Usuario? UsuarioPorDni(ushort Dni, string Pasword)
    {
        throw new NotImplementedException();
    }
    #endregion
    #region Tarjeta
    #endregion
    #region Recarga
    #endregion
    #region Fichin
    #endregion
    #region JuegaFichin
    #endregion
}