using Entidades.dto.Product;
using Aplicacion.Product;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace sales.Controllers
{
    public class ProductController : BaseApiController
    {

        [HttpGet("Listar")]
        public async Task<IEnumerable<ProductDto>> Listado()
        {
            return await Mediator.Send(new Listar_BL.Query());
        }

        [HttpPost("Crear")]
        public async Task<Guid> Crear(Crear_BL.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("Eliminar")]
        public async Task<int> Eliminar(Eliminar_BL.CommandDelete command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("Obtener")]
        public async Task<ProductDto> Obtener(Obtener_BL.CommandObtener command)
        {
            return await Mediator.Send(command);
        }
    }
}
