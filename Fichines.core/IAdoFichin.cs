using Fichines.core.Tablas;

namespace Fichines.core;
public interface IAdoFichin
{
    void RegistrarUsuario(Usuario usuario);
    Usuario? UsuarioPorDni(ushort Dni, string Pasword);
}