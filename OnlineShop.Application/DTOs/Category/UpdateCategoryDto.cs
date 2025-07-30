using OnlineShop.Application.DTOs.Common;

namespace OnlineShop.Application.DTOs.Category
{
    public class UpdateCategoryDto : BaseDto
    {
        public string Name { get; set; }
        public string Desc { get; set; }
    }
}
