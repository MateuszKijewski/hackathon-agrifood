using Hackathon.AgriFood.Models.Dtos.Relations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Services.Interfaces.Relations
{
    public interface ITagToProductService
    {
        Task AddTagToProduct(TagToProductDto tagToProductDto);

        Task AddManyTagToProducts(IEnumerable<TagToProductDto> tagToProductDtos);

        Task<TagToProductDto> GetTagToProduct(Guid firstGuid, Guid secondId);

        Task<IEnumerable<TagToProductDto>> GetTagToProductsByFirstId(Guid firstId);

        Task<IEnumerable<TagToProductDto>> GetTagToProductsBySecondId(Guid secondId);

        Task<IEnumerable<TagToProductDto>> GetAllTagToProducts();

        Task UpdateTagToProduct(TagToProductDto tagToProductDto);

        Task UpdateManyTagToProducts(IEnumerable<TagToProductDto> tagToProductDtos);

        Task DeleteTagToProduct(TagToProductDto tagToProductDto);

        Task DeleteManyTagToProducts(IEnumerable<TagToProductDto> tagToProductDtos);
    }
}
