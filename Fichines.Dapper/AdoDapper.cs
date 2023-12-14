using System.Data;
using Dapper;
using Fichines.core.Dapper;
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
    private static readonly string _queryTarjeta
        = @"SELECT  idTarjeta, U.dni, saldo
            FROM    Tarjeta
            JOIN    Usuario U USING (dni)
            WHERE   idTarjeta = @id";
/*public void AltaTarjeta(Tarjeta tarjeta)
    {
        //Parametros para el ticket
        var parametros = new DynamicParameters();
        parametros.Add("@unTTarjeta", direction: ParameterDirection.Output);
        parametros.Add("@unTDni", ticket.Cajero.Dni);

        //Abro la conexion
        _conexion.Open();
        using (var transaccion = _conexion.BeginTransaction())
        {
            try
            {
                _conexion.Execute("altaTarjeta", parametros, commandType: CommandType.StoredProcedure, transaction: transaccion);
                tarjeta.idTarjeta = parametros.Get<int>("@unTTarjeta");

                //creo una lista con los valores que le vamos a pasar al SP
                var paraItems = ticket.Items.
                    Select(i => new { unIdProducto = i.Producto.IdProducto, unIdTicket = ticket.Id, unaCantidad = i.Cantidad }).
                    ToList();

                _conexion.Execute("ingresoItem", paraItems, commandType: CommandType.StoredProcedure, transaction: transaccion);

                //Como todo se ejecuto ok, confirmo los cambios
                transaccion.Commit();

                ticket.Items.ForEach(i => i.IdTicket = ticket.Id);
            }
            catch (MySqlException e)
            {
                //Si hubo algun problema, doy marcha atras con los posibles cambios
                transaccion.Rollback();
                throw new InvalidOperationException(e.Message, e);
            }
        }
    }*/
    #endregion
    #region Fichin
        public Fichin(Fichin fichin)
        : base(JuegaFichin.idFichin)
        => precio = acopio.juegaFichin;
    #endregion
    #region JuegaFichin
    private static readonly string _queryJueFichin
        = @"SELECT  idTarjeta, idFichin, fechayHora, acopio
            FROM    JuegaFichin
            JOIN    Tarjeta USING (idTarjeta)
            WHERE   idTarjeta = @id";
    public void altaJuegaFichin(JuegaFichin juegaFichin)
    {
        //Parametros para el ticket
        var parametros = new DynamicParameters();
        parametros.Add("@unJTarjeta", direction: ParameterDirection.Output);
        parametros.Add("@unJFichin", direction: ParameterDirection.Output);
        parametros.Add("@unJFYH",JuegaFichin.fechayHora);
        parametros.Add("@unAcopio", JuegaFichin.acopio);

        //Abro la conexion
        _conexion.Open();
        using (var transaccion = _conexion.BeginTransaction())
        {
            try
            {
                _conexion.Execute("altaJuegaFichin", parametros, commandType: CommandType.StoredProcedure, transaction: transaccion);
                juegaFichin.idTarjeta = parametros.Get<int>("@unJTarjeta");

                //creo una lista con los valores que le vamos a pasar al SP
                var paraJueFichin = Tarjeta.JuegaFichin.
                    Select(i => new { unJTarjeta = i.Tarjeta.unJueFichin, unJFichin = Fichin.unJueFichin, unAcopio = i.unAcopio }).
                    ToList();

                _conexion.Execute("ingresoTarjeta", paraTarjeta, commandType: CommandType.StoredProcedure, transaction: transaccion);

                //Como todo se ejecuto ok, confirmo los cambios
                transaccion.Commit();

                juegaFichin.JuegaFichin.ForEach(i => i.unJTarjeta = Tarjeta.unJTarjeta);
            }
            catch (MySqlException e)
            {
                //Si hubo algun problema, doy marcha atras con los posibles cambios
                transaccion.Rollback();
                throw new InvalidOperationException(e.Message, e);
            }
        }
    }
    public JuegaFichin? ObtenerJueFichin(int unJTarjeta)
    {
        var tarjeta = _conexion.Query<JuegaFichin, Tarjeta, Fichin>
            (_queryJueFichin,
            (JuegaFichin, Tarjeta) =>
                {
                    JuegaFichin.idTarjeta = tarjeta;
                    return tarjeta;
                },
            new { id = unJTarjeta },
            splitOn: "dni").
            FirstOrDefault();

        if (tarjeta is null)
            return null;
        JuegaFichin.idTarjeta = unJTarjeta;
        JuegaFichin.idTarjeta = _conexion.Query<JuegaFichin, Tarjeta, Fichin>
            ("DetalleTicket",
            (JuegaFichin, Tarjeta, Fichin) =>
                {
                    Fichin.idFichin = Fichin;
                    Tarjeta.idTarjeta = tarjeta;
                },
            new { unJueFichin = unJFYH },
            splitOn: "idTarjeta, idFichin",
            commandType: CommandType.StoredProcedure).
            ToList();
        
        return JuegaFichin;
    }
    #endregion
}