using MediatR;
using Persistencia.Dapper.Product;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Aplicacion.Product
{
    public class Crear_BL
    {

        public class Command : IRequest<Guid> {

            public string Name { get; set; }

            public float Price { get; set; }

            public string Description { get; set; }

        }

        public class Manejador : IRequestHandler<Command, Guid>
        {

            private readonly IProduct _ProductRepository;

            public Manejador(IProduct ProductRepository)
            {
                _ProductRepository = ProductRepository;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
             return await _ProductRepository.Crear(request.Name, request.Price, request.Description);
            }
        }



    }
}
