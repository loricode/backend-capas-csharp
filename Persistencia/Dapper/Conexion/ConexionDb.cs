using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Persistencia.Dapper.Conexion
{
    public class ConexionConfiguracion
    {
        public string DefaultConnection { get; set; }

    }
    public class ConexionDb: IConexionDb
    {

        private IDbConnection _connection;

        private readonly IOptions<ConexionConfiguracion> _configs;

        public ConexionDb(IOptions<ConexionConfiguracion> configs)
        {
            _configs = configs;
        }

        public void CloseConection()
        {
            if (_connection != null)
            {
                _connection.Close();
            }
        }

        public IDbConnection GetConection()
        {
            if (_connection == null)
            {
               
                _connection = new SqlConnection(_configs.Value.DefaultConnection);
              
            }

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
           
            return _connection;
        }

    }
}
