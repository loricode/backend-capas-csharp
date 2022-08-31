using Entidades.dto.Product;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistencia.Dapper.Product
{
    public interface IProduct
    {
        public Task<IEnumerable<ProductDto>> Listado();

        public Task<Guid> Crear(string Name, float Price, string Description);

        public Task<int> Eliminar(Guid id);

        public Task<ProductDto> Obtener(Guid id);
    }
}
