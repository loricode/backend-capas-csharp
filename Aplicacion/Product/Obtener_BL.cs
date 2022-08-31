using MediatR;
using System;
using System.Threading.Tasks;
using Persistencia.Dapper.Product;
using Entidades.dto.Product;
using System.Threading;

namespace Aplicacion.Product
{
    public class Obtener_BL : IRequest<int>
    {
        public class CommandObtener : IRequest<ProductDto>
        {
            public Guid Id { get; set; }

        }
        public class Manejador : IRequestHandler<CommandObtener, ProductDto>
        {

            private readonly IProduct _ProductRepository;

            public Manejador(IProduct ProductRepository)
            {
                _ProductRepository = ProductRepository;
            }

            public async Task<ProductDto> Handle(CommandObtener request, CancellationToken cancellationToken)
            {
                return await _ProductRepository.Obtener(request.Id);
            }
        }
    }
}
