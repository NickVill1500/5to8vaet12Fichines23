namespace Fichines.core.Tablas;

public interface IAdoFichin
{
    void RegistrarCliente (Usuario usuario, string pasword);
    Usuario? ClientePorPass (ushort Dni, string pasword);
    /*void AltaTarjeta (Tarjeta tarjeta);
    List<Tarjeta> ObtenerTarjetas();
    void AltaRecarga (Recarga recarga);
    void AltaFichin (Fichin fichin);
    List<Fichin> ObtenerFichin();
    void AltaJuegaFichin (JuegaFichin juegaFichin);*/
}
