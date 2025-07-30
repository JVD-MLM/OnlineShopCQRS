using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineShop.Application.DTOs.Category;

namespace OnlineShop.Application.Features.Category.Requests.Query
{
    public class GetCategoryRequest : IRequest<CategoryDto>
    {
        public int Id { get; set; }
    }
}
