using MediatR;
using System;
using Persistencia.Dapper.Product;
using System.Threading.Tasks;
using System.Threading;

namespace Aplicacion.Product
{
    public class Eliminar_BL
    {
       public class CommandDelete : IRequest<int>
       {

            public Guid Id { get; set; }

       }

        public class Manejador : IRequestHandler<CommandDelete, int>
        {

            private readonly IProduct _ProductRepository;

            public Manejador(IProduct ProductRepository)
            {
                _ProductRepository = ProductRepository;
            }

            public async Task<int> Handle(CommandDelete request, CancellationToken cancellationToken)
            {
               return await _ProductRepository.Eliminar(request.Id);
            }
        }

    }
}
