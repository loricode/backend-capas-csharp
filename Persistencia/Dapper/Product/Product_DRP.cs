using Entidades.dto.Product;
using Persistencia.Dapper.Conexion;
using System;
using System.Data;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistencia.Dapper.Product
{
    public class Product_DRP : IProduct
    {

        private readonly IConexionDb _factoryConnection;

        public Product_DRP(IConexionDb factoryConnection)
        {
            _factoryConnection = factoryConnection;
        }

        public async Task<Guid> Crear(string Name, float Price, string Description)
        {
            string storeProcedure = "sp_products_create";
           
            try
            {
              
               var dynamicParam = new DynamicParameters();
               dynamicParam.Add("@Name", Name, dbType: DbType.String, direction: ParameterDirection.Input);
               dynamicParam.Add("@Price", Price, dbType: DbType.Double, direction: ParameterDirection.Input);
               dynamicParam.Add("@Description", Description, dbType: DbType.String, direction: ParameterDirection.Input);
               dynamicParam.Add("@Id", Guid.Empty, dbType: DbType.Guid, direction: ParameterDirection.Output);
           
               var connection = _factoryConnection.GetConection();

               await connection.ExecuteAsync(storeProcedure,  dynamicParam, commandType:CommandType.StoredProcedure);

               return dynamicParam.Get<Guid>("@Id");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Guid.Empty;
            }
            finally
            {
                _factoryConnection.CloseConection();
            }
           
        }

        public async Task<IEnumerable<ProductDto>> Listado()
        {

            IEnumerable<ProductDto> listProducts = null;
            var storeProcedure = "sp_products_list";

            try
            {
             
                var connection = _factoryConnection.GetConection();

                listProducts = await connection.QueryAsync<ProductDto>(
                    storeProcedure,
                    commandType: CommandType.StoredProcedure
                );

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _factoryConnection.CloseConection();
            }
            
            return listProducts;
            
        }

        public async Task<int> Eliminar(Guid Id)
        {
            string storeProcedure = "sp_products_delete";

            try
            {

                var connection = _factoryConnection.GetConection();

                var result = await connection.ExecuteAsync(
                     storeProcedure,
                     new { id = Id },
                     commandType: CommandType.StoredProcedure
                );

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                _factoryConnection.CloseConection();
            }

        }

        public async Task<ProductDto> Obtener(Guid Id)
        {

            string storeProcedure = "sp_products_getById";

            try
            {

                var connection = _factoryConnection.GetConection();

                var result = await connection.QueryFirstAsync<ProductDto>(
                     storeProcedure,
                     new { id = Id },
                     commandType: CommandType.StoredProcedure
                );

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                _factoryConnection.CloseConection();
            }

        }
    }
}
