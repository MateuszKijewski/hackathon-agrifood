using Hackathon.AgriFood.Models.Converters.Interfaces;
using Hackathon.AgriFood.Models.Dtos;
using Hackathon.AgriFood.Models.Models;
using Mapster;
using System.Linq;
using Hackathon.AgriFood.Models.Models.Relations;
using Hackathon.AgriFood.Models.Dtos.Relations;

namespace Hackathon.AgriFood.Models.Converters
{
    public class EntityConverter : IEntityConverter
    {
        public CustomerDto GetDtoFromModel(Customer customer)
        {
            var customerDto = customer.Adapt<CustomerDto>();
            customerDto.FavoriteFarmers = customer.FavoriteFarmers.Select(x => x.Farmer.Adapt<FarmerDto>());
            customerDto.FavoriteProducts = customer.FavoriteProducts.Select(x => x.Product.Adapt<ProductDto>());
            customerDto.FavoriteShops = customer.FavoriteShops.Select(x => x.Shop.Adapt<ShopDto>());

            return customerDto;
        }

        public FarmerDto GetDtoFromModel(Farmer farmer)
        {
            var farmerDto = farmer.Adapt<FarmerDto>();
            farmerDto.Localization = farmer.Localization.Adapt<LocalizationDto>();
            farmerDto.Products = farmer.Products.Select(x => x.Adapt<ProductDto>());
            farmerDto.Photos = farmer.Photos.Select(x => x.Adapt<FarmerPhotoDto>());
            farmerDto.Shops = farmer.Shops.Select(x => x.Adapt<ShopDto>());
            farmerDto.FavoringCustomers = farmer.FavoringCustomers.Select(x => x.Customer).AsQueryable().ProjectToType<CustomerDto>();

            return farmerDto;
        }

        public FarmerPhotoDto GetDtoFromModel(FarmerPhoto farmerPhoto)
        {
            var farmerPhotoDto = farmerPhoto.Adapt<FarmerPhotoDto>();
            farmerPhotoDto.Farmer = farmerPhoto.Farmer.Adapt<FarmerDto>();

            return farmerPhotoDto;
        }

        public LocalizationDto GetDtoFromModel(Localization localization)
        {
            var localizationDto = localization.Adapt<LocalizationDto>();
            localizationDto.Farmers = localization.Farmers.Select(x => x.Adapt<FarmerDto>());
            localizationDto.Shops = localization.Shops.Select(x => x.Adapt<ShopDto>());

            return localizationDto;
        }

        public ProductDto GetDtoFromModel(Product product)
        {
            var productDto = product.Adapt<ProductDto>();
            productDto.Farmer = product.Farmer.Adapt<FarmerDto>();
            productDto.Shop = product.Shop.Adapt<ShopDto>();
            productDto.Photos = product.Photos.Select(x => x.Adapt<ProductPhotoDto>());
            productDto.Tags = product.Tags.Select(x => x.Adapt<TagDto>());
            productDto.FavoringCustomers = product.FavoringCustomers.Select(x => x.Customer).AsQueryable().ProjectToType<CustomerDto>();

            return productDto;
        }

        public ProductPhotoDto GetDtoFromModel(ProductPhoto productPhoto)
        {
            var productPhotoDto = productPhoto.Adapt<ProductPhotoDto>();
            productPhotoDto.Product= productPhoto.Product.Adapt<ProductDto>();

            return productPhotoDto;
        }

        public ShopDto GetDtoFromModel(Shop shop)
        {
            var shopDto = shop.Adapt<ShopDto>();
            shopDto.Localization = shop.Localization.Adapt<LocalizationDto>();
            shopDto.Products = shop.Products.Select(x => x.Adapt<ProductDto>());
            shopDto.Farmers = shop.Farmers.Select(x => x.Adapt<FarmerDto>());
            shopDto.FavoringCustomers = shop.FavoringCustomers.Select(x => x.Customer).AsQueryable().ProjectToType<CustomerDto>();

            return shopDto;
        }

        public ShopPhotoDto GetDtoFromModel(ShopPhoto shopPhoto)
        {
            var shopPhotoDto = shopPhoto.Adapt<ShopPhotoDto>();
            shopPhotoDto.Shop = shopPhoto.Shop.Adapt<ShopDto>();
            
            return shopPhotoDto;
        }

        public TagDto GetDtoFromModel(Tag tag)
        {
            var tagDto = tag.Adapt<TagDto>();
            tagDto.TaggedProducts = tag.TaggedProducts.Select(x => x.Product).AsQueryable().ProjectToType<ProductDto>();

            return tagDto;
        }

        public CustomerToFarmerDto GetDtoFromModel(CustomerToFarmer customerToFarmer)
        {
            var customerToFarmerDto = customerToFarmer.Adapt<CustomerToFarmerDto>();
            customerToFarmerDto.Customer = customerToFarmer.Customer.Adapt<CustomerDto>();
            customerToFarmerDto.Farmer = customerToFarmer.Farmer.Adapt<FarmerDto>();

            return customerToFarmerDto;
        }

        public CustomerToProductDto GetDtoFromModel(CustomerToProduct customerToProduct)
        {
            var customerToProductDto = customerToProduct.Adapt<CustomerToProductDto>();
            customerToProductDto.Customer = customerToProduct.Customer.Adapt<CustomerDto>();
            customerToProductDto.Product = customerToProduct.Product.Adapt<ProductDto>();

            return customerToProductDto;
        }

        public CustomerToShopDto GetDtoFromModel(CustomerToShop customerToShop)
        {
            var customerToShopDto = customerToShop.Adapt<CustomerToShopDto>();
            customerToShopDto.Customer = customerToShop.Customer.Adapt<CustomerDto>();
            customerToShopDto.Shop = customerToShop.Shop.Adapt<ShopDto>();

            return customerToShopDto;
        }

        public ShopToFarmerDto GetDtoFromModel(ShopToFarmer shopToFarmer)
        {
            var shopToFarmerDto = shopToFarmer.Adapt<ShopToFarmerDto>();
            shopToFarmerDto.Shop = shopToFarmer.Shop.Adapt<ShopDto>();
            shopToFarmerDto.Farmer = shopToFarmer.Farmer.Adapt<FarmerDto>();

            return shopToFarmerDto;
        }

        public TagToProductDto GetDtoFromModel(TagToProduct tagToProduct)
        {
            var tagToProductDto = tagToProduct.Adapt<TagToProductDto>();
            tagToProductDto.Tag = tagToProduct.Tag.Adapt<TagDto>();
            tagToProductDto.Product = tagToProduct.Product.Adapt<ProductDto>();

            return tagToProductDto;
        }

        public Customer GetModelFromDto(CustomerDto customerDto)
        {
            return customerDto.Adapt<Customer>();
        }

        public Farmer GetModelFromDto(FarmerDto farmerDto)
        {
            return farmerDto.Adapt<Farmer>();
        }

        public FarmerPhoto GetModelFromDto(FarmerPhotoDto farmerPhotoDto)
        {
            return farmerPhotoDto.Adapt<FarmerPhoto>();
        }

        public Localization GetModelFromDto(LocalizationDto localizationDto)
        {
            return localizationDto.Adapt<Localization>();
        }

        public Product GetModelFromDto(ProductDto productDto)
        {
            return productDto.Adapt<Product>();
        }

        public ProductPhoto GetModelFromDto(ProductPhotoDto productPhotoDto)
        {
            return productPhotoDto.Adapt<ProductPhoto>();
        }

        public Shop GetModelFromDto(ShopDto shopDto)
        {
            return shopDto.Adapt<Shop>();
        }

        public ShopPhoto GetModelFromDto(ShopPhotoDto shopPhotoDto)
        {
            return shopPhotoDto.Adapt<ShopPhoto>();
        }

        public Tag GetModelFromDto(TagDto tagDto)
        {
            return tagDto.Adapt<Tag>();
        }

        public CustomerToFarmer GetModelFromDto(CustomerToFarmerDto customerToFarmerDto)
        {
            return customerToFarmerDto.Adapt<CustomerToFarmer>();
        }

        public CustomerToProduct GetModelFromDto(CustomerToProductDto customerToProductDto)
        {
            return customerToProductDto.Adapt<CustomerToProduct>();
        }

        public CustomerToShop GetModelFromDto(CustomerToShopDto customerToShopDto)
        {
            return customerToShopDto.Adapt<CustomerToShop>();
        }

        public ShopToFarmer GetModelFromDto(ShopToFarmerDto shopToFarmerDto)
        {
            return shopToFarmerDto.Adapt<ShopToFarmer>();
        }

        public TagToProduct GetModelFromDto(TagToProductDto tagToProductDto)
        {
            return tagToProductDto.Adapt<TagToProduct>();
        }
    }
}