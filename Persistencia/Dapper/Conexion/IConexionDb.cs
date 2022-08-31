using System.Data;

namespace Persistencia.Dapper.Conexion
{
    public interface IConexionDb
    {
        void CloseConection();

        IDbConnection GetConection();

    }
}
