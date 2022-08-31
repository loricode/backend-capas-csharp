using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.dto.Product
{
    public class GenericaIdGuid
    {

        public GenericaIdGuid(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; set; }
    }
}
