namespace Fichines.core;

public class Tarjeta
{
    public ushort idTarjeta {get;set;}
    public ushort Dni {get;set;}
    public decimal saldo {get;set;}

    [SetsRequiredMembers]
    public Recarga(Tarjeta tarjeta, ushort tarjeta)
    {
        idTarjeta = idTarjeta;
        montoRecargado = montoRecargado;
    }

    //Este constructor es necesario para Dapper
    [SetsRequiredMembers]
    public Recarga(decimal montoRecargado)
    {
        this.montoRecargado = montoRecargado;
    }
    public void IncrementarMonto(decimal montoRecargado)
        => montoRecargado += montoRecargado;
}