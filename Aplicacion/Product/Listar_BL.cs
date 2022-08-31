using MediatR;
using System.Collections.Generic;
using Entidades.dto.Product;
using Persistencia.Dapper.Product;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Product
{
    public class Listar_BL
    {
        public class Query : IRequest<IEnumerable<ProductDto>> { }

        public class Manejador : IRequestHandler<Query, IEnumerable<ProductDto>>
        {

            private readonly IProduct _ProductoRepository;

            public Manejador(IProduct ProductoRepository)
            {
                _ProductoRepository = ProductoRepository;
                
            }

            public async Task<IEnumerable<ProductDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                
                return await _ProductoRepository.Listado();


            }

        }

    }
}
