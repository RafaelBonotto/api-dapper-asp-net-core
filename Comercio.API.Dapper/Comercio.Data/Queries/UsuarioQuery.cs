namespace Comercio.Data.Queries
{
    public static class UsuarioQuery
    {
        public const string SELECT_USUARIO = "SELECT * FROM comercioDB.tb_usuario WHERE email = @Email";
    }
}
