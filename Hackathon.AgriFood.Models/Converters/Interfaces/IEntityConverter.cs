using Hackathon.AgriFood.Models.Dtos;
using Hackathon.AgriFood.Models.Dtos.Relations;
using Hackathon.AgriFood.Models.Models;
using Hackathon.AgriFood.Models.Models.Relations;

namespace Hackathon.AgriFood.Models.Converters.Interfaces
{
    public interface IEntityConverter
    {
        CustomerDto GetDtoFromModel(Customer customer);

        FarmerDto GetDtoFromModel(Farmer farmer);

        FarmerPhotoDto GetDtoFromModel(FarmerPhoto farmerPhoto);

        LocalizationDto GetDtoFromModel(Localization localization);

        ProductDto GetDtoFromModel(Product product);

        ProductPhotoDto GetDtoFromModel(ProductPhoto productPhoto);

        ShopDto GetDtoFromModel(Shop shop);

        ShopPhotoDto GetDtoFromModel(ShopPhoto shopPhoto);

        TagDto GetDtoFromModel(Tag tag);

        Customer GetModelFromDto(CustomerDto customerDto);

        Farmer GetModelFromDto(FarmerDto farmerDto);

        FarmerPhoto GetModelFromDto(FarmerPhotoDto farmerPhotoDto);

        Localization GetModelFromDto(LocalizationDto localizationDto);

        Product GetModelFromDto(ProductDto productDto);

        ProductPhoto GetModelFromDto(ProductPhotoDto productPhotoDto);

        Shop GetModelFromDto(ShopDto shopDto);

        ShopPhoto GetModelFromDto(ShopPhotoDto shopPhotoDto);

        Tag GetModelFromDto(TagDto tagDto);

        CustomerToFarmer GetModelFromDto(CustomerToFarmerDto customerToFarmerDto);

        CustomerToProduct GetModelFromDto(CustomerToProductDto customerToProductDto);

        CustomerToShop GetModelFromDto(CustomerToShopDto customerToShopDto);

        ShopToFarmer GetModelFromDto(ShopToFarmerDto shopToFarmerDto);

        TagToProduct GetModelFromDto(TagToProductDto tagToProductDto);
    }
}