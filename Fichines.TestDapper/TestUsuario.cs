using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fichines.TestDapper
{
    public class TestUsuario
    {
    [Theory]
    [InlineData(11561816,"Gerente", "Uno", "gerentefichin@gmail.com", "gerente1504")]
    public void TraerCLiente(byte dni, string nombre, string apellido, string mail, string pasword)
    {
        var usuario = Ado.UsuarioPorDni(usuario, dni);

        Assert.NotNull(usuario);
        Assert.Equal(nombre, usuario.Nombre);
        Assert.Equal<uint>(dni, usuario.Dni);
    }
    [Fact]
    public void UsuarioPorDni()
    {
        byte dni = 11561816;
        string pass = "gerente1504";
        string nombre = "Gerente";
        string apellido = "Uno";

        var Usuario = Ado.UsuarioPorDni(usuario, dni);

        Assert.Null(Usuario);

        var nuevoUno = new Usuario()
        {
            Dni = dni,
            Nombre = nombre,
            Apellido = apellido
        };

        Ado.Usuario(nuevoUno, pass);

        var mismoUsuario = Ado.UsuarioPordni(usuario, dni);
        
        Assert.NotNull(mismoUsuario);
        Assert.Equal(nombre, mismoUsuario.Nombre);
        Assert.Equal(apellido, mismoUsuariov.Apellido);
    }
}