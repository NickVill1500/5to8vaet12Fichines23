using Fichines.core.Tablas;

namespace Fichines.core;
public interface IAdo
{
    void RegistrarUsuario(Usuario usuario);
    List<Usuario> ObtenerUsuarios();
    Usuario? UsuarioPorDni(ushort Dni, string pasword);

    void altaTarjeta(Tarjeta tarjeta);
    List <Tarjeta> ObtenerTarjetas();

    void altaRecarga(Recarga recarga);
    List <Tarjeta> ObtenerRecargas();

    void altaFichin(Fichin fichin);
    List <Tarjeta> ObtenerFichines();

    void altaJuegaFichin(JuegaFichin juegaFichin);
    List <Tarjeta> ObtenerJueFichines();
}