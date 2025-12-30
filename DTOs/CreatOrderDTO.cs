using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record CreatOrderDTO
    (
        int userId,
        List<OrderItemDTO> OrderItemDTOs
    );
}
